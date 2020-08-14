using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace huyblog.Models.ViewModel
{
    public class PostViewModel
    {
        public int AuthorId { get; set; }
        public DateTime CreateDate { get; set; }
        public string Title { get; set; }
        public string MetaTitle { get; set; }
        public bool Published { get; set; }
        public DateTime UpdateDate { get; set; }
        public string Content { get; set; }
    }
}
