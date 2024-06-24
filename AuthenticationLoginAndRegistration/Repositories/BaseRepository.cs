using AuthenticationLoginAndRegistration.Contracts;
using AuthenticationLoginAndRegistration.Data;
using AuthenticationLoginAndRegistration.Data.Entities;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Data.Common;
using System.Security.Claims;


namespace AuthenticationLoginAndRegistration.Repositories
{

    public class BaseRepository<T> : IBaseRepository<T>
        where T: class, IBaseModel
    {

        private readonly DbContext _db;
        private readonly DbSet<T> _table;
       

        public BaseRepository(ApplicationDbContext db)
        {
            _db = db;
            _table = _db.Set<T>();
           
        }


        public async Task Create(T entity)
        {
            try
            {
                await _table.AddAsync(entity);
                await _db.SaveChangesAsync();
            }
            catch(DbUpdateException ex) 
            {
                throw;
            }
          
        }

       

        public async Task<IEnumerable<T>> GetAll()
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

        public async Task<T> GetById(object id)
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

        public async Task Update(object id, object model)
        {
            try 
            {
                var t = await GetById(id);

                if(t != null) 
                {
                    _db.Entry(t).CurrentValues.SetValues(model);
                    await _db.SaveChangesAsync();
                }

            }
            catch(DbUpdateException)
            {
                throw;
            }
        }

        public async Task Delete(object id)
        {
            try 
            {
                var t = await GetById(id);
                if(t != null) 
                {
                    _table.Remove(t);
                    await _db.SaveChangesAsync();
                }
            }
            catch(DbUpdateException)
            {
                throw;
            }
        }

        
        public async Task<IEnumerable<T>> GetAllTodo(string userId)
        {
            return await _table.Where(x => x.aspUser_Id == userId).ToListAsync();
        }
        
    }
}
