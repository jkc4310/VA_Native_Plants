using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using VA_Native_Plants.Models;

namespace VA_Native_Plants.Controllers
{
    public class PlantsController : Controller
    {
        private IPlantRepository repo;

        public PlantsController(IPlantRepository repo)
        {
            this.repo = repo;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            var plants = repo.GetAllPlants();

            return View(plants);
        }

        //[HttpGet]
        //[Route("Plants/ViewPlant/{commonName:string}")]
        public IActionResult ViewPlant(string id)
        {
            var plants = repo.GetPlants(id);
            return View(plants);
        }

        public IActionResult UpdatePlant(string id)
        {
            Plants plants = repo.GetPlants(id);
            if(plants == null)
            {
                return View("PlantNotFound");
            }
            return View(plants);
        }

        public IActionResult UpdatePlantToDatabase(Plants plants)
        {
            repo.UpdatePlant(plants);

            return RedirectToAction("ViewPlant", new { id = plants.CommonName });
        }

        public IActionResult InsertPlant()
        {
            var plant = repo.AssignPlantAdd();
            return View(plant);
        }

        public IActionResult InsertPlantToDatabase(Plants plantsToInsert)
        {
            repo.InsertPlant(plantsToInsert);
            return RedirectToAction("Index");
        }
    }
}

