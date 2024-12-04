using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;
using VideoPlayer.FTPConn;

namespace VideoPlayer
{
    public partial class Form1 : Form
    {
        private FTPConnection fTPConn = new FTPConnection();

        public Form1()
        {
            InitializeComponent();
            fTPConn.DataBase();

            var container = new ImageTextContainer()
            {
                ContainerImage = Image.FromFile("C:\\ftp\\1729598674043780.jpg"),
                ContainerText = "Texto de ejemplo",
                Location = new Point(50, 50) // Posición en el formulario
            };

            // Manejar el evento de clic
            container.ContainerClicked += (s, e) =>
            {
                MessageBox.Show("Contenedor clickeado!");
            };

            // Agregar el contenedor al formulario
            this.Controls.Add(container);
        }

        private void buttonUpload_Click(object sender, EventArgs e)
        {
            if (openFileDialogFolderPicker.ShowDialog() == DialogResult.OK) 
            {
                string selectedFile = openFileDialogFolderPicker.FileName;
                if (fTPConn.IsValidVideoFile(selectedFile)) 
                {
                    string url = ftpUrl.Text; 
                    fTPConn.UploadFile(url, selectedFile);
                }
                else
                {
                    MessageBox.Show("Please select a valid file");
                }
            }
        }

        private void buttonDownload_Click(object sender, EventArgs e)
        {
            // Open the folder picker dialog
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                string downloadPath = Path.Combine(folderBrowserDialog1.SelectedPath, "downloaded_video.mp4");

                string url = ftpUrl.Text;  // FTP URL
                fTPConn.DownloadFile(url, downloadPath);
            }
        }

    }
}
