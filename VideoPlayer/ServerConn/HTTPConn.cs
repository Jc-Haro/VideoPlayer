using AxWMPLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoPlayer.ServerConn
{
    public class HTTPConn
    {

        public void SetVideo(AxWindowsMediaPlayer videoPlayer, string url)
        {
            videoPlayer.URL = url;

            videoPlayer.Ctlcontrols.play();
        }
    }
}
