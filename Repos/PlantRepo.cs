using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PlantMicroservice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlantMicroservice.Repos
{
    public class PlantRepo:IPlantRepo
    {
        private readonly PlantDbContext _context;
        public PlantRepo(PlantDbContext context)
        {
            _context = context;
        }
        public async Task<List<Part>> ViewReOrderDetails()
        {
            return await _context.Parts.ToListAsync();
        }



        public async Task<Part> ViewStockInHand(int PartId)
        {
            var stock = await _context.Parts.Where(x => x.PartId == PartId).Select(x => new Part()
            {
                PartId = x.PartId,
                PartDescription = x.PartDescription,
                PartSpecification = x.PartSpecification,
                StockInHand = x.StockInHand
            }).FirstOrDefaultAsync();
            return stock;



        }
        //public async Task<List<ReorderRules>> UpdateMinMax(int min, int max, int Partid)
        //{

        //    List<ReorderRules> reo = _context.ReoRule.ToList();
        //    List<Demand> dem = _context.Demands.ToList();
        //    {
        //        var rec = from r in reo
        //                  join d in dem on r.PartId equals d.PartId
        //                  where r.PartId == Partid
        //                  select d.DemandCount;
        //        int a = rec.First();
                

        //        if (min > (.3 * max) && min <= (.5 * max))
        //        {
                    
        //            if (max < 0.2 *a)
        //            {

        //                var dbSup = await _context.ReoRule.FindAsync(Partid);
        //                if (dbSup == null)
        //                {
        //                    return BadRequest("not found.");
        //                }
        //                else
        //                {
        //                    dbSup.MinQuantity = min;
        //                    dbSup.MaxQuantity = max;

        //                    await _context.SaveChangesAsync();
        //                    return await _context.ReoRule.ToListAsync());
        //                }
        //            }
        //        }
        //        return BadRequest();
        //    }
        //}

    }


}
