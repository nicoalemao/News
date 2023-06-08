using System;
using System.Collections.Generic;
using System.Text;

namespace News.Models
{
    public class HltvArticle
    {
        public string title { get; set; }
        public string description { get; set; }
        public string link { get; set; }
        public DateTime time { get; set; }
    }

    public class HltvResult
    {
        public List<HltvArticle> HltvArticles { get; set; }
    }

}
