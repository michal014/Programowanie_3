using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace Projekt
{
    internal class ShowItemClass
    {
        public int id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public int allscore { get; set; }
        public int numberOfEpisodes { get; set; }
        public int episodeProgress { get; set; }
        public int score { get; set; }
        public string genre { get; set; }
        public string producer { get; set; }
        public bool isAdded { get; set; }
        public BitmapImage picture { get; set; }

        public ShowItemClass()
        {
            this.id= 0;
            this.name = string.Empty;
            this.description = string.Empty;
            this.allscore = 0;
            this.numberOfEpisodes = 0;
            this.episodeProgress = 0;
            this.score = 0;
            this.genre = string.Empty;
            this.producer = string.Empty;
            isAdded= false;
            picture = new BitmapImage();

        }

        public ShowItemClass(int id, string name, string description, int allscore, int numberOfEpisodes,int episodeProgress, int score,string genre,string producer, bool isAdded, BitmapImage picture)
        {
            this.id = id;
            this.name = name;
            this.description = description;
            this.allscore = allscore;
            this.numberOfEpisodes = numberOfEpisodes;
            this.episodeProgress = episodeProgress;
            this.score = score;
            this.genre = genre;
            this.producer = producer;
            this.isAdded = isAdded;
            this.picture = picture;
        }

        public ShowItemClass(int id, string name, string description, int allscore, int numberOfEpisodes, int episodeProgress, int score, string genre, string producer, bool isAdded, string picture)
        {
            this.id = id;
            this.name = name;
            this.description = description;
            this.allscore = allscore;
            this.numberOfEpisodes = numberOfEpisodes;
            this.episodeProgress = episodeProgress;
            this.score = score;
            this.genre = genre;
            this.producer = producer;
            this.isAdded = isAdded;
            this.picture = Base64ToImage(picture);
        }

        public ShowItemClass(ShowItemClass sic)
        {
            this.id = sic.id;
            this.name = sic.name;
            this.description = sic.description;
            this.allscore = sic.allscore;
            this.numberOfEpisodes= sic.numberOfEpisodes;
            this.episodeProgress = sic.episodeProgress;
            this.score = sic.score;
            this.genre = sic.genre;
            this.producer = sic.producer;
            this.isAdded= sic.isAdded;
            this.picture = sic.picture;
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
