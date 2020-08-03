using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OfficeAuthomation.Domains.Accounts.Users.Repositories;

namespace OfficeAuthomation.Presentation.Areas.AdminPanel.Controllers
{
    [Area("AdminPanel")]
    public class UserManagerController : Controller
    {
        private IUserRepositoryQuery _userRepositoryQuery;

        public UserManagerController(IUserRepositoryQuery userRepositoryQuery)
        {
            _userRepositoryQuery = userRepositoryQuery;
        }



        public IActionResult Index()
        {
            return View();
        }




        [HttpPost]
        public async Task<JsonResult> GetAllUser()
        {
            var data = await _userRepositoryQuery.GetAllUser();
            var total = data.Count;

         

            return Json(new
            {
                data=data,
                total = total

            });
        }


        public async Task<IActionResult> UserDetail(string userId)
        {

            var user = await _userRepositoryQuery.GetUserById(userId);

            if (user==null)
            {
                return NotFound();
            }
           
            return View(user);
        }
    }
}
