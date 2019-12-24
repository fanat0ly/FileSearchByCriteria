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
        private void mainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (worker.IsBusy)
                worker.CancelAsync();
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

        #region buttons handlers                               
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
            try
            {
                bool value = (cmdSearch.Tag as bool?) ?? true;

                if (value)
                {
                    UpdateView_Start();
                    
                    SaveSettings(); // сохранить введенные критерии поиска

                    // очистить стек
                    processingDirs.Clear();
                    // добавить в стек корневую папку
                    processingDirs.Push(new DirectoryNode(txtSelectedFolder.Text));

                    // сбросить счетчики
                    cntSearched = 0;
                    cntProcessed = 0;
                    _ticks = 0;
                    
                    // запускаем поиск и таймер
                    worker.RunWorkerAsync();
                    timer1.Start();
                }
                else
                {
                    if (worker.IsBusy)
                        cmdSearch.Enabled = false;
                    worker.CancelAsync();
                    UpdateView_Stop();
                    timer1.Stop();
                }                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                UpdateView_Stop();
                timer1.Stop();
                cmdPause.Enabled = true;
                cmdSearch.Enabled = true;
            }
        }

        // Пауза / Возобновление
        private void cmdPause_Click(object sender, EventArgs e)
        {
            try
            {
                bool value = (cmdPause.Tag as bool?) ?? true;

                if (value) // если пауза
                {
                    cmdPause.Enabled = false;
                    cmdPause.Tag = !value;
                    cmdPause.Text = value ? "Продолжить" : "Пауза";
                    worker.CancelAsync();
                    timer1.Stop();
                }
                else // продолжить 
                {
                    cmdPause.Tag = !value;
                    cmdPause.Text = value ? "Продолжить" : "Пауза";
                    worker.RunWorkerAsync();
                    timer1.Start();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                UpdateView_Stop();
                timer1.Stop();
                cmdPause.Enabled = true;
                cmdSearch.Enabled = true;
            }
        }
        #endregion

        #region view
        private void UpdateView_Stop()
        {
            cmdPause.Visible = false;
            
            cmdSelectFolder.Enabled = true;
            txtFNPattern.Enabled = true;
            txtFContentPattern.Enabled = true;
            
            cmdSearch.Tag = true;
            cmdSearch.Text = "Поиск";
            cmdPause.Tag = true;
            cmdPause.Text = "Пауза";

            pnlSCriteria.Update();
        }
        private void UpdateView_Start()
        {
            cmdSearch.Tag = false;
            cmdSearch.Text = "Стоп";
            cmdPause.Visible = true; // показать кнопку паузы
            
            // очистить предыдущие результаты
            lblCurrentFile.Text = String.Empty;
            lblTime.Text = "00:00:00";
            lblPCount.Text = "";
            lblSCount.Text = "";
            
            tviewSFiles.Nodes.Clear(); // очистить дерево найденных файлов

            // сделать недоступными критерии поиска
            cmdSelectFolder.Enabled = false;
            txtFNPattern.Enabled = false;
            txtFContentPattern.Enabled = false;

            pnlSCriteria.Update();
        }
        #endregion

        #region worker
        // Событие вызывается, когда операция запущена на выполнение
        private void worker_DoWork(object sender, DoWorkEventArgs e)
        {
            BuildTree(processingDirs, txtFNPattern.Text.ToLower(), txtFContentPattern.Text, e);                      
        }
        // Событие вызывается, когда операция завершена или отменена
        private void worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            // если поиск завершился и не стоит на паузе
            if (!e.Cancelled)
            {
                UpdateView_Stop();
                timer1.Stop();
            }
            cmdPause.Enabled = true;
            cmdSearch.Enabled = true;
        }
        #endregion

        #region timer
        long _ticks = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            _ticks++;
            lblTime.Text = TimeSpan.FromSeconds(_ticks).ToString(@"hh\:mm\:ss");
        }

        #endregion
        
    }
}
