namespace PandoraKeys
{
   partial class AboutForm
   {
      /// <summary>
      /// Required designer variable.
      /// </summary>
      private System.ComponentModel.IContainer components = null;

      /// <summary>
      /// Clean up any resources being used.
      /// </summary>
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
         this.labelProductName = new System.Windows.Forms.Label();
         this.labelVersion = new System.Windows.Forms.Label();
         this.labelCopyright = new System.Windows.Forms.Label();
         this.okButton = new System.Windows.Forms.Button();
         this.FamFamLinkLabel = new System.Windows.Forms.LinkLabel();
         this.ContributeLinkLabel = new System.Windows.Forms.LinkLabel();
         this.ContributeTextLbl = new System.Windows.Forms.Label();
         this.pictureBox1 = new System.Windows.Forms.PictureBox();
         this.pictureBox2 = new System.Windows.Forms.PictureBox();
         this.DonateLinkLabel = new System.Windows.Forms.LinkLabel();
         this.DonationTextLbl = new System.Windows.Forms.Label();
         this.labelCompanyName = new System.Windows.Forms.LinkLabel();
         this.tabControl1 = new System.Windows.Forms.TabControl();
         this.AboutTab1 = new System.Windows.Forms.TabPage();
         this.AboutTab2 = new System.Windows.Forms.TabPage();
         this.linkLabel1 = new System.Windows.Forms.LinkLabel();
         this.label1 = new System.Windows.Forms.Label();
         ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
         this.tabControl1.SuspendLayout();
         this.AboutTab1.SuspendLayout();
         this.AboutTab2.SuspendLayout();
         this.SuspendLayout();
         // 
         // labelProductName
         // 
         this.labelProductName.AutoSize = true;
         this.labelProductName.Location = new System.Drawing.Point(9, 14);
         this.labelProductName.Margin = new System.Windows.Forms.Padding(6, 0, 3, 0);
         this.labelProductName.MaximumSize = new System.Drawing.Size(500, 17);
         this.labelProductName.Name = "labelProductName";
         this.labelProductName.Size = new System.Drawing.Size(75, 13);
         this.labelProductName.TabIndex = 19;
         this.labelProductName.Text = "Product Name";
         this.labelProductName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
         // 
         // labelVersion
         // 
         this.labelVersion.AutoSize = true;
         this.labelVersion.Location = new System.Drawing.Point(9, 30);
         this.labelVersion.Margin = new System.Windows.Forms.Padding(6, 0, 3, 0);
         this.labelVersion.MaximumSize = new System.Drawing.Size(0, 17);
         this.labelVersion.MinimumSize = new System.Drawing.Size(100, 20);
         this.labelVersion.Name = "labelVersion";
         this.labelVersion.Size = new System.Drawing.Size(100, 20);
         this.labelVersion.TabIndex = 0;
         this.labelVersion.Text = "Version";
         this.labelVersion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
         // 
         // labelCopyright
         // 
         this.labelCopyright.AutoSize = true;
         this.labelCopyright.Location = new System.Drawing.Point(9, 69);
         this.labelCopyright.Margin = new System.Windows.Forms.Padding(6, 0, 3, 0);
         this.labelCopyright.MaximumSize = new System.Drawing.Size(0, 17);
         this.labelCopyright.MinimumSize = new System.Drawing.Size(100, 20);
         this.labelCopyright.Name = "labelCopyright";
         this.labelCopyright.Size = new System.Drawing.Size(100, 20);
         this.labelCopyright.TabIndex = 21;
         this.labelCopyright.Text = "Copyright";
         this.labelCopyright.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
         // 
         // okButton
         // 
         this.okButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
         this.okButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
         this.okButton.Location = new System.Drawing.Point(452, 311);
         this.okButton.Name = "okButton";
         this.okButton.Size = new System.Drawing.Size(75, 21);
         this.okButton.TabIndex = 24;
         this.okButton.Text = "&OK";
         // 
         // FamFamLinkLabel
         // 
         this.FamFamLinkLabel.AutoSize = true;
         this.FamFamLinkLabel.Location = new System.Drawing.Point(9, 102);
         this.FamFamLinkLabel.Name = "FamFamLinkLabel";
         this.FamFamLinkLabel.Size = new System.Drawing.Size(191, 13);
         this.FamFamLinkLabel.TabIndex = 25;
         this.FamFamLinkLabel.TabStop = true;
         this.FamFamLinkLabel.Text = "Icons from http://www.famfamfam.com";
         this.FamFamLinkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.FamFamLinkLabelClicked);
         // 
         // ContributeLinkLabel
         // 
         this.ContributeLinkLabel.AutoSize = true;
         this.ContributeLinkLabel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
         this.ContributeLinkLabel.Location = new System.Drawing.Point(36, 134);
         this.ContributeLinkLabel.MinimumSize = new System.Drawing.Size(100, 0);
         this.ContributeLinkLabel.Name = "ContributeLinkLabel";
         this.ContributeLinkLabel.Size = new System.Drawing.Size(100, 13);
         this.ContributeLinkLabel.TabIndex = 26;
         this.ContributeLinkLabel.TabStop = true;
         this.ContributeLinkLabel.Text = "Contribute";
         this.ContributeLinkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.ContribueLabelClicked);
         // 
         // ContributeTextLbl
         // 
         this.ContributeTextLbl.AutoSize = true;
         this.ContributeTextLbl.Location = new System.Drawing.Point(9, 159);
         this.ContributeTextLbl.Name = "ContributeTextLbl";
         this.ContributeTextLbl.Size = new System.Drawing.Size(363, 13);
         this.ContributeTextLbl.TabIndex = 27;
         this.ContributeTextLbl.Text = "Pandora Keys is open source! We invite you to come make it better with us.";
         // 
         // pictureBox1
         // 
         this.pictureBox1.Image = global::PandoraKeys.Properties.Resources.application_osx_terminal;
         this.pictureBox1.Location = new System.Drawing.Point(12, 134);
         this.pictureBox1.Name = "pictureBox1";
         this.pictureBox1.Size = new System.Drawing.Size(18, 20);
         this.pictureBox1.TabIndex = 28;
         this.pictureBox1.TabStop = false;
         // 
         // pictureBox2
         // 
         this.pictureBox2.Image = global::PandoraKeys.Properties.Resources.money;
         this.pictureBox2.Location = new System.Drawing.Point(12, 182);
         this.pictureBox2.Name = "pictureBox2";
         this.pictureBox2.Size = new System.Drawing.Size(18, 20);
         this.pictureBox2.TabIndex = 29;
         this.pictureBox2.TabStop = false;
         // 
         // DonateLinkLabel
         // 
         this.DonateLinkLabel.AutoSize = true;
         this.DonateLinkLabel.Location = new System.Drawing.Point(36, 182);
         this.DonateLinkLabel.Name = "DonateLinkLabel";
         this.DonateLinkLabel.Size = new System.Drawing.Size(42, 13);
         this.DonateLinkLabel.TabIndex = 30;
         this.DonateLinkLabel.TabStop = true;
         this.DonateLinkLabel.Text = "Donate";
         this.DonateLinkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.DonateLinkLabelClicked);
         // 
         // DonationTextLbl
         // 
         this.DonationTextLbl.AutoSize = true;
         this.DonationTextLbl.Location = new System.Drawing.Point(9, 205);
         this.DonationTextLbl.Name = "DonationTextLbl";
         this.DonationTextLbl.Size = new System.Drawing.Size(386, 13);
         this.DonationTextLbl.TabIndex = 31;
         this.DonationTextLbl.Text = "If you find this application useful please consider supporting further developmen" +
             "t.";
         // 
         // labelCompanyName
         // 
         this.labelCompanyName.AutoSize = true;
         this.labelCompanyName.Location = new System.Drawing.Point(9, 53);
         this.labelCompanyName.Name = "labelCompanyName";
         this.labelCompanyName.Size = new System.Drawing.Size(77, 13);
         this.labelCompanyName.TabIndex = 32;
         this.labelCompanyName.TabStop = true;
         this.labelCompanyName.Text = "CompanyNane";
         this.labelCompanyName.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.CompanyLabelClicked);
         // 
         // tabControl1
         // 
         this.tabControl1.Controls.Add(this.AboutTab1);
         this.tabControl1.Controls.Add(this.AboutTab2);
         this.tabControl1.Dock = System.Windows.Forms.DockStyle.Top;
         this.tabControl1.Location = new System.Drawing.Point(9, 9);
         this.tabControl1.Name = "tabControl1";
         this.tabControl1.SelectedIndex = 0;
         this.tabControl1.Size = new System.Drawing.Size(521, 296);
         this.tabControl1.TabIndex = 33;
         // 
         // AboutTab1
         // 
         this.AboutTab1.Controls.Add(this.labelProductName);
         this.AboutTab1.Controls.Add(this.labelCompanyName);
         this.AboutTab1.Controls.Add(this.labelVersion);
         this.AboutTab1.Controls.Add(this.DonationTextLbl);
         this.AboutTab1.Controls.Add(this.labelCopyright);
         this.AboutTab1.Controls.Add(this.DonateLinkLabel);
         this.AboutTab1.Controls.Add(this.FamFamLinkLabel);
         this.AboutTab1.Controls.Add(this.pictureBox2);
         this.AboutTab1.Controls.Add(this.ContributeLinkLabel);
         this.AboutTab1.Controls.Add(this.pictureBox1);
         this.AboutTab1.Controls.Add(this.ContributeTextLbl);
         this.AboutTab1.Location = new System.Drawing.Point(4, 22);
         this.AboutTab1.Name = "AboutTab1";
         this.AboutTab1.Padding = new System.Windows.Forms.Padding(3);
         this.AboutTab1.Size = new System.Drawing.Size(513, 270);
         this.AboutTab1.TabIndex = 0;
         this.AboutTab1.Text = "About";
         this.AboutTab1.UseVisualStyleBackColor = true;
         // 
         // AboutTab2
         // 
         this.AboutTab2.Controls.Add(this.label1);
         this.AboutTab2.Controls.Add(this.linkLabel1);
         this.AboutTab2.Location = new System.Drawing.Point(4, 22);
         this.AboutTab2.Name = "AboutTab2";
         this.AboutTab2.Padding = new System.Windows.Forms.Padding(3);
         this.AboutTab2.Size = new System.Drawing.Size(513, 270);
         this.AboutTab2.TabIndex = 1;
         this.AboutTab2.Text = "Contributors";
         this.AboutTab2.UseVisualStyleBackColor = true;
         // 
         // linkLabel1
         // 
         this.linkLabel1.AutoSize = true;
         this.linkLabel1.Location = new System.Drawing.Point(6, 17);
         this.linkLabel1.Name = "linkLabel1";
         this.linkLabel1.Size = new System.Drawing.Size(141, 13);
         this.linkLabel1.TabIndex = 0;
         this.linkLabel1.TabStop = true;
         this.linkLabel1.Text = "Samuel Haddad - Developer";
         this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.SamuelHaddadLabelClicked);
         // 
         // label1
         // 
         this.label1.AutoSize = true;
         this.label1.Location = new System.Drawing.Point(3, 39);
         this.label1.Name = "label1";
         this.label1.Size = new System.Drawing.Size(87, 13);
         this.label1.TabIndex = 1;
         this.label1.Text = " David Bullington";
         // 
         // AboutForm
         // 
         this.AcceptButton = this.okButton;
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(539, 344);
         this.Controls.Add(this.tabControl1);
         this.Controls.Add(this.okButton);
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
         this.MaximizeBox = false;
         this.MinimizeBox = false;
         this.Name = "AboutForm";
         this.Padding = new System.Windows.Forms.Padding(9);
         this.ShowIcon = false;
         this.ShowInTaskbar = false;
         this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
         this.Text = "About Pandora Keys";
         ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
         this.tabControl1.ResumeLayout(false);
         this.AboutTab1.ResumeLayout(false);
         this.AboutTab1.PerformLayout();
         this.AboutTab2.ResumeLayout(false);
         this.AboutTab2.PerformLayout();
         this.ResumeLayout(false);

      }

      #endregion

      private System.Windows.Forms.Label labelProductName;
      private System.Windows.Forms.Label labelVersion;
      private System.Windows.Forms.Label labelCopyright;
      private System.Windows.Forms.Button okButton;
      private System.Windows.Forms.LinkLabel FamFamLinkLabel;
      private System.Windows.Forms.LinkLabel ContributeLinkLabel;
      private System.Windows.Forms.Label ContributeTextLbl;
      private System.Windows.Forms.PictureBox pictureBox1;
      private System.Windows.Forms.PictureBox pictureBox2;
      private System.Windows.Forms.LinkLabel DonateLinkLabel;
      private System.Windows.Forms.Label DonationTextLbl;
      private System.Windows.Forms.LinkLabel labelCompanyName;
      private System.Windows.Forms.TabControl tabControl1;
      private System.Windows.Forms.TabPage AboutTab1;
      private System.Windows.Forms.TabPage AboutTab2;
      private System.Windows.Forms.LinkLabel linkLabel1;
      private System.Windows.Forms.Label label1;
   }
}
