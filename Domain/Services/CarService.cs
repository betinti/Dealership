using Domain.Models;
using Domain.Interfaces.Services;
using Domain.Interfaces.Repositories;
using Domain.Exception;
using Domain.Enumerations;
using Domain.DTO;

namespace Domain.Services
{
    public class CarService : BaseService<Car>, ICarService
    {
        private readonly new ICarRepository _carRepository;
        private readonly new ILazyService _lazyService;

        public CarService(ICarRepository repository, ILazyService lazyService) : base(repository)
        {
            _carRepository = repository;
            _lazyService = lazyService;
        }

        public override Car Create<CarDTO>(CarDTO request)
        {
            throw new NotImplementedException();
        }

        public Car UpdateOrCreate(CarDTO car)
        {
            var model = car.ToModel();

            if (!car.Id.HasValue || car.Id.Value == 0)
                _carRepository.Create(model);
            else
                _carRepository.Update(model);

            return model;
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

        public List<Car> GetBySystemVersion(int systemVersion)
        {
            var cars = _carRepository.GetBySystemVersion(systemVersion).ToList();

            if (cars.Count <= 0)
                throw new ArgumentException("Não foram encontrados veículo com tal versão do sistema.");

            return cars;
        }

        public List<Car> GetBySystemVersionRange(int startSystemVersion, int endSystemVersion)
        {
            if (startSystemVersion > endSystemVersion)
                throw new BaseException(ErrorType.ParameterError);

            var cars = _carRepository.GetBySystemVersionRange(startSystemVersion, endSystemVersion).ToList();

            if (cars.Count <= 0)
                throw new BaseException(ErrorType.AnyFound);

            return cars;
        }
    }
}