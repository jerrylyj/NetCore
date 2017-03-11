using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ShangBao.Model
{
    public class User:BaseEntity
    {
        [StringLength(50)]
        public string Name { get; set; }
 
        public long Age { get; set; }
 
         //其它属性...
 
         public virtual ICollection<Product> Products { get; set; }
}
}
