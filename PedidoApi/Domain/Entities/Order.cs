public class Order
{
    public int Id { get; set; }

    public decimal Value { get; set; }

    public int UserId { get; set; }

    public User User { get; set; } = null!;
}