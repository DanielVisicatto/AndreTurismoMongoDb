using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace AndreTurismoMongoDb.Models
{
    public class City
    {
        #region[Properties]
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string? Description { get; set; }
        public DateTime RegisterDate { get; set; }
        #endregion       
    }
}
