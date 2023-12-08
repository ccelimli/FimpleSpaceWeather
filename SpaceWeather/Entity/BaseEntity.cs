using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceWeather.Entity
{
    public class BaseEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        private int _Id;
        private string _Name;
        private float _Raidus;
        private int _MagneticField;
        private int _RotationSpeed;
        private int _Temperature;
        private int _Humidity;
        private int _WindSpeed;
        private int _Pressure;
        private int _SunRadiation;

        public BaseEntity(int id, string name, float raidus, int magneticField, int rotationSpeed, int temperature, int humidity, int windSpeed, int pressure, int sunRadiation)
        {
            _Id = id;
            _Name = name;
            _Raidus = raidus;
            _MagneticField = magneticField;
            _RotationSpeed = rotationSpeed;
            _Temperature = temperature;
            _Humidity = humidity;
            _WindSpeed = windSpeed;
            _Pressure = pressure;
            _SunRadiation = sunRadiation;
        }

        public BaseEntity()
        {
        }

        public int Id { get => _Id; set => _Id = value; }
        public string Name { get => _Name; set => _Name = value; }
        public float Raidus { get => _Raidus; set => _Raidus = value; }
        public int MagneticField { get => _MagneticField; set => _MagneticField = value; }
        public int RotationSpeed { get => _RotationSpeed; set => _RotationSpeed = value; }
        public int Temperature { get => _Temperature; set => _Temperature = value; }
        public int Humidity { get => _Humidity; set => _Humidity = value; }
        public int WindSpeed { get => _WindSpeed; set => _WindSpeed = value; }
        public int Pressure { get => _Pressure; set => _Pressure = value; }
        public int SunRadiation { get => _SunRadiation; set => _SunRadiation = value; }
    }   
}
