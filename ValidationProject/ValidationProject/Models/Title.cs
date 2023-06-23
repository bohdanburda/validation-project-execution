using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValidationProject.Models
{
	internal class Title
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public int ReleaseYear { get; set; }
		public string AgeCertification { get; set; }
		public int Runtime { get; set; }
		public List<string> Genres { get; set; }
		public string ProductionCountry { get; set; }
		public int? Seasons { get; set; } // Nullable to represent "empty for movies"

	}
}
