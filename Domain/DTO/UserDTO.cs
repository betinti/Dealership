using Domain.Enumerations;
using Domain.Exception;
using Domain.Models;

namespace Domain.DTO
{
    public class UserDTO : BaseDTO<User, UserDTO>
    {
        public AddressDTO Address { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public int? Age { get; set; }
        public string Phone { get; set; }
        public int DDD { get; set; }
        public string CpfCnpj { get; set; }
        public DateTime? BirthDate { get; set; }

        public override UserDTO FromModel(User model)
        {
            if (model == null)
                return null;

            try
            {
                this.Id = model.Id;
                this.Address = new AddressDTO().FromModel(model.Address);
                this.Name = model.Name;
                this.Email = model.Email;
                this.Age = model.Age;
                this.Phone = model.Phone;
                this.DDD = model.DDD;
                this.CpfCnpj = model.CpfCnpj;
                this.BirthDate = model.BirthDate;
            }
            catch (ApplicationException e)
            {
                throw new BaseException(ErrorType.ParseError, e);
            }

            return this;
        }

        public override User ToModel()
        {
            return new User
            {
                Address = this.Address.ToModel(),
                Name = this.Name,
                Email = this.Email,
                Age = this.Age,
                Phone = this.Phone,
                DDD = this.DDD,
                CpfCnpj = this.CpfCnpj,
                BirthDate = this.BirthDate
            };
        }
    }
}