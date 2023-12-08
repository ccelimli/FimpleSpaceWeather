using Entity.DTO;
using SpaceWeather.Entity;

namespace DataAccess.Abstract
{
    public interface ISatelliteInMemoryDal
    {
        void Add(Satellite satellite);
        void Delete(int id);
        void Update(Satellite satellite);
        List<SatelliteDTO> GetAll();
        SatelliteDTO GetById(int id);
        List<SatelliteDTO> Pagination(int pageNo, int size);
        List<SatelliteDTO> Filter(int temperature);
        List<SatelliteDTO> SortByNameAsc();
        List<SatelliteDTO> SortByNameDesc();
    }
}
