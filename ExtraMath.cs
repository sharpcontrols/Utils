using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpControls.Utils
{
    public static class ExtraMath
    {
        /// <summary>
        /// Calculates the distance between two coordinates in kilometers
        /// </summary>
        /// <param name="lat1">Latitute of first coordinates</param>
        /// <param name="lon1">Longitute of first coordinates</param>
        /// <param name="lat2">Latitute of second coordinates</param>
        /// <param name="lon2">Longitute of second coordinates</param>
        /// <returns>Returns distance in km as double</returns>
        public static double Haversine(double lat1, double lon1, double lat2, double lon2)
        {
            // Convert latitude and longitude from degrees to radians
            double dLat = ToRadians(lat2 - lat1);
            double dLon = ToRadians(lon2 - lon1);
            lat1 = ToRadians(lat1);
            lat2 = ToRadians(lat2);

            // Haversine formula
            double a = Math.Pow(Math.Sin(dLat / 2), 2) +
                       Math.Pow(Math.Sin(dLon / 2), 2) * Math.Cos(lat1) * Math.Cos(lat2);
            double c = 2 * Math.Asin(Math.Sqrt(a));

            // Radius of the Earth in kilometers
            const double R = 6371;

            // Calculate the distance
            return R * c;
        }

        /// <summary>
        /// Converts the angle into radiants
        /// </summary>
        /// <param name="angle"></param>
        /// <returns></returns>
        public static double ToRadians(double angle)
        {
            return Math.PI * angle / 180.0;
        }
    }
}
