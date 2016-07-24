using System.Data.Linq;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Text;
using PoGoLocationExtractor.Data.Entities;

namespace PoGoLocationExtractor
{
// ReSharper disable once ClassNeverInstantiated.Global
    class Program
    {
        private static string outputDirectory;
// ReSharper disable once RedundantAssignment
        static void Main(string[] args)
        {
#if DEBUG
            args = new[] {@"C:\Users\Thomas\Downloads\pogom.db", "Output"};
#endif
            var connection = new SQLiteConnection(@"Data Source=" + args[0]);
            outputDirectory = args[1];

            var context = new DataContext(connection);
            var converter = new LocationToKmlConverter();
            WriteGyms(context, converter);
            WritePokemons(context, converter);
        }

        private static void WritePokemons(DataContext context, LocationToKmlConverter converter)
        {
            for (int pokemonNumber = 1; pokemonNumber <= 150; pokemonNumber++)
            {
                int number = pokemonNumber;
                var mons = context.GetTable<Pokemon>().Where(p=>p.PokemonNumber==number);

                if (!mons.Any())
                    continue;

                var text = converter.Convert(mons);

                WriteFile(number.ToString("D3") + ".kml", text);
            }
        }

        private static void WriteGyms(DataContext context, LocationToKmlConverter converter)
        {
            var gyms = context.GetTable<Gym>();
            var text = converter.Convert(gyms);
            WriteFile("Gyms.kml", text);
        }

        private static void WriteFile(string fileName, StringBuilder text)
        {
            using (var stream = File.OpenWrite(OutputPath(fileName)))
            {
                using (var writer = new StreamWriter(stream))
                {
                    writer.Write(text);
                }
            }
        }

        private static string OutputPath(string fileName)
        {
            Directory.CreateDirectory(outputDirectory);
            return Path.Combine(outputDirectory, fileName);
        }

    }
}
