using Core.Utilities.Results;
using Entity.DTO;

namespace Business.Abstract
{
    public interface IPlanetService
    {
        IResult Add(PlanetDTO planetDTO);
        IResult Delete(int id);
        IResult Update(PlanetDTO planetDTO);
        IDataResult<List<PlanetDTO>> GetAll();
        IDataResult<PlanetDTO> GetById(int id);
        IDataResult<List<PlanetDTO>> Pagination(int pageNo, int size);
        IDataResult<List<PlanetDTO>> Filter(int temperature);
        IDataResult<List<PlanetDTO>> SortByNameAsc();
        IDataResult<List<PlanetDTO>> SortByNameDesc();
    }
}
