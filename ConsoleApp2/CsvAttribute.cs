using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    [AttributeUsage(AttributeTargets.Property)]     
    public class CsvAttribute : Attribute
    {
        public int ColoumnOrder { get; }
        public string? Heading { get; set; }
        public string? Format { get; set; }
        public string? Units { get; set; }
        public CsvAttribute(int coloumnOrder) 
        {
            ColoumnOrder = coloumnOrder;
        }



    }
}
