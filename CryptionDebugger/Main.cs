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
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void encryptButton_Click(object sender, EventArgs e)
        {
            cipherTextBox.Text = Crypt.Encrypt(sourceTextBox.Text, keyBox.Text);
        }

        private void decryptButton_Click(object sender, EventArgs e)
        {
            sourceTextBox.Text = Crypt.Decrypt(cipherTextBox.Text, keyBox.Text);
        }

        private void showRollingKeyFormButton_Click(object sender, EventArgs e)
        {
            var frm = new RollingKey();
            frm.ShowDialog();
        }
    }
}
