using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace app.Entities.Models
{
    public class ApplicationUser : IdentityUser
    {
        /// <summary>
        /// تاریخ عضویت
        /// </summary>
        [Display(Name = "تاریخ عضویت")]
        [Required(ErrorMessage = "{0} را وارد کنید")]
        public DateTime RegisterDate { get; set; } = DateTime.Now;
        /// <summary>
        /// نام
        /// </summary>
        [Display(Name = "نام")]
        [MaxLength(64, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد")]
        [Required(ErrorMessage = "{0} را وارد کنید")]
        public string firstName { get; set; }
        /// <summary>
        /// نام خانوادگی
        /// </summary>
        [Display(Name = "نام خانوادگی")]
        [MaxLength(128, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد")]
        [Required(ErrorMessage = "{0} را وارد کنید")]
        public string lastName { get; set; }
        /// <summary>
        /// ایمیل
        /// </summary>
        [Display(Name = "ایمیل")]
        public override string Email { get => base.Email; set => base.Email = value; }
        /// <summary>
        /// تصویر
        /// </summary>
        [Display(Name = "تصویر")]
        [MaxLength(256, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد")]
        public string avatar { get; set; }
        /// <summary>
        /// موبایل
        /// </summary>
        [Display(Name = "موبایل")]
        [MaxLength(11, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد")]
        public string mobile { get; set; }
        /// <summary>
        /// تلفن
        /// </summary>
        [Display(Name = "تلفن")]
        [MaxLength(11, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد")]
        public override string PhoneNumber { get => base.PhoneNumber; set => base.PhoneNumber = value; }
        /// <summary>
        /// نام کاربری
        /// </summary>
        [Display(Name = "نام کاربری")]
        public override string UserName { get => base.UserName; set => base.UserName = value; }
        /// <summary>
        /// آدرس
        /// </summary>
        [Display(Name = "آدرس")]
        [MaxLength(1024, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد")]
        public string address { get; set; }
        /// <summary>
        /// کدپستی
        /// </summary>
        [Display(Name = "کدپستی")]
        [MaxLength(11, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد")]
        public string postalCode { get; set; }

        [NotMapped]
        [Display(Name = "نام و نام خانوادگی")]
        public string fullName => $"{firstName} {lastName}";
        [NotMapped]
        public string displayAvatar => string.IsNullOrEmpty(this.avatar) ? "/images/avatar.jpg" : this.avatar;

    }
}
