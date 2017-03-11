using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ShangBao.Model
{
    public class BaseEntity
    {
        [Key]
        public string Id { get; set; }

         public DateTime CreateTime { get; set; }
 
         public DateTime UpdateTime { get; set; }
    }
}
