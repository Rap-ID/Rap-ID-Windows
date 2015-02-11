namespace WiAuth.Installer
{
    partial class Install
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
            this.insButton = new System.Windows.Forms.Button();
            this.uninsButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.dirBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // insButton
            // 
            this.insButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.insButton.Location = new System.Drawing.Point(12, 47);
            this.insButton.Name = "insButton";
            this.insButton.Size = new System.Drawing.Size(107, 40);
            this.insButton.TabIndex = 0;
            this.insButton.Text = "安装";
            this.insButton.UseVisualStyleBackColor = true;
            this.insButton.Click += new System.EventHandler(this.insButton_Click);
            // 
            // uninsButton
            // 
            this.uninsButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.uninsButton.Location = new System.Drawing.Point(125, 47);
            this.uninsButton.Name = "uninsButton";
            this.uninsButton.Size = new System.Drawing.Size(111, 40);
            this.uninsButton.TabIndex = 1;
            this.uninsButton.Text = "卸载";
            this.uninsButton.UseVisualStyleBackColor = true;
            this.uninsButton.Click += new System.EventHandler(this.uninsButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 21);
            this.label1.TabIndex = 2;
            this.label1.Text = "目录";
            // 
            // dirBox
            // 
            this.dirBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dirBox.Location = new System.Drawing.Point(73, 12);
            this.dirBox.Name = "dirBox";
            this.dirBox.Size = new System.Drawing.Size(321, 29);
            this.dirBox.TabIndex = 3;
            // 
            // Install
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(406, 99);
            this.Controls.Add(this.dirBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.uninsButton);
            this.Controls.Add(this.insButton);
            this.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "Install";
            this.Text = "WiAuth安装程序";
            this.Load += new System.EventHandler(this.Install_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button insButton;
        private System.Windows.Forms.Button uninsButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox dirBox;
    }
}