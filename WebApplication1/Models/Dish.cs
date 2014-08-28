namespace WebApplication1.Models
{
    public class Dish
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
    }

    public class OrderDetail
    {
        public int DishId { get; set; }
        public int Quantity { get; set; }
    }
}