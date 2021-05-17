using RadioOnline.GetTitleMusic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RadioOnline
{
    class Station
    {
        public string Name { get; set; }
        public Uri Uri { get; set; }
        public string AddressTitleMusic { get; set; }

        public Station(string name, string uri, string addressTitleMusic)
        {
            Name = name;
            Uri = new Uri(uri);
            AddressTitleMusic = addressTitleMusic;
        }

        public override string ToString() => $"{Name}";
    }
}
