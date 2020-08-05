using System;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OfficeAuthomation.Domains.Accounts.Users.Repositories;
using OfficeAuthomation.Domains.Commons;
using OfficeAuthomation.Presentation.Accounts;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using OfficeAuthomation.Domains.Accounts.Users.Commands;
using OfficeAuthomation.Domains.Accounts.Users.Entities;
using OfficeAuthomation.Domains.Enums;
using OfficeAuthomation.Presentation.Utilities;
using Serilog;

namespace OfficeAuthomation.Presentation.Areas.AdminPanel.Controllers
{
    [Area("AdminPanel")]
    public class UserManagerController : Controller
    {
        private readonly IUserRepositoryQuery _userRepositoryQuery;
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        private UserManager<User> _userManager;

        public UserManagerController(IUserRepositoryQuery userRepositoryQuery, IMediator mediator, IMapper mapper, UserManager<User> userManager)
        {
            _userRepositoryQuery = userRepositoryQuery;
            _mediator = mediator;
            _mapper = mapper;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            return View();
        }


        #region AddUser

        [HttpGet]
        public IActionResult AddUser()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddUser(UserViewModel userViewModel, IFormFile ImagePath, IFormFile SignaturePath, string PersianBirthDatePicker, byte gender, byte roleAdmin)
        {

            #region ImagePath

            if (ImagePath == null)
            {
                ModelState.AddModelError("ImagePath", "تصویر را انتخاب نمایید.");
                return View(userViewModel);
            }

            else
            {
                var imageName = Generator.GenerateGuid() + Path.GetExtension(ImagePath.FileName);


                using (var imageStrem = new FileStream(Directory.GetCurrentDirectory() + "/wwwroot/Images//UserAvatar/" + imageName, FileMode.Create))
                {
                    ImagePath.CopyTo(imageStrem);
                }

                userViewModel.ImagePath = imageName;
            }


            #endregion

            #region SignaturePath

            if (SignaturePath == null)
            {
                ModelState.AddModelError("SignaturePath", "امضا را انتخاب نمایید");
            }
            else
            {
                var signatureName = Generator.GenerateGuid() + Path.GetExtension(SignaturePath.FileName);
                using (var signatureStream = new FileStream(Directory.GetCurrentDirectory() + "/wwwroot/Images/Signature/" + signatureName, FileMode.Create))
                {
                    SignaturePath.CopyTo(signatureStream);
                }

                userViewModel.SignaturePath = signatureName;
            }

            #endregion

            #region PersianBirthDatePicker

            if (PersianBirthDatePicker == null)
            {
                ModelState.AddModelError("", "تاریخ تولد را وارد نمایید");

                return View(userViewModel);
            }

            #endregion

            #region Gender

            //if (gender != 1 || gender != 2)
            //{
            //    ModelState.AddModelError("Gender", "جنسیت را انتخاب نمایید");
            //    return View(userViewModel);
            //}


            #endregion

            #region roleAdmin

            //if (roleAdmin != 1 || roleAdmin != 2)
            //{
            //    ModelState.AddModelError("roleAdmin", "نقش را انتخاب نمایید");
            //    return View(userViewModel);
            //}

            #endregion


            var query = new AddUserCommand()
            {
                ImagePath = userViewModel.ImagePath,
                SignaturePath = userViewModel.SignaturePath,
                FirstName = userViewModel.FirstName,
                LastName = userViewModel.LastName,
                UserName = userViewModel.UserName,
                Gender = gender,
                ShamsiBirthDate = PersianBirthDatePicker,
                PersonalCode = userViewModel.PersonalCode,
                PhoneNumber = userViewModel.PhoneNumber,
                Email = userViewModel.Email,
                Address = userViewModel.Address,
                MeliCode = userViewModel.MeliCode,
                RoleAdmin = roleAdmin



            };
            var result = await _mediator.Send(query);
            switch (result)
            {
                case ResultStatusType.failed:
                    return View(userViewModel);
                case ResultStatusType.success:
                    return RedirectToAction("Index", "UserManager");
                default:
                    return View(userViewModel);
            }



        }

        #endregion


        #region GetAllUser

        [HttpPost]
        public async Task<JsonResult> GetAllUser()
        {
            var data = await _userRepositoryQuery.GetAllUser();
            var total = data.Count;



            return Json(new
            {
                data = data,
                total = total

            });
        }

        #endregion


        #region UserDetail

        public async Task<IActionResult> UserDetail(string userId)
        {

            var user = await _userRepositoryQuery.GetUserById(userId);

            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        #endregion


        #region EditUser

        public async Task<IActionResult> EditUser(String userId)
        {
            var user = await _userRepositoryQuery.GetUserById(userId);
            
            if (user == null)
            {
                return BadRequest();
            }

            var userMap = _mapper.Map<UserViewModel>(user);

            return View(userMap);
        }



        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> EditUser(UserViewModel userViewModel, IFormFile ImagePath, IFormFile SignaturePath, string PersianBirthDatePicker, byte gender, byte roleAdmin)
        {
            var user = await _userRepositoryQuery.GetUserById(userViewModel.Id);
            if (user == null)
            {
                Log.ForContext("Message", "کاربری یافت نشد")
                    .Error($"Error: کاربری یافت نشد StatusCode: {404}");
                return NotFound();
            }

            #region ImagePath

            if (ImagePath == null)
            {
                userViewModel.ImagePath = user.ImagePath;
            }

            else
            {
                var imageName = Generator.GenerateGuid() + Path.GetExtension(ImagePath.FileName);


                using (var imageStrem = new FileStream(Directory.GetCurrentDirectory() + "/wwwroot/Images//UserAvatar/" + imageName, FileMode.Create))
                {
                    ImagePath.CopyTo(imageStrem);
                }

                userViewModel.ImagePath = imageName;
            }


            #endregion

            #region SignaturePath

            if (SignaturePath == null)
            {
                userViewModel.SignaturePath = user.SignaturePath;
            }
            else
            {
                var signatureName = Generator.GenerateGuid() + Path.GetExtension(SignaturePath.FileName);
                using (var signatureStream = new FileStream(Directory.GetCurrentDirectory() + "/wwwroot/Images/Signature/" + signatureName, FileMode.Create))
                {
                    SignaturePath.CopyTo(signatureStream);
                }

                userViewModel.SignaturePath = signatureName;
            }

            #endregion

            #region PersianBirthDatePicker

            if (PersianBirthDatePicker == null)
            {
                userViewModel.ShamsiBirthDate = user.ShamsiBirthDate;
            }
            else
            {
                userViewModel.ShamsiBirthDate = PersianBirthDatePicker;
            }
            #endregion

            #region gender

            if (gender == 0)
            {
                userViewModel.Gender = user.Gender;

            }
            else
            {
                userViewModel.Gender = gender;
            }

            #endregion

            #region RoleAdmin

            if (roleAdmin == 0)
            {
                userViewModel.RoleAdmin = user.RoleAdmin;
            }
            else
            {
                userViewModel.RoleAdmin = roleAdmin;
            }

            #endregion

            var userMap = _mapper.Map<EditUserCommand>(userViewModel);
            var result = await _mediator.Send(userMap);

            switch (result)
            {
                case ResultStatusType.failed:
                    return View(userViewModel);
                case ResultStatusType.success:
                    return RedirectToAction("Index");
                default:
                    return View(userViewModel);
            }


        }

        #endregion




        #region ActiveOrDeActiveUser

        public async Task<IActionResult> ActiveOrDeActiveUser(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            ViewBag.status = user.IsActive;
            ViewBag.alert = user.IsActive == true ? "alert-danger" : "alert-primary";
            ViewBag.fullName = user.FirstName + ' ' + user.LastName;
            ViewBag.bgState = user.IsActive == true ? "danger" : "success";
            ViewBag.userId = userId;

            return PartialView("_activeOrDeActive");
        }


        [HttpPost]
        public async Task<IActionResult> ActiveOrDeActive(string userId)
        {

            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                return NotFound();
            }

            user.IsActive = !user.IsActive;
            var result = await _userManager.UpdateAsync(user);
            if (result.Succeeded)
            {
                return RedirectToAction("Index");
            }

            return BadRequest();
        }




        #endregion


    }
}
