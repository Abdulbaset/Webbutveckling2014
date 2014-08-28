using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class DishViewModel
    {
        public int Id { get; set; }

        [DisplayName("Maträtt")]
        public string Name { get; set; }

        [DisplayName("Antal")]
        [Range(0, 10, ErrorMessage = "Måste vara mellan 0 och 10.")]
        public int OrderedQty { get; set; }

        [DisplayName("Pris")]
        public decimal Price { get; set; }
    }
}