namespace Domain.DTO
{
    public class BuyCarDTO
    {
        public int CarId { get; set; }
        public int SellerId { get; set; }
        public int OwnerId { get; set; }
        public double Price { get; set; }
    }
}