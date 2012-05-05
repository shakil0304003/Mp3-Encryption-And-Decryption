using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Mp3_Converter
{
    public partial class Form1 : Form
    {
        private string _filePath = "";
        private string _destinationPath = "";

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            _filePath = openFileDialog1.FileName;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            saveFileDialog1.ShowDialog();
        }

        private void saveFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            _destinationPath = saveFileDialog1.FileName;
            Convert();
        }

        private void Convert()
        {
            byte[] data = File.ReadAllBytes(_filePath);
            data = EncryptionHelper.Encrypt(data);
            File.WriteAllBytes(_destinationPath, data);
            MessageBox.Show("Complete");
        }
    }
}
