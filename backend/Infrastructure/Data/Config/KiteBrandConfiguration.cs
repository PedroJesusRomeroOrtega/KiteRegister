using KiteRegister.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Config
{
    public class KiteBrandConfiguration : IEntityTypeConfiguration<KiteBrand>
    {
        public void Configure(EntityTypeBuilder<KiteBrand> builder)
        {
            builder.HasKey(kb=> kb.Id);

            builder
                .HasIndex(kb => kb.Name)
                .IsUnique();

            builder.Property(kb => kb.Id)
                .UseHiLo("kite_brand_hilo")
                .IsRequired();

            builder.Property(kb => kb.Name)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(kb => kb.Url)
                .IsRequired(false);
        }
    }
}
