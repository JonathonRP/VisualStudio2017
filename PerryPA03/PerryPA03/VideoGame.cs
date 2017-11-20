using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Linq.Mapping;
using System.Collections;

namespace PerryPA03
{
    class VideoGame : IEnumerable<VideoGame>
    {
        List<VideoGame> video_games = new List<VideoGame>();

        private double USA = 0;
        private double Europe = 0;
        private double Japan = 0;
        private double Other = 0;
        private double Global = 0;

        internal string Location { get; set; }
        internal Dictionary<string, string> location = new Dictionary<string, string>();
        public int Rank { get; set; }
        public string Name { get; set; }
        public string Platform { get; set; }
        public int Year { get; set; }
        public string Genre { get; set; }
        public string Publisher { get; set; }
        internal string Sales { get; set; }
        internal Dictionary<string, double> sales = new Dictionary<string, double>();
        internal Dictionary<string, string> _sales = new Dictionary<string, string>();

        public VideoGame(int rank, string name, string platform, int year, string genre, string publisher, 
            double na_sales, double eu_sales, double jp_sales, double other_sales, double global_sales)
        {
            Rank = rank;
            Name = name;
            Platform = platform;
            Year = year;
            Genre = genre;
            Publisher = publisher;
            USA = na_sales;
            Europe = eu_sales;
            Japan = jp_sales;
            Other = other_sales;
            Global = global_sales;

            location["NA"] = $"North America";
            sales["NA"] = USA;
            _sales["NA"] = $"{USA:C2} million";

            location["EU"] = $"Europe";
            sales["EU"] = Europe;
            _sales["EU"] = $"{Europe:C2} million";

            location["JP"] = $"Japan";
            sales["JP"] = Japan;
            _sales["JP"] = $"{Japan:C2} million";

            location["Other"] = $"Other";
            sales["Other"] = Other;
            _sales["Other"] = $"{Other:C2} million";

            location["Global"] = $"Global";
            sales["Global"] = Global;
            _sales["Global"] = $"{Global:C2} million";
        }

        public void Add(VideoGame game)
        {
            video_games.Add(game);
        }

        public IEnumerator<VideoGame> GetEnumerator()
        {
            return video_games.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
