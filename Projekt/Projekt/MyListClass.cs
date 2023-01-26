using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace Projekt
{
    public class MyListClass
    {
        public int id { get; set; }
        public string name { get; set; }
        public string type { get; set; }
        public string episodeProgress { get; set; }
        public int score { get; set; }
        public BitmapImage picture {get; set;}

        public MyListClass()
        {
            this.id= 0;
            this.name = string.Empty;
            this.type = string.Empty;
            this.episodeProgress = string.Empty;
            this.score = 0;
            picture = new BitmapImage();
        }

        public MyListClass(int id, string name, string type, string episodeProgress, int score, string picture)
        {
            this.id = id;
            this.name = name;
            this.type = type;
            this.episodeProgress = episodeProgress;
            this.score = score;
            this.picture = Base64ToImage(picture);
        }
        public MyListClass(int id, string name, string type, string episodeProgress, int score, BitmapImage picture)
        {
            this.id = id;
            this.name = name;
            this.type = type;
            this.episodeProgress = episodeProgress;
            this.score = score;
            this.picture = picture;
        }

        public MyListClass(MyListClass mlc) 
        {
            this.id =mlc.id;
            this.name = mlc.name;
            this.type = mlc.type;
            this.episodeProgress= mlc.episodeProgress;
            this.score = mlc.score;
            this.picture = mlc.picture;
        }

        private BitmapImage Base64ToImage(string base64image)
        {
            byte[] bytes = Convert.FromBase64String(base64image);
            MemoryStream stream = new MemoryStream(bytes);
            BitmapImage bi = new BitmapImage();
            bi.BeginInit();
            bi.StreamSource = stream;
            bi.EndInit();
            return bi;
        }
    }


}
