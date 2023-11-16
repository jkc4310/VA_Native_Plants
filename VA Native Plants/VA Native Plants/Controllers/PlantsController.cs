using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using VA_Native_Plants.Models;

// Implements the methods from the PlantRepository
namespace VA_Native_Plants.Controllers
{
    public class PlantsController : Controller
    {
        private IPlantRepository repo;

        public PlantsController(IPlantRepository repo)
        {
            this.repo = repo;
        }

        // GET: view plants page
        public IActionResult Index()
        {
            var plants = repo.GetAllPlants();

            return View(plants);
        }

        //[HttpGet] View specific plant
        //[Route("Plants/ViewPlant/{commonName:string}")]
        public IActionResult ViewPlant(string id)
        {
            var plants = repo.GetPlants(id);
            return View(plants);
        }

        //update existing plant
        public IActionResult UpdatePlant(string id)
        {
            Plants plants = repo.GetPlants(id);
            if(plants == null)
            {
                return View("PlantNotFound");
            }
            return View(plants);
        }

        //update existing plant to the database
        public IActionResult UpdatePlantToDatabase(Plants plants)
        {
            repo.UpdatePlant(plants);

            return RedirectToAction("ViewPlant", new { id = plants.CommonName });
        }

        //create a new plant
        public IActionResult InsertPlant()
        {
            var plant = repo.AssignPlantAdd();
            return View(plant);
        }

        //create a new plant and insert it into the database
        public IActionResult InsertPlantToDatabase(Plants plantsToInsert)
        {
            repo.InsertPlant(plantsToInsert);
            return RedirectToAction("Index");
        }

        //Delete a plant
        public IActionResult DeletePlant(Plants plants)
        {
            repo.DeletePlant(plants);
            return RedirectToAction("Index");
        }
    }
}

