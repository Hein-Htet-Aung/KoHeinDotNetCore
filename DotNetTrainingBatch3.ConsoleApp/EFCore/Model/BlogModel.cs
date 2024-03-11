using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoHein.ConsoleApp.EFCore.Model
{
    [Table("Tbl_Blog")]
    public class BlogModel
    {
        [Key]
        public int BlogId { get; set; }
        //[Column("BlogTitle")]
        public string BlogTitle { get; set; }
        public string BlogAuthor { get; set; }
        public string BlogContent { get; set; }
    }
}
