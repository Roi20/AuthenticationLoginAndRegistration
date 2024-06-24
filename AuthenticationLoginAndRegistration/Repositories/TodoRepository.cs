using AuthenticationLoginAndRegistration.Contracts;
using AuthenticationLoginAndRegistration.Data;
using AuthenticationLoginAndRegistration.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace AuthenticationLoginAndRegistration.Repositories
{
    public class TodoRepository :  ITodoRepository
    {
        
        public TodoRepository(ApplicationDbContext db)
        {
           
        }

        public Task Create(Todo model)
        {
            throw new NotImplementedException();
        }
    }
}
