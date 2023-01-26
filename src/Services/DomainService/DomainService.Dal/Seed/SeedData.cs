using DomainService.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DomainService.Dal.Seed;

/// <summary>
/// Seed data extension
/// </summary>
public static class SeedData
{
    public static void Seed(this ModelBuilder modelBuilder)
    {
        var listOfCountries = new List<Country>
        {
            new("Angola", new List<Province>()) { Id = Guid.NewGuid(), CreatedOn = DateTime.UtcNow, UpdatedOn = DateTime.UtcNow },
            new("Botswana", new List<Province>()) { Id = Guid.NewGuid(), CreatedOn = DateTime.UtcNow, UpdatedOn = DateTime.UtcNow },
            new("Canada", new List<Province>()) { Id = Guid.NewGuid(), CreatedOn = DateTime.UtcNow, UpdatedOn = DateTime.UtcNow },
            new("Dominica", new List<Province>()) { Id = Guid.NewGuid(), CreatedOn = DateTime.UtcNow, UpdatedOn = DateTime.UtcNow },
        };

        var listOfProvinces = new List<Province>
        {
            new("Bengo") { CountryId = listOfCountries[0].Id, Id = Guid.NewGuid(), CreatedOn = DateTime.UtcNow, UpdatedOn = DateTime.UtcNow },
            new("Cuanza Sul") { CountryId = listOfCountries[0].Id, Id = Guid.NewGuid(), CreatedOn = DateTime.UtcNow, UpdatedOn = DateTime.UtcNow },
            new("Cunene") { CountryId = listOfCountries[0].Id, Id = Guid.NewGuid(), CreatedOn = DateTime.UtcNow, UpdatedOn = DateTime.UtcNow },
            new("Huambo") { CountryId = listOfCountries[0].Id, Id = Guid.NewGuid(), CreatedOn = DateTime.UtcNow, UpdatedOn = DateTime.UtcNow },
            new("Luanda") { CountryId = listOfCountries[0].Id, Id = Guid.NewGuid(), CreatedOn = DateTime.UtcNow, UpdatedOn = DateTime.UtcNow },
            new("Malanje") { CountryId = listOfCountries[0].Id, Id = Guid.NewGuid(), CreatedOn = DateTime.UtcNow, UpdatedOn = DateTime.UtcNow },
            new("Moxico") { CountryId = listOfCountries[0].Id, Id = Guid.NewGuid(), CreatedOn = DateTime.UtcNow, UpdatedOn = DateTime.UtcNow },
            new("Bengo23") { CountryId = listOfCountries[0].Id, Id = Guid.NewGuid(), CreatedOn = DateTime.UtcNow, UpdatedOn = DateTime.UtcNow },
            new("Namibe") { CountryId = listOfCountries[0].Id, Id = Guid.NewGuid(), CreatedOn = DateTime.UtcNow, UpdatedOn = DateTime.UtcNow },

            new("Gaborone") { CountryId = listOfCountries[1].Id, Id = Guid.NewGuid(), CreatedOn = DateTime.UtcNow, UpdatedOn = DateTime.UtcNow },
            new("Cuanza Sul") { CountryId = listOfCountries[1].Id, Id = Guid.NewGuid(), CreatedOn = DateTime.UtcNow, UpdatedOn = DateTime.UtcNow },
            new("Francistown") { CountryId = listOfCountries[1].Id, Id = Guid.NewGuid(), CreatedOn = DateTime.UtcNow, UpdatedOn = DateTime.UtcNow },
            new("Jwaneng") { CountryId = listOfCountries[1].Id, Id = Guid.NewGuid(), CreatedOn = DateTime.UtcNow, UpdatedOn = DateTime.UtcNow },
            new("Orapa") { CountryId = listOfCountries[1].Id, Id = Guid.NewGuid(), CreatedOn = DateTime.UtcNow, UpdatedOn = DateTime.UtcNow },
            new("Malanje") { CountryId = listOfCountries[1].Id, Id = Guid.NewGuid(), CreatedOn = DateTime.UtcNow, UpdatedOn = DateTime.UtcNow },
            new("Kanye") { CountryId = listOfCountries[1].Id, Id = Guid.NewGuid(), CreatedOn = DateTime.UtcNow, UpdatedOn = DateTime.UtcNow },
            new("Ramotswa") { CountryId = listOfCountries[1].Id, Id = Guid.NewGuid(), CreatedOn = DateTime.UtcNow, UpdatedOn = DateTime.UtcNow },
            new("Mochudi") { CountryId = listOfCountries[1].Id, Id = Guid.NewGuid(), CreatedOn = DateTime.UtcNow, UpdatedOn = DateTime.UtcNow },
            new("Mochudi2") { CountryId = listOfCountries[1].Id, Id = Guid.NewGuid(), CreatedOn = DateTime.UtcNow, UpdatedOn = DateTime.UtcNow },
            new("Mochudi3") { CountryId = listOfCountries[1].Id, Id = Guid.NewGuid(), CreatedOn = DateTime.UtcNow, UpdatedOn = DateTime.UtcNow },
            new("Mochudias") { CountryId = listOfCountries[1].Id, Id = Guid.NewGuid(), CreatedOn = DateTime.UtcNow, UpdatedOn = DateTime.UtcNow },
            new("Mochudids") { CountryId = listOfCountries[1].Id, Id = Guid.NewGuid(), CreatedOn = DateTime.UtcNow, UpdatedOn = DateTime.UtcNow },
            new("Mochudixc") { CountryId = listOfCountries[1].Id, Id = Guid.NewGuid(), CreatedOn = DateTime.UtcNow, UpdatedOn = DateTime.UtcNow },

            new("Gaborone") { CountryId = listOfCountries[2].Id, Id = Guid.NewGuid(), CreatedOn = DateTime.UtcNow, UpdatedOn = DateTime.UtcNow },
            new("Cuanza Sul") { CountryId = listOfCountries[2].Id, Id = Guid.NewGuid(), CreatedOn = DateTime.UtcNow, UpdatedOn = DateTime.UtcNow },
            new("Francistown") { CountryId = listOfCountries[2].Id, Id = Guid.NewGuid(), CreatedOn = DateTime.UtcNow, UpdatedOn = DateTime.UtcNow },
            new("Jwaneng") { CountryId = listOfCountries[2].Id, Id = Guid.NewGuid(), CreatedOn = DateTime.UtcNow, UpdatedOn = DateTime.UtcNow },
            new("Orapa") { CountryId = listOfCountries[2].Id, Id = Guid.NewGuid(), CreatedOn = DateTime.UtcNow, UpdatedOn = DateTime.UtcNow },
            new("Malanje") { CountryId = listOfCountries[2].Id, Id = Guid.NewGuid(), CreatedOn = DateTime.UtcNow, UpdatedOn = DateTime.UtcNow },
            new("Kanye") { CountryId = listOfCountries[2].Id, Id = Guid.NewGuid(), CreatedOn = DateTime.UtcNow, UpdatedOn = DateTime.UtcNow },
            new("Ramotswa") { CountryId = listOfCountries[2].Id, Id = Guid.NewGuid(), CreatedOn = DateTime.UtcNow, UpdatedOn = DateTime.UtcNow },
            new("Mochudi") { CountryId = listOfCountries[2].Id, Id = Guid.NewGuid(), CreatedOn = DateTime.UtcNow, UpdatedOn = DateTime.UtcNow },
            new("Mochudi2") { CountryId = listOfCountries[2].Id, Id = Guid.NewGuid(), CreatedOn = DateTime.UtcNow, UpdatedOn = DateTime.UtcNow },
            new("Mochudi3") { CountryId = listOfCountries[2].Id, Id = Guid.NewGuid(), CreatedOn = DateTime.UtcNow, UpdatedOn = DateTime.UtcNow },
            new("Mochudias") { CountryId = listOfCountries[2].Id, Id = Guid.NewGuid(), CreatedOn = DateTime.UtcNow, UpdatedOn = DateTime.UtcNow },
            new("Mochudids") { CountryId = listOfCountries[2].Id, Id = Guid.NewGuid(), CreatedOn = DateTime.UtcNow, UpdatedOn = DateTime.UtcNow },
            new("Mochudixc") { CountryId = listOfCountries[2].Id, Id = Guid.NewGuid(), CreatedOn = DateTime.UtcNow, UpdatedOn = DateTime.UtcNow },

            new("Marigot") { CountryId = listOfCountries[3].Id, Id = Guid.NewGuid(), CreatedOn = DateTime.UtcNow, UpdatedOn = DateTime.UtcNow },
            new("Castle Bruce") { CountryId = listOfCountries[3].Id, Id = Guid.NewGuid(), CreatedOn = DateTime.UtcNow, UpdatedOn = DateTime.UtcNow },
            new("Roseau") { CountryId = listOfCountries[3].Id, Id = Guid.NewGuid(), CreatedOn = DateTime.UtcNow, UpdatedOn = DateTime.UtcNow },
            new("Portsmouth") { CountryId = listOfCountries[3].Id, Id = Guid.NewGuid(), CreatedOn = DateTime.UtcNow, UpdatedOn = DateTime.UtcNow },
            new("Saint Joseph") { CountryId = listOfCountries[3].Id, Id = Guid.NewGuid(), CreatedOn = DateTime.UtcNow, UpdatedOn = DateTime.UtcNow },
            new("Pointe Michel") { CountryId = listOfCountries[3].Id, Id = Guid.NewGuid(), CreatedOn = DateTime.UtcNow, UpdatedOn = DateTime.UtcNow },
            new("Moxico") { CountryId = listOfCountries[3].Id, Id = Guid.NewGuid(), CreatedOn = DateTime.UtcNow, UpdatedOn = DateTime.UtcNow },
            new("Soufrière") { CountryId = listOfCountries[3].Id, Id = Guid.NewGuid(), CreatedOn = DateTime.UtcNow, UpdatedOn = DateTime.UtcNow },
            new("Berekua") { CountryId = listOfCountries[3].Id, Id = Guid.NewGuid(), CreatedOn = DateTime.UtcNow, UpdatedOn = DateTime.UtcNow },
        };

        modelBuilder.Entity<Province>()
            .HasData(listOfProvinces);

        modelBuilder.Entity<Country>()
            .HasData(listOfCountries);
    }
}
