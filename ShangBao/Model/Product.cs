using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShangBao.Model
{
    public class Product
    {
        public String Name { get; set; }
 
        public virtual User Owner { get; set; }
    }
}
