using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace AndreTurismoMongoDb.Models
{
    public class Customer
    {
        #region[Properties]
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string? Name { get; set; }
        public Address Address { get; set; }
        public string? PhoneNumber { get; set; }
        public string? CellPhoneNumber { get; set; }
        public DateTime RegisterDate { get; set; }
        #endregion       
    }
}
