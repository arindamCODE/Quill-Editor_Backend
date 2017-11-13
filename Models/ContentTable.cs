using System;
using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class ContentTable
    {
        public int ID { get; set; }
        public string Content { get; set; }
        public string MetaTags { get; set; }
        public bool Favourites { get; set;}
        public string Users { get; set; }
    }
}