using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookingApp.Data.Entities
{
    public class BaseEntity
    {
        public int Id { get; set; }
        public DateTime CreatedData { get; set; }
        public DateTime? ModifiedData { get; set; }
        public bool IsDeleted { get; set; }

    }

    public abstract class BaseConfiguration<TEntity> : IEntityTypeConfiguration<TEntity>where TEntity : BaseEntity
    {
        public virtual void Configure(EntityTypeBuilder<TEntity> builder)
        {

            builder.HasQueryFilter(x => x.IsDeleted == false);
            // Bu veritabanı üzerinde yapılacak bütün sorgulamalarda ve diğer LINQ işlemlerinde geçerli olacak bir filtreleme yazdık.
            // Böylelikle hiçbir zaman bir daha soft delete edilmiş verilerle uğraşmayacağız.
            builder.Property(x => x.ModifiedData).IsRequired(false);
        }


    }
}
