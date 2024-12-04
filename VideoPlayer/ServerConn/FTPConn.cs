using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Data.SqlClient;
using System.Reflection;


namespace VideoPlayer.FTPConn
{
    public class FTPConnection
    {
        public class VideoInformation
        {
            public string Title { get; set; }
            public string Url { get; set; }
        }

        List<VideoInformation> videos;

        public void GetVideosInfo()
        {

            videos = new List<VideoInformation>();
            string connData = "Server=localhost;Database=videofilesdb;User id=root;Password=;";
            string query = "SELECT Title, Url FROM videofiles;";
            MySqlConnection connection = new MySqlConnection(connData);
            MySqlCommand result = new MySqlCommand(query, connection);

            try
            {
                connection.Open();
                MySqlDataReader reader = result.ExecuteReader();

                while (reader.Read())
                {
                    videos.Add(new VideoInformation
                    {
                        Title = reader.GetString(0),
                        Url = reader.GetString(1),
                    });
                }
                Console.WriteLine("videos " + videos[0].Title);
            }
            catch (Exception ex) 
            {
                MessageBox.Show(ex.Message, "error insesperado", MessageBoxButtons.OK);
            }

        }

        public void DataBase()
        {
            string conexionString = "Server=localhost;Database=videofilesdb;User id=root;Password=;";
            using (MySqlConnection conexion = new MySqlConnection(conexionString))
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
