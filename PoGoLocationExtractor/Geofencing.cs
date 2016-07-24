using System.Linq;
using PoGoLocationExtractor.Data;

namespace PoGoLocationExtractor
{
    public class Geofencing
    {
        //public bool IsInside(IPoint[] polygon, IPoint point)
        //{
        //    //int sides = polygon.Count() - 1;
        //    //int j = sides - 1;
        //    //bool pointStatus = false;
        //    //for (int i = 0; i < sides; i++)
        //    //{
        //    //    if (polygon[i].Latitude < point.Latitude && polygon[j].Latitude >= point.Latitude ||
        //    //        polygon[j].Latitude < point.Latitude && polygon[i].Latitude >= point.Latitude)
        //    //    {
        //    //        if (polygon[i].Longitude + (point.Latitude - polygon[i].Latitude) /
        //    //            (polygon[j].Latitude - polygon[i].Latitude) * (polygon[j].Longitude - polygon[i].Longitude) < point.Longitude)
        //    //        {
        //    //            pointStatus = !pointStatus;
        //    //        }
        //    //    }
        //    //    j = i;
        //    //}
        //    //return pointStatus;
        //}

        public bool IsPointInPolygon(IPoint[] poly, IPoint point)
        {
            int i, j;
            bool c = false;
            for (i = 0, j = poly.Count() - 1; i < poly.Count(); j = i++)
            {
                if ((((poly[i].Latitude <= point.Latitude) && (point.Latitude < poly[j].Latitude)) 
                        || ((poly[j].Latitude <= point.Latitude) && (point.Latitude < poly[i].Latitude))) 
                        && (point.Longitude < (poly[j].Longitude - poly[i].Longitude) * (point.Latitude - poly[i].Latitude) 
                            / (poly[j].Latitude - poly[i].Latitude) + poly[i].Longitude))

                    c = !c;
                }

            return c;
        }
    }

    public class Point : IPoint
    {
        public Point(double latitude, double longitude)
        {
            Latitude = latitude;
            Longitude = longitude;
        }

        public double Latitude { get; set; }
        public double Longitude { get; set; }

        public override string ToString()
        {
            return string.Format("Lat: {0}, Lng: {1}", Latitude, Longitude);
        }
    }
}   


