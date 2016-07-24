using System;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
using System.Globalization;
using System.Text;
using PoGoLocationExtractor.Data;

namespace PoGoLocationExtractor
{
    public class LocationToKmlConverter
    {
        public StringBuilder Convert(IEnumerable<ILocation> locations)
        {
            var result = new StringBuilder();
            AddHeader(result);
            foreach (var loc in locations)
            {
                AddPlacemark(result, loc);
            }
            AddFooter(result);
            return result;
        }

        private void AddHeader(StringBuilder result)
        {
            result.AppendLine("<?xml version=\"1.0\" encoding=\"UTF-8\"?>");
            result.AppendLine("<kml xmlns=\"http://www.opengis.net/kml/2.2\">");
            result.AppendLine("<Document>");
        }

        private static void AddPlacemark(StringBuilder result, ILocation location)
        {
            result.AppendLine("<Placemark>");
            result.AppendFormat("<name>{0}</name>{1}", location.Type, Environment.NewLine);
            result.AppendFormat("<description>{0}</description>{1}", location.Id, Environment.NewLine);
            result.AppendLine("<Point>");
            result.AppendFormat("<coordinates>{0},{1}</coordinates>{2}",
                System.Convert.ToString(location.Longitude, CultureInfo.InvariantCulture),
                System.Convert.ToString(location.Latitude, CultureInfo.InvariantCulture),
                Environment.NewLine);
            result.AppendLine("</Point>");
            result.AppendLine("</Placemark>");
        }

        private void AddFooter(StringBuilder result)
        {
            result.AppendLine("</Document>");
            result.AppendLine("</kml>");
        }
    }
}
