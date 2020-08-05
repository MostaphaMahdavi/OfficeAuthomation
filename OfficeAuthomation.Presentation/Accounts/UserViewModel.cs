using System;
using System.ComponentModel.DataAnnotations;

namespace OfficeAuthomation.Presentation.Accounts
{
    public class UserViewModel
    {
        [Display(Name = "نام کاربری")]
        public string Id { get; set; }

        [Display(Name = "نام")]
        [Required(ErrorMessage = "فیلد {0} اجباری می باشد")]
        [MaxLength(150, ErrorMessage = "طول فیلد {0} باید حداکثر {1} باشد")]
        public string FirstName { get; set; }

        [Display(Name = "نام خانوادگی")]
        [Required(ErrorMessage = "فیلد {0} اجباری می باشد")]
        [MaxLength(150, ErrorMessage = "طول فیلد {0} باید حداکثر {1} باشد")]
        public string LastName { get; set; }

        [Display(Name = "کد پرسنلی")]
        [Required(ErrorMessage = "فیلد {0} اجباری می باشد")]
        [MaxLength(10, ErrorMessage = "طول فیلد {0} باید  {1} باشد")]
        [MinLength(10, ErrorMessage = "طول فیلد {0} باید  {1} باشد")]
        public string PersonalCode { get; set; }
        [Display(Name = "کد ملی")]
        [Required(ErrorMessage = "فیلد {0} اجباری می باشد")]
        [MaxLength(10, ErrorMessage = "طول فیلد {0} باید  {1} باشد")]
        [MinLength(10, ErrorMessage = "طول فیلد {0} باید  {1} باشد")]
        public string MeliCode { get; set; }

        [Display(Name = "آدرس")]
        [Required(ErrorMessage = "فیلد {0} اجباری می باشد")]
        [MaxLength(1000, ErrorMessage = "طول فیلد {0} باید حداکثر {1} باشد")]
        public string Address { get; set; }

      

        [Display(Name = "تاریخ تولد ")]
        [Required(ErrorMessage = "فیلد {0} اجباری می باشد")]
        [MaxLength(10, ErrorMessage = "طول فیلد {0} باید حداکثر {1} باشد")]
        public string ShamsiBirthDate { get; set; }

        [Display(Name = "جنسیت")]
        [Required(ErrorMessage = "فیلد {0} اجباری می باشد")]
        public byte Gender { get; set; }

        [Display(Name = "تصویر کاربر")]
        public string ImagePath { get; set; }

        [Display(Name = "امصا کاربر")]
        public string SignaturePath { get; set; }

         [Display(Name = "فعال/غیرفعال")]
        public byte IsActive { get; set; }


        [Display(Name = "ایمیل")]
        [Required(ErrorMessage = "فیلد {0} اجباری می باشد")]
        [MaxLength(100, ErrorMessage = "طول فیلد {0} باید حداکثر {1} باشد")]
        [EmailAddress(ErrorMessage = "ایمیل وارد شده اشتباه است")]
        public string Email { get; set; }

        [Display(Name = "موبایل")]
        [Required(ErrorMessage = "فیلد {0} اجباری می باشد")]
        [MaxLength(11, ErrorMessage = "طول فیلد {0} باید {1} باشد")]
        [MinLength(11, ErrorMessage = "طول فیلد {0} باید {1} باشد")]
        public string PhoneNumber { get; set; }

        [Display(Name = "نام کاربری")]
        [Required(ErrorMessage = "فیلد {0} اجباری می باشد")]
        [MaxLength(50, ErrorMessage = "طول فیلد {0} باید حداکثر {1} باشد")]
        public string UserName { get; set; }

        [Display(Name = "نقش کاربر")]
        public byte RoleAdmin { get; set; }

    }
}