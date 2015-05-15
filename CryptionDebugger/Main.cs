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

namespace RapID.Debug.Cryption
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void encryptButton_Click(object sender, EventArgs e)
        {
            cipherTextBox.Text = Crypt.Encrypt(sourceTextBox.Text);
        }

        private void decryptButton_Click(object sender, EventArgs e)
        {
            sourceTextBox.Text = Crypt.Decrypt(cipherTextBox.Text);
        }
    }
}
