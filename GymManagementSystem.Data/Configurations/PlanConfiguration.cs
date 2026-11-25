using GymManagementSystem.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GymManagementSystem.Data.Configurations;

public class PlanConfiguration : IEntityTypeConfiguration<Plan>
{
    public void Configure(EntityTypeBuilder<Plan> builder)
    {
        builder.ToTable("Plans", table =>
        {
            table.HasCheckConstraint(
                "CK_Plans_DurationDays",
                "[DurationDays] BETWEEN 1 AND 365"
            );
        });

        builder.HasKey(p => p.Id);

        builder.Property(p => p.Name)
            .IsRequired();

        builder.Property(p => p.Description)
            .IsRequired();

        builder.Property(p => p.DurationDays)
            .IsRequired();

        builder.Property(p => p.Price)
            .HasPrecision(18, 2)
            .IsRequired();

        builder.Property(p => p.IsActive)
            .IsRequired();

        builder.Property(p => p.CreatedAt)
            .HasDefaultValueSql("GETDATE()");

        builder.HasMany(p => p.Memberships)
            .WithOne(m => m.Plan)
            .HasForeignKey(m => m.PlanId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}