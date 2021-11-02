using System;
using System.Threading.Tasks;
using Events.webui.EmailServices;
using Events.webui.Identity;
using Events.webui.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;


namespace shopapp.webui.Controllers
{
    [AutoValidateAntiforgeryToken]
    public class AccountController:Controller
    {
        private UserManager<User> _userManager;
        private IEmailSender _emailSender;
        private SignInManager<User> _signİnManager;
        public AccountController(UserManager<User> userManager,IEmailSender emailSender, SignInManager<User> signInManager)
        {
           
            _userManager=userManager;
            _emailSender = emailSender;
            _signİnManager = signInManager;
       
        }
        public void CreateMessage(string message, string type)
        {
            var msg = new AlertMessage()
            {
                Message = message,
                AlertType = type,
            };
            TempData["message"] = JsonConvert.SerializeObject(msg);
        }

       
        public IActionResult Login(string ReturnUrl=null)
        {

           return View(new Login()
           {
               ReturnUrl = ReturnUrl
           });
        }

        [HttpPost]
        public async Task<IActionResult> Login(Login model)
        {
            if(!ModelState.IsValid)
            {
                return View(model);
            }
            var user = await _userManager.FindByEmailAsync(model.Email);
            if(user == null)
            {
                ModelState.AddModelError("","Bu kullanıcı adı ile daha önce kayıt oluşturulmammıştır.");
            }
            if(!await _userManager.IsEmailConfirmedAsync(user))
            {
                ModelState.AddModelError("","Lütfen email adresinize gelen onay linkini tıklayınız.");
            }
            var result = await _signİnManager.PasswordSignInAsync(user,model.Password,false,false);
             if(result.Succeeded) 
            {
                return Redirect(model.ReturnUrl??"~/");
            }

            ModelState.AddModelError("","Girilen kullanıcı adı veya parola yanlış");
            return View(model);

        }

        public IActionResult Register()
        {
            return View();
        }
        public async Task<IActionResult> Logout()
        {
            await _signİnManager.SignOutAsync();
            return RedirectToAction("Index","Home");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(Register model)
        {
            if(!ModelState.IsValid)
            {
                return View(model);
            }

            var user = new User()
            {
                Firstname  = model.Name,
                Lastname = model.LastName,
                UserName = model.UserName,
                Email = model.Email    
            };           

            var result = await _userManager.CreateAsync(user,model.Password);
            if(result.Succeeded)
            {
                var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                var url = Url.Action("ConfirmEmail","Account",new {
                    userId = user.Id,
                    token = code    
                });
                Console.Write(url);

                await _emailSender.SendEmailAsync(model.Email,"Hesabınızı onaylayınız.",$"Lütfen email hesabınızı onaylamak için linke <a href='https://localhost:5000{url}'>tıklayınız.</a>");
                return RedirectToAction("Login","Account");
            }           

            ModelState.AddModelError("","Bilinmeyen hata oldu lütfen tekrar deneyiniz.");
            return View(model);
        }
       
        public async Task<IActionResult> ConfirmEmail(string userId,string token)
        {
            if(userId==null || token ==null)
            {
                CreateMessage("Geçersiz token","danger");
                return View();
            }
            var user = await _userManager.FindByIdAsync(userId);
            if(user!=null)
            {
                var result = await _userManager.ConfirmEmailAsync(user,token);
                if(result.Succeeded)
                {
                     CreateMessage("Hesap onaylandı","success");
                   
                    return View();
                }
            }
          
            return View();
        }


   
   
    }
}