using System;
using System.Collections.Generic;
using System.Data;
using Dapper;

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
    }
}

