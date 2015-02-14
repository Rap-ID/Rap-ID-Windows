namespace WiAuth.ClassLibrary.Forms
{
    partial class Error
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Error));
            this.messageBox = new System.Windows.Forms.RichTextBox();
            this.okButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // messageBox
            // 
            this.messageBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.messageBox.Location = new System.Drawing.Point(13, 13);
            this.messageBox.Name = "messageBox";
            this.messageBox.Size = new System.Drawing.Size(384, 171);
            this.messageBox.TabIndex = 0;
            this.messageBox.Text = "WiAuth遇到问题需要关闭，对此带来的不便我们深表歉意。\n程序已经记录下错误发生时的日志信息，您可以手动将其发送到team@cotr.me来帮助我们修复问题。\n" +
    "日志存放在：";
            // 
            // okButton
            // 
            this.okButton.Location = new System.Drawing.Point(13, 191);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(384, 44);
            this.okButton.TabIndex = 1;
            this.okButton.Text = "OK";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // Error
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(409, 247);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.messageBox);
            this.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.Name = "Error";
            this.Text = "Error - WiAuth";
            this.Load += new System.EventHandler(this.Error_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox messageBox;
        private System.Windows.Forms.Button okButton;
    }
}