namespace WiAuth.Debug
{
    partial class MainForm
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
            this.broadcastingButton = new System.Windows.Forms.Button();
            this.tcpButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // broadcastingButton
            // 
            this.broadcastingButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.broadcastingButton.Location = new System.Drawing.Point(13, 13);
            this.broadcastingButton.Name = "broadcastingButton";
            this.broadcastingButton.Size = new System.Drawing.Size(259, 23);
            this.broadcastingButton.TabIndex = 0;
            this.broadcastingButton.Text = "broadcasting";
            this.broadcastingButton.UseVisualStyleBackColor = true;
            this.broadcastingButton.Click += new System.EventHandler(this.broadcastingButton_Click);
            // 
            // tcpButton
            // 
            this.tcpButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tcpButton.Location = new System.Drawing.Point(13, 42);
            this.tcpButton.Name = "tcpButton";
            this.tcpButton.Size = new System.Drawing.Size(259, 23);
            this.tcpButton.TabIndex = 1;
            this.tcpButton.Text = "TCP";
            this.tcpButton.UseVisualStyleBackColor = true;
            this.tcpButton.Click += new System.EventHandler(this.tcpButton_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.tcpButton);
            this.Controls.Add(this.broadcastingButton);
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button broadcastingButton;
        private System.Windows.Forms.Button tcpButton;
    }
}