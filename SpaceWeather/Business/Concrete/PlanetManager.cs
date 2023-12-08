using Business.Abstract;
using Business.Constant;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entity.DTO;
using Microsoft.EntityFrameworkCore;
using SpaceWeather.Entity;

namespace Business.Concrete
{
    public class PlanetManager : IPlanetService
    {
        IPlanetInMemoryDal _planetInMemoryDal;

        public PlanetManager(IPlanetInMemoryDal planetInMemoryDal)
        {
            _planetInMemoryDal = planetInMemoryDal;
        }

        public IResult Add(PlanetDTO planetDTO)
        {
            try
            {
                PlanetDTO planet = _planetInMemoryDal.GetById(planetDTO.Id);

                if (planet != null)
                {
                    return new ErrorResult("Bu id'ye sahip bir gezegen zaten var");
                }
                else
                {
                    _planetInMemoryDal.Add(planetDTO);
                    return new SuccessResult(Messages.PlanetAdded);
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
                PlanetDTO planet = _planetInMemoryDal.GetById(id);

                if (planet == null)
                    throw new Exception("Id'ye sahip bir gezegen bulunamadı");

                _planetInMemoryDal.Delete(id);
                return new SuccessResult(Messages.PlanetDeleted);
            }
            catch (Exception ex)
            {
                return new ErrorResult(ex.Message);
            }
        }

        public IDataResult<List<PlanetDTO>> Filter(int temparature)
        {
            try {
                return new SuccessDataResult<List<PlanetDTO>>(_planetInMemoryDal.Filter(temparature), Messages.PlanetsListed);
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<List<PlanetDTO>>(ex.Message);
            }
        }

        public IDataResult<List<PlanetDTO>> GetAll()
        {
            try
            {
                return new SuccessDataResult<List<PlanetDTO>>(_planetInMemoryDal.GetAll(), Messages.PlanetsListed);

            }catch(Exception ex)
            {
                return new ErrorDataResult<List<PlanetDTO>>(ex.Message);
            }
        }

        public IDataResult<PlanetDTO> GetById(int id)
        {
            try
            {
                PlanetDTO planet = _planetInMemoryDal.GetById(id);

                if (planet == null)
                    throw new Exception("Id'ye sahip bir gezegen bulunamadı");

                return new SuccessDataResult<PlanetDTO>(_planetInMemoryDal.GetById(id), Messages.PlanetListed);
            }catch (Exception ex)
            {
                return new ErrorDataResult<PlanetDTO>(ex.Message);
            }
            
        }

        public IDataResult<List<PlanetDTO>> Pagination(int pageNo, int size)
        {
            try
            {
                return new SuccessDataResult<List<PlanetDTO>>(_planetInMemoryDal.Pagination(pageNo, size), Messages.PlanetsListed);

            }catch(Exception ex)
            {
                return new ErrorDataResult<List<PlanetDTO>>(ex.Message);
            }
        }

        public IDataResult<List<PlanetDTO>> SortByNameAsc()
        {
            try
            {
                return new SuccessDataResult<List<PlanetDTO>>(_planetInMemoryDal.SortByNameAsc(), Messages.PlanetsListed);

            }catch(Exception ex)
            {
                return new ErrorDataResult<List<PlanetDTO>>(ex.Message);
            }
        }

        public IDataResult<List<PlanetDTO>> SortByNameDesc()
        {
            try
            {
                return new SuccessDataResult<List<PlanetDTO>>(_planetInMemoryDal.SortByNameDesc(), Messages.PlanetsListed);
            }
            catch (Exception ex)
            {

                return new ErrorDataResult<List<PlanetDTO>>(ex.Message);
            }

        }

        public IResult Update(PlanetDTO planetDTO)
        {
            try
            {
                _planetInMemoryDal.Update(planetDTO);
                return new SuccessResult(Messages.PlanetUpdated);
            }
            catch (Exception ex)
            {
                return new ErrorResult(ex.Message);
            }
        }
    }
}
