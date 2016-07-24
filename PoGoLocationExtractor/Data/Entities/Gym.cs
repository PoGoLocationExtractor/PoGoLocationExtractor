using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PoGoLocationExtractor.Data.Entities
{
    [System.Data.Linq.Mapping.Table(Name="gym")]
    public class Gym : ILocation
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [System.Data.Linq.Mapping.Column(Name = "gym_id")]
        public string Id { get; set; }

        [System.Data.Linq.Mapping.Column(Name = "latitude")]
        public decimal Latitude { get; set; }

        [System.Data.Linq.Mapping.Column(Name = "longitude")]
        public decimal Longitude { get; set; }

        [NotMapped]
        public string Type { get { return "Gym"; }}
    }
}
