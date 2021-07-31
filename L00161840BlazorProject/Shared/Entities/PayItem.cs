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

        public override bool Equals(object obj)
        {
            return obj is PayItem item &&
                   Id == item.Id &&
                   PayItemType == item.PayItemType &&
                   Name == item.Name &&
                   MappedReference == item.MappedReference;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id, PayItemType, Name, MappedReference);
        }

        public override string ToString()
        {
            return PayItemType.ToString() + ": " + Name;
        }
    }
}
