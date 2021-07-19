using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L00161840BlazorProject.Shared.Entities
{
    public class Company
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="This field is required")]
        public string Name { get; set; }
        [Required(ErrorMessage = "This field is required")]
        public string TaxReference { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string Address3 { get; set; }
        public string Address4 { get; set; }
        public string Address5 { get; set; }
        public string AdminEmail { get; set; }
        public string Phone { get; set; }
        public List<Employee> Employees { get; set; } = new List<Employee>();
    }
}
