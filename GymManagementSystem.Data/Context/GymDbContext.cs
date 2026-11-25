using GymManagementSystem.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace GymManagementSystem.Data.Context;

public class GymDbContext : DbContext
{
    public GymDbContext(DbContextOptions<GymDbContext> options)
        : base(options)
    {
    }

    public DbSet<Member> Members => Set<Member>();

    public DbSet<Trainer> Trainers => Set<Trainer>();

    public DbSet<Plan> Plans => Set<Plan>();

    public DbSet<Session> Sessions => Set<Session>();

    public DbSet<Membership> Memberships => Set<Membership>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(
            typeof(GymDbContext).Assembly
        );

        modelBuilder.HasSequence<int>(
            "MembershipSequence",
            "dbo"
        )
        .StartsAt(1)
        .IncrementsBy(1);
    }
}