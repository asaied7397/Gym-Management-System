using GymManagementSystem.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GymManagementSystem.Data.Configurations;

public class MemberConfiguration : IEntityTypeConfiguration<Member>
{
    public void Configure(EntityTypeBuilder<Member> builder)
    {
        // Table Name
        builder.ToTable("Members", table =>
        {
            table.HasCheckConstraint(
                "CK_Members_Email",
                "[Email] LIKE '_%@_%._%'"
            );

            table.HasCheckConstraint(
                "CK_Members_Phone",
                @"[Phone] LIKE '01[0125]%'
                  AND LEN([Phone]) = 11
                  AND [Phone] NOT LIKE '%[^0-9]%'"
            );
        });

        builder.Property(m => m.CreatedAt)
            .HasColumnName("JoinDate")
            .HasDefaultValueSql("GETDATE()");

        builder.Property(m => m.Photo)
            .IsRequired(false);

        builder.HasMany(m => m.Memberships)
            .WithOne(ms => ms.Member)
            .HasForeignKey(ms => ms.MemberId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}