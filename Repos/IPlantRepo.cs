using Microsoft.AspNetCore.Mvc;
using PlantMicroservice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlantMicroservice.Repos
{
    public interface IPlantRepo
    {
        Task<List<Part>> ViewReOrderDetails();
        Task<Part> ViewStockInHand(int PartId);
       // Task<string> UpdateMinMax(int min, int max, int Partid);


    }
}
