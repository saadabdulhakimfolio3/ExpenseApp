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
        public Guid Id{ get; }

        // Mapping each property to an element in MongoDB.
        [BsonElement("description")]
        public string Description{ get; }
        [BsonElement("category")]
        public string Category { get; }
        [BsonElement("date")]
        public DateTime Date { get; }
        [BsonElement("lastModified")]
        public DateTime LastModified{ get; }
        [BsonElement("ammount")]
        public int Ammount {  get; }

        public Expense(Guid id, string description, string category, DateTime date, DateTime lastModified, int ammount)
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
