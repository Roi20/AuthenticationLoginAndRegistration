using AuthenticationLoginAndRegistration.Data.Entities;

namespace AuthenticationLoginAndRegistration.Contracts
{
    public interface ITodoRepository
    {

        Task Create(Todo model);

    }
}
