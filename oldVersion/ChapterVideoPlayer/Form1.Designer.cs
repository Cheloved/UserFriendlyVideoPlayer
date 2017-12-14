namespace ChapterVideoPlayer
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.panel1 = new System.Windows.Forms.Panel();
            this.playlistButton = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.файлToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.открытьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openPath = new System.Windows.Forms.ToolStripMenuItem();
            this.openLast = new System.Windows.Forms.ToolStripMenuItem();
            this.видToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.темыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.whiteThemeStrip = new System.Windows.Forms.ToolStripMenuItem();
            this.darkThemeStrip = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsMenuStrip = new System.Windows.Forms.ToolStripMenuItem();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.movieTrackBar = new System.Windows.Forms.TrackBar();
            this.panel5 = new System.Windows.Forms.Panel();
            this.returnButton = new System.Windows.Forms.Button();
            this.timeLabel = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.volumeBar = new System.Windows.Forms.TrackBar();
            this.playButton = new System.Windows.Forms.Button();
            this.muteButton = new System.Windows.Forms.Button();
            this.stopButton = new System.Windows.Forms.Button();
            this.fullScreenButton = new System.Windows.Forms.Button();
            this.VideoPanel = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.movieTrackBar)).BeginInit();
            this.panel5.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.volumeBar)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.playlistButton);
            this.panel1.Controls.Add(this.menuStrip1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.ForeColor = System.Drawing.SystemColors.Control;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(989, 29);
            this.panel1.TabIndex = 0;
            // 
            // playlistButton
            // 
            this.playlistButton.Dock = System.Windows.Forms.DockStyle.Right;
            this.playlistButton.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.playlistButton.Location = new System.Drawing.Point(925, 0);
            this.playlistButton.Name = "playlistButton";
            this.playlistButton.Size = new System.Drawing.Size(64, 29);
            this.playlistButton.TabIndex = 0;
            this.playlistButton.Text = "Плейлист";
            this.playlistButton.UseVisualStyleBackColor = true;
            this.playlistButton.Click += new System.EventHandler(this.playlistButton_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.Transparent;
            this.menuStrip1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.файлToolStripMenuItem,
            this.видToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(989, 29);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // файлToolStripMenuItem
            // 
            this.файлToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.открытьToolStripMenuItem});
            this.файлToolStripMenuItem.Name = "файлToolStripMenuItem";
            this.файлToolStripMenuItem.Size = new System.Drawing.Size(48, 25);
            this.файлToolStripMenuItem.Text = "Файл";
            // 
            // открытьToolStripMenuItem
            // 
            this.открытьToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openPath,
            this.openLast});
            this.открытьToolStripMenuItem.Name = "открытьToolStripMenuItem";
            this.открытьToolStripMenuItem.Size = new System.Drawing.Size(121, 22);
            this.открытьToolStripMenuItem.Text = "Открыть";
            // 
            // openPath
            // 
            this.openPath.Name = "openPath";
            this.openPath.Size = new System.Drawing.Size(194, 22);
            this.openPath.Text = "По пути";
            this.openPath.Click += new System.EventHandler(this.openPath_Click);
            // 
            // openLast
            // 
            this.openLast.Name = "openLast";
            this.openLast.Size = new System.Drawing.Size(194, 22);
            this.openLast.Text = "Последний открытый";
            this.openLast.Click += new System.EventHandler(this.openLast_Click);
            // 
            // видToolStripMenuItem
            // 
            this.видToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.темыToolStripMenuItem,
            this.settingsMenuStrip});
            this.видToolStripMenuItem.Name = "видToolStripMenuItem";
            this.видToolStripMenuItem.Size = new System.Drawing.Size(39, 25);
            this.видToolStripMenuItem.Text = "Вид";
            // 
            // темыToolStripMenuItem
            // 
            this.темыToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.whiteThemeStrip,
            this.darkThemeStrip});
            this.темыToolStripMenuItem.Name = "темыToolStripMenuItem";
            this.темыToolStripMenuItem.Size = new System.Drawing.Size(134, 22);
            this.темыToolStripMenuItem.Text = "Темы";
            // 
            // whiteThemeStrip
            // 
            this.whiteThemeStrip.Name = "whiteThemeStrip";
            this.whiteThemeStrip.Size = new System.Drawing.Size(118, 22);
            this.whiteThemeStrip.Text = "Светлая";
            this.whiteThemeStrip.Click += new System.EventHandler(this.whiteThemeStrip_Click);
            // 
            // darkThemeStrip
            // 
            this.darkThemeStrip.Name = "darkThemeStrip";
            this.darkThemeStrip.Size = new System.Drawing.Size(118, 22);
            this.darkThemeStrip.Text = "Тёмная";
            this.darkThemeStrip.Click += new System.EventHandler(this.darkThemeStrip_Click);
            // 
            // settingsMenuStrip
            // 
            this.settingsMenuStrip.Name = "settingsMenuStrip";
            this.settingsMenuStrip.Size = new System.Drawing.Size(134, 22);
            this.settingsMenuStrip.Text = "Настройки";
            this.settingsMenuStrip.Click += new System.EventHandler(this.settingsMenuStrip_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.panel4);
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Controls.Add(this.fullScreenButton);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 521);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(989, 40);
            this.panel2.TabIndex = 1;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.movieTrackBar);
            this.panel4.Controls.Add(this.panel5);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(234, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(714, 40);
            this.panel4.TabIndex = 8;
            // 
            // movieTrackBar
            // 
            this.movieTrackBar.BackColor = System.Drawing.SystemColors.Control;
            this.movieTrackBar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.movieTrackBar.Location = new System.Drawing.Point(105, 0);
            this.movieTrackBar.Maximum = 60;
            this.movieTrackBar.Name = "movieTrackBar";
            this.movieTrackBar.Size = new System.Drawing.Size(609, 40);
            this.movieTrackBar.TabIndex = 5;
            this.movieTrackBar.TickFrequency = 60;
            this.movieTrackBar.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.movieTrackBar.Scroll += new System.EventHandler(this.movieTrackBar_Scroll);
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.SystemColors.Control;
            this.panel5.Controls.Add(this.returnButton);
            this.panel5.Controls.Add(this.timeLabel);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel5.Location = new System.Drawing.Point(0, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(105, 40);
            this.panel5.TabIndex = 0;
            // 
            // returnButton
            // 
            this.returnButton.BackgroundImage = global::ChapterVideoPlayer.Properties.Resources.if_arrow_left_01_186410;
            this.returnButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.returnButton.Location = new System.Drawing.Point(75, 8);
            this.returnButton.Name = "returnButton";
            this.returnButton.Size = new System.Drawing.Size(27, 25);
            this.returnButton.TabIndex = 7;
            this.returnButton.UseVisualStyleBackColor = true;
            this.returnButton.Click += new System.EventHandler(this.returnButton_Click);
            // 
            // timeLabel
            // 
            this.timeLabel.AutoSize = true;
            this.timeLabel.Location = new System.Drawing.Point(19, 14);
            this.timeLabel.Name = "timeLabel";
            this.timeLabel.Size = new System.Drawing.Size(0, 13);
            this.timeLabel.TabIndex = 6;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.Control;
            this.panel3.Controls.Add(this.volumeBar);
            this.panel3.Controls.Add(this.playButton);
            this.panel3.Controls.Add(this.muteButton);
            this.panel3.Controls.Add(this.stopButton);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(234, 40);
            this.panel3.TabIndex = 7;
            // 
            // volumeBar
            // 
            this.volumeBar.BackColor = System.Drawing.SystemColors.Control;
            this.volumeBar.Location = new System.Drawing.Point(126, 9);
            this.volumeBar.Name = "volumeBar";
            this.volumeBar.Size = new System.Drawing.Size(104, 45);
            this.volumeBar.TabIndex = 2;
            this.volumeBar.TickStyle = System.Windows.Forms.TickStyle.None;
            this.volumeBar.Scroll += new System.EventHandler(this.volumeBar_Scroll);
            // 
            // playButton
            // 
            this.playButton.BackColor = System.Drawing.SystemColors.Control;
            this.playButton.BackgroundImage = global::ChapterVideoPlayer.Properties.Resources.playIMG;
            this.playButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.playButton.Location = new System.Drawing.Point(3, 3);
            this.playButton.Name = "playButton";
            this.playButton.Size = new System.Drawing.Size(35, 35);
            this.playButton.TabIndex = 0;
            this.playButton.UseVisualStyleBackColor = false;
            this.playButton.Click += new System.EventHandler(this.playButton_Click);
            // 
            // muteButton
            // 
            this.muteButton.BackgroundImage = global::ChapterVideoPlayer.Properties.Resources.volumeIMG;
            this.muteButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.muteButton.Location = new System.Drawing.Point(85, 3);
            this.muteButton.Name = "muteButton";
            this.muteButton.Size = new System.Drawing.Size(35, 35);
            this.muteButton.TabIndex = 3;
            this.muteButton.UseVisualStyleBackColor = true;
            this.muteButton.Click += new System.EventHandler(this.muteButton_Click);
            // 
            // stopButton
            // 
            this.stopButton.BackgroundImage = global::ChapterVideoPlayer.Properties.Resources.stopIMG;
            this.stopButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.stopButton.Location = new System.Drawing.Point(44, 3);
            this.stopButton.Name = "stopButton";
            this.stopButton.Size = new System.Drawing.Size(35, 35);
            this.stopButton.TabIndex = 1;
            this.stopButton.UseVisualStyleBackColor = true;
            this.stopButton.Click += new System.EventHandler(this.stopButton_Click);
            // 
            // fullScreenButton
            // 
            this.fullScreenButton.BackgroundImage = global::ChapterVideoPlayer.Properties.Resources.fullscreenIMG;
            this.fullScreenButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.fullScreenButton.Dock = System.Windows.Forms.DockStyle.Right;
            this.fullScreenButton.Location = new System.Drawing.Point(948, 0);
            this.fullScreenButton.Name = "fullScreenButton";
            this.fullScreenButton.Size = new System.Drawing.Size(41, 40);
            this.fullScreenButton.TabIndex = 4;
            this.fullScreenButton.UseVisualStyleBackColor = true;
            this.fullScreenButton.Click += new System.EventHandler(this.fullScreenButton_Click);
            // 
            // VideoPanel
            // 
            this.VideoPanel.BackColor = System.Drawing.SystemColors.Control;
            this.VideoPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.VideoPanel.Location = new System.Drawing.Point(0, 29);
            this.VideoPanel.Name = "VideoPanel";
            this.VideoPanel.Size = new System.Drawing.Size(989, 492);
            this.VideoPanel.TabIndex = 2;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(989, 561);
            this.Controls.Add(this.VideoPanel);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MainMenuStrip = this.menuStrip1;
            this.MinimumSize = new System.Drawing.Size(350, 300);
            this.Name = "Form1";
            this.Text = "Chapter Video Player";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.movieTrackBar)).EndInit();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.volumeBar)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem файлToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem открытьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openPath;
        private System.Windows.Forms.ToolStripMenuItem openLast;
        private System.Windows.Forms.Button playButton;
        private System.Windows.Forms.Button stopButton;
        public System.Windows.Forms.TrackBar volumeBar;
        private System.Windows.Forms.Button muteButton;
        private System.Windows.Forms.Button fullScreenButton;
        private System.Windows.Forms.TrackBar movieTrackBar;
        private System.Windows.Forms.Label timeLabel;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.ToolStripMenuItem видToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem темыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem whiteThemeStrip;
        private System.Windows.Forms.ToolStripMenuItem darkThemeStrip;
        private System.Windows.Forms.Button returnButton;
        private System.Windows.Forms.ToolStripMenuItem settingsMenuStrip;
        private System.Windows.Forms.Button playlistButton;
        private System.Windows.Forms.Panel VideoPanel;
    }
}

