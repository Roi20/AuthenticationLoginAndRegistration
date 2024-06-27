using AuthenticationLoginAndRegistration.Data;
using AuthenticationLoginAndRegistration.Data.Entities;
using AuthenticationLoginAndRegistration.Services;
using Microsoft.EntityFrameworkCore;

namespace AuthenticationLoginAndRegistration.TodoService
{
    public class TodoService : ITodoService
    {
        private readonly DbContext _db;
        private readonly DbSet<Todo> _table;


        public TodoService(ApplicationDbContext db)
        {
            _db = db;
            _table = _db.Set<Todo>();

        }

        public async Task<IEnumerable<Todo>> GetAll()
        {
            try
            {
                return await _table.ToListAsync();
            }
            catch
            {
                throw new Exception($"An error occured while trying to fetch all data.");
            }
        }

        public async Task<Todo> GetById(object id)
        {
            try
            {
                return await _table.FindAsync(id);
            }
            catch
            {
                throw new Exception("An error occured while trying to fetch data.");
            }
        }

       
        public async Task<IEnumerable<Todo>> GetAllTodo(string userId)
        {
            return await _table.Where(x => x.aspUser_Id == userId).ToListAsync();
        }

    }
}
