using Domain.Enumerations;
using Domain.Exception;
using Domain.Models;

namespace Domain.DTO
{
    public class ModelDTO : BaseDTO<Model, ModelDTO>
    {
        public string Brand { get; set; }
        public int ModelYear { get; set; }
        public int ManufactureYear { get; set; }
        public string ModelDescription { get; set; }
        public string? Engine { get; set; }
        public int? GearsCount { get; set; }
        public int? PassagersCount { get; set; }
        public int? HorsesPower { get; set; }
        public int? GrossWeight { get; set; }

        public override ModelDTO FromModel(Model model)
        {
            if (model == null)
                return null;

            try
            {
                this.Id = model.Id;
                this.Brand = model.Brand;
                this.ModelYear = model.ModelYear;
                this.ManufactureYear = model.ManufactureYear;
                this.ModelDescription = model.ModelDescription;
                this.Engine = model.Engine;
                this.GearsCount = model?.GearsCount;
                this.PassagersCount = model?.PassagersCount;
                this.HorsesPower = model?.HorsesPower;
                this.GrossWeight = model?.GrossWeight;
            }
            catch (ApplicationException e)
            {
                throw new BaseException(ErrorType.ParseError, e);
            }

            return this;
        }

        public override Model ToModel()
        {
            if (this.Brand == null)
                throw new BaseException("The brand of a model is required");

            if (this.ModelYear == null)
                throw new BaseException("The year of a model is required");

            if (this.ManufactureYear == null)
                throw new BaseException("The manufactore year of a model is required");

            if (this.ModelDescription == null)
                throw new BaseException("The description of a model is required");

            return new Model
                {
                    Brand = this.Brand,
                    ModelYear = this.ModelYear,
                    ManufactureYear = this.ManufactureYear,
                    ModelDescription = this.ModelDescription,
                    Engine = this.Engine,
                    GearsCount = this.GearsCount,
                    PassagersCount = this.PassagersCount,
                    HorsesPower = this.HorsesPower,
                    GrossWeight = this.GrossWeight,
                    Id = this.Id.HasValue ? this.Id.Value : 0
                };
        }
    }
}