using System;
using System.Timers;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.Win32;

namespace UFVP
{
    public partial class MainWindow : Window
    {
        bool isPaused = false;
        bool fullscreen = false;
        bool repeat = false;
        bool mouseHold;
        string fileType;
        Timer timer;
        Timer idleTimer;
        int idleTime = 0;

        string logName = "log.txt";
        string logPath;
        string logFile;

        List<string> list = new List<string>();
        int currentIndex;
        public MainWindow(string path = "")
        {
            InitializeComponent();
            this.KeyDown += new KeyEventHandler(keyDown);
            this.MinHeight = 364;
            this.MinWidth = 902;
            videoSlider.SelectionStart = 0;
            videoSlider.IsSelectionRangeEnabled = true;
            volumeSlider.Value = 1;

            logPath = @"C:\Users\" + Environment.UserName + @"\Documents\UFMP\";
            checkDirectory(logPath);
            logFile = logPath + logName;
            
            this.Closing += new System.ComponentModel.CancelEventHandler(onClosing);

            idleTimer = new Timer(1000);
            idleTimer.Elapsed += new ElapsedEventHandler(idleTimerTick);
            idleTimer.Enabled = true;
            this.MouseMove += new MouseEventHandler(mouseAction); 
            if (path != "")
                OpenLastByDir(path);
        }
        void keyDown(object owner, KeyEventArgs e)
        {
            switch(e.Key)
            {
                case Key.Escape:
                    {
                        if (fullscreen)
                        {
                            this.Content = mainGrid;
                            mainGrid.Children.Add(MediaPlayer);
                            this.WindowStyle = WindowStyle.SingleBorderWindow;
                            this.WindowState = WindowState.Normal;
                            fullscreen = !fullscreen;
                        }
                        break;
                    }
                case Key.Left:
                    {
                        if (MediaPlayer.Source == null) return;
                        if(fileType == "video")
                             MediaPlayer.Position = new TimeSpan((int)MediaPlayer.Position.TotalHours, (int)MediaPlayer.Position.TotalMinutes, (int)MediaPlayer.Position.TotalSeconds - 10);
                        break;
                    }
                case Key.Right:
                    {
                        if (MediaPlayer.Source == null) return;
                        if (fileType == "video")
                            MediaPlayer.Position = new TimeSpan((int)MediaPlayer.Position.TotalHours, (int)MediaPlayer.Position.TotalMinutes, (int)MediaPlayer.Position.TotalSeconds + 10);
                        break;
                    }
                case Key.Space:
                    {
                        if (playButton.IsFocused) return;
                        if (isPaused) { playButton_Click(new object(), new RoutedEventArgs()); isPaused = false; }
                        else { pauseButton_Click(new object(), new RoutedEventArgs()); isPaused = true; }
                        break;
                    }
            }
        }
        void InitializeTimer()
        {
            timer = new Timer(1);
            timer.Elapsed += new ElapsedEventHandler(TimerTick);
            timer.Enabled = true;
        }
        void TimerTick(object state, ElapsedEventArgs e)
        {
            MediaPlayer.Dispatcher.BeginInvoke(new Action(delegate()
            {
                if (MediaPlayer.NaturalDuration.HasTimeSpan)
                {
                    if (!mouseHold)
                    {
                        videoSlider.Value = MediaPlayer.Position.TotalSeconds;
                        videoSlider.SelectionEnd = videoSlider.Value;
                    }
                    timeLabel.Content = MediaPlayer.Position.Hours + ":" + MediaPlayer.Position.Minutes+ ":" + MediaPlayer.Position.Seconds;
                    timeLabel.Visibility = System.Windows.Visibility.Visible;
                    if (MediaPlayer.Position < MediaPlayer.NaturalDuration) return;
                    if(repeat)
                    {
                        if(MediaPlayer.Position.TotalSeconds >= MediaPlayer.NaturalDuration.TimeSpan.TotalSeconds)
                        {
                            TimeSpan time = new TimeSpan(0, 0, 0);
                            MediaPlayer.Position = time;
                        }
                    }
                    else
                    {
                        playNext(new object(), new RoutedEventArgs());
                    }
                }
            }));
        }
        void idleTimerTick(object state, ElapsedEventArgs e)
        {
            idleTime++;
            if(idleTime >= 2)
            {
                buttonsGrid.Dispatcher.BeginInvoke(new Action(delegate()
                {
                    buttonsGrid.Margin = new Thickness(0, 45, 0, 0);                    
                }));
            }
        }
        void mouseAction(object owner, MouseEventArgs e)
        {
            idleTime = 0;
            buttonsGrid.Dispatcher.BeginInvoke(new Action(delegate()
            {
                buttonsGrid.Margin = new Thickness(0);
            }));
        }
        void VideoOpen(string path, double time = 0)
        {
            MediaPlayer.Source = new Uri(path);
            MediaPlayer.Play();
            MediaPlayer.Position = new TimeSpan(0, 0, (int)time);
        }
        private void OpenPath(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            if(dialog.ShowDialog().Value)
            {
                VideoOpen(dialog.FileName);
            }
        }
        private void playButton_Click(object sender, RoutedEventArgs e)
        {
            if (MediaPlayer.Source == null) return;
            MediaPlayer.Play();
            playButton.Visibility = System.Windows.Visibility.Hidden;
            pauseButton.Visibility = System.Windows.Visibility.Visible;
            isPaused = false;
        }       
        private void pauseButton_Click(object sender, RoutedEventArgs e)
        {
            if (MediaPlayer.Source == null) return;
            MediaPlayer.Pause();
            playButton.Visibility = System.Windows.Visibility.Visible;
            pauseButton.Visibility = System.Windows.Visibility.Hidden;
            SaveLog("pause");
            isPaused = true;
        }
        private void MediaPlayer_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (isPaused) { playButton_Click(new object(), new RoutedEventArgs()); isPaused = false; }
            else { pauseButton_Click(new object(), new RoutedEventArgs()); isPaused = true; }
        }
        private void fullscreenButton_Click(object sender, RoutedEventArgs e)
        {
            if (MediaPlayer.Source == null) return;
            if (!fullscreen)
            {
                mainGrid.Children.Remove(MediaPlayer);
                this.Content = MediaPlayer;
                this.WindowStyle = WindowStyle.None;
                this.WindowState = WindowState.Maximized;
            }
            else
            {
                this.Content = mainGrid;
                mainGrid.Children.Add(MediaPlayer);
                this.WindowStyle = WindowStyle.SingleBorderWindow;
                this.WindowState = WindowState.Normal;
            }
            fullscreen = !fullscreen;
        }
        private void MediaPlayer_MediaOpened(object sender, RoutedEventArgs e)
        {
            fileType = "video";
            volumeButton.Visibility = System.Windows.Visibility.Visible;
            repeatButton.Visibility = System.Windows.Visibility.Visible;
            stopButton.Visibility = System.Windows.Visibility.Visible;
            mainGrid.Margin = new Thickness(0, 0, 0, 5);
            if (!MediaPlayer.HasVideo && MediaPlayer.HasAudio) //audio
            {
                this.WindowState = System.Windows.WindowState.Normal;
                this.Width = this.MinWidth;
                this.Height = this.MinHeight;
                fileType = "audio";
            }
            this.Width = MediaPlayer.NaturalVideoWidth;
            this.Height = MediaPlayer.NaturalVideoHeight + 115;
            if (this.Width > System.Windows.Forms.Screen.PrimaryScreen.WorkingArea.Width - 50 || this.Height > System.Windows.Forms.Screen.PrimaryScreen.WorkingArea.Height - 50)
            {
                this.WindowState = System.Windows.WindowState.Maximized;
            }
            if (MediaPlayer.HasVideo && !MediaPlayer.HasAudio) //picture
            {
                volumeButton.Visibility = System.Windows.Visibility.Hidden;
                repeatButton.Visibility = System.Windows.Visibility.Hidden;
                stopButton.Visibility = System.Windows.Visibility.Hidden;
                fileType = "picture";
                return;
            }
            playButton.Visibility = System.Windows.Visibility.Hidden;
            pauseButton.Visibility = System.Windows.Visibility.Visible;
            videoSlider.Maximum = MediaPlayer.NaturalDuration.TimeSpan.TotalSeconds;
            isPaused = false;
            InitializeTimer();
        }
        private void playlistButton_Click(object sender, RoutedEventArgs e)
        {
            if (playlist.Visibility == System.Windows.Visibility.Hidden)
                playlist.Visibility = System.Windows.Visibility.Visible;
            else
                playlist.Visibility = System.Windows.Visibility.Hidden;
        }
        private void videoSlider_LostMouseCapture(object sender, MouseEventArgs e)
        {
            TimeSpan time = new TimeSpan(0, 0, (int)videoSlider.Value); 
            MediaPlayer.Position = time;
            mouseHold = false;
        }
        private void videoSlider_GotMouseCapture(object sender, MouseEventArgs e)
        {
            mouseHold = true;
        }
        private void videoSlider_MouseMove(object sender, MouseEventArgs e)
        {
            
        }
        private void volumeSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            MediaPlayer.Volume = volumeSlider.Value;
        }
        private void volumeButton_Click(object sender, RoutedEventArgs e)
        {
            if (volumeGrid.Visibility == System.Windows.Visibility.Hidden)
                volumeGrid.Visibility = System.Windows.Visibility.Visible;
            else
                volumeGrid.Visibility = System.Windows.Visibility.Hidden;
        }
        private void repeatButton_Click(object sender, RoutedEventArgs e)
        {
            if (repeat)
                repeatButton.Background = Brushes.Transparent;
            else
                repeatButton.Background = Brushes.LightGray;

            repeat = !repeat;
        }
        private void volumeGrid_MouseLeave(object sender, MouseEventArgs e)
        {
            volumeGrid.Visibility = System.Windows.Visibility.Hidden;
        }
        private void stopButton_Click(object sender, RoutedEventArgs e)
        {
            if (MediaPlayer.Source == null) return;
            MediaPlayer.Stop();
            playButton.Visibility = System.Windows.Visibility.Visible;
            pauseButton.Visibility = System.Windows.Visibility.Hidden;
        }
        void checkDirectory(string path) { if (!Directory.Exists(path)) { Directory.CreateDirectory(path); } }
        void SaveLog(string reason = "default")
        {
            if (MediaPlayer.Source == null) return;
            FileStream fs = new FileStream(logFile, FileMode.Append);
            StreamWriter writer = new StreamWriter(fs);
            writer.Write("\n☼" + MediaPlayer.Source.OriginalString + "\nTime:" + MediaPlayer.Position.TotalSeconds + "\nReason:" + reason);
            writer.Close();
            fs.Close();
        }
        void OpenLast(object sender, RoutedEventArgs e)
        {
            FileStream fs = new FileStream(logFile, FileMode.OpenOrCreate);
            StreamReader reader = new StreamReader(fs);
            string[] buffer = reader.ReadToEnd().Split('☼');
            reader.Close();
            fs.Close();
            VideoOpen(buffer[buffer.Length-1].Split('\n')[0], double.Parse(buffer[buffer.Length-1].Split('\n')[1].Split(':')[1]));
            string[] b = new string[1] { buffer[buffer.Length - 1].Split('\n')[0] };
            PlaylistAdd(b);
        }       
        void getType()
        {
            fileType = "video";
            volumeButton.Visibility = System.Windows.Visibility.Visible;
            repeatButton.Visibility = System.Windows.Visibility.Visible;
            stopButton.Visibility = System.Windows.Visibility.Visible;
            if (!MediaPlayer.HasVideo && MediaPlayer.HasAudio) //audio
            {
                this.WindowState = System.Windows.WindowState.Normal;
                this.Width = this.MinWidth;
                this.Height = this.MinHeight;
                fileType = "audio";
            }
            if (MediaPlayer.HasVideo && !MediaPlayer.HasAudio) //picture
            {
                volumeButton.Visibility = System.Windows.Visibility.Hidden;
                repeatButton.Visibility = System.Windows.Visibility.Hidden;
                stopButton.Visibility = System.Windows.Visibility.Hidden;
                fileType = "picture";
                return;
            }
        }
        void OpenLastByDir(string path)
        {
            if (MediaPlayer.Source != null)
                SaveLog("choosingAnotherOne");
            FileStream fs = new FileStream(logFile, FileMode.OpenOrCreate);
            StreamReader reader = new StreamReader(fs);
            string[] buffer = reader.ReadToEnd().Split('☼');
            reader.Close();
            fs.Close();
            for(int i = buffer.Length - 1; i > 0; i--)
            {
                if(buffer[i].Split('\n')[0] == path)
                {
                    getType();
                    if (MessageBox.Show("Продолжить просмотр?", "", MessageBoxButton.OKCancel, MessageBoxImage.Question) == MessageBoxResult.OK && fileType == "video")
                    {
                        VideoOpen(path, double.Parse(buffer[i].Split('\n')[1].Split(':')[1]));
                    }
                    else
                    {
                        VideoOpen(path);
                    }
                    return;
                }
            }
            VideoOpen(path);
        }
        private void addButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Multiselect = true;
            if(dialog.ShowDialog().Value)
            {
                PlaylistAdd(dialog.FileNames);
            }
        }
        void PlaylistAdd(string[] path)
        {
            for(int i = 0; i < path.Length; i++)
            {
                ListBoxItem item = new ListBoxItem();
                item.Content = path[i].Split('\\')[path[i].Split('\\').Length - 1];
                playlistBox.Items.Add(item);
                list.Add(path[i]);
            }
            if (list.Count == path.Length) OpenLastByDir(path[0]);
        }
        private void playlistBox_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (playlistBox.SelectedItem == null) return;
            currentIndex = playlistBox.SelectedIndex;
            SaveLog("choosingAnotherOne");
            OpenLastByDir(list[playlistBox.SelectedIndex]);
        }
        void onClosing(object owner, EventArgs e)
        {
            SaveLog("closing");
        }
        void playNext(object sender, RoutedEventArgs e)
        {
            if (currentIndex == playlistBox.Items.Count - 1 || MediaPlayer.Source == null) return;
            int index = list.IndexOf(MediaPlayer.Source.OriginalString);
            SaveLog("gotoNext");
            OpenLastByDir(list[index + 1]);
        }
        private void playlist_MouseLeave(object sender, MouseEventArgs e)
        {
            playlist.Visibility = System.Windows.Visibility.Hidden;
        }
        private void upButton_Click(object sender, RoutedEventArgs e)
        {
            if (playlistBox.SelectedIndex == 0 || playlistBox.SelectedItem == null) return;
            int index = playlistBox.SelectedIndex;
            string buffer = list[index];
            playlistBox.Items.RemoveAt(index);
            list.Remove(buffer);
            playlistBox.Items.Insert(index - 1, buffer.Split('\\')[buffer.Split('\\').Length - 1]);
            list.Insert(index - 1, buffer);
        }
        private void downButton_Click(object sender, RoutedEventArgs e)
        {
            if (playlistBox.SelectedIndex == playlistBox.Items.Count - 1 || playlistBox.SelectedItem == null) return;
            int index = playlistBox.SelectedIndex;
            string buffer = list[index];
            playlistBox.Items.RemoveAt(index);
            list.Remove(buffer);
            playlistBox.Items.Insert(index + 1, buffer.Split('\\')[buffer.Split('\\').Length - 1]);
            list.Insert(index + 1, buffer);
        }
        private void playPrevious(object sender, RoutedEventArgs e)
        {
            if (currentIndex == 0 || MediaPlayer.Source == null) return;
            int index = list.IndexOf(MediaPlayer.Source.OriginalString);
            SaveLog("gotoPrevious");
            OpenLastByDir(list[index - 1]);
        }
    }
}