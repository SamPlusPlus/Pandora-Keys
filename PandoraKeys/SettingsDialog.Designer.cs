namespace PandoraKeys
{
    partial class SettingsDialog
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
            this.settingsSaveBtn = new System.Windows.Forms.Button();
            this.cancelbtn = new System.Windows.Forms.Button();
            this.KeyboardTab = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.DislikeSet = new System.Windows.Forms.LinkLabel();
            this.LikeSet = new System.Windows.Forms.LinkLabel();
            this.NextTrackSet = new System.Windows.Forms.LinkLabel();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.PlayPauseLabel = new System.Windows.Forms.Label();
            this.NextTrackLabel = new System.Windows.Forms.Label();
            this.LikeLabel = new System.Windows.Forms.Label();
            this.DislikeLabel = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.PlayPauseSet = new System.Windows.Forms.LinkLabel();
            this.SettingsTabControl = new System.Windows.Forms.TabControl();
            this.KeyboardTab.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SettingsTabControl.SuspendLayout();
            this.SuspendLayout();
            // 
            // settingsSaveBtn
            // 
            this.settingsSaveBtn.Location = new System.Drawing.Point(341, 175);
            this.settingsSaveBtn.Name = "settingsSaveBtn";
            this.settingsSaveBtn.Size = new System.Drawing.Size(75, 23);
            this.settingsSaveBtn.TabIndex = 1;
            this.settingsSaveBtn.Text = "Save";
            this.settingsSaveBtn.UseVisualStyleBackColor = true;
            this.settingsSaveBtn.Click += new System.EventHandler(this.settingsSaveBtn_Click);
            // 
            // cancelbtn
            // 
            this.cancelbtn.Location = new System.Drawing.Point(422, 175);
            this.cancelbtn.Name = "cancelbtn";
            this.cancelbtn.Size = new System.Drawing.Size(75, 23);
            this.cancelbtn.TabIndex = 2;
            this.cancelbtn.Text = "Cancel";
            this.cancelbtn.UseVisualStyleBackColor = true;
            this.cancelbtn.Click += new System.EventHandler(this.cancelbtn_Click);
            // 
            // KeyboardTab
            // 
            this.KeyboardTab.Controls.Add(this.tableLayoutPanel1);
            this.KeyboardTab.Location = new System.Drawing.Point(4, 22);
            this.KeyboardTab.Name = "KeyboardTab";
            this.KeyboardTab.Padding = new System.Windows.Forms.Padding(3);
            this.KeyboardTab.Size = new System.Drawing.Size(477, 131);
            this.KeyboardTab.TabIndex = 1;
            this.KeyboardTab.Text = "Keyboard Shortcuts";
            this.KeyboardTab.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Inset;
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 34.03756F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 39.67136F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 26.52582F));
            this.tableLayoutPanel1.Controls.Add(this.DislikeSet, 2, 4);
            this.tableLayoutPanel1.Controls.Add(this.LikeSet, 2, 3);
            this.tableLayoutPanel1.Controls.Add(this.NextTrackSet, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.label6, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label5, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.label4, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.PlayPauseLabel, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.NextTrackLabel, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.LikeLabel, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.DislikeLabel, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.label7, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.label8, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.label9, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.PlayPauseSet, 2, 1);
            this.tableLayoutPanel1.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.FixedSize;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(11, 11);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(460, 112);
            this.tableLayoutPanel1.TabIndex = 6;
            // 
            // DislikeSet
            // 
            this.DislikeSet.AutoSize = true;
            this.DislikeSet.Location = new System.Drawing.Point(340, 90);
            this.DislikeSet.Name = "DislikeSet";
            this.DislikeSet.Size = new System.Drawing.Size(23, 13);
            this.DislikeSet.TabIndex = 18;
            this.DislikeSet.TabStop = true;
            this.DislikeSet.Text = "Set";
            this.DislikeSet.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.DislikeSet_LinkClicked);
            // 
            // LikeSet
            // 
            this.LikeSet.AutoSize = true;
            this.LikeSet.Location = new System.Drawing.Point(340, 68);
            this.LikeSet.Name = "LikeSet";
            this.LikeSet.Size = new System.Drawing.Size(23, 13);
            this.LikeSet.TabIndex = 17;
            this.LikeSet.TabStop = true;
            this.LikeSet.Text = "Set";
            this.LikeSet.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LikeSet_LinkClicked);
            // 
            // NextTrackSet
            // 
            this.NextTrackSet.AutoSize = true;
            this.NextTrackSet.Location = new System.Drawing.Point(340, 46);
            this.NextTrackSet.Name = "NextTrackSet";
            this.NextTrackSet.Size = new System.Drawing.Size(23, 13);
            this.NextTrackSet.TabIndex = 16;
            this.NextTrackSet.TabStop = true;
            this.NextTrackSet.Text = "Set";
            this.NextTrackSet.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.NextTrackSet_LinkClicked);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(5, 24);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 13);
            this.label6.TabIndex = 9;
            this.label6.Text = "Play/Pause ";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(340, 2);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(26, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Set";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(160, 2);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Shortcut";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(5, 2);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Function";
            // 
            // PlayPauseLabel
            // 
            this.PlayPauseLabel.AutoSize = true;
            this.PlayPauseLabel.Location = new System.Drawing.Point(160, 24);
            this.PlayPauseLabel.Name = "PlayPauseLabel";
            this.PlayPauseLabel.Size = new System.Drawing.Size(65, 13);
            this.PlayPauseLabel.TabIndex = 0;
            this.PlayPauseLabel.Text = "Play/Pause ";
            // 
            // NextTrackLabel
            // 
            this.NextTrackLabel.AutoSize = true;
            this.NextTrackLabel.Location = new System.Drawing.Point(160, 46);
            this.NextTrackLabel.Name = "NextTrackLabel";
            this.NextTrackLabel.Size = new System.Drawing.Size(60, 13);
            this.NextTrackLabel.TabIndex = 1;
            this.NextTrackLabel.Text = "Next Track";
            // 
            // LikeLabel
            // 
            this.LikeLabel.AutoSize = true;
            this.LikeLabel.Location = new System.Drawing.Point(160, 68);
            this.LikeLabel.Name = "LikeLabel";
            this.LikeLabel.Size = new System.Drawing.Size(27, 13);
            this.LikeLabel.TabIndex = 2;
            this.LikeLabel.Text = "Like";
            // 
            // DislikeLabel
            // 
            this.DislikeLabel.AutoSize = true;
            this.DislikeLabel.Location = new System.Drawing.Point(160, 90);
            this.DislikeLabel.Name = "DislikeLabel";
            this.DislikeLabel.Size = new System.Drawing.Size(38, 13);
            this.DislikeLabel.TabIndex = 3;
            this.DislikeLabel.Text = "Dislike";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(5, 46);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(60, 13);
            this.label7.TabIndex = 10;
            this.label7.Text = "Next Track";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(5, 68);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(27, 13);
            this.label8.TabIndex = 11;
            this.label8.Text = "Like";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(5, 90);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(38, 13);
            this.label9.TabIndex = 12;
            this.label9.Text = "Dislike";
            // 
            // PlayPauseSet
            // 
            this.PlayPauseSet.AutoSize = true;
            this.PlayPauseSet.Location = new System.Drawing.Point(340, 24);
            this.PlayPauseSet.Name = "PlayPauseSet";
            this.PlayPauseSet.Size = new System.Drawing.Size(23, 13);
            this.PlayPauseSet.TabIndex = 15;
            this.PlayPauseSet.TabStop = true;
            this.PlayPauseSet.Text = "Set";
            this.PlayPauseSet.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.PlayPauseSet_LinkClicked);
            // 
            // SettingsTabControl
            // 
            this.SettingsTabControl.Controls.Add(this.KeyboardTab);
            this.SettingsTabControl.Location = new System.Drawing.Point(12, 12);
            this.SettingsTabControl.Name = "SettingsTabControl";
            this.SettingsTabControl.SelectedIndex = 0;
            this.SettingsTabControl.Size = new System.Drawing.Size(485, 157);
            this.SettingsTabControl.TabIndex = 0;
            // 
            // SettingsDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(506, 209);
            this.Controls.Add(this.cancelbtn);
            this.Controls.Add(this.settingsSaveBtn);
            this.Controls.Add(this.SettingsTabControl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "SettingsDialog";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Settings";
            this.Load += new System.EventHandler(this.SettingsDialog_Load);
            this.KeyboardTab.ResumeLayout(false);
            this.KeyboardTab.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.SettingsTabControl.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button settingsSaveBtn;
        private System.Windows.Forms.Button cancelbtn;
        private System.Windows.Forms.TabPage KeyboardTab;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.LinkLabel DislikeSet;
        private System.Windows.Forms.LinkLabel LikeSet;
        private System.Windows.Forms.LinkLabel NextTrackSet;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label PlayPauseLabel;
        private System.Windows.Forms.Label NextTrackLabel;
        private System.Windows.Forms.Label LikeLabel;
        private System.Windows.Forms.Label DislikeLabel;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.LinkLabel PlayPauseSet;
        private System.Windows.Forms.TabControl SettingsTabControl;
    }
}