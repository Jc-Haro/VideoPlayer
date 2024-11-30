using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoPlayer
{
    internal class VideoData
    {
        public VideoData(string title)
        {
            Title = title;
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public string Path { get; set; }
    }
}
