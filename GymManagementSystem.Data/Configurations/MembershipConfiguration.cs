using GymManagementSystem.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GymManagementSystem.Data.Configurations;

public class MembershipConfiguration
    : IEntityTypeConfiguration<Membership>
{
    public void Configure(EntityTypeBuilder<Membership> builder)
    {
        builder.ToTable("Memberships");

        builder.HasKey(m => m.Id);

        builder.Property(m => m.Id)
            .HasDefaultValueSql(
                "NEXT VALUE FOR dbo.MembershipSequence"
            );

        builder.Property(m => m.MemberId)
            .IsRequired();

        builder.Property(m => m.PlanId)
            .IsRequired();

        builder.Property(m => m.StartDate)
            .IsRequired();

        builder.Property(m => m.EndDate)
            .IsRequired();

        builder.Property(m => m.CreatedAt)
            .HasDefaultValueSql("GETDATE()");

        builder.HasOne(m => m.Member)
            .WithMany(member => member.Memberships)
            .HasForeignKey(m => m.MemberId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(m => m.Plan)
            .WithMany(plan => plan.Memberships)
            .HasForeignKey(m => m.PlanId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.Ignore(m => m.Status);
        builder.Ignore(m => m.IsActive);
    }
}