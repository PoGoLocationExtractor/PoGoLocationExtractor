using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoGoLocationExtractor.Data
{
    public interface IPoint
    {
        double Latitude { get; set; }
        double Longitude { get; set; }
    }

    public interface ILocation : IPoint
    {
        string Id { get; set; }
        string Type { get; }
    }
}
