using AuthenticationLoginAndRegistration.Data.Entities;
using AuthenticationLoginAndRegistration.Services;
using Microsoft.AspNetCore.Mvc;

namespace AuthenticationLoginAndRegistration.ViewComponents
{
    public class MyModelViewComponent : ViewComponent
    {
        private readonly ITodoService _service;
        public MyModelViewComponent(ITodoService service)
        {
            _service = service;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {

            
            TempData["Message"] = "Create";
            return View();
       

        }
    }
}
