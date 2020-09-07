using KiteRegister.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Infrastructure.Data.Config
{
    public class KiteConfiguration : IEntityTypeConfiguration<Kite>
    {
        public void Configure(EntityTypeBuilder<Kite> builder)
        {
            builder.HasKey(km => km.Id);

            builder.Property(km => km.Id)
                .UseHiLo("kite_hilo")
                .IsRequired();

            builder.Property(km => km.Size)
                .IsRequired();

            builder.Property(km => km.PrincipalColor)
                .IsRequired(false);

            builder.Property(km => km.PurchaseDate)
                .IsRequired();

            builder.Property(km => km.KiteModelId)
                .IsRequired();

        }
    }
}
