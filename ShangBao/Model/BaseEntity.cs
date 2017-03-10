using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShangBao.Model
{
    public class BaseEntity
    {
         public int Id { get; set; }

         public DateTime CreateTime { get; set; }
 
         public DateTime UpdateTime { get; set; }
    }
}
