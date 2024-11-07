using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using marketplace3.DataAccessLayer.Interfaces;
using marketplace3.DataAccessLayer.Entities;

namespace marketplace3.DataAccessLayer.Seeding
{
    public class LocationSeeder : ISeeder<Location>
    {
        private static readonly List<Location> locations = new()
        {
            new Location { LocationId = 1, City = "City One", StreetAddress = "123 Main St" },
            new Location { LocationId = 2, City = "City Two", StreetAddress = "456 Second St" },
            new Location { LocationId = 3, City = "City Three", StreetAddress = "789 Third St" }
        };

        public void Seed(EntityTypeBuilder<Location> builder)
        {
            foreach (var location in locations)
            {
                builder.HasData(location);
            }
        }
    }
}
