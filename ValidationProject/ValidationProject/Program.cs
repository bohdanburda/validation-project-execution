// Create an instance of the DataGenerator
using CsvHelper;
using System.Globalization;
using ValidationProject;

var dataGenerator = new DataGenerator();

// Generate the Titles and Credits
var titles = dataGenerator.GenerateTitleData();
var credits = dataGenerator.GenerateCreditData();

// Convert the data to CSV and write to file
using (var writer = new StreamWriter("titles.csv"))
using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
{
	csv.WriteRecords(titles);
}

using (var writer = new StreamWriter("credits.csv"))
using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
{
	csv.WriteRecords(credits);
}
