using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using Dapper;

//Houses the implementation of the IplantRepository methods
namespace VA_Native_Plants.Models
{
	public class PlantRepository : IPlantRepository
	{
        private IDbConnection _conn;

		public PlantRepository(IDbConnection conn)
		{
            _conn = conn;
		}

        public IEnumerable<Plants> GetAllPlants()
        {
            return _conn.Query<Plants>("SELECT * FROM PLANTS;");
        }
        //Virginia%20Chain%20Fern
        public Plants GetPlants(string id)
        {
           return _conn.QuerySingle<Plants>("SELECT * FROM PLANTS WHERE COMMONNAME = @id", new { id = id });
            
        }

        public void UpdatePlant(Plants plants)
        {
             _conn.Execute("UPDATE plants SET Region = @region, Notes = @notes, Uses = @uses WHERE CommonName = @id",
            new { region = plants.Region, notes = plants.Notes, uses = plants.Uses, id = plants.CommonName });

        }

        public void InsertPlant(Plants plantsToInsert)
        {
            _conn.Execute("INSERT INTO plants (TYPE, COMMONNAME, SCIENTIFICNAME, REGION, USES, LIGHT, MOISTURE, NOTES) VALUES (@type, @CommonName, @scientificname, @region, @uses, @light, @moisture, @notes);",
                new
                {
                    type = plantsToInsert.Type,
                    CommonName = plantsToInsert.CommonName,
                    scientificname = plantsToInsert.ScientificName,
                    region = plantsToInsert.Region,
                    uses = plantsToInsert.Uses,
                    light = plantsToInsert.Light,
                    moisture = plantsToInsert.Moisture,
                    notes = plantsToInsert.Notes
                });
        }

        public IEnumerable<PlantAdd> GetCategories()
        {
            return _conn.Query<PlantAdd>("SELECT * FROM plants;");
        }

        public Plants AssignPlantAdd()
        {
            var plantList = GetCategories();
            var plant = new Plants();
            plant.Categories = plantList;
            return plant;
        }

        public void DeletePlant(Plants plants)
        {
            _conn.Execute("DELETE FROM PLANTS WHERE COMMONNAME = @id;", new { id = plants.CommonName });
        }
    }
}
    
