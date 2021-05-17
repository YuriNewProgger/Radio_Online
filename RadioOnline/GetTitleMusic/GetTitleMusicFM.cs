using AngleSharp.Dom;
using AngleSharp.Html.Parser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace RadioOnline.GetTitleMusic
{
    class GetTitleMusicFM : ITitleMusic
    {
        public string GetTitle(string address)
        {
            if (address == "No support")
                return address;

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(address);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            HtmlParser parser = new HtmlParser();
            var document = parser.ParseDocument(response.GetResponseStream());

            List<IElement> items = document.QuerySelectorAll("a")
                    .Where(i => i.ClassName != null && i.ClassName.Contains("ajax"))
                    .ToList();

            response.Close();
            return items[17].TextContent;
        }
    }
}
