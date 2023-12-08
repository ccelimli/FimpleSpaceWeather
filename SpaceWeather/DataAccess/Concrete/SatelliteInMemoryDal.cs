using AutoMapper;
using DataAccess.Abstract;
using Entity.DTO;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SpaceWeather.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete
{
    public class SatelliteInMemoryDal : ISatelliteInMemoryDal
    {
        private readonly SpaceWeatherContext _context;
        private readonly IMapper _mapper;

        public SatelliteInMemoryDal(SpaceWeatherContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public static void InitializeData(IServiceProvider serviceProvider)
        {
            using (var context = new SpaceWeatherContext(serviceProvider.GetRequiredService<DbContextOptions<SpaceWeatherContext>>()))
            {
                if (context.Satellites.Any())
                {
                    return;
                }

                var satellite1 = new Satellite(1, "Titan1", 12, 100, 1000, 30, 4, 60, 12, 34, 1, false);
                var satellite2 = new Satellite(2, "Titan2", 11, 200, 1100, 40, 6, 70, 15, 38, 2, true);

                context.Satellites.AddRange(satellite1, satellite2);
                context.SaveChanges();
            }
        }

        public void Add(Satellite satellite)
        {
            //var satellites = _mapper.Map<Satellite>(satellite);

            _context.Satellites.Add(satellite);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            Satellite delete = _context.Satellites.Find(id);

            _context.Satellites.Remove(delete);
            _context.SaveChanges();
        }

        public List<SatelliteDTO> Filter(int temperature)
        {
            List<Satellite> filterList = _context.Satellites.Where(p => p.Temperature > temperature).ToList();
            List<SatelliteDTO> satelliteDTOs = _mapper.Map<List<SatelliteDTO>>(filterList);
            return satelliteDTOs;
        }

        public List<SatelliteDTO> GetAll()
        {
            var list = _context.Satellites.OrderBy(p => p.Id).ToList<Satellite>();
            List<SatelliteDTO> listDTO = _mapper.Map<List<SatelliteDTO>>(list);

            return listDTO;
        }

        public SatelliteDTO GetById(int id)
        {
            Satellite satellite = _context.Satellites.Find(id);

            SatelliteDTO satelliteDTO = _mapper.Map<SatelliteDTO>(satellite);

            return satelliteDTO;
        }

        public List<SatelliteDTO> Pagination(int pageNo, int size)
        {
            var list = _context.Satellites.Skip((pageNo - 1) * size).Take(size);
            List<SatelliteDTO> listDTO = _mapper.Map<List<SatelliteDTO>>(list);

            return listDTO;
        }

        public List<SatelliteDTO> SortByNameAsc()
        {
            List<Satellite> listAsc = _context.Satellites.OrderBy(p => p.Name).ToList();
            List<SatelliteDTO> listDTO = _mapper.Map<List<SatelliteDTO>>(listAsc);

            return listDTO;
        }

        public List<SatelliteDTO> SortByNameDesc()
        {
            List<Satellite> listAsc = _context.Satellites.OrderByDescending(p => p.Name).ToList();
            List<SatelliteDTO> listDTO = _mapper.Map<List<SatelliteDTO>>(listAsc);

            return listDTO;
        }

        public void Update(Satellite satellite)
        {
            var satellites = _context.Satellites.SingleOrDefault(p => p.Id == satellite.Id);

            _context.Satellites.Remove(satellite);

            var update = _mapper.Map<Satellite>(satellite);

            _context.Satellites.Add(update);
            _context.SaveChanges();
        }
    }
}
