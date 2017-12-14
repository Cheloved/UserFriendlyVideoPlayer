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
    public partial class settingsForm : Form
    {
        Form1 mainForm;
        public settingsForm(Form1 owner)
        {
            InitializeComponent();
            mainForm = owner;
            confirmChechBox.Checked = mainForm.reqvToContinue;
            openAfterAddingBox.Checked = mainForm.openAfterAdding;
        }

        private void returnButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void confirmButton_Click(object sender, EventArgs e)
        {
            FileStream fs = new FileStream(mainForm.configFile, FileMode.Truncate);
            StreamWriter writer = new StreamWriter(fs);
            writer.WriteLine("StartVolume:" + mainForm.volumeBar.Value);
            writer.Write("Theme:" + mainForm.theme);
            writer.Write("\nRequestToContinueVideo:" + confirmChechBox.Checked.ToString());
            writer.Write("\nOpenVideoAfterAddingAtPlaylist:" + openAfterAddingBox.Checked.ToString());
            writer.Close();
            fs.Close();
            mainForm.getSettings();
            this.Close();
        }

        private void clearLogButton_Click(object sender, EventArgs e) { File.Create(mainForm.logFile).Close();}

        private void rebuildConfigButton_Click(object sender, EventArgs e)
        {
            mainForm.createConfig();
            mainForm.getSettings();
            this.Close();
        }
    }
}
