using Bogus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ValidationProject.Models;

namespace ValidationProject
{
	internal class DataGenerator
	{
		private List<Title>? titles;

		// List of possible values for AgeCertification
		private string[] ageCertifications = new[] { "G", "PG", "PG-13", "R", "NC-17", "U", "U/A", "A", "S", "AL", "6", "9", "12", "12A", "15", "18", "18R", "R18", "R21", "M", "MA15+", "R16", "R18+", "X18", "T", "E", "E10+", "EC", "C", "CA", "GP", "M/PG", "TV-Y", "TV-Y7", "TV-G", "TV-PG", "TV-14", "TV-MA" };

		// List of possible values for Role
		private string[] roles = new[] { "Director", "Producer", "Screenwriter", "Actor", "Actress", "Cinematographer", "Film Editor", "Production Designer", "Costume Designer", "Music Composer" };


		public List<Title> GenerateTitleData() 
		{
			// Define the Fakers
			var titleFaker = new Faker<Title>()
				.RuleFor(t => t.Id, f => f.IndexFaker + 1)
				.RuleFor(t => t.Name, f => f.Lorem.Sentence(3))
				.RuleFor(t => t.Description, f => f.Lorem.Sentence(10))
				.RuleFor(t => t.ReleaseYear, f => f.Random.Int(1950, 2023))
				.RuleFor(t => t.AgeCertification, f => f.PickRandom(ageCertifications))
				.RuleFor(t => t.Runtime, f => f.Random.Int(60, 240))
				.RuleFor(t => t.Genres, f => f.Make(f.Random.Int(1, 3), () => f.Random.Word()).ToList())
				.RuleFor(t => t.ProductionCountry, f => f.Address.CountryCode())
				.RuleFor(t => t.Seasons, f => f.Random.Int(0, 10));

			// Generate Titles
			titles = titleFaker.Generate(100);

			return titles;
		}

		public List<Credit> GenerateCreditData() 
		{
			// Now generate Credits using these Titles
			var creditFaker = new Faker<Credit>()
				.RuleFor(c => c.Id, f => f.IndexFaker + 1)
				.RuleFor(c => c.TitleId, f => f.PickRandom(titles).Id)
				.RuleFor(c => c.RealName, f => f.Name.FullName())
				.RuleFor(c => c.CharacterName, f => f.Name.FullName())
				.RuleFor(c => c.Role, f => f.PickRandom(roles));

			List<Credit> credits = creditFaker.Generate(500); // Assuming each Title may have multiple Credits

			return credits;
		}
	}
}
