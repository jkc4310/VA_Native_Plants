using System;
using System.Collections.Generic;


namespace VA_Native_Plants.Models
{
	public interface IPlantRepository
	{
        public IEnumerable<Plants> GetAllPlants();

        public Plants GetPlants(string commonName);

        public void UpdatePlant(Plants plants);

        public void InsertPlant(Plants plantsToInsert);

        public IEnumerable<PlantAdd> GetCategories();

        public Plants AssignPlantAdd();
    }
}

