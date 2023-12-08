using Core.Utilities.Results;
using Entity.DTO;
using SpaceWeather.Entity;

namespace Business.Abstract
{
    public interface ISatelliteService
    {
        IResult Add(Satellite satellite);
        IResult Delete(int id);
        IResult Update(Satellite satellite);
        IDataResult<List<SatelliteDTO>> GetAll();
        IDataResult<SatelliteDTO> GetById(int id);
        IDataResult<List<SatelliteDTO>> Pagination(int pageNo, int size);
        IDataResult<List<SatelliteDTO>> Filter(int temperature);
        IDataResult<List<SatelliteDTO>> SortByNameAsc();
        IDataResult<List<SatelliteDTO>> SortByNameDesc();
    }
}
