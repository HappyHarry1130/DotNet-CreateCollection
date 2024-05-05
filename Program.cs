using MongoDB.Bson;
using MongoDB.Driver;
using System;

namespace MongoDBExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define MongoDB connection string
            string connectionString = "mongodb://localhost:27017";

            // Establish connection to MongoDB server
            MongoClient client = new MongoClient(connectionString);
            IMongoDatabase database = client.GetDatabase("mydatabase");
            IMongoCollection<BsonDocument> collection = database.GetCollection<BsonDocument>("add");

            // Create a document to be inserted
            var document = new BsonDocument
            {
                { "name", "John Doe" },
                { "age", 30 },
                { "city", "New York" }
            };

            // Insert the document into the collection
            InsertDocument(collection, document);

            // Close connection to MongoDB server
            client = null; // Dispose MongoClient instance
        }

        static void InsertDocument(IMongoCollection<BsonDocument> collection, BsonDocument document)
        {
            collection.InsertOne(document);
            Console.WriteLine("Document inserted successfully.");
        }
    }
}
