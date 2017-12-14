using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ChapterVideoPlayer
{
    public partial class playlistForm : Form
    {
        Form1 mainForm;
        public playlistForm(Form1 owner)
        {
            InitializeComponent();
            mainForm = owner;
            scrollBar.Parent = playlistBox;
        }
        private void addButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Media Files(*.MP4;*.AVI;*.FLV;*.MPE;*.MPEG;*.SVF;*.WMV;*.MKV;*.MOV;*.TS;*.OGM;*.WebM)|*.MP4;*.AVI;*.FLV;*.MPE;*.MPEG;*.SVF;*.WMV;*.MKV;*.MOV;*.TS;*.OGM;*.WebM|All files (*.*)|*.*";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                if(mainForm.openAfterAdding)
                {
                    mainForm.VideoOpenLastByName(dialog.FileName);
                }else
                {
                    PlaylistAdd(dialog.FileName);
                }
            }
        }
        public void PlaylistAdd(string filePath)
        {
            if (!mainForm.PlayList.Contains(filePath))
            {
                playlistBox.Items.Add(filePath.Split('\\')[filePath.Split('\\').Length - 1]);
                mainForm.PlayList.Add(filePath.Split('\n')[0]);
            }
        }
        private void deleteButton_Click(object sender, EventArgs e)
        {
            if (playlistBox.SelectedItem != null)
            {
                if(mainForm.PlayList[playlistBox.SelectedIndex] == mainForm.path)
                {
                    mainForm.logSave(mainForm.video.CurrentPosition.ToString(), "Choosing another one in playlist");
                    mainForm.video.Dispose();
                    if(playlistBox.SelectedIndex != 0)
                    {
                        mainForm.VideoOpenLastByName(mainForm.PlayList[playlistBox.SelectedIndex - 1]);
                    }
                    else mainForm.VideoOpenLastByName(mainForm.PlayList[playlistBox.SelectedIndex + 1]);
                }
                mainForm.PlayList.RemoveAt(playlistBox.SelectedIndex);
                playlistBox.Items.Remove(playlistBox.SelectedItem);
            }
        }
        private void playlistBox_DoubleClick(object sender, EventArgs e)
        {
            int index = playlistBox.SelectedIndex;
            if(mainForm.video != null)
            {
                mainForm.logSave(mainForm.video.CurrentPosition.ToString(), "Choosing another one in playlist");
                mainForm.video.Dispose();
            }
            bool buffer = mainForm.reqvToContinue;
            mainForm.timer.Enabled = false;
            mainForm.reqvToContinue = false;
            mainForm.VideoOpenLastByName(mainForm.PlayList[index]);
            mainForm.reqvToContinue = buffer;
            mainForm.timer.Enabled = true;
        }
        private void form_Closing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Visible = false;
            mainForm.playlistOpened = false;
        }
        public void getPlaylistByDir(string dir)
        {
            string[] fileBuffer = Directory.GetFiles(dir);
            foreach (string file in fileBuffer)
            {
                string ext = getExtension(file);
                if (mainForm.readableExtensions.Contains(ext))
                {
                    PlaylistAdd(file);
                }
            }
        }
        string getExtension(string fileName)
        {
            return fileName.Split('.')[fileName.Split('.').Length - 1];
        }
        public string getFileDirectory(string path)
        {
            string directory = string.Empty;
            string[] buffer = path.Split('\\');
            for (int i = 0; i < buffer.Length - 1; i++)
            {
                directory += buffer[i];
                directory += "\\";
            }
            return directory;
        }
        int getCurrentIndex()
        {
            return mainForm.PlayList.IndexOf(mainForm.path);
        }
        public void playNext()
        {
            int index = getCurrentIndex();
            if(index < mainForm.PlayList.Count - 1)
            {
                bool buffer = mainForm.reqvToContinue;
                mainForm.reqvToContinue = false;
                mainForm.timer.Enabled = false;
                mainForm.VideoOpenLastByName(mainForm.PlayList[index + 1]);
                mainForm.reqvToContinue = buffer;
                mainForm.timer.Enabled = true;
                playlistBox.SelectedIndex = index + 1;
            }
        }
        void onDragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop, false) == true)
            {
                e.Effect = DragDropEffects.All;
            }
        }
        void onDragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            foreach (string file in files)
            {
                PlaylistAdd(file);
            }
        }
        private void upButton_Click(object sender, EventArgs e)
        {
            if(playlistBox.SelectedItem != null)
            {
                if(playlistBox.SelectedIndex != 0)
                {
                    int index = playlistBox.SelectedIndex;
                    string buffer = mainForm.PlayList[index];
                    mainForm.PlayList.RemoveAt(index);
                    playlistBox.Items.RemoveAt(index);
                    mainForm.PlayList.Insert(index - 1, buffer);
                    playlistBox.Items.Insert(index - 1, buffer.Split('\\')[buffer.Split('\\').Length - 1]);
                    playlistBox.SelectedIndex = index - 1;
                }
            }
        }
        private void downButton_Click(object sender, EventArgs e)
        {
            if(playlistBox.SelectedItem != null)
            {
                if(playlistBox.SelectedIndex != playlistBox.Items.Count - 1)
                {
                    int index = playlistBox.SelectedIndex;
                    string buffer = mainForm.PlayList[index];
                    mainForm.PlayList.RemoveAt(index);
                    playlistBox.Items.RemoveAt(index);
                    mainForm.PlayList.Insert(index + 1, buffer);
                    playlistBox.Items.Insert(index + 1, buffer.Split('\\')[buffer.Split('\\').Length - 1]);
                    playlistBox.SelectedIndex = index + 1;
                }
            }
        }
    }
}
