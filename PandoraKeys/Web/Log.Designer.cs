namespace PandoraKeys
{
    partial class Log
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
            this.textlog = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // textlog
            // 
            this.textlog.Location = new System.Drawing.Point(2, 0);
            this.textlog.Name = "textlog";
            this.textlog.Size = new System.Drawing.Size(737, 419);
            this.textlog.TabIndex = 0;
            this.textlog.Text = "Log";
            // 
            // Log
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(737, 420);
            this.Controls.Add(this.textlog);
            this.Name = "Log";
            this.Text = "Log";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Log_FormClosed);
            this.Resize += new System.EventHandler(this.Log_Resize);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox textlog;
    }
}