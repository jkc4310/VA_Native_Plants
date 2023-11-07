using System;
using System.Collections.Generic;


namespace VA_Native_Plants.Models
{
	public interface IPlantRepository
	{
        public IEnumerable<Plants> GetAllPlants();
    }
}

