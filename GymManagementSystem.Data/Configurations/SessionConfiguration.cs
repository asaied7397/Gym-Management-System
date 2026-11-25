using GymManagementSystem.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GymManagementSystem.Data.Configurations;

public class SessionConfiguration : IEntityTypeConfiguration<Session>
{
    public void Configure(EntityTypeBuilder<Session> builder)
    {
        builder.ToTable("Sessions", table =>
        {
            table.HasCheckConstraint(
                "CK_Sessions_Capacity",
                "[Capacity] BETWEEN 1 AND 25"
            );

            table.HasCheckConstraint(
                "CK_Sessions_Dates",
                "[EndDate] > [StartDate]"
            );
        });

        builder.HasKey(s => s.Id);

        builder.Property(s => s.Description)
            .IsRequired();

        builder.Property(s => s.Capacity)
            .IsRequired();

        builder.Property(s => s.StartDate)
            .IsRequired();

        builder.Property(s => s.EndDate)
            .IsRequired();

        builder.Property(s => s.TrainerId)
            .IsRequired();

        builder.HasOne(s => s.Trainer)
            .WithMany(t => t.Sessions)
            .HasForeignKey(s => s.TrainerId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}