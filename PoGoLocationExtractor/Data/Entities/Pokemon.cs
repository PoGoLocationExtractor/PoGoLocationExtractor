
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;

namespace PoGoLocationExtractor.Data.Entities
{
    [System.Data.Linq.Mapping.Table(Name = "pokemon")]
    public class Pokemon : ILocation
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [System.Data.Linq.Mapping.Column(Name = "encounter_id")]
        public string Id { get; set; }

        [System.Data.Linq.Mapping.Column(Name = "latitude")]
        public decimal Latitude { get; set; }

        [System.Data.Linq.Mapping.Column(Name = "longitude")]
        public decimal Longitude { get; set; }

        [System.Data.Linq.Mapping.Column(Name = "pokemon_id")]
        public int PokemonNumber { get; set; }

        [NotMapped]
        public string Type { get { return PokemonNumber.ToString(CultureInfo.InvariantCulture); } }
    }
}
