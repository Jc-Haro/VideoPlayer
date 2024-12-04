using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using System.Windows.Forms;
using System.Data.SqlClient;



namespace VideoPlayer.FTPConn
{
    public class FTPConnection
    {
        public void DataBase()
        {
            string conexionString = "Server=localhost;Database=videofilesdb;User id=root;Password=;";
            using (SqlConnection conexion = new SqlConnection(conexionString))
            try
            {
                conexion.Open();
                MessageBox.Show("conecxion correcta","conecxioncorrecta",MessageBoxButtons.OK);
            }
            catch (Exception ex) 
            {
                MessageBox.Show(ex.Message,"error insesperado",MessageBoxButtons.OK);
            }
        }
        public void UploadFile(string url, string filePath)
        {

            try
            {
                FtpWebRequest request = (FtpWebRequest)WebRequest.Create(url + Path.GetFileName(filePath));
                request.Method = WebRequestMethods.Ftp.UploadFile;
                request.Credentials = new NetworkCredential("ftpuser", "1234");
                request.UseBinary = true;

                byte[] fileContent = File.ReadAllBytes(filePath);
                request.ContentLength = fileContent.Length;

                using (Stream requestStream = request.GetRequestStream())
                {
                    requestStream.Write(fileContent, 0, fileContent.Length);
                }
            }
            catch(Exception ex) 
            {
                Console.WriteLine("Error while uploading: " + ex.Message);
            }
        }
        public void DownloadFile(string url, string downloadPath) 
        {
            try
            {
                FtpWebRequest request = (FtpWebRequest)WebRequest.Create(url);
                request.Method = WebRequestMethods.Ftp.DownloadFile;
                request.Credentials = new NetworkCredential("ftpuser", "1234");

                FtpWebResponse ftpWebResponse = (FtpWebResponse)request.GetResponse();
                Stream responseStream = ftpWebResponse.GetResponseStream();
                FileStream fileStream = new FileStream(downloadPath, FileMode.Create);
                responseStream.CopyTo(fileStream);
            }
            catch(Exception ex)
            {
                Console.WriteLine("Error while uploading: " + ex.Message);
            }
        }

        public bool IsValidVideoFile(string fileName)
        {
            string[] validExtensions = { ".mp4", ".avi", ".mkv", ".mov", ".flv", ".wmv" };
            string extension = Path.GetExtension(fileName).ToLower();
            return Array.Exists(validExtensions, ext => ext == extension);
        }
    }
}
