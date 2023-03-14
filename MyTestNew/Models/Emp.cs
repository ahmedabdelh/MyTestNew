using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata.Ecma335;

namespace MyTestNew.Models
{
    public class Emp
    {
        public Guid Id { get; set; }

        [Display(Name = "Employee Name"),MaxLength(25)]
        public string Name { get; set; } = string.Empty;

        public bool IsWorck { get; set; }

        [Display(Name ="Email"),EmailAddress]
        public string ?Email { get; set; }

        [Range(0, 9999999999999999.99, ErrorMessage = "Invalid Target Salary; Max 18 digits")]
        public decimal Salary { get; set; }

      
        public string ?Companies { get; set; }


        public string UserName { get; set; } = string.Empty;

        public string ?WorkNote { get; set; }









    }
}
