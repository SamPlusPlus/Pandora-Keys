namespace PandoraKeys
{
    sealed partial class Tuner
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Tuner));
            this.PandoraBrowser = new System.Windows.Forms.WebBrowser();
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.playPauseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nextTrackToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.likeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dislikeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.hideShowPlayerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.log = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ResetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // PandoraBrowser
            // 
            this.PandoraBrowser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PandoraBrowser.Location = new System.Drawing.Point(0, 0);
            this.PandoraBrowser.MinimumSize = new System.Drawing.Size(20, 20);
            this.PandoraBrowser.Name = "PandoraBrowser";
            this.PandoraBrowser.ScriptErrorsSuppressed = true;
            this.PandoraBrowser.ScrollBarsEnabled = false;
            this.PandoraBrowser.Size = new System.Drawing.Size(839, 591);
            this.PandoraBrowser.TabIndex = 0;
            this.PandoraBrowser.Url = new System.Uri("https://www.pandora.com", System.UriKind.Absolute);
            // 
            // notifyIcon
            // 
            this.notifyIcon.ContextMenuStrip = this.contextMenu;
            this.notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon.Icon")));
            this.notifyIcon.Text = "Pandora Keys";
            this.notifyIcon.Visible = true;
            this.notifyIcon.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon_MouseDoubleClick);
            // 
            // contextMenu
            // 
            this.contextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.playPauseToolStripMenuItem,
            this.nextTrackToolStripMenuItem,
            this.likeToolStripMenuItem,
            this.dislikeToolStripMenuItem,
            this.toolStripSeparator1,
            this.hideShowPlayerToolStripMenuItem,
            this.ResetToolStripMenuItem,
            this.settingsToolStripMenuItem,
            this.toolStripSeparator3,
            this.log,
            this.toolStripSeparator2,
            this.aboutToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.contextMenu.Name = "contextMenu";
            this.contextMenu.Size = new System.Drawing.Size(169, 264);
            // 
            // playPauseToolStripMenuItem
            // 
            this.playPauseToolStripMenuItem.Name = "playPauseToolStripMenuItem";
            this.playPauseToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.playPauseToolStripMenuItem.Text = "Play/Pause";
            this.playPauseToolStripMenuItem.Click += new System.EventHandler(this.playPauseToolStripMenuItem_Click);
            // 
            // nextTrackToolStripMenuItem
            // 
            this.nextTrackToolStripMenuItem.Name = "nextTrackToolStripMenuItem";
            this.nextTrackToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.nextTrackToolStripMenuItem.Text = "Next Track";
            this.nextTrackToolStripMenuItem.Click += new System.EventHandler(this.nextTrackToolStripMenuItem_Click);
            // 
            // likeToolStripMenuItem
            // 
            this.likeToolStripMenuItem.Name = "likeToolStripMenuItem";
            this.likeToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.likeToolStripMenuItem.Text = "Like";
            this.likeToolStripMenuItem.Click += new System.EventHandler(this.likeToolStripMenuItem_Click);
            // 
            // dislikeToolStripMenuItem
            // 
            this.dislikeToolStripMenuItem.Name = "dislikeToolStripMenuItem";
            this.dislikeToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.dislikeToolStripMenuItem.Text = "Dislike";
            this.dislikeToolStripMenuItem.Click += new System.EventHandler(this.dislikeToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(165, 6);
            // 
            // hideShowPlayerToolStripMenuItem
            // 
            this.hideShowPlayerToolStripMenuItem.Name = "hideShowPlayerToolStripMenuItem";
            this.hideShowPlayerToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.hideShowPlayerToolStripMenuItem.Text = "Hide/Show Player";
            this.hideShowPlayerToolStripMenuItem.Click += new System.EventHandler(this.hideShowPlayerToolStripMenuItem_Click);
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.settingsToolStripMenuItem.Text = "Settings";
            this.settingsToolStripMenuItem.Click += new System.EventHandler(this.settingsToolStripMenuItem_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(165, 6);
            // 
            // log
            // 
            this.log.Name = "log";
            this.log.Size = new System.Drawing.Size(168, 22);
            this.log.Text = "Log";
            this.log.Click += new System.EventHandler(this.log_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(165, 6);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // ResetToolStripMenuItem
            // 
            this.ResetToolStripMenuItem.Name = "ResetToolStripMenuItem";
            this.ResetToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.ResetToolStripMenuItem.Text = "Reset";
            this.ResetToolStripMenuItem.Click += new System.EventHandler(this.ResetToolStripMenuItem_Click);
            // 
            // Tuner
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(839, 591);
            this.Controls.Add(this.PandoraBrowser);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Tuner";
            this.ShowInTaskbar = false;
            this.Text = "Pandora Keys";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Tuner_FormClosed);
            this.Resize += new System.EventHandler(this.Tuner_Resize);
            this.contextMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.WebBrowser PandoraBrowser;
        private System.Windows.Forms.NotifyIcon notifyIcon;
        private System.Windows.Forms.ContextMenuStrip contextMenu;
        private System.Windows.Forms.ToolStripMenuItem playPauseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nextTrackToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem likeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dislikeToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem hideShowPlayerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem log;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem ResetToolStripMenuItem;
    }
}

