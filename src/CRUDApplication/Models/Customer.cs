using MongoDB.Bson;
using System.ComponentModel.DataAnnotations;

namespace CRUDApplication.Models
{
    public class Customer
    {
        public ObjectId _id { get; set; }
        [Required(ErrorMessage = "Invalid Name")]
        [RegularExpression(@"^[a-zA-Z]+(([',. -][a-zA-Z ])?[a-zA-Z]*)*$", ErrorMessage = "Invalid Format Of Name")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Invalid Email")]
        [RegularExpression(@"^\w+([\.-]?\w+)*@\w+([\.-]?\w+)*(\.\w{2,3})+$", ErrorMessage = "Invalid Format Of Email")]
        public string Email { get; set; }
    }
}
