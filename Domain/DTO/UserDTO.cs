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
        public int? DDD { get; set; }
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

        public override User ToSimpleModel()
        {
            if (this.Name == null)
                throw new BaseException("Name is required in user");

            if (this.Email == null)
                throw new BaseException("E-mail is required in user");

            if (this.Phone == null)
                throw new BaseException("Phone is required in user");

            if (!this.DDD.HasValue)
                throw new BaseException("DDD is required in user");

            if (this.CpfCnpj == null)
                throw new BaseException("Cpf or Cnpj is required in user");
            else if (this.CpfCnpj.Length > 18)
                throw new BaseException("Cpf or Cnpj is bigger than 18 characters");
            else if (this.CpfCnpj.Length < 11)
                throw new BaseException("Cpf or Cnpj is lower than 11 characters");

            return new User
            {
                Name = this.Name,
                Email = this.Email,
                Phone = this.Phone,
                DDD = this.DDD.HasValue ? this.DDD.Value : 0,
                CpfCnpj = this.CpfCnpj,
                Id = this.Id.HasValue ? this.Id.Value : 0
            };
        }

        public override User ToModel()
        {
            if (this.Address == null)
                throw new BaseException("Addres is required in user");

            var user = ToSimpleModel();

            user.Address = this.Address.ToModel();
            user.Age = this.Age;
            user.BirthDate = this.BirthDate;

            return user;
        }
    }
}