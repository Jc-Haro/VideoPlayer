using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.Json;


namespace VideoPlayer
{
    internal class SaveData
    {
        private static string filePath = AppDomain.CurrentDomain.BaseDirectory + "\\videos.json";

        public SaveData(VideoData _newEntry) 
        {
            List<VideoData> list = new List<VideoData>();
            if (File.Exists(filePath))
            {
                GetData data = new GetData();
                string jsonIn = data.GetDataFromFile(filePath);
                list = JsonSerializer.Deserialize<List<VideoData>>(jsonIn);
            }
            _newEntry.Id = list.Count;
            _newEntry.Path = list.Count.ToString() + ".mp4";
            list.Add(_newEntry);
            string jsonOut = JsonSerializer.Serialize(list);
            Console.WriteLine(filePath);
            File.WriteAllText(filePath, jsonOut);
        }
    }
}
