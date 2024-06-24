using AuthenticationLoginAndRegistration.Contracts;
using AuthenticationLoginAndRegistration.Data;
using AuthenticationLoginAndRegistration.Data.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.IdentityModel.Tokens;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using System.Security.Claims;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace AuthenticationLoginAndRegistration.Controllers
{
    
    public class TodoItemController : BaseController
    {
        //private readonly UserManager<AppIdentityUser> _userManager;
        private readonly IBaseRepository<Todo> _repo;
        private readonly ILogger<TodoItemController> _logger;
       
        public TodoItemController(IBaseRepository<Todo> repo, ILogger<TodoItemController> logger) 
        {
            _repo = repo;
            _logger = logger;
           // _userManager = userManager;
        }

        
        public IActionResult Create() 
        {
            
            return View(new Todo());
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Todo item) 
        {

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (userId != null) 
            {
                item.aspUser_Id = userId;
            }

            try
            {
              

                await _repo.Create(item);
                TempData["Message"] = $"{item.Name}, Added to your list";
                return RedirectToAction("Index");

            }
            catch(DbUpdateException ex)
            {

                ModelState.AddModelError("", "An error occured while trying to save your todo item");
                _logger.LogWarning($"Error saving todo: {ex.Message}", ex);
                
                return View(item);
               
            }
            catch(Exception ex) 
            {
                _logger.LogError($"Error: {ex.Message} | StackTrace: {ex.StackTrace}", ex);
                return StatusCode(500, "An unexpected error occured");
               
            }

        }



        public async Task<IActionResult> Index() 
        {

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            
            if(userId != null) 
            {
                var entities = await _repo.GetAllTodo(userId);
                return View(entities);
            }
           
            return NotFound();
            
            
           // var entities = await _repo.GetAll();
           
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(Todo model) 
        {
            try 
            {

                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

                if(userId != null)
                    model.aspUser_Id = userId;
                   
                
                await _repo.Update(model.id, new { model.Name, model.Description, model.Date, model.Time });
                    
                TempData["Message"] = $"{model.Name}, Updated successfully";
                return RedirectToAction("Index");

            }
            catch(DbUpdateException ex) 
            {
                ModelState.AddModelError("", $"Unable to update todo. | Error: {ex.Message} | {ex.StackTrace}");
                _logger.LogWarning($"Unable to save the data on the database. | Exception: {ex.Message} | {ex.StackTrace}");
                return View(model);
                
            }
            catch(Exception ex)
            {
                _logger.LogError($"Exception: {ex.Message} | {ex.StackTrace}");
                throw new Exception($"Exception: {ex.Message} | {ex.StackTrace}");
               
            }

        }

        public async Task<IActionResult> Update(int id) 
        {

            if (!ModelState.IsValid)
            {
                return View();
            }

            var entity = await _repo.GetById(id);
            if(entity == null) 
            {
                return NotFound();
            }

            return View(entity);

        }

        public async Task<IActionResult> Delete(int id) 
        {
            try
            {

                var entity = await _repo.GetById(id);

                if (entity == null)
                {
                    return NotFound();
                }

                return View(entity);
            }
            catch(DbUpdateException ex) 
            {
                _logger.LogWarning($"Unable to delete todo. | Exception: {ex.Message} || StackTrace: {ex.StackTrace}");
                throw new DbUpdateException($"Exception: {ex.Message} | StackTrace {ex.StackTrace}");
            }
            catch(Exception ex) 
            {
                throw new Exception($"Exception {ex.Message} | StackTrace: {ex.StackTrace}");
            }
            
        }

       
        public async Task<IActionResult> ConfirmedDelete(Todo model)
        {
            try 
            {

                await _repo.Delete(model.id);

                TempData["Message"] = $"Deleted successfully";

                return RedirectToAction("Index");


            }
            catch (DbUpdateException ex)
            {
                _logger.LogWarning($"Unable to delete todo. Exception: {ex.Message} | StackTrace: {ex.StackTrace}");
                throw new DbUpdateException($"Exception: {ex.Message} | StackTrace: {ex.StackTrace}");
            }
            catch (Exception ex) 
            {
                throw new Exception($"Exception: {ex.Message}");
            }
           
         
        }
       

    }
}
