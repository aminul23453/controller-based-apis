using Microsoft.EntityFrameworkCore;

namespace PetApi.Models;

public class PetContext : DbContext
{
    public PetContext(DbContextOptions<PetContext> options)
        : base(options)
    {
    }

    public DbSet<Pet> Pets { get; set; } = null!;
}