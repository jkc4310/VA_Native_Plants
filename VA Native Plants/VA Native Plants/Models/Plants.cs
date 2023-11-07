using System;
namespace VA_Native_Plants.Models
{
	public class Plants
	{
		public Plants()
		{
		}

		public string? Type { get; set; }
        public string? CommonName { get; set; }
        public string? ScientificName { get; set; }
        public string? Region { get; set; }
        public string? Uses { get; set; }
        public string? Light { get; set; }
        public string? Moisture { get; set; }
        public string? Notes { get; set; }

    }
}

