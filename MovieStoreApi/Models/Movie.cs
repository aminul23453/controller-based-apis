using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Text.Json.Serialization;

namespace MovieStoreApi.Models;

public class Movie
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }

    [BsonElement("Title")]
    [JsonPropertyName("Title")]
    public string MovieTitle { get; set; } = null!;

    public decimal Price { get; set; }

    public string Genre { get; set; } = null!;

    public string Director { get; set; } = null!;
}