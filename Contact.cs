using MongoDB.Bson;

namespace Askme.Poc.Mongodb;

public class Contact
{
    //hack: attributes commented due no need for fine-grain control over bson attributes names
    //[BsonId] 
    public ObjectId Id { get; set; }

    //[BsonElement("firstName")]
    public string FirstName { get; set; }

    //[BsonElement("lastName")]
    public string LastName { get; set; }

    //[BsonElement("phoneNumber")]
    public string PhoneNumber { get; set; }

    public override string ToString()
    {
        return $"{Id}: {FirstName} {LastName} - {PhoneNumber}";
    }
}