using MongoDB.Bson;

namespace CRUDApplication.Models
{
    public class Customer
    {
        public ObjectId _id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
    }
}
