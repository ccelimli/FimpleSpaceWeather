using Entity.DTO;
using SpaceWeather.Entity;

namespace DataAccess.Abstract
{
    public interface IPlanetInMemoryDal
    {
        void Add(PlanetDTO planetDTO);
        void Delete(int id);
        void Update(PlanetDTO planetDTO);
        List<PlanetDTO> GetAll();
        PlanetDTO GetById(int id);
        List<PlanetDTO> Pagination(int pageNo, int size);
        List<PlanetDTO> Filter(int temperature);
        List<PlanetDTO> SortByNameAsc();
        List<PlanetDTO> SortByNameDesc();
    }
}
