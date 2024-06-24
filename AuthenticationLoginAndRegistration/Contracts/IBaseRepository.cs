using AuthenticationLoginAndRegistration.Data.Entities;

namespace AuthenticationLoginAndRegistration.Contracts
{
    public interface IBaseRepository<T>
    {

        Task Create(T entity);

        Task<T> GetById(object id);

        Task<IEnumerable<T>>GetAll();

        Task Update(object id, object model);

        Task Delete(object id);

        Task<IEnumerable<T>> GetAllTodo(string userId);

    }
}
