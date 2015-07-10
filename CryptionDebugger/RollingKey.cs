using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RapID.ClassLibrary;

namespace RapID.CryptionDebugger
{
    public partial class RollingKey : Form
    {
        public RollingKey()
        {
            InitializeComponent();
        }

        private void encryptButton_Click(object sender, EventArgs e)
        {
            this.cipherTextBox.Text = Crypt.Encrypt(this.sourceTextBox.Text, Crypt.GenerateKey(this.originalKeyBox.Text));
        }

        private void decryptButton_Click(object sender, EventArgs e)
        {
            this.sourceTextBox.Text = Crypt.Decrypt(this.cipherTextBox.Text, Crypt.GenerateKey(this.originalKeyBox.Text));
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            this.keyBox.Text = Crypt.GenerateKey(this.originalKeyBox.Text);
        }
    }
}
