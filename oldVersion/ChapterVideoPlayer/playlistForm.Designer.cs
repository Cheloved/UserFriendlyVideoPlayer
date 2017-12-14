namespace ChapterVideoPlayer
{
    partial class playlistForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(playlistForm));
            this.playlistBox = new System.Windows.Forms.ListBox();
            this.addButton = new System.Windows.Forms.Button();
            this.upButton = new System.Windows.Forms.Button();
            this.deleteButton = new System.Windows.Forms.Button();
            this.downButton = new System.Windows.Forms.Button();
            this.scrollBar = new System.Windows.Forms.VScrollBar();
            this.SuspendLayout();
            // 
            // playlistBox
            // 
            this.playlistBox.AllowDrop = true;
            this.playlistBox.Dock = System.Windows.Forms.DockStyle.Left;
            this.playlistBox.FormattingEnabled = true;
            this.playlistBox.Location = new System.Drawing.Point(0, 0);
            this.playlistBox.Name = "playlistBox";
            this.playlistBox.Size = new System.Drawing.Size(280, 561);
            this.playlistBox.TabIndex = 0;
            this.playlistBox.DragDrop += new System.Windows.Forms.DragEventHandler(this.onDragDrop);
            this.playlistBox.DragEnter += new System.Windows.Forms.DragEventHandler(this.onDragEnter);
            this.playlistBox.DoubleClick += new System.EventHandler(this.playlistBox_DoubleClick);
            // 
            // addButton
            // 
            this.addButton.BackgroundImage = global::ChapterVideoPlayer.Properties.Resources.if_plus_118619;
            this.addButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.addButton.Location = new System.Drawing.Point(287, 12);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(30, 30);
            this.addButton.TabIndex = 1;
            this.addButton.UseVisualStyleBackColor = true;
            this.addButton.Click += new System.EventHandler(this.addButton_Click);
            // 
            // upButton
            // 
            this.upButton.BackgroundImage = global::ChapterVideoPlayer.Properties.Resources.if_arrow_up_01_186407;
            this.upButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.upButton.Location = new System.Drawing.Point(287, 220);
            this.upButton.Name = "upButton";
            this.upButton.Size = new System.Drawing.Size(30, 30);
            this.upButton.TabIndex = 2;
            this.upButton.UseVisualStyleBackColor = true;
            this.upButton.Click += new System.EventHandler(this.upButton_Click);
            // 
            // deleteButton
            // 
            this.deleteButton.BackgroundImage = global::ChapterVideoPlayer.Properties.Resources.if_remove_01_186389;
            this.deleteButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.deleteButton.Location = new System.Drawing.Point(287, 256);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(30, 30);
            this.deleteButton.TabIndex = 3;
            this.deleteButton.UseVisualStyleBackColor = true;
            this.deleteButton.Click += new System.EventHandler(this.deleteButton_Click);
            // 
            // downButton
            // 
            this.downButton.BackgroundImage = global::ChapterVideoPlayer.Properties.Resources.if_arrow_down_01_186411;
            this.downButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.downButton.Location = new System.Drawing.Point(287, 292);
            this.downButton.Name = "downButton";
            this.downButton.Size = new System.Drawing.Size(30, 30);
            this.downButton.TabIndex = 4;
            this.downButton.UseVisualStyleBackColor = true;
            this.downButton.Click += new System.EventHandler(this.downButton_Click);
            // 
            // scrollBar
            // 
            this.scrollBar.Location = new System.Drawing.Point(263, 0);
            this.scrollBar.Name = "scrollBar";
            this.scrollBar.Size = new System.Drawing.Size(17, 561);
            this.scrollBar.TabIndex = 5;
            // 
            // playlistForm
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(329, 561);
            this.Controls.Add(this.scrollBar);
            this.Controls.Add(this.downButton);
            this.Controls.Add(this.deleteButton);
            this.Controls.Add(this.upButton);
            this.Controls.Add(this.addButton);
            this.Controls.Add(this.playlistBox);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "playlistForm";
            this.Text = "Плейлист";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.form_Closing);
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.ListBox playlistBox;
        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.Button upButton;
        private System.Windows.Forms.Button deleteButton;
        private System.Windows.Forms.Button downButton;
        private System.Windows.Forms.VScrollBar scrollBar;

    }
}