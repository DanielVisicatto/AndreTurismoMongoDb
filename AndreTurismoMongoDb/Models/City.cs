using MongoDB.Bson.Serialization.Attributes;

namespace AndreTurismoMongoDb.Models
{
    public class City
    {
        #region[Properties]
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string Id { get; set; }
        public string? Description { get; set; }
        public DateTime RegisterDate { get; set; }
        #endregion

        //public override string ToString()
        //{
        //    return $"ID_cidade:             {Id}\n" +
        //           $"Descrição_Cidade:      {Description}\n" +
        //           $"Data do Registro:      {RegisterDate}\n";
        //}
    }
}
