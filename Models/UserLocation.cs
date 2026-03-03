using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace NearbyFriendsApp.Models
{
    [BsonIgnoreExtraElements]
    public class UserLocation
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        public string Name { get; set; }

        public double Latitude { get; set; }

        public double Longitude { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}