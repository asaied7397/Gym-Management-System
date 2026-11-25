namespace GymManagementSystem.Data.ComplexTypes;

public class Address
{
    public int BuildingNumber { get; set; }

    public string City { get; set; } = null!;

    public string Street { get; set; } = null!;
}