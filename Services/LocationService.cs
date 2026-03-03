using MongoDB.Driver;
using NearbyFriendsApp.Models;

namespace NearbyFriendsApp.Services
{
    public class LocationService
    {
        private readonly IMongoCollection<UserLocation> _locations;

        public LocationService(IConfiguration config)
        {
            var client = new MongoClient(config["MongoDbSettings:ConnectionString"]);
            var database = client.GetDatabase(config["MongoDbSettings:DatabaseName"]);
            _locations = database.GetCollection<UserLocation>(config["MongoDbSettings:CollectionName"]);
        }

        public void SaveLocation(UserLocation location)
        {
            _locations.InsertOne(location);
        }

        public List<UserLocation> GetAll()
        {
            return _locations.Find(x => true).ToList();
        }
    }
}