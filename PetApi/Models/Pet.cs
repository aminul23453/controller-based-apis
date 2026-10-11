namespace PetApi.Models;

public class Pet
{
    public long Id { get; set; }
    public string? Name { get; set; }
    public bool IsAdopted { get; set; }
    public string? Secret { get; set; }
}