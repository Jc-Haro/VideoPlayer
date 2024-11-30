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

namespace VideoPlayer
{
    public partial class Form1 : Form
    {
        int mondongocount = 0;
        private static string filePath = AppDomain.CurrentDomain.BaseDirectory + "\\videos.json";


        public Form1()
        {
            InitializeComponent();
            FillVideosBox();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            VideoData videoData = new VideoData("title");
            SaveData data = new SaveData(videoData);
        }

        private void FillVideosBox()
        {
            List<VideoData> list = new List<VideoData>();
            if (File.Exists(filePath))
            {
                GetData data = new GetData();
                string jsonIn = data.GetDataFromFile(filePath);
                list = JsonSerializer.Deserialize<List<VideoData>>(jsonIn);
                for (int i = 0; i < list.Count; i++)
                {
                    textBox1.Text += list[i].Title + " "  + Environment.NewLine;
                    mondongocount++;
                    textBox1.SelectionStart = textBox1.TextLength;
                }
            }
            
        }
    }
}
