using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceWeather.Entity
{
    public class Satellite:BaseEntity
    {
        private int _PlanetId;
        private bool _GeologicalActivity;

        public Satellite(int id, string name, float raidus, int magneticField, int rotationSpeed, int temperature, int humidity, int windSpeed, int pressure, int sunRadiation, int planetId, bool geologicalActivity) : base(id, name, raidus, magneticField, rotationSpeed, temperature, humidity, windSpeed, pressure, sunRadiation)
        {
            PlanetId = planetId;
            GeologicalActivity = geologicalActivity;
        }

        public int PlanetId { get => _PlanetId; set => _PlanetId = value; }
        public bool GeologicalActivity { get => _GeologicalActivity; set => _GeologicalActivity = value; }
    }
}
