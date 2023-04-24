﻿using MongoDB.Bson.Serialization.Attributes;
using System.Net;

namespace AndreTurismoMongoDb.Models
{
    public class Customer
    {
        #region[Properties]
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string Id { get; set; }
        public string? Name { get; set; }
        public Address Address { get; set; }
        public string? PhoneNumber { get; set; }
        public string? CellPhoneNumber { get; set; }
        public DateTime RegisterDate { get; set; }
        #endregion

        //public override string ToString()
        //{
        //    return $"ID_Cliente:                {Id}\n" +
        //           $"Nome_Cliente:              {Name}\n" +
        //           $"Endereço_Cliente:          {Address}\n" +
        //           $"Telefone:                  {PhoneNumber}\n" +
        //           $"Celular:                   {CellPhoneNumber}\n" +
        //           $"Registrado em:             {RegisterDate}\n\n";
        //}
    }
}
