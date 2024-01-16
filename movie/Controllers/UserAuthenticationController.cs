using Microsoft.AspNetCore.Mvc;
using movie.Models.DTO;
using movie.Repositories.Abstract;
using System.Diagnostics.Eventing.Reader;

namespace movie.Controllers
{
    public class UserAuthenticationController : Controller
    {
        private IUserAuthenticationService authService;  
        public UserAuthenticationController(IUserAuthenticationService authService)
        {
            this.authService = authService;
        }
        /* we will create a user with admin rights and after that we're gonna comment this method because we need only one user in this app
         if we need other users , we can implement this registration method with view 
         */


        /*public async Task<IActionResult> Register()
        {
            var model = new RegistrationModel
            {
                Email = "admin@gmail.com",
                Username = "admin",
                Name = "faycal",
                Password = "Admin@123",
                PasswordConfirm = "Admin@123",
                Role = "Admin"
            };
            //If I do wanna register as user I need to change role to user
            var result = await authService.RegisterAsync(model);
            return Ok(result.Message);  
        }*/

        public async Task<IActionResult> Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var result = await authService.LoginAsync(model);
            if(result.StatusCode==1)
            {
                return RedirectToAction("Index","Home");
            }
            else
            {
                TempData["msg"] = "SORRY COULD NOT LOGGED IN TRY AGAIN ";
                return RedirectToAction(nameof(Login));
            }
        }

        public async Task<IActionResult> Logout()
        {
             await authService.LogoutAsync();   
             return RedirectToAction(nameof(Login));
        }
    }
}
