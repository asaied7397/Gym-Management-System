using GymManagementSystem.Data.ComplexTypes;
using GymManagementSystem.Data.Enums;

namespace GymManagementSystem.Data.Entities;

public abstract class GymUser : BaseEntity
{
    public string Name { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Phone { get; set; } = null!;

    public DateOnly DateOfBirth { get; set; }

    public Gender Gender { get; set; }

    public Address Address { get; set; } = new();
}