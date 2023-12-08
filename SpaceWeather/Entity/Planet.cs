using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceWeather.Entity
{
    public class Planet:BaseEntity
    {
        private int _CountOfSatellite;

        public Planet(int id, string name, int raidus, int magneticField, int rotationSpeed, int temperature, int humidity, int windSpeed, int pressure, int sunRadiation, int countOfSatellite) : base(id, name, raidus, magneticField, rotationSpeed, temperature, humidity, windSpeed, pressure, sunRadiation)
        {
            _CountOfSatellite = countOfSatellite;
        }

        public Planet()
        {
        }

        public int CountOfSatellite { get => _CountOfSatellite; set => _CountOfSatellite = value; }
    }
}
 