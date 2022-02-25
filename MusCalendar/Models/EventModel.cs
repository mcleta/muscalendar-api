using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MusCalendar.Models
{
    public class EventModel
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }
        public string Titulo { get; set; }
        public BsonDateTime Data { get; set; }
        public string? Descricao { get; set; }
        public bool Importante { get; set; }
        internal BsonDateTime DataCriacao { get; set; }
    }
}
