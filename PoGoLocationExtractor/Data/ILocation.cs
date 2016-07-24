using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoGoLocationExtractor.Data
{
    public interface ILocation
    {
        string Id { get; set; }
        decimal Latitude { get; set; }
        decimal Longitude { get; set; }
        string Type { get; }
    }
}
