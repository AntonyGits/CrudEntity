using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudEntity
{
    public class Presidents
    {
        public int PresidentId { get; set; }
        [StringLength(255)]
        public string FullName { get; set; }
        [StringLength(255)]
        public string Birhsday { get; set; }
        [StringLength(255)]
        public string Data { get; set; }
        [StringLength(255)]
        public string Country { get; set; }
        [StringLength(255)]
        public string ImagePhoto { get; set; }
        public string ImageFlags { get; set; }
        
        public int ObjectState { get; set; }
     
     } 
}
