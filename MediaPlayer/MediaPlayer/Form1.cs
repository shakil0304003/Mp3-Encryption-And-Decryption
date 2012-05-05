using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WMPLib;
using System.IO;

namespace MediaPlayer
{
    public partial class Form1 : Form
    {
        private WindowsMediaPlayer player = new WindowsMediaPlayer();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            string fileUrl = openFileDialog1.FileName;
            string tempPath = Path.GetDirectoryName(Application.ExecutablePath) + "\\temp.dat";

            if (File.Exists(tempPath))
                File.Delete(tempPath);

            byte[] data = File.ReadAllBytes(fileUrl);
            data = EncryptionHelper.Decrypt(data);
            File.WriteAllBytes(tempPath, data);
            
            player.URL = tempPath;
            player.controls.play();
        }
    }
}
