using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyTestNew.Models
{
    public class Company
    {
        public long Id  { get; set; }

        [Display(Name ="Company Name"),MaxLength(10)]
        public string Name { get; set; } = string.Empty;

        public string UserName { get; set; } = string.Empty;


        public int Emps { get; set; }


        public Guid MangId { get; set; }
        [ForeignKey("MangId")]
        public Emp? emp { get; set; }


    }
}
