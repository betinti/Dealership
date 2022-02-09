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


        public Car CreateWithCreateds(CarDTO request, int modelId, int accessoryId, int ownerId)
        {
            var car = request.ToSimpleModel();

            car.Model = _lazyService.Get<IModelService>().Get(modelId);

            if (ownerId != 0)
                car.Owner = _lazyService.Get<IOwnerService>().Get(ownerId);

            if (accessoryId != 0)
                car.Accessory = _lazyService.Get<IAccessoryService>().Get(accessoryId);

            return Create(car);
        }

        public override Car Create<CarDTO>(CarDTO request)
        {
            var model = request.ToModel();

            try
            {
                model = _carRepository.Create(model);
            }
            catch (ApplicationException e)
            {
                throw new BaseException("Erro ao criar carro", e);
            }

            if (model == null)
                throw new BaseException("Erro ao criar carro");

            return model;
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

        public List<Car> GetByMileageRange(double startMileage, double endMileage)
        {

            if (startMileage > endMileage)
                throw new BaseException(ErrorType.ParameterError);

            var cars = _carRepository.GetByMileageRange(startMileage, endMileage).ToList();

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

        public List<Car> GetBySystemVersionAndMileage(int systemVersion, double mileage)
        {
            var cars = _carRepository.GetBySystemVersionAndMileage(systemVersion, mileage).ToList();
            if (cars == null) throw new BaseException(ErrorType.AnyFound);
            else if (cars.Count == 0) throw new BaseException(ErrorType.AnyFound);

            return cars;
        }
    }
}