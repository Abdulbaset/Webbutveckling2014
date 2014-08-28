using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class DishViewModel
    {
        public int Id { get; set; }

        [DisplayName("Matr�tt")]
        public string Name { get; set; }

        [DisplayName("Antal")]
        [Range(0, 10, ErrorMessage = "M�ste vara mellan 0 och 10.")]
        public int OrderedQty { get; set; }

        [DisplayName("Pris")]
        public decimal Price { get; set; }
    }
}