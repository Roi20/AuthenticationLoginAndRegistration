using AuthenticationLoginAndRegistration.Contracts;
using AuthenticationLoginAndRegistration.Data.Entities;

namespace AuthenticationLoginAndRegistration.Services
{
    public interface ITodoService
    {
        Task<IEnumerable<Todo>> GetAllTodo(string userId);
        Task<Todo> GetById(object id);
        Task<IEnumerable<Todo>> GetAll();
        
    }
}
