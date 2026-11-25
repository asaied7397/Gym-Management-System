using GymManagementSystem.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GymManagementSystem.Data.Configurations;

public class GymUserConfiguration : IEntityTypeConfiguration<GymUser>
{
    public void Configure(EntityTypeBuilder<GymUser> builder)
    {
        builder.UseTpcMappingStrategy();

        builder.HasKey(u => u.Id);

        builder.Property(u => u.Name)
            .IsRequired()
            .HasColumnType("varchar(50)");

        builder.Property(u => u.Email)
            .IsRequired();

        builder.HasIndex(u => u.Email)
            .IsUnique();

        builder.Property(u => u.Phone)
            .IsRequired()
            .HasColumnType("varchar(11)");

        builder.ComplexProperty(u => u.Address, address =>
        {
            address.IsRequired();

            address.Property(a => a.BuildingNumber)
                .IsRequired();

            address.Property(a => a.City)
                .IsRequired();

            address.Property(a => a.Street)
                .IsRequired();
        });
    }
}