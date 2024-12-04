using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using VideoPlayer.FTPConn;

namespace VideoPlayer
{
    public partial class Form1 : Form
    {
        private FTPConnection fTPConn = new FTPConnection();
        private FlowLayoutPanel flowLayoutPanel;

        public Form1()
        {
            InitializeComponent();

            // Inicializar el FlowLayoutPanel
            InitializeFlowLayoutPanel();

            // Agregar un contenedor inicial como ejemplo
            var container = new ImageTextContainer("C:\\ftp\\faust.jpg", "hola 1");
            var container2 = new ImageTextContainer("C:\\ftp\\roland.jpg", "hola 2");
            var container3 = new ImageTextContainer("C:\\ftp\\rodion.jpg", "hola 3");
            AddImageTextContainer(container);
            AddImageTextContainer(container2);
            AddImageTextContainer(container3);
        }

        private void InitializeFlowLayoutPanel()
        {
            // Configurar el FlowLayoutPanel
            flowLayoutPanel = new FlowLayoutPanel
            {
                //Dock = DockStyle.Fill,
                AutoScroll = true, // Habilitar scroll
                FlowDirection = FlowDirection.TopDown, // Alinear los elementos verticalmente
                WrapContents = false, // No permitir contenido fuera del eje vertical
                Location = new Point(100, 100),
            };

            // Agregar el FlowLayoutPanel al formulario
            this.Controls.Add(flowLayoutPanel);
        }

        // Método para agregar un contenedor al FlowLayoutPanel
        private void AddImageTextContainer(ImageTextContainer container)
        {
            container.ContainerClicked += (s, e) =>
            {
                MessageBox.Show($"¡Has hecho clic en: {container.ContainerText}!");
            };

            flowLayoutPanel1.Controls.Add(container);
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

                    // Agregar un nuevo contenedor al FlowLayoutPanel con la imagen subida
                    var container = new ImageTextContainer(selectedFile, "Archivo Subido");
                    AddImageTextContainer(container);
                }
                else
                {
                    MessageBox.Show("Please select a valid file");
                }
            }
        }

        private void buttonDownload_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                string downloadPath = Path.Combine(folderBrowserDialog1.SelectedPath, "downloaded_video.mp4");

                string url = ftpUrl.Text;  // FTP URL
                fTPConn.DownloadFile(url, downloadPath);

                // Agregar un nuevo contenedor al FlowLayoutPanel con la imagen descargada
                var container = new ImageTextContainer(downloadPath, "Archivo Descargado");
                AddImageTextContainer(container);
            }
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
