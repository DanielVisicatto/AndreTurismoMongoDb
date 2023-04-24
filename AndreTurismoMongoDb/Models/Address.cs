using MongoDB.Bson.Serialization.Attributes;

namespace AndreTurismoMongoDb.Models
{
    public class Address
    {
        #region[Properties]
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string Id { get; set; }
        public string? Street { get; set; }
        public int Number { get; set; }
        public string? Neighborhood { get; set; }
        public string? ZipCode { get; set; }
        public string? Complement { get; set; }
        public City City { get; set; }
        public DateTime RegisterDate { get; set; }
        #endregion

        //public override string ToString()
        //{
        //    return $"Id: {Id}\n" +
        //           $"Logradouro: {Street}, nº {Number}, Compl:{Complement}\n" +
        //           $"Bairro: {Neighborhood},     {City.Description}\n" +
        //           $"CEP: {ZipCode}\n" +
        //           $"Registrado em: {RegisterDate}\n";
        //}
    }
}
