using Domain.Brands;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations;

internal sealed class BrandConfiguration : IEntityTypeConfiguration<Brand>
{
    public void Configure(EntityTypeBuilder<Brand> builder)
    {
        builder.Property(static m => m.Id).HasField("_id").ValueGeneratedNever();
        builder.Property(static m => m.Title).HasField("_title");
        builder.Property(static m => m.Description).HasField("_description");

        builder.HasIndex(static m => m.Title).IsUnique();

        builder
            .HasOne(static b => b.Manufacturer)
            .WithMany(static b => b.Brands);
    }
}