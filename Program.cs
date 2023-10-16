using Askme.Poc.Mongodb;
using MongoDB.Bson;
using MongoDB.Driver;

//get client
var dbClient = new MongoClient("mongodb://localhost:27017/admin");

//list databases
Console.WriteLine("The list of databases on this server is: ");
dbClient
    .ListDatabases()
    .ToList()
    .ForEach(Console.WriteLine);

Console.WriteLine();



//get collection contacts for askme database
var collection = dbClient
    .GetDatabase("askme-poc-mongodb")
    .GetCollection<Contact>("contacts");

//retrieve all
RetrieveAll(collection);

//delete all
Console.WriteLine("delete all ------------------------");
collection.DeleteMany(new BsonDocument());
Console.WriteLine("done!");
Console.WriteLine();

//retrieve all
RetrieveAll(collection);

//creating random
Console.WriteLine("creating random ------------------------");
collection.InsertOne(new Contact { FirstName = Guid.NewGuid().ToString(), LastName = Guid.NewGuid().ToString(), PhoneNumber = Guid.NewGuid().ToString()});
Console.WriteLine("done!");
Console.WriteLine();

//retrieve all
RetrieveAll(collection);

//creating
Console.WriteLine("creating ------------------------");
var contact = new Contact { FirstName = "Albert", LastName = "Einstein", PhoneNumber = "2222-1111" };
collection.InsertOne(contact);
Console.WriteLine("done!");
Console.WriteLine();

//retrieve all
RetrieveAll(collection);

//retrieve
Console.WriteLine("retrieving by id ------------------------");
var filter = Builders<Contact>.Filter.Eq("Id", contact.Id);

contact = collection
    .Find(filter)
    .FirstOrDefault();

Console.WriteLine($"retrieved: {contact}");
Console.WriteLine("done!");
Console.WriteLine();

//update
Console.WriteLine("updating ------------------------");
contact.FirstName = "Salvador";
contact.LastName = "Dali";
contact.PhoneNumber = "3333-2222";

collection.ReplaceOne(filter, contact);

Console.WriteLine("done!");
Console.WriteLine();

//retrieve all
RetrieveAll(collection);

//delete
Console.WriteLine("deleting ------------------------");
collection
    .DeleteOne(filter);
Console.WriteLine("done!");
Console.WriteLine();

//retrieve all
Console.WriteLine("retrieving all ------------------------");
collection
    .Find(new BsonDocument())
    .ToList()
    .ForEach(Console.WriteLine);

void RetrieveAll(IMongoCollection<Contact> mongoCollection)
{
    Console.WriteLine("retrieving all ------------------------");
    mongoCollection
        .Find(new BsonDocument())
        .ToList()
        .ForEach(Console.WriteLine);
    Console.WriteLine("done!");
    Console.WriteLine();
}
