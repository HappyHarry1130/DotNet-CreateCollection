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

            // Create a collection
            string collectionName = "add";
            CreateCollection(database, collectionName);

            // Access the collection
            //IMongoCollection<BsonDocument> collection = database.GetCollection<BsonDocument>(collectionName);

            // Close connection to MongoDB server
            client = null; // Dispose MongoClient instance
        }

        static void CreateCollection(IMongoDatabase database, string collectionName)
        {
            // Check if the collection already exists
            var collectionsCursor = database.ListCollections();
            var collections = collectionsCursor.ToList();
            foreach (var collection in collections)
            {
                if (collection["name"].AsString == collectionName)
                {
                    Console.WriteLine("Collection already exists.");
                    return;
                }
            }

            // Create the collection
            database.CreateCollection(collectionName);
            Console.WriteLine("Collection created successfully.");
        }
    }
}
