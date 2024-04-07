using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace KoHeinDotNetCore.LoginUser.Models
{
    [Table("Tbl_Login")]
    public class LoginModel
    {
        [Key]
        public int Id { get; set; }
        public string UserId { get; set; }
        public string SessionId { get; set; }
        public DateTime SessionExpired { get; set; }

    }
}
