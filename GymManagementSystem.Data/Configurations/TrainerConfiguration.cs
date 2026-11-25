using GymManagementSystem.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GymManagementSystem.Data.Configurations;

public class TrainerConfiguration : IEntityTypeConfiguration<Trainer>
{
    public void Configure(EntityTypeBuilder<Trainer> builder)
    {
        builder.ToTable("Trainers", table =>
        {
            table.HasCheckConstraint(
                "CK_Trainers_Email",
                "[Email] LIKE '_%@_%._%'"
            );

            table.HasCheckConstraint(
                "CK_Trainers_Phone",
                @"[Phone] LIKE '01[0125]%'
                  AND LEN([Phone]) = 11
                  AND [Phone] NOT LIKE '%[^0-9]%'"
            );
        });

        builder.Property(t => t.CreatedAt)
            .HasDefaultValueSql("GETDATE()");

        builder.Property(t => t.HireDate)
            .IsRequired();

        builder.Property(t => t.Specialties)
            .IsRequired();

        builder.HasMany(t => t.Sessions)
            .WithOne(s => s.Trainer)
            .HasForeignKey(s => s.TrainerId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}