using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace CRUDApplication.Models
{
    public class UserSignin
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
