using Domain.Models;
using Domain.Interfaces.Services;
using Domain.Interfaces.Repositories;
using Domain.Exception;
using Domain.Enumerations;

namespace Domain.Services
{
    public class CarService : BaseService<Car>, ICarService
    {
        private readonly new ICarRepository _carRepository;

        public CarService(ICarRepository repository) : base(repository)
        {
            _carRepository = repository;
        }

        public List<Car> GetByMileage(double mileage)
        {
            var cars = _carRepository.GetByMileage(mileage).ToList();

            if (cars.Count <= 0)
                throw new BaseException(ErrorType.AnyFound);

            return cars;
        }

        public List<Car> GetByMileageRange(double startMiliage, double endMiliage)
        {

            if (startMiliage > endMiliage)
                throw new BaseException(ErrorType.ParameterError);

            var cars = _carRepository.GetByMileageRange(startMiliage, endMiliage).ToList();

            if (cars.Count <= 0)
                throw new BaseException(ErrorType.AnyFound);

            return cars;
        }

        public List<Car> GetBySistemVersion(int sistemVersion)
        {
            var cars = _carRepository.GetBySistemVersion(sistemVersion).ToList();

            if (cars.Count <= 0)
                throw new ArgumentException("Não foram encontrados veículo com tal versão do sistema.");

            return cars;
        }

        public List<Car> GetBySistemVersionRange(int startSistemVersion, int endSistemVersion)
        {
            if (startSistemVersion > endSistemVersion)
                throw new BaseException(ErrorType.ParameterError);

            var cars = _carRepository.GetBySistemVersionRange(startSistemVersion, endSistemVersion).ToList();

            if (cars.Count <= 0)
                throw new BaseException(ErrorType.AnyFound);

            return cars;
        }
    }
}