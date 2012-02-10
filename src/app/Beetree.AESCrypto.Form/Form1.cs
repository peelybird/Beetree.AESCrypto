using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Beetree.AESCrypto.Frontend
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // save a new private encryption key to file
            var privateKey = SimpleAES.GenerateEncryptionKey();
            // save a new shared IV to a file
            var sharedIV = SimpleAES.GenerateEncryptionVector();

            SaveBytesToFile(privateKey, "Save the private key file", "key.txt");

            SaveBytesToFile(sharedIV, "Save the shared IV file", "iv.txt");

        }

        private void SaveBytesToFile(byte[] privateKey, string dialogPrompt, string fileName)
        {
            var saveDialog = new SaveFileDialog() { FileName = fileName, Title = dialogPrompt };
            var dialogResult = saveDialog.ShowDialog();

            // write the Private Key to file
            var file = File.Create(saveDialog.FileName, privateKey.Length, FileOptions.None);
            file.Write(privateKey, 0, privateKey.Length);
            file.Close();
        }
    }
}
