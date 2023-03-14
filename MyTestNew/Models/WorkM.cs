using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;

namespace MyTestNew.Models
{
    public class WorkM
    {

        public Guid Id { get; set; }

        [DataType(DataType.Date), Display(Name = "Date")]
        public DateTime Date { get; set; }



        public string UserName { get; set; } = string.Empty;


        public Guid EmpId { get; set; }

        [ForeignKey("EmpId")]
        public Emp? emp { get; set; }
    }
}
