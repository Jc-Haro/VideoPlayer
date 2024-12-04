using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using VideoPlayer.FTPConn;
using System.Threading;

namespace VideoPlayer
{
    public partial class Form1 : Form
    {
        private FTPConnection fTPConn = new FTPConnection();
        private FlowLayoutPanel flowLayoutPanel;
        string videoToDowload;
        Thread hilo1;
        Thread hilo2;
        Thread hilo3;
        public Form1()
        {
            InitializeComponent();

            // Inicializar el FlowLayoutPanel
            InitializeFlowLayoutPanel();
            ThreadStart dataThead  = new ThreadStart(fTPConn.DataBase);
            hilo1 = new Thread(dataThead);
            hilo1.Start();


            // Agregar un contenedor inicial como ejemplo
            var container = new ImageTextContainer("C:\\ftp\\faust.jpg", "hola 1","musculoso.mp4");
            var container2 = new ImageTextContainer("C:\\ftp\\roland.jpg", "hola 2","ocellot.mp4");
            var container3 = new ImageTextContainer("C:\\ftp\\rodion.jpg", "hola 3","transition.mp4");
            var container4 = new ImageTextContainer("C:\\ftp\\ryoshu.jpg", "hola 4", "plinplon.mp4");
            AddImageTextContainer(container);
            AddImageTextContainer(container2);
            AddImageTextContainer(container3);
            AddImageTextContainer(container4);
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
                ftpUrl.Text = container.ChangeDowloadText();
                videoPlayer.URL = container.ChangeVideoURL();
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
                    Thread uploadThead = new Thread(() => fTPConn.UploadFile(url, selectedFile));
                    uploadThead.Start();
                    //fTPConn.UploadFile(url, selectedFile);

                    // Agregar un nuevo contenedor al FlowLayoutPanel con la imagen subida
                    //var container = new ImageTextContainer(selectedFile, "Archivo Subido", ftpUrl.Text);
                    // AddImageTextContainer(container);
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
                Thread downloadThead = new Thread(() => fTPConn.DownloadFile(url, downloadPath));
                //hilo3 = new Thread(downloadThead);
                downloadThead.Start();
            }
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
