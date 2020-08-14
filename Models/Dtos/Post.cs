using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace huyblog.Models.Dtos
{
    public class Post
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int AuthorId { get; set; }
        public DateTime CreateDate { get; set; }
        public string Title { get; set; }
        public string MetaTitle { get; set; }
        public bool Published { get; set; }
        public DateTime UpdateDate { get; set; }
        [Column(TypeName = "text")]
        public string Content { get; set; }
    }
}
