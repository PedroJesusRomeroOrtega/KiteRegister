using KiteRegister.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Config
{
    public class KiteModelConfiguration : IEntityTypeConfiguration<KiteModel>
    {
        public void Configure(EntityTypeBuilder<KiteModel> builder)
        {
            builder.HasKey(km => km.Id);

            builder.HasIndex(km => new { km.Name, km.YearProduction })
                .IsUnique();

            builder.Property(km => km.Id)
                .UseHiLo("kite_model_hilo")
                .IsRequired();

            builder.Property(km => km.Name)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(km => km.Url)
                .IsRequired(false);

            builder.Property(km => km.KiteBrandId)
                .IsRequired();
        }
    }
}
