
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PlantMicroservice.Models;
using PlantMicroservice.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlantMicroservice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class PlantController : ControllerBase
    {
        private readonly PlantDbContext _context;

        //public PlantController(PlantDbContext context)
        //{
        //    _context = context;
        //}
        private IPlantRepo _repo;

        public PlantController(IPlantRepo repo, PlantDbContext context)
        {
            _repo = repo;
            _context = context;
        }

        //getpartdetails 
        //[HttpGet("get")]
        //// public async Task<ActionResult<List<PlantReorderDetails>>> ViewPartsReOrder()
        //public async Task<ActionResult<List<PlantReorderDetails>>> ViewPartsReOrder()
        //{

        //    return Ok(await _context.PlantReoDetail.ToListAsync());
        //    //var pl = await _repo.ViewPartsReOrder();
        //    //return Ok(pl);
        //}

        //New Get api
        [HttpGet("getReorder")]
        // public async Task<ActionResult<List<PlantReorderDetails>>> ViewPartsReOrder()
        public async Task<ActionResult<List<Part>>> ViewReOrderDetails()
        {

            //return Ok(await _context.Parts.ToListAsync());
            var pl = await _repo.ViewReOrderDetails();
            return Ok(pl);
        }

        //getstockinhandbyid
        [HttpGet("{PartId}")]
        //public async Task<ActionResult<Part>> ViewStockInHand(int Id)
        public async Task<ActionResult<Part>> ViewStockInHand(int PartId)
        {
            //var stock = await _context.Parts.Where(x => x.PartId == PartId).Select(x => new Part()
            //{
            //    PartId = x.PartId,
            //    PartDescription = x.PartDescription,
            //    PartSpecification = x.PartSpecification,
            //    StockInHand = x.StockInHand
            //}).FirstOrDefaultAsync();
            //if (stock == null)
            //    return BadRequest("Part Id not found.");
            //return Ok(stock);
            var pl1 = await _repo.ViewStockInHand(PartId);
            return Ok(pl1);

        }


        [HttpPut("Putminmax")]
        public async Task<ActionResult<List<ReorderRules>>> UpdateMinMax(updateobj request)
        {
            //var pl2 = await _repo.UpdateMinMax(min, max, id);
            //return pl2;
            try
            {
                List<ReorderRules> reo = _context.ReoRule.ToList();
                List<Demand> dem = _context.Demands.ToList();

                var rec = from r in reo
                          join d in dem on r.PartId equals d.PartId
                          where r.PartId == request.id
                          select d.DemandCount;
                int a = rec.First();

                if (request.min > (.3 * request.max) && request.min <= (.5 * request.max))
                {

                    if (request.max < 0.2 * a)
                    {

                        var dbSup = await _context.ReoRule.FindAsync(request.id);
                        if (dbSup == null)
                            return BadRequest("not found.");
                        dbSup.MinQuantity = request.min;
                        dbSup.MaxQuantity = request.max;

                        await _context.SaveChangesAsync();
                        return Ok(await _context.ReoRule.ToListAsync());
                    }
                }
                return BadRequest();
            }
            catch(Exception ex)
            {
                return NotFound();
            }
            
        }


    }
}

