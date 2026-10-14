using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tamas_Gergo_Gordon_KBGyakorlas
{


    public class Gaming
    {
        public Gaming(string name, string type, string platform, int release, double rating)
        {
            Name = name;
            Type = type;
            Platform = platform;
            Release = release;
            Rating = rating;
        }

        public string Name { get; set; }
        public string Type { get; set; }
        public string Platform { get; set; }
        public int Release { get; set; }
        public double Rating { get; set; }
    }
}
