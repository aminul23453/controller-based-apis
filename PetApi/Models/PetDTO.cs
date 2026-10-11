namespace PetApi.Models;

public class PetDTO
{
    public long Id { get; set; }
    public string? Name { get; set; }
    public bool IsAdopted { get; set; }
}