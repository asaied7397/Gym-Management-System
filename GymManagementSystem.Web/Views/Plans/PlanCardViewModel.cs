namespace GymManagementSystem.Web.ViewModels.Plans;

public class PlanCardViewModel
{
    public int Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public string? Description { get; set; }

    public int DurationDays { get; set; }

    public decimal Price { get; set; }

    public bool IsActive { get; set; }

    public bool IsLocked { get; set; }
}