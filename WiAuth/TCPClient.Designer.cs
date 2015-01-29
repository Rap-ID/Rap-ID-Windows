namespace WiAuth.Debug
{
    partial class TCPClient
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
            this.connectButton = new System.Windows.Forms.Button();
            this.ipBox = new System.Windows.Forms.TextBox();
            this.msgBox = new System.Windows.Forms.TextBox();
            this.sendButton = new System.Windows.Forms.Button();
            this.pairButton = new System.Windows.Forms.Button();
            this.passBox = new System.Windows.Forms.TextBox();
            this.pairStateBox = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // connectButton
            // 
            this.connectButton.Location = new System.Drawing.Point(223, 10);
            this.connectButton.Name = "connectButton";
            this.connectButton.Size = new System.Drawing.Size(75, 23);
            this.connectButton.TabIndex = 0;
            this.connectButton.Text = "connect";
            this.connectButton.UseVisualStyleBackColor = true;
            this.connectButton.Click += new System.EventHandler(this.connectButton_Click);
            // 
            // ipBox
            // 
            this.ipBox.Location = new System.Drawing.Point(12, 12);
            this.ipBox.Name = "ipBox";
            this.ipBox.Size = new System.Drawing.Size(205, 21);
            this.ipBox.TabIndex = 1;
            // 
            // msgBox
            // 
            this.msgBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.msgBox.Location = new System.Drawing.Point(12, 39);
            this.msgBox.Multiline = true;
            this.msgBox.Name = "msgBox";
            this.msgBox.Size = new System.Drawing.Size(286, 102);
            this.msgBox.TabIndex = 2;
            // 
            // sendButton
            // 
            this.sendButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.sendButton.Location = new System.Drawing.Point(194, 148);
            this.sendButton.Name = "sendButton";
            this.sendButton.Size = new System.Drawing.Size(103, 30);
            this.sendButton.TabIndex = 3;
            this.sendButton.Text = "send";
            this.sendButton.UseVisualStyleBackColor = true;
            this.sendButton.Click += new System.EventHandler(this.sendButton_Click);
            // 
            // pairButton
            // 
            this.pairButton.Location = new System.Drawing.Point(482, 12);
            this.pairButton.Name = "pairButton";
            this.pairButton.Size = new System.Drawing.Size(76, 23);
            this.pairButton.TabIndex = 4;
            this.pairButton.Text = "send pair";
            this.pairButton.UseVisualStyleBackColor = true;
            this.pairButton.Click += new System.EventHandler(this.pairButton_Click);
            // 
            // passBox
            // 
            this.passBox.Location = new System.Drawing.Point(305, 13);
            this.passBox.Name = "passBox";
            this.passBox.Size = new System.Drawing.Size(171, 21);
            this.passBox.TabIndex = 5;
            // 
            // pairStateBox
            // 
            this.pairStateBox.AutoSize = true;
            this.pairStateBox.Location = new System.Drawing.Point(305, 39);
            this.pairStateBox.Name = "pairStateBox";
            this.pairStateBox.Size = new System.Drawing.Size(101, 12);
            this.pairStateBox.TabIndex = 6;
            this.pairStateBox.Text = "no pair req sent";
            // 
            // TCPClient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(570, 190);
            this.Controls.Add(this.pairStateBox);
            this.Controls.Add(this.passBox);
            this.Controls.Add(this.pairButton);
            this.Controls.Add(this.sendButton);
            this.Controls.Add(this.msgBox);
            this.Controls.Add(this.ipBox);
            this.Controls.Add(this.connectButton);
            this.Name = "TCPClient";
            this.Text = "TCPClient";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button connectButton;
        private System.Windows.Forms.TextBox ipBox;
        private System.Windows.Forms.TextBox msgBox;
        private System.Windows.Forms.Button sendButton;
        private System.Windows.Forms.Button pairButton;
        private System.Windows.Forms.TextBox passBox;
        private System.Windows.Forms.Label pairStateBox;
    }
}