using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PlantMicroservice.Models
{
    public class PlantReorderDetails
    {
        [ForeignKey("Part")]
        public int PartId { get; set; }
        [Key]
        public int PlantReorderId { get; set; }
        public string PartDetails { get; set; }
        public String ReorderStatus { get; set; }
        public DateTime ReorderDate { get; set; }
    }
}
