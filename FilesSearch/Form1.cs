using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FilesSearch
{
    public partial class mainForm : Form
    {
        public mainForm()
        {
            InitializeComponent();
        }

        private void mainForm_Load(object sender, EventArgs e)
        {
            LoadSettings();           
        }


        #region app settings
        /// <summary>
        /// Загрузка сохраненных критериев поиска
        /// </summary>
        private void LoadSettings()
        {
            if (String.IsNullOrEmpty(Properties.Settings.Default.StartupDirectory))
                txtSelectedFolder.Text = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            else
                txtSelectedFolder.Text = Properties.Settings.Default.StartupDirectory;
            txtFNPattern.Text = Properties.Settings.Default.FileNamePattern;
            txtFContentPattern.Text = Properties.Settings.Default.FileContentPattern;
        }

        /// <summary>
        /// Сохранение критериев поиска
        /// </summary>
        private void SaveSettings()
        {
            Properties.Settings.Default.StartupDirectory = txtSelectedFolder.Text;
            Properties.Settings.Default.FileNamePattern = txtFNPattern.Text;
            Properties.Settings.Default.FileContentPattern = txtFContentPattern.Text;

            Properties.Settings.Default.Save();
        }
        #endregion

                                 
        private void cmdSelectFolder_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            fbd.Description = "Select a folder to search in...";
            fbd.ShowNewFolderButton = false;

            if (fbd.ShowDialog() == DialogResult.OK)
            {
                string selectedFolder = fbd.SelectedPath;
                txtSelectedFolder.Text = selectedFolder;
            }
        }

                     

        // Обработчик кнопки "Поиск"
        private void cmdSearch_Click(object sender, EventArgs e)
        {
            cmdSearch.Enabled = false;

            bool value = (cmdSearch.Tag as bool?) ?? true;
           
            if (value)
            {
                cmdSearch.Tag = !value;
                cmdSearch.Text = value ? "Стоп" : "Поиск";

                SaveSettings(); // сохранить введенные критерии поиска

                // очистить стек
                processingDirs.Clear();
                // добавить в стек корневую папку
                processingDirs.Push(new DirectoryNode(txtSelectedFolder.Text));

                // Сбросить счетчики и очистить предыдущие результаты
                cntSearched = 0;
                cntProcessed = 0;
                _ticks = 0;
                lblCurrentFile.Text = String.Empty;
                lblTime.Text = "00:00:00";
                lblPCount.Text = "";
                lblSCount.Text = "";
                tviewSFiles.Nodes.Clear(); // очистить дерево найденных файлов
                
                // показать кнопку паузы
                cmdPause.Visible = true;
                cmdSelectFolder.Enabled = false;
                txtFNPattern.Enabled = false;
                txtFContentPattern.Enabled = false;

                // запускаем поиск и таймер
                //worker.RunWorkerAsync(new Action(() => BuildTree(processingDirs, txtFNPattern.Text.ToLower(), txtFContentPattern.Text)));
                worker.RunWorkerAsync();
                timer1.Start();
            }
            else
            {
                worker.CancelAsync();

                cmdPause.Visible = false;
                cmdSelectFolder.Enabled = true;
                txtFNPattern.Enabled = true;
                txtFContentPattern.Enabled = true;
                // Меняем название кнопки для поиска
                cmdSearch.Tag = !value;
                cmdSearch.Text = value ? "Стоп" : "Поиск";

                cmdPause.Tag = true;
                cmdPause.Text = "Пауза";
                timer1.Stop();
            }
            cmdSearch.Enabled = true;
        }
        

        private void worker_DoWork(object sender, DoWorkEventArgs e)
        {
            BuildTree(processingDirs, txtFNPattern.Text.ToLower(), txtFContentPattern.Text, e);
            //((Action)e.Argument)();            
        }

        private void worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            // если поиск завершился и не стоит на паузе
            if (!e.Cancelled)
            {
                cmdPause.Visible = false;
                cmdSelectFolder.Enabled = true;
                txtFNPattern.Enabled = true;
                txtFContentPattern.Enabled = true;
                
                // Меняем название кнопки для поиска
                bool value = (cmdSearch.Tag as bool?) ?? true;
                cmdSearch.Tag = !value;
                cmdSearch.Text = value ? "Стоп" : "Поиск";
                        
                timer1.Stop();
            }            
        }
        
        long _ticks = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            _ticks++;
            lblTime.Text = TimeSpan.FromSeconds(_ticks).ToString(@"hh\:mm\:ss");
        }

        // Пауза / Возобновление
        private void cmdPause_Click(object sender, EventArgs e)
        {
            bool value = (cmdPause.Tag as bool?) ?? true;

            if (value) // если пауза
            {
                cmdPause.Tag = !value;
                cmdPause.Text = value ? "Продолжить" : "Пауза";
                worker.CancelAsync();
                timer1.Stop();
            }
            else // продолжить 
            {
                cmdPause.Tag = !value;
                cmdPause.Text = value ? "Продолжить" : "Пауза";
                //worker.RunWorkerAsync(new Action(() => BuildTree(processingDirs, txtFNPattern.Text.ToLower(), txtFContentPattern.Text)));
                worker.RunWorkerAsync();
                timer1.Start();
            }
        }
    }
}
