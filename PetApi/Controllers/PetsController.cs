using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PetApi.Models;

namespace PetApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PetsController : ControllerBase
{
    private readonly PetContext _context;

    public PetsController(PetContext context)
    {
        _context = context;
    }

    // GET: api/Pets
    [HttpGet]
    public async Task<ActionResult<IEnumerable<PetDTO>>> GetPets()
    {
        return await _context.Pets
            .Select(x => PetToDTO(x))
            .ToListAsync();
    }

    // GET: api/Pets/5
    [HttpGet("{id}")]
    public async Task<ActionResult<PetDTO>> GetPet(long id)
    {
        var pet = await _context.Pets.FindAsync(id);

        if (pet == null)
        {
            return NotFound();
        }

        return PetToDTO(pet);
    }

    // PUT: api/Pets/5
    [HttpPut("{id}")]
    public async Task<IActionResult> PutPet(long id, PetDTO petDTO)
    {
        if (id != petDTO.Id)
        {
            return BadRequest();
        }

        var pet = await _context.Pets.FindAsync(id);
        if (pet == null)
        {
            return NotFound();
        }

        pet.Name = petDTO.Name;
        pet.IsAdopted = petDTO.IsAdopted;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException) when (!PetExists(id))
        {
            return NotFound();
        }

        return NoContent();
    }

    // POST: api/Pets
    [HttpPost]
    public async Task<ActionResult<PetDTO>> PostPet(PetDTO petDTO)
    {
        var pet = new Pet
        {
            IsAdopted = petDTO.IsAdopted,
            Name = petDTO.Name
        };

        _context.Pets.Add(pet);
        await _context.SaveChangesAsync();

        return CreatedAtAction(
            nameof(GetPet),
            new { id = pet.Id },
            PetToDTO(pet));
    }

    // DELETE: api/Pets/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeletePet(long id)
    {
        var pet = await _context.Pets.FindAsync(id);
        if (pet == null)
        {
            return NotFound();
        }

        _context.Pets.Remove(pet);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool PetExists(long id)
    {
        return _context.Pets.Any(e => e.Id == id);
    }

    private static PetDTO PetToDTO(Pet pet) =>
       new PetDTO
       {
           Id = pet.Id,
           Name = pet.Name,
           IsAdopted = pet.IsAdopted
       };
}