namespace RapID.CryptionDebugger
{
    partial class Main
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
            this.encryptButton = new System.Windows.Forms.Button();
            this.decryptButton = new System.Windows.Forms.Button();
            this.sourceTextBox = new System.Windows.Forms.TextBox();
            this.cipherTextBox = new System.Windows.Forms.TextBox();
            this.showRollingKeyFormButton = new System.Windows.Forms.Button();
            this.keyBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // encryptButton
            // 
            this.encryptButton.Location = new System.Drawing.Point(197, 39);
            this.encryptButton.Name = "encryptButton";
            this.encryptButton.Size = new System.Drawing.Size(75, 40);
            this.encryptButton.TabIndex = 0;
            this.encryptButton.Text = "Encrypt";
            this.encryptButton.UseVisualStyleBackColor = true;
            this.encryptButton.Click += new System.EventHandler(this.encryptButton_Click);
            // 
            // decryptButton
            // 
            this.decryptButton.Location = new System.Drawing.Point(197, 85);
            this.decryptButton.Name = "decryptButton";
            this.decryptButton.Size = new System.Drawing.Size(75, 40);
            this.decryptButton.TabIndex = 1;
            this.decryptButton.Text = "Decrypt";
            this.decryptButton.UseVisualStyleBackColor = true;
            this.decryptButton.Click += new System.EventHandler(this.decryptButton_Click);
            // 
            // sourceTextBox
            // 
            this.sourceTextBox.Location = new System.Drawing.Point(12, 50);
            this.sourceTextBox.Name = "sourceTextBox";
            this.sourceTextBox.Size = new System.Drawing.Size(179, 21);
            this.sourceTextBox.TabIndex = 2;
            // 
            // cipherTextBox
            // 
            this.cipherTextBox.Location = new System.Drawing.Point(12, 96);
            this.cipherTextBox.Name = "cipherTextBox";
            this.cipherTextBox.Size = new System.Drawing.Size(179, 21);
            this.cipherTextBox.TabIndex = 3;
            // 
            // showRollingKeyFormButton
            // 
            this.showRollingKeyFormButton.Location = new System.Drawing.Point(12, 131);
            this.showRollingKeyFormButton.Name = "showRollingKeyFormButton";
            this.showRollingKeyFormButton.Size = new System.Drawing.Size(260, 21);
            this.showRollingKeyFormButton.TabIndex = 4;
            this.showRollingKeyFormButton.Text = "Show Rolling Key Form";
            this.showRollingKeyFormButton.UseVisualStyleBackColor = true;
            this.showRollingKeyFormButton.Click += new System.EventHandler(this.showRollingKeyFormButton_Click);
            // 
            // keyBox
            // 
            this.keyBox.Location = new System.Drawing.Point(12, 12);
            this.keyBox.Name = "keyBox";
            this.keyBox.Size = new System.Drawing.Size(260, 21);
            this.keyBox.TabIndex = 5;
            this.keyBox.Text = "RapIDK01";
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 165);
            this.Controls.Add(this.keyBox);
            this.Controls.Add(this.showRollingKeyFormButton);
            this.Controls.Add(this.cipherTextBox);
            this.Controls.Add(this.sourceTextBox);
            this.Controls.Add(this.decryptButton);
            this.Controls.Add(this.encryptButton);
            this.Name = "Main";
            this.Text = "Main";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button encryptButton;
        private System.Windows.Forms.Button decryptButton;
        private System.Windows.Forms.TextBox sourceTextBox;
        private System.Windows.Forms.TextBox cipherTextBox;
        private System.Windows.Forms.Button showRollingKeyFormButton;
        private System.Windows.Forms.TextBox keyBox;
    }
}