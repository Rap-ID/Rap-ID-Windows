using MaterialSkin.Controls;

namespace RapID.Installer
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
            this.insButton = new MaterialSkin.Controls.MaterialRaisedButton();
            this.uninsButton = new MaterialSkin.Controls.MaterialFlatButton();
            this.label1 = new MaterialSkin.Controls.MaterialLabel();
            this.dirBox = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.SuspendLayout();
            // 
            // insButton
            // 
            this.insButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.insButton.Depth = 0;
            this.insButton.Location = new System.Drawing.Point(12, 119);
            this.insButton.MouseState = MaterialSkin.MouseState.HOVER;
            this.insButton.Name = "insButton";
            this.insButton.Primary = true;
            this.insButton.Size = new System.Drawing.Size(46, 36);
            this.insButton.TabIndex = 0;
            this.insButton.Text = "安装";
            this.insButton.UseVisualStyleBackColor = true;
            this.insButton.Click += new System.EventHandler(this.insButton_Click);
            // 
            // uninsButton
            // 
            this.uninsButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.uninsButton.AutoSize = true;
            this.uninsButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.uninsButton.Depth = 0;
            this.uninsButton.Location = new System.Drawing.Point(65, 119);
            this.uninsButton.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.uninsButton.MouseState = MaterialSkin.MouseState.HOVER;
            this.uninsButton.Name = "uninsButton";
            this.uninsButton.Primary = false;
            this.uninsButton.Size = new System.Drawing.Size(42, 36);
            this.uninsButton.TabIndex = 1;
            this.uninsButton.Text = "卸载";
            this.uninsButton.UseVisualStyleBackColor = true;
            this.uninsButton.Click += new System.EventHandler(this.uninsButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Depth = 0;
            this.label1.Font = new System.Drawing.Font("Roboto", 11F);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label1.Location = new System.Drawing.Point(12, 80);
            this.label1.MouseState = MaterialSkin.MouseState.HOVER;
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 19);
            this.label1.TabIndex = 2;
            this.label1.Text = "目录";
            // 
            // dirBox
            // 
            this.dirBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dirBox.Depth = 0;
            this.dirBox.Hint = "";
            this.dirBox.Location = new System.Drawing.Point(73, 77);
            this.dirBox.MouseState = MaterialSkin.MouseState.HOVER;
            this.dirBox.Name = "dirBox";
            this.dirBox.PasswordChar = '\0';
            this.dirBox.SelectedText = "";
            this.dirBox.SelectionLength = 0;
            this.dirBox.SelectionStart = 0;
            this.dirBox.Size = new System.Drawing.Size(254, 23);
            this.dirBox.TabIndex = 3;
            this.dirBox.UseSystemPasswordChar = false;
            // 
            // Install
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(339, 167);
            this.Controls.Add(this.dirBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.uninsButton);
            this.Controls.Add(this.insButton);
            this.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "Install";
            this.Text = "Rap-ID安装程序";
            this.Load += new System.EventHandler(this.Install_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MaterialRaisedButton insButton;
        private MaterialFlatButton uninsButton;
        private MaterialLabel label1;
        private MaterialSingleLineTextField dirBox;
    }
}