using AndreTurismoMongoDb.Config;
using AndreTurismoMongoDb.Models;
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
        public Address Create(Address address)
        {
            _address.InsertOne(address);
            return address;
        }
        public void Update(string id, Address address) => _address.ReplaceOne(x => x.Id == id, address);
        public void Delete(string id) => _address.DeleteOne(x => x.Id == id);
        public void Delete(Address address) => _address.DeleteOne(x => x.Id == address.Id);
    }
}
