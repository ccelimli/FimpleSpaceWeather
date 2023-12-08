using DataAccess;
using DataAccess.Abstract;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SpaceWeather.Entity;
using Entity.DTO;
using AutoMapper;
using Core.Utilities.Results;

public class PlanetInMemoryDal:IPlanetInMemoryDal
{
    private readonly SpaceWeatherContext _context;
    private readonly IMapper _mapper;

    public PlanetInMemoryDal(SpaceWeatherContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public static void InitializeData(IServiceProvider serviceProvider)
    {
        using (var context = new SpaceWeatherContext(serviceProvider.GetRequiredService<DbContextOptions<SpaceWeatherContext>>()))
        {
            if (context.Planets.Any())
            {
                return;
            }

            var planet1 = new Planet(1, "Mars1", 10, 100, 1100, 20, 8, 35, 20, 12,2);
            var planet2 = new Planet(2, "Mars2", 1, 200, 1200, 5, 9, 30, 25, 13,2);

            context.Planets.AddRange(planet1, planet2);
            context.SaveChanges();
        }
    }

    public void Add(PlanetDTO planetDTO)
    {
        var planet = _mapper.Map<Planet>(planetDTO);

        _context.Planets.Add(planet);
        _context.SaveChanges();
    }

    public void Delete(int id)
    {
        Planet delete = _context.Planets.Find(id);

        _context.Planets.Remove(delete);
        _context.SaveChanges();
    }

    public List<PlanetDTO> Filter(int temperature)
    {
        List<Planet> filterList = _context.Planets.Where(p => p.Temperature > temperature).ToList();
        List<PlanetDTO> planetDTOs = _mapper.Map<List<PlanetDTO>>(filterList);
        return planetDTOs;
    }

    public List<PlanetDTO> GetAll()
    {
        var plantList = _context.Planets.OrderBy(p => p.Id).ToList<Planet>();
        List<PlanetDTO> planetDTOList = _mapper.Map<List<PlanetDTO>>(plantList);

        return planetDTOList;
    }

    public PlanetDTO GetById(int id)
    {

        Planet planet = _context.Planets.Find(id);

        PlanetDTO planetDTO = _mapper.Map<PlanetDTO>(planet);

        return planetDTO;
    }

    public List<PlanetDTO> Pagination(int pageNo, int size)
    {
        var paginatedList = _context.Planets.Skip((pageNo - 1) * size) .Take(size);
        List<PlanetDTO> planetDTOs = _mapper.Map<List<PlanetDTO>>(paginatedList);

        return planetDTOs;
    }

    public List<PlanetDTO> SortByNameAsc()
    {
        List<Planet> planetListAsc = _context.Planets.OrderBy(p => p.Name).ToList();
        List<PlanetDTO> planetDTOs = _mapper.Map<List<PlanetDTO>>(planetListAsc);

        return planetDTOs;
    }

    public List<PlanetDTO> SortByNameDesc()
    {
        List<Planet> planetListAsc = _context.Planets.OrderByDescending(p => p.Name).ToList();
        List<PlanetDTO> planetDTOs = _mapper.Map<List<PlanetDTO>>(planetListAsc);

         return planetDTOs;
    }

    public void Update(PlanetDTO planetDTO)
    {
        var planet = _context.Planets.SingleOrDefault(p => p.Id == planetDTO.Id);

        _context.Planets.Remove(planet);

        var planetUpdate = _mapper.Map<Planet>(planetDTO);

        _context.Planets.Add(planetUpdate);
        _context.SaveChanges();
    }
}
