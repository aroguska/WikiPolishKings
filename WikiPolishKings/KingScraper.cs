using HtmlAgilityPack;
using System.Text.RegularExpressions;

namespace WikiPolishKings
{
    public class KingScraper
    {

        private const string baseURL = "https://pl.wikipedia.org/wiki/Kr%C3%B3l_Polski";

        public IEnumerable<KingModel> GetKing()
        {

            var web = new HtmlWeb();
            var document = web.Load(baseURL);
            var tableOfKing = document.QuerySelectorAll("table tr").Skip(1);

            foreach (var king in tableOfKing)
            {
                var info = king.QuerySelectorAll("td");

                if (info.Count > 7)
                {
                    var nameFromHtml = info[1].InnerHtml;
                    string name = Regex.Match(nameFromHtml, "(?<=<a[^>]*>).*?(?=</a>)", RegexOptions.IgnoreCase).Value;

                    var beginngOfTheReign = info[5].InnerText; 
                    beginngOfTheReign = Regex.Match(beginngOfTheReign, @"\d{4}", RegexOptions.IgnoreCase).Value; 

                    var endOfTheReign = info[6].InnerText;
                    endOfTheReign = Regex.Match(endOfTheReign, @"\d{4}", RegexOptions.IgnoreCase).Value; 

                    yield return new KingModel(name, beginngOfTheReign, endOfTheReign);
                }
            }
        }
    }
}


