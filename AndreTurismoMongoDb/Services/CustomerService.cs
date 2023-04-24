using AndreTurismoMongoDb.Config;
using AndreTurismoMongoDb.Models;
using MongoDB.Driver;

namespace AndreTurismoMongoDb.Services
{
    public class CustomerService
    {
        private readonly IMongoCollection<Customer> _customer;

        public CustomerService(IAndreTurismoMongoSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);
            _customer = database.GetCollection<Customer>(settings.CustomerCollectionName);
        }

        public List<Customer> Get() => _customer.Find(x => true).ToList();
        public Customer Get(string id) => _customer.Find<Customer>(x => x.Id == id).FirstOrDefault();
        public Customer Create(Customer customer)
        {
            _customer.InsertOne(customer);
            return customer;
        }
        public void Update(string id, Customer customer) => _customer.ReplaceOne(x => x.Id == id, customer);
        public void Delete(string id) => _customer.DeleteOne(x => x.Id == id);
        public void Delete(Customer customer) => _customer.DeleteOne(x => x.Id == customer.Id);
    }
}
