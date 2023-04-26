using AndreTurismoMongoDb.Config;
using AndreTurismoMongoDb.Models;
using MongoDB.Bson;
using MongoDB.Driver;

namespace AndreTurismoMongoDb.Services
{
    public class AddressService
    {
        private readonly IMongoCollection<Address> _address;

        public AddressService(IAndreTurismoMongoSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);
            _address = database.GetCollection<Address>(settings.AddressCollectionName);
        }

        public List<Address> Get() => _address.Find(x => true).ToList();


        public Address Get(string id) => _address.Find<Address>(x => x.Id == id).FirstOrDefault();


        public Address GetBy(string description) => _address.Find<Address>(x => x.Street == description).FirstOrDefault();


        public Address GetAddress(Address address) =>
            _address.Find(x =>
        x.Street == address.Street &&
        x.Number == address.Number &&
        x.Neighborhood == address.Neighborhood &&
        x.ZipCode == address.ZipCode &&
        x.Complement == address.Complement &&
        x.City == address.City &&
        x.RegisterDate == address.RegisterDate)
            .FirstOrDefault();


        public Address Create(Address address)
        {
            //address.Id = BsonObjectId.GenerateNewId().ToString();
            _address.InsertOne(address);
            return address;
        }

        public void Update(string id, Address address) => _address.ReplaceOne(x => x.Id == id, address);


        public void Delete(string id) => _address.DeleteOne(x => x.Id == id);


        public void Delete(Address address) => _address.DeleteOne(x => x.Id == address.Id);
    }
}
