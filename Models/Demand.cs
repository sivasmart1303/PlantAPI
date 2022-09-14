using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PlantMicroservice.Models
{
    public class Demand
    {

        [Key]
        public int DemandId { get; set; }

        public int DemandCount { get; set; }
        [ForeignKey("Part")]
        public int PartId { get; set; }
        public DateTime DemandRaisedDate { get; set; }
    }
}
