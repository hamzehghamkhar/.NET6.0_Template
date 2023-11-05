using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace app.Entities.Common
{
    public class CaptchaViewModel
    {
        [NotMapped]
        [HiddenInput]
        [Display(Name = "کد امنیتی")]
        [Required(ErrorMessage = "{0} را وارد نمائید")]
        public virtual string Captcha { get; set; }
    }
}
