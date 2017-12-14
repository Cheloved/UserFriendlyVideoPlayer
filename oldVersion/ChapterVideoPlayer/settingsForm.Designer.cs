namespace ChapterVideoPlayer
{
    partial class settingsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(settingsForm));
            this.confirmButton = new System.Windows.Forms.Button();
            this.returnButton = new System.Windows.Forms.Button();
            this.confirmChechBox = new System.Windows.Forms.CheckBox();
            this.clearLogButton = new System.Windows.Forms.Button();
            this.rebuildConfigButton = new System.Windows.Forms.Button();
            this.openAfterAddingBox = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // confirmButton
            // 
            this.confirmButton.Location = new System.Drawing.Point(191, 112);
            this.confirmButton.Name = "confirmButton";
            this.confirmButton.Size = new System.Drawing.Size(75, 23);
            this.confirmButton.TabIndex = 0;
            this.confirmButton.Text = "Применить";
            this.confirmButton.UseVisualStyleBackColor = true;
            this.confirmButton.Click += new System.EventHandler(this.confirmButton_Click);
            // 
            // returnButton
            // 
            this.returnButton.Location = new System.Drawing.Point(272, 112);
            this.returnButton.Name = "returnButton";
            this.returnButton.Size = new System.Drawing.Size(75, 23);
            this.returnButton.TabIndex = 1;
            this.returnButton.Text = "Отмена";
            this.returnButton.UseVisualStyleBackColor = true;
            this.returnButton.Click += new System.EventHandler(this.returnButton_Click);
            // 
            // confirmChechBox
            // 
            this.confirmChechBox.AutoSize = true;
            this.confirmChechBox.Location = new System.Drawing.Point(12, 12);
            this.confirmChechBox.Name = "confirmChechBox";
            this.confirmChechBox.Size = new System.Drawing.Size(272, 17);
            this.confirmChechBox.TabIndex = 3;
            this.confirmChechBox.Text = "Спрашивать разрешение на продолжение видео";
            this.confirmChechBox.UseVisualStyleBackColor = true;
            // 
            // clearLogButton
            // 
            this.clearLogButton.Location = new System.Drawing.Point(12, 68);
            this.clearLogButton.Name = "clearLogButton";
            this.clearLogButton.Size = new System.Drawing.Size(111, 23);
            this.clearLogButton.TabIndex = 4;
            this.clearLogButton.Text = "Очистить логи";
            this.clearLogButton.UseVisualStyleBackColor = true;
            this.clearLogButton.Click += new System.EventHandler(this.clearLogButton_Click);
            // 
            // rebuildConfigButton
            // 
            this.rebuildConfigButton.Location = new System.Drawing.Point(12, 97);
            this.rebuildConfigButton.Name = "rebuildConfigButton";
            this.rebuildConfigButton.Size = new System.Drawing.Size(111, 23);
            this.rebuildConfigButton.TabIndex = 5;
            this.rebuildConfigButton.Text = "По умолчанию";
            this.rebuildConfigButton.UseVisualStyleBackColor = true;
            this.rebuildConfigButton.Click += new System.EventHandler(this.rebuildConfigButton_Click);
            // 
            // openAfterAddingBox
            // 
            this.openAfterAddingBox.AutoSize = true;
            this.openAfterAddingBox.Location = new System.Drawing.Point(12, 35);
            this.openAfterAddingBox.Name = "openAfterAddingBox";
            this.openAfterAddingBox.Size = new System.Drawing.Size(270, 17);
            this.openAfterAddingBox.TabIndex = 6;
            this.openAfterAddingBox.Text = "Открывать видео после добавления в плейлист";
            this.openAfterAddingBox.UseVisualStyleBackColor = true;
            // 
            // settingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(359, 147);
            this.Controls.Add(this.openAfterAddingBox);
            this.Controls.Add(this.rebuildConfigButton);
            this.Controls.Add(this.clearLogButton);
            this.Controls.Add(this.confirmChechBox);
            this.Controls.Add(this.returnButton);
            this.Controls.Add(this.confirmButton);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "settingsForm";
            this.Text = "Настройки";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button confirmButton;
        private System.Windows.Forms.Button returnButton;
        private System.Windows.Forms.CheckBox confirmChechBox;
        private System.Windows.Forms.Button clearLogButton;
        private System.Windows.Forms.Button rebuildConfigButton;
        private System.Windows.Forms.CheckBox openAfterAddingBox;
    }
}