using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Microsoft.DirectX;
using Microsoft.DirectX.AudioVideoPlayback;

namespace ChapterVideoPlayer
{
    public partial class Form1 : Form
    {
        char splitChar = '♫';
        public string path;
        string programmDirectory;
        public string logFile;
        public Video video;
        public Timer timer;
        bool isMuted;
        public string theme;
        public int startVolume;
        public bool isHoverTrackBar = false;
        public bool reqvToContinue;
        public string configFile;
        public bool playlistOpened;
        public List<string> PlayList = new List<string>();
        public List<string> readableExtensions = new List<string>
        {
            "mp4","avi","flv","mpe","mpeg","svf","wmv","mkv","mov","ts","ogm","WebM"
        };
        playlistForm formPlaylist;
        public bool openAfterAdding;

        //ФОРМА//
        public Form1(string openWithPath)
        {
            InitializeComponent();
            formPlaylist = new playlistForm(this);
            formPlaylist.Visible = false;
            playlistOpened = false;
            this.KeyUp += new KeyEventHandler(keyPressed);
            programmDirectory = @"C:\Users\" + Environment.UserName + @"\Documents\CVideoPlayer\";
            logFile = programmDirectory + "log.cvp";
            configFile = programmDirectory + "player.cfg";
            checkDir(programmDirectory);
            checkConfig();
            getSettings();
            isMuted = false;
            volumeBar.SetRange(-6000, 0);
            volumeBar.Value = startVolume;
            FileStream fs = new FileStream(logFile, FileMode.OpenOrCreate);
            StreamReader reader = new StreamReader(fs);
            string[] blocks = reader.ReadToEnd().Split(splitChar);
            reader.Close();
            fs.Close();
            timer = new Timer();
            InitializeTimer();
            movieTrackBar.MouseEnter += new EventHandler(trackBarEnter);
            setTheme(theme);
            if (openWithPath != null)
            {
                path = openWithPath;
                VideoOpenLastByName(openWithPath);
                formPlaylist.getPlaylistByDir(formPlaylist.getFileDirectory(path));
            }
            else
            {
                if (blocks.Length > 1)
                {
                    if (MessageBox.Show("Открыть там, где остановились?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        VideoOpenLast();
                    }
                }
            }
        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (video != null)
            {
                logSave(Convert.ToString(video.CurrentPosition), "Exit");
                saveConfig();
            }
        }
        void setTheme(string Theme)
        {
            switch(Theme)
            {
                case "bright":
                    {
                        ResetAllControlsBackColor(this);
                        theme = "bright";
                        break;
                    }
                case "dark":
                    {
                        menuStrip1.BackColor = Color.FromName("DimGray");
                        this.BackColor = Color.FromName("ControlDarkDark");
                        VideoPanel.BackColor = Color.FromName("ControlDark");
                        panel1.BackColor = Color.FromName("ControlDarkDark");
                        movieTrackBar.BackColor = Color.FromName("ControlDarkDark");
                        panel3.BackColor = Color.FromName("ControlDarkDark");
                        volumeBar.BackColor = Color.FromName("ControlDarkDark");
                        panel5.BackColor = Color.FromName("ControlDarkDark");
                        timeLabel.BackColor = Color.FromName("ControlDarkDark");
                        theme = "dark";
                        break;
                    }
            }
        }
        private void ResetAllControlsBackColor(Control control)
        {
            control.BackColor = SystemColors.Control;
            control.ForeColor = SystemColors.ControlText;
            if (control.HasChildren)
            {
                foreach (Control childControl in control.Controls)
                {
                    ResetAllControlsBackColor(childControl);
                }
            }
        }
        
        //ТАЙМЕР//
        private void InitializeTimer()
        {
            timer.Interval = 100;
            timer.Tick += new EventHandler(timer_Tick);
            timer.Enabled = true;
        }
        private void timer_Tick(object Sender, EventArgs e)
        {
            if (video != null)
            {
                int seconds = (int)video.CurrentPosition;
                int minuts = seconds / 60;
                seconds = seconds - minuts * 60;
                int hours = minuts / 60;
                minuts = minuts - hours * 60;
                timeLabel.Text = hours + ":" + minuts + ":" + seconds;
                movieTrackBar.Value = (int)video.CurrentPosition;
                if(video.CurrentPosition >= video.Duration)
                {
                    logSave("0", "End");
                    formPlaylist.playNext();
                } 
                if(isHoverTrackBar)
                {
                    Label lbl = new Label();
                    lbl.Text = Cursor.Position.ToString();
                    lbl.Location = Cursor.Position;
                    this.Controls.Add(lbl);
                    lbl.Visible = true;
                    lbl.BringToFront();
                    lbl.Dispose();
                    //this.Controls.Remove(lbl);
                }
            }
        }


        //ДРУГОЕ//
        private void keyPressed(object Sender, KeyEventArgs e)
        {
            if(video != null)
            {
                switch(e.KeyCode)
                {
                    case Keys.Escape:
                        {
                            if (video.Fullscreen) { video.Fullscreen = false; }
                            break;
                        }
                    case Keys.Space:
                        {
                            if (video.Fullscreen) { playButton_Click(new object(), new EventArgs()); }
                            if (!playButton.Focused) { playButton_Click(new object(), new EventArgs()); }
                            break;
                        }
                    case Keys.Left:
                        {
                            video.CurrentPosition -= 10;
                            break;
                        }
                    case Keys.Right:
                        {
                            video.CurrentPosition += 10;
                            break;
                        }
                    case Keys.E:
                        {
                            
                            break;
                        }
                }
            }
        }
        void setBtnImg(string img, Button btn)
        {
            switch (img)
            {
                case "play": { btn.BackgroundImage = ChapterVideoPlayer.Properties.Resources.playIMG; break; }
                case "pause": { btn.BackgroundImage = ChapterVideoPlayer.Properties.Resources.pauseIMG; break; }
                case "volume": { btn.BackgroundImage = ChapterVideoPlayer.Properties.Resources.volumeIMG; break; }
                case "mute": { btn.BackgroundImage = ChapterVideoPlayer.Properties.Resources.muteIMG; break; }
            }
        }                


        //ВИДЕО//
        void VideoOpen(string FilePath, float Time)
        {
            if (video != null) video.Stop();
            video = new Video(FilePath);
            path = FilePath;
            formPlaylist.PlaylistAdd(FilePath);
            setBtnImg("play", playButton);
            video.Open(FilePath);
            video.Owner = VideoPanel;
            video.Play();
            video.CurrentPosition = Time;
            video.Pause();
            video.Audio.Volume = volumeBar.Value;
            movieTrackBar.Maximum = (int)video.Duration;
            
        }
        void VideoOpenLast()
            {
                FileStream fs = new FileStream(logFile, FileMode.Open);
                StreamReader reader = new StreamReader(fs);
                string[] blocks = reader.ReadToEnd().Split(splitChar);
                if (blocks.Length <= 1) { MessageBox.Show("Логи пусты", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }
                string[,] str = new string[blocks.Length, 3];
                for (int a = 0; a < 3; a++)
                {
                    str[blocks.Length - 1, a] = blocks[blocks.Length - 1].Split('\n')[a];
                }
                string name = str[blocks.Length - 1, 0];
                path = name;
                float time = float.Parse(str[blocks.Length - 1, 1].Split(' ')[1]);
                reader.Close();
                fs.Close();
                VideoOpen(name, time);
            }
        public void VideoOpenLastByName(string name)
        {
            FileStream fs = new FileStream(logFile, FileMode.Open);
            StreamReader reader = new StreamReader(fs);
            string[] blocks = reader.ReadToEnd().Split(splitChar);
            reader.Close();
            fs.Close();
            float time = 0f;
            for (int i = 1; i < blocks.Length; i++)
            {
                if(blocks[i].Split('\n')[0] == name)
                {
                    time = float.Parse(blocks[i].Split('\n')[1].Split(' ')[1]);
                }
            }
            if(time != 0)
            {
                if (reqvToContinue)
                {
                    if (MessageBox.Show("Продолжить?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        VideoOpen(name, time);
                    }
                    else
                    {
                        VideoOpen(name, 0);
                    }
                }
                else { VideoOpen(name, time); }
            }else
            {
                VideoOpen(name, 0);
            }
        }


        //РАБОТА С ФАЙЛАМИ//
        public void logSave(string time, string reason)
        {
            FileStream fs = new FileStream(logFile, FileMode.Append);
            StreamWriter writer = new StreamWriter(fs);
            string text = "\n" + splitChar + path + "\nTime: " + time + "\nSave Reason: " + reason;
            writer.Write(text);
            writer.Close();
            fs.Close();
        }
        void checkDir(string path) { if (!Directory.Exists(path)) Directory.CreateDirectory(path); }

        //КОНФИГ//
        public void getSettings()
        {
            FileStream fs = new FileStream(configFile, FileMode.OpenOrCreate);
            StreamReader reader = new StreamReader(fs);
            string[] blocks = null;
            blocks = reader.ReadToEnd().Split('\n');
            startVolume = int.Parse(blocks[0].Split(':')[1]);
            theme = blocks[1].Split(':')[1];
            switch(blocks[2].Split(':')[1])
            {
                case "True": { reqvToContinue = true; break; }
                case "False": { reqvToContinue = false; break; }
            }
            switch (blocks[3].Split(':')[1])
            {
                case "True": { openAfterAdding = true; break; }
                case "False": { openAfterAdding = false; break; }
            }
            setTheme(theme);
            volumeBar.Minimum = -6000;
            volumeBar.Value = startVolume;
            reader.Close();
            fs.Close();
        }
        void checkConfig()
        {
            FileStream fs = new FileStream(configFile, FileMode.OpenOrCreate);
            StreamReader reader = new StreamReader(fs);
            string[] blocks = reader.ReadToEnd().Split('\n');
            reader.Close();
            fs.Close();
            if (blocks.Length <= 1) { createConfig(); }
        }
        public void createConfig()
        {
            FileStream fs = new FileStream(configFile, FileMode.Truncate);
            StreamWriter writer = new StreamWriter(fs);
            writer.WriteLine("StartVolume:0");
            writer.Write("Theme:bright");
            writer.Write("\nRequestToContinueVideo:True");
            writer.Write("\nOpenVideoAfterAddingAtPlaylist:True");
            writer.Close();
            fs.Close();
        }
        void saveConfig()
        {
            FileStream fs = new FileStream(configFile, FileMode.Truncate);
            StreamWriter writer = new StreamWriter(fs);
            writer.WriteLine("StartVolume:" + volumeBar.Value);
            writer.Write("Theme:" + theme);
            writer.Write("\nRequestToContinueVideo:" + reqvToContinue.ToString());
            writer.Write("\nOpenVideoAfterAddingAtPlaylist:" + openAfterAdding.ToString());
            writer.Close();
            fs.Close();
        }

        //GUI СОБЫТИЯ//
            //###########КНОПКИ###########//
            private void playButton_Click(object sender, EventArgs e)
        {
            if (video != null)
            {
                if (video.Playing)
                {
                    setBtnImg("play", playButton);
                    logSave(Convert.ToString(video.CurrentPosition), "Pause");
                    video.Pause();
                }
                else
                {
                    setBtnImg("pause", playButton);
                    video.Play();
                }
            }
        }
            private void stopButton_Click(object sender, EventArgs e)
            {
                if (video != null)
                {
                    logSave(Convert.ToString(video.CurrentPosition), "Stop button");
                    video.CurrentPosition = 0;
                    video.Stop();
                    video = null;
                    setBtnImg("play", playButton);
                }
            }
            private void muteButton_Click(object sender, EventArgs e)
        {
            if (video != null)
            {
                switch (isMuted)
                {
                    case false:
                        {
                            volumeBar.Value = volumeBar.Minimum;
                            video.Audio.Volume = -10000;
                            setBtnImg("mute", muteButton);
                            break;
                        }
                    case true:
                        {
                            video.Audio.Volume = volumeBar.Value;
                            setBtnImg("volume", muteButton);
                            break;
                        }
                }
                isMuted = !isMuted;
            }
        }
            private void fullScreenButton_Click(object sender, EventArgs e)
            {
                if (video != null)
                {
                    if (!video.Fullscreen)
                    {
                        video.Fullscreen = true;
                    }
                }
            }
            private void playlistButton_Click(object sender, EventArgs e)
            {
                playlistOpened = !playlistOpened;
                formPlaylist.Visible = playlistOpened;
                formPlaylist.Location = new Point(this.Size.Width + this.Location.X, this.Location.Y);
                if (video != null) formPlaylist.playlistBox.SelectedItem = path.Split('\\')[path.Split('\\').Length - 1];
            }        


            //###########МЕНЮ#############//
            private void openLast_Click(object sender, EventArgs e)
        {
            VideoOpenLast();
        }
            public void openPath_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Media Files(*.MP4;*.AVI;*.FLV;*.MPE;*.MPEG;*.SVF;*.WMV;*.MKV;*.MOV;*.TS;*.OGM;*.WebM)|*.MP4;*.AVI;*.FLV;*.MPE;*.MPEG;*.SVF;*.WMV;*.MKV;*.MOV;*.TS;*.OGM;*.WebM|All files (*.*)|*.*";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                path = dialog.FileName;
                VideoOpenLastByName(path);
            }
        }
            private void whiteThemeStrip_Click(object sender, EventArgs e)
            {
                theme = "bright";
                setTheme(theme);
                saveConfig();
            }
            private void darkThemeStrip_Click(object sender, EventArgs e)
            {
                theme = "dark";
                setTheme(theme);
                saveConfig();
            }
            private void settingsMenuStrip_Click(object sender, EventArgs e)
            {
                settingsForm SF = new settingsForm(this);
                SF.Visible = true;
            }  


            //#############ПОЛЗУНКИ##########//
            private void movieTrackBar_Scroll(object sender, EventArgs e)
            {
                if (video != null)
                {
                    video.CurrentPosition = movieTrackBar.Value;
                }
            }
            private void volumeBar_Scroll(object sender, EventArgs e)
            {
                if (video != null)
                    if (!isMuted)
                        video.Audio.Volume = volumeBar.Value;
            }
            private void returnButton_Click(object sender, EventArgs e)
            {
                if(video != null)
                {
                    video.CurrentPosition = 0;
                }
            }
        void trackBarEnter(object owner, EventArgs e)
        {
            isHoverTrackBar = true;
        }
    }
}
