using AndreTurismoMongoDb.Config;
using AndreTurismoMongoDb.Models;
using MongoDB.Bson;
using MongoDB.Driver;

namespace AndreTurismoMongoDb.Services
{
    public class CityService
    {
        private readonly IMongoCollection<City> _city;

        public CityService(IAndreTurismoMongoSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);
            _city = database.GetCollection<City>(settings.CityCollectionName);
        }

        public List<City> Get() => _city.Find(x => true).ToList();
        public City Get(string id) => _city.Find<City>(x => x.Id == id).FirstOrDefault();
        public City GetByName(string description) => _city.Find<City>(x => x.Description == description).FirstOrDefault();
        public City Create(City city)
        {
            _city.InsertOne(city);
            city.Id = BsonObjectId.GenerateNewId().ToString();
            return city;
        }
        public void Update (string id, City city) => _city.ReplaceOne(x => x.Id == id, city);
        public void Delete (string id) => _city.DeleteOne(x => x.Id == id);
        public void Delete(City city) => _city.DeleteOne(x => x.Id == city.Id);
    }
}
