using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PlantMicroservice.Models
{
    public class ReorderRules
    {
        public int PartId { get; set; }
        [Key]
        public int ReorderId { get; set; }
        //public int DemandCount { get; set; }

        [ForeignKey("Demand")]
        public int DemandId { get; set; }
        public int MinQuantity { get; set; }
        public int MaxQuantity { get; set; }
        public int ReorderFrequency { get; set; }
    }
}
