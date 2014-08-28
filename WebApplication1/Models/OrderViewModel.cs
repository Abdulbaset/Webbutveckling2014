using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using WebApplication1.Persistance;

namespace WebApplication1.Models
{
    public class OrderViewModel
    {
        public OrderViewModel()
        {
            var dishRepository = new DishRepository();

            Dishes = dishRepository
                .GetAll()
                .Select(d => new DishViewModel
                    {
                        Id = d.Id,
                        Name = d.Name,
                        Price = d.Price
                    })
                .ToList();
        }

        public List<DishViewModel> Dishes { get; set; }

        [EmailAddress(ErrorMessage = "Inte en epostadress.")]
        [Required]
        [DisplayName("E-post")]
        public string Email { get; set; }

        public string QtyErrorMessage { get; set; }
    }
}