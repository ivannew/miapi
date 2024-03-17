using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace miapi.Models
{
    public class Proyectos
    {

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]

        public string Id = string.Empty;
        [BsonElement("Nombre")]
        public string Nombre { get; set; }
        [BsonElement("Fecha")]
        public string Fecha { get; set; }

        [BsonElement("Descripcion")]
        public string Descripcion { get; set; }
    }
}
