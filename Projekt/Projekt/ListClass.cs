using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Projekt
{
    public class ListClass
    {
        public int id { get; set; }
        public string name { get; set; }
        public string type { get; set; }
        public int numberOfEpisodes { get; set; }
        public string producer { get; set; }
        public string genre { get; set; }
        public BitmapImage picture { get; set; }

        public ListClass()
        {
            this.id = 0;
            this.name = string.Empty;
            this.type = string.Empty;
            this.numberOfEpisodes = 0;
            this.producer = string.Empty;
            this.genre = string.Empty;
            this.picture = new BitmapImage();
        }

        public ListClass(int id, string name, string type, int numberOfEpisodes, string producer, string genre, BitmapImage picture)
        {
            this.id = id;
            this.name = name;
            this.type = type;
            this.numberOfEpisodes = numberOfEpisodes;
            this.producer = producer;
            this.genre = genre;
            this.picture = picture;
        }

        public ListClass(int id, string name, string type, int numberOfEpisodes, string producer, string genre, string picture)
        {
            this.id = id;
            this.name = name;
            this.type = type;
            this.numberOfEpisodes = numberOfEpisodes;
            this.producer = producer;
            this.genre = genre;
            this.picture = Base64ToImage(picture);
        }

        public ListClass(ListClass ls)
        { 
            this.id = ls.id;
            this.name = ls.name;
            this.type = ls.type;
            this.numberOfEpisodes = ls.numberOfEpisodes;
            this.producer = ls.producer;
            this.genre = ls.genre;
            this.picture = ls.picture;
        }

        private BitmapImage Base64ToImage(string base64image)
        {
            byte[] bytes = Convert.FromBase64String(base64image);
            MemoryStream stream= new MemoryStream(bytes);
            BitmapImage bi = new BitmapImage();
            bi.BeginInit();
            bi.StreamSource = stream;
            bi.EndInit();
            return bi;
        }
    }
}
