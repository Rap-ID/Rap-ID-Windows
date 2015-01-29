namespace WiAuth.Debug
{
    partial class DebugBroadcasting
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
            this.receiver.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.startButton = new System.Windows.Forms.Button();
            this.ipListBox = new System.Windows.Forms.ListBox();
            this.stopButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // startButton
            // 
            this.startButton.Location = new System.Drawing.Point(13, 13);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(119, 23);
            this.startButton.TabIndex = 0;
            this.startButton.Text = "startReceiver";
            this.startButton.UseVisualStyleBackColor = true;
            this.startButton.Click += new System.EventHandler(this.startButton_Click);
            // 
            // ipListBox
            // 
            this.ipListBox.FormattingEnabled = true;
            this.ipListBox.ItemHeight = 12;
            this.ipListBox.Location = new System.Drawing.Point(13, 43);
            this.ipListBox.Name = "ipListBox";
            this.ipListBox.Size = new System.Drawing.Size(244, 244);
            this.ipListBox.TabIndex = 1;
            // 
            // stopButton
            // 
            this.stopButton.Enabled = false;
            this.stopButton.Location = new System.Drawing.Point(138, 13);
            this.stopButton.Name = "stopButton";
            this.stopButton.Size = new System.Drawing.Size(119, 23);
            this.stopButton.TabIndex = 2;
            this.stopButton.Text = "stopReceiver";
            this.stopButton.UseVisualStyleBackColor = true;
            this.stopButton.Click += new System.EventHandler(this.stopButton_Click);
            // 
            // DebugBroadcasting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(270, 300);
            this.Controls.Add(this.stopButton);
            this.Controls.Add(this.ipListBox);
            this.Controls.Add(this.startButton);
            this.Name = "DebugBroadcasting";
            this.Text = "DebugBroadcasting";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button startButton;
        private System.Windows.Forms.ListBox ipListBox;
        private System.Windows.Forms.Button stopButton;
    }
}