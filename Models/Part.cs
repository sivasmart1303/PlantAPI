using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PlantMicroservice.Models
{
    public class Part
    {
        [Key]
        public int PartId { get; set; }
        public string PartDescription { get; set; }
        public string PartSpecification { get; set; }
        public int StockInHand { get; set; }
    }
}
