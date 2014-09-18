using System.ComponentModel;

namespace WebApplication1.Models
{
    public class LoginModel
    {
        [DisplayName("Anst.nr")]
        public int EmployeeNumber { get; set; }
        [DisplayName("Lösenord")]
        public string Password { get; set; }
    }
}