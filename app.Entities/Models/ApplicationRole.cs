using Microsoft.AspNetCore.Identity;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace app.Entities.Models
{
    public class ApplicationRole : IdentityRole
    {
        public ApplicationRole() : base()
        {
        }
        [DisplayName("والد")]
        [MaxLength(450, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد")]
        public string parentId { get; set; } = null;
        [DisplayName("عنوان")]
        public override string Name { get => base.Name; set => base.Name = value; }
        [DisplayName("شرح")]
        public string Descriptions { get; set; }
    }
}
