using Priut2.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Priut2.Models
{
    public class Article
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ArticleText { get; set; }
        public string Image { get; set; }      
        public DateTime Date{ get; set; }

    }
}
