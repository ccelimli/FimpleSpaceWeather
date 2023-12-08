using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.DTO
{
    public class PlanetDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public float Radius { get; set; }
        public int MagneticField { get; set; }
        public int RotationSpeed { get; set; }
        public int Temperature { get; set; }
        public int Humidity { get; set; }
        public int WindSpeed { get; set; }
        public int Pressure { get; set; }
        public int SunRadiation { get; set; }
        public int CountOfSatellite { get; set; }
    }
}
