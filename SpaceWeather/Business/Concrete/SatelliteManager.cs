using Business.Abstract;
using Business.Constant;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entity.DTO;
using SpaceWeather.Entity;

namespace Business.Concrete
{
    public class SatelliteManager : ISatelliteService
    {
        ISatelliteInMemoryDal _satelliteInMemoryDal;

        public SatelliteManager(ISatelliteInMemoryDal satelliteInMemoryDal)
        {
            _satelliteInMemoryDal = satelliteInMemoryDal;
        }

        public IResult Add(Satellite satellite)
        {
            try
            {
                SatelliteDTO satellites = _satelliteInMemoryDal.GetById(satellite.Id);

                if (satellite != null)
                {
                    return new ErrorResult("Bu id'ye sahip bir uydu zaten var");
                }
                else
                {
                    _satelliteInMemoryDal.Add(satellite);
                    return new SuccessResult(Messages.SatelliteAdded);
                }
            }
            catch (Exception ex)
            {
                return new ErrorResult(ex.Message);
            }
        }

        public IResult Delete(int id)
        {
            try
            {
                SatelliteDTO satellite = _satelliteInMemoryDal.GetById(id);

                if (satellite == null)
                    throw new Exception("Id'ye sahip bir uydu bulunamadı");

                _satelliteInMemoryDal.Delete(id);
                return new SuccessResult(Messages.SatelliteDeleted);
            }
            catch (Exception ex)
            {
                return new ErrorResult(ex.Message);
            }
        }

        public IDataResult<List<SatelliteDTO>> Filter(int temperature)
        {
            try
            {
                return new SuccessDataResult<List<SatelliteDTO>>(_satelliteInMemoryDal.Filter(temperature), Messages.SatellitesListed);
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<List<SatelliteDTO>>(ex.Message);
            }
        }

        public IDataResult<List<SatelliteDTO>> GetAll()
        {
            try
            {
                return new SuccessDataResult<List<SatelliteDTO>>(_satelliteInMemoryDal.GetAll(), Messages.PlanetsListed);

            }
            catch (Exception ex)
            {
                return new ErrorDataResult<List<SatelliteDTO>>(ex.Message);
            }
        }

        public IDataResult<SatelliteDTO> GetById(int id)
        {
            try
            {
                SatelliteDTO satellite = _satelliteInMemoryDal.GetById(id);

                if (satellite == null)
                    throw new Exception("Id'ye sahip bir uydu bulunamadı");

                return new SuccessDataResult<SatelliteDTO>(_satelliteInMemoryDal.GetById(id), Messages.SatellitesListed);
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<SatelliteDTO>(ex.Message);
            }
        }

        public IDataResult<List<SatelliteDTO>> Pagination(int pageNo, int size)
        {
            try
            {
                return new SuccessDataResult<List<SatelliteDTO>>(_satelliteInMemoryDal.Pagination(pageNo, size), Messages.SatellitesListed);

            }
            catch (Exception ex)
            {
                return new ErrorDataResult<List<SatelliteDTO>>(ex.Message);
            }
        }

        public IDataResult<List<SatelliteDTO>> SortByNameAsc()
        {
            try
            {
                return new SuccessDataResult<List<SatelliteDTO>>(_satelliteInMemoryDal.SortByNameAsc(), Messages.SatellitesListed);

            }
            catch (Exception ex)
            {
                return new ErrorDataResult<List<SatelliteDTO>>(ex.Message);
            }
        }

        public IDataResult<List<SatelliteDTO>> SortByNameDesc()
        {
            try
            {
                return new SuccessDataResult<List<SatelliteDTO>>(_satelliteInMemoryDal.SortByNameDesc(), Messages.SatellitesListed);
            }
            catch (Exception ex)
            {

                return new ErrorDataResult<List<SatelliteDTO>>(ex.Message);
            }
        }

        public IResult Update(Satellite satellite)
        {
            try
            {
                _satelliteInMemoryDal.Update(satellite);
                return new SuccessResult(Messages.SatelliteUpdated);
            }
            catch (Exception ex)
            {
                return new ErrorResult(ex.Message);
            }
        }
    }
}
