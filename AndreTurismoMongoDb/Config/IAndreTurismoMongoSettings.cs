namespace AndreTurismoMongoDb.Config
{
    public interface IAndreTurismoMongoSettings
    {
        string CustomerCollectionName { get; set; }
        string CityCollectionName { get; set; }
        string AddressCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}
