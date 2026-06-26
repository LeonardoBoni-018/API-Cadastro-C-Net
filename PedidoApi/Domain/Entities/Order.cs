public class Order
{
    public int Id {get; set;}

    public decimal value {get; set;}

    public int UserId {get; set;}

    public User User {get; set;}
}