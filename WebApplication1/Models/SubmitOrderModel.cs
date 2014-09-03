using System.Collections.Generic;

namespace WebApplication1.Models
{
    public class SubmitOrderModel
    {
        public string Email { get; set; }
        public List<SubmitOrderDetailModel> Dishes { get; set; }
    }
}