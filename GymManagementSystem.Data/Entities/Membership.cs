using System.ComponentModel.DataAnnotations.Schema;

namespace GymManagementSystem.Data.Entities;

public class Membership : BaseEntity
{
    public int MemberId { get; set; }

    public Member Member { get; set; } = null!;

    public int PlanId { get; set; }

    public Plan Plan { get; set; } = null!;

    public DateTime StartDate { get; set; }

    public DateTime EndDate { get; set; }

    [NotMapped]
    public string Status =>
        EndDate > DateTime.Now ? "Active" : "Expired";

    [NotMapped]
    public bool IsActive =>
        EndDate > DateTime.Now;
}