using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace marketplace3.DataAccessLayer.Interfaces
{
    public interface ISeeder<T> where T : class
    {
        void Seed(EntityTypeBuilder<T> builder);
    }
}
