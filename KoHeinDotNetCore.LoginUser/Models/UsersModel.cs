using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoHeinDotNetCore.LoginUser.Models
{
    [Table("Tbl_Users")]
    public class UsersModel
    {
        [Key]
        public string UserId { get; set; }
        //[Column("BlogTitle")]
        public string UserName { get; set; }
        public string Password { get; set; }

    }
}
