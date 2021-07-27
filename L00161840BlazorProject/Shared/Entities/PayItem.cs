using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L00161840BlazorProject.Shared.Entities
{
    public class PayItem
    {
        public int Id { get; set; }
        public PayItemType PayItemType { get; set; }
        public string Name { get; set; }
        public string MappedReference { get; set; }
        [NotMapped]
        public string FullDescription
        {
            get
            {
                return PayItemType.ToString() + ": " + Name;
            }
        }
    }
}
