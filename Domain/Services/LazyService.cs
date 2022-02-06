using Domain.Interfaces.Services;

namespace Domain.Services
{
    public class LazyService : ILazyService
    {
        private readonly IServiceProvider provider;

        public LazyService(IServiceProvider provider)
        {
            this.provider = provider;
        }

        public T Get<T>()
            => (T)provider.GetService(typeof(T));
    }
}