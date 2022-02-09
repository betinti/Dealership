using System.Text.Json;
using Domain.Models;

namespace Domain.DTO
{
    public abstract class BaseDTO<TModel, TResponse>
      where TModel : BaseModel, new()
      where TResponse : BaseDTO<TModel, TResponse>, new()
    {
        public int? Id { get; set; }


        public virtual TModel ToModel() => new TModel();
        public virtual TModel ToSimpleModel() => new TModel();
        public virtual TResponse FromModel(TModel model) => new TResponse();

        public virtual Dictionary<string, string> ToDictionary()
        {
            var json = JsonSerializer.Serialize(this);
            var dictionary = JsonSerializer.Deserialize<Dictionary<string, string>>(json);
            return dictionary;
        }

    }
}