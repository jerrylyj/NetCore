using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShangBao.Model
{
    public class User:BaseEntity
    {
       public string Name { get; set; }
 
        public long Age { get; set; }
 
         //其它属性...
 
         public virtual ICollection<Product> Products { get; set; }
}
}
