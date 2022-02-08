using Domain.Enumerations;
using Domain.Exception;
using Domain.Models;

namespace Domain.DTO
{
    public class AddressDTO : BaseDTO<Address, AddressDTO>
    {
        public string Street { get; set; }
        public string City { get; set; }
        public string UF { get; set; }
        public string CEP { get; set; }
        public int Number { get; set; }
        public string Complement { get; set; }
        public string Reference { get; set; }


        public override AddressDTO FromModel(Address model)
        {
            if (model == null)
                return null;

            try
            {
                this.Id = model.Id;
                this.Street = model.Street;
                this.City = model.City;
                this.UF = model.UF;
                this.CEP = model.CEP;
                this.Number = model.Number;
                this.Complement = model.Complement;
                this.Reference = model.Reference;
            }
            catch (ApplicationException e)
            {
                throw new BaseException(ErrorType.ParseError, e);
            }

            return this;
        }

        public override Address ToModel()
        {
            return new Address
            {
                Street = this.Street,
                City = this.City,
                UF = this.UF,
                CEP = this.CEP,
                Number = this.Number,
                Complement = this.Complement,
                Reference = this.Reference,
                Id = this.Id.HasValue ? this.Id.Value : 0
            };

        }
    }

}