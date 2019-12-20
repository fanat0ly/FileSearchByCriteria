using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.IO;
using System.Drawing;
using System.ComponentModel;

namespace FilesSearch
{
    partial class mainForm
    {
        // файлов обработано
        int cntProcessed = 0;
        // файлов найдено (соответствующих критериям поиска)
        int cntSearched = 0;
        delegate void InvokeDelegate();
        // стек для сохранения промежуточного состояния поиска
        private Stack<DirectoryNode> processingDirs = new Stack<DirectoryNode>();

        /// <summary>
        /// Добавить узел в дерево
        /// </summary>
        /// <param name="parent">родительский узел, который уже содержится в дереве</param>
        /// <param name="child">дочерний узел, который будет добавлен</param>
        private void AddTreeNode(TreeNode parent, TreeNode child)
        {
            if (parent == null)
                this.Invoke(new InvokeDelegate(() => tviewSFiles.Nodes.Add(child)));
            else
                this.Invoke(new InvokeDelegate(() => parent.Nodes.Add(child)));            
        }   

        /// <summary>
        /// Удалить узел из дерева (вместе с его подузлами)
        /// </summary>
        /// <param name="node">узел, который будет удален</param>
        private void RemoveTreeNode(TreeNode node)
        {
            this.BeginInvoke(new InvokeDelegate(() => node.Remove()));
        }

        /// <summary>
        /// Обновить информацию об обрабатываемых файлах
        /// </summary>
        /// <param name="fileName">имя обрабатываемого файла</param>
        /// <param name="cntProcessed">файлов обработано</param>
        /// <param name="cntSearched">файлов найдено (соответствующих критериям поиска)</param>
        private void UpdateProcessingInfo(string fileName, int cntProcessed, int cntSearched)
        {
            this.BeginInvoke(new InvokeDelegate(() => lblCurrentFile.Text = fileName));
            this.BeginInvoke(new InvokeDelegate(() => lblPCount.Text = cntProcessed.ToString()));
            this.BeginInvoke(new InvokeDelegate(() => lblSCount.Text = cntSearched.ToString()));
        }

        // 
        /// <summary>
        /// Построение дерева найденных по критериям файлов
        /// </summary>
        /// <param name="processingDirs">стек состояния поиска</param>
        /// <param name="fileNameMask">маска имени файла</param>
        /// <param name="filePattern">символы для поиска по содержимому файла</param>
        private void BuildTree(Stack<DirectoryNode> processingDirs, string fileNameMask, string filePattern, DoWorkEventArgs e)
        {
            try
            {
                // пока стек не пуст
                while (processingDirs?.Count > 0)
                {
                    // текущий узел получаем с вершины стека
                    var currentNode = processingDirs.Peek();

                    // Если у текущей папки еще не получали подпапки (1 стадия), получаем их...
                    if (!currentNode.DirsEnumerated)
                    {
                        currentNode.DirsEnumerated = true;
                       
                        // получаем подпапки, отсортированные по убыванию
                        foreach (var dir in Directory.GetDirectories(currentNode.FullName).OrderByDescending(n => n))
                        {
                            currentNode.DirsCount++;
                            // добавляем подпапку в стек 
                            processingDirs.Push(new DirectoryNode(dir, currentNode));
                        }
                    }
                    // иначе - получаем файлы (2 стадия)...
                    else 
                    {
                        // только те файлы, имя которых соответствует шаблону
                        var files = Directory.GetFiles(currentNode.FullName, fileNameMask);
                        for (int i = currentNode.FilesCount; i < files.Length; i++)
                        //foreach (var file in Directory.GetFiles(currentNode.FullName, fileNameMask))
                        {
                            var file = files[i];
                            // отмена поиска
                            if (worker.CancellationPending)
                            {
                                UpdateProcessingInfo("", cntProcessed, cntSearched);
                                e.Cancel = true;
                                return;
                            }

                            UpdateProcessingInfo(file, ++cntProcessed, cntSearched);

                            // читаем содержимое файла
                            using (StreamReader sr = new StreamReader(file, true))
                            {
                                string line;
                                
                                while (sr.Peek() != -1)
                                {
                                    line = sr.ReadLine();

                                    // если файл содержит заданное слово/фразу
                                    if (line.IndexOf(filePattern, StringComparison.InvariantCultureIgnoreCase) != -1)
                                    {
                                        currentNode.FilesCount++;
                                        ++cntSearched;

                                        // добавляем папку в дерево, если в ней найден хотя бы один файл,
                                        // удовлетворяющий критерию поиска
                                        if (currentNode.FilesCount == 1)
                                        {
                                            var node = currentNode;
                                            while (node != null && !node.IsAddedToTree)
                                            {
                                                node.IsAddedToTree = true;
                                                AddTreeNode(node.Parent, node);
                                                node = node.Parent;
                                            }
                                        }
                                        // добавляем файл в дерево
                                        AddTreeNode(currentNode, new TreeNode(Path.GetFileName(file)) { BackColor = Color.LightGreen });
                                        break;
                                    }
                                }                                
                            }
                            //UpdateProcessingInfo("", cntProcessed, cntSearched);
                        }

                        // если узел пустой (и не корень) - удалить 
                        if (currentNode.IsEmpty && !currentNode.IsRoot)
                        {
                            currentNode.Parent.DirsCount--;
                            //RemoveTreeNode(currentNode);
                        }

                        // извлекаем узел папки из стека (и подпапки, и файлы получены)
                        processingDirs.Pop();
                    }                    
                }
                UpdateProcessingInfo("", cntProcessed, cntSearched);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}