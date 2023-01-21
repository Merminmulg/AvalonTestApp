using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvalonTestApp.Models
{
    public class AlbumTitle
    {
        public string Title { get; set; }
        public string Discription { get; set; }
        public string ImageUrl { get; set; }
        public AlbumTitle(string title, string desription, string imageUrl)
        {
            Title = title;
            Discription = desription;
            ImageUrl = imageUrl;
        }
    }
}
