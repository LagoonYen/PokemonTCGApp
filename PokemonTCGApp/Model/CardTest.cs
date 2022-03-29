using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace PokemonTCGApp.Model
{
    [BsonIgnoreExtraElements]
    public class CardTest
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = String.Empty;

        [BsonElement("cardname")]
        public string CardName { get; set; } = String.Empty;

        [BsonElement("setid")]
        public string? SetId { get; set; }

        [BsonElement("img")]
        public string? Img { get; set; }

        [BsonElement("abilities")]
        public List<Ability>? Abilities { get; set; }

        [BsonElement("createtime")]
        public DateTime CreateTime { get; set; }

        [BsonElement("updatetime")]
        public DateTime UpdateTime { get; set; }
    }

    public class Ability
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
    }
}
