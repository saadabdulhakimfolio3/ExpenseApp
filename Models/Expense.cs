using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ExpenseApp.Models
{
    public class Expense
    {
        // Every field can only be returned not modified.

        // Converts MongoDB datatype into .Net Guid datatype.
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id{ get; set; }

        // Mapping each property to an element in MongoDB.
        [BsonElement("description")]
        public string Description{ get; set; }
        [BsonElement("category")]
        public string Category { get; set; }
        [BsonElement("date")]
        public DateTime Date { get; set; }
        [BsonElement("lastModified")]
        public DateTime LastModified{ get; set; }
        [BsonElement("ammount")]
        public int Ammount { get; set; }

        public Expense(string description, string category, DateTime date, DateTime lastModified, int ammount)
        {
            Description = description;
            Category = category;
            Date = date;
            LastModified = lastModified;
            Ammount = ammount;
        }
        public Expense(string id, string description, string category, DateTime date, DateTime lastModified, int ammount)
        {
            Id = id;
            Description = description;
            Category = category;
            Date = date;
            LastModified = lastModified;
            Ammount = ammount;
        }
    }
}
