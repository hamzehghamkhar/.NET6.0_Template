using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace app.Entities.Common
{
    public class BaseEntity<T>
    {
        [Key]
        [Required]
        [HiddenInput]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public virtual T Id { get; set; }
        [HiddenInput]
        public int identity { get; set; } = 0;
        [MaxLength(450, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد")]
        public string creatorId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "فروشگاه پیش فرض")]
        [MaxLength(450, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد")]
        public virtual string shopId { get; set; }
        [DisplayName("تاریخ ثبت")]
        public virtual DateTime createDate { get; set; } = DateTime.Now;
        [HiddenInput]
        [ScaffoldColumn(false)]
        [DisplayName("تاریخ بروزرسانی")]
        public virtual DateTime? lastUpdate { get; set; } = null;
        [HiddenInput]
        [ScaffoldColumn(false)]
        public virtual int year { get; set; } = PersianDateTime.Now.Year;
        [HiddenInput]
        [ScaffoldColumn(false)]
        public virtual int month { get; set; } = PersianDateTime.Now.Month;
        [HiddenInput]
        [ScaffoldColumn(false)]
        public virtual int day { get; set; } = PersianDateTime.Now.Day;
        [DisplayName("منتشر شده")]
        public virtual bool published { get; set; } = true;
        [DisplayName("حذف شده")]
        public bool deleted { get; set; } = false;
        [NotMapped]
        [DisplayName("تاریخ")]
        public DateTime displayDate => this.lastUpdate.HasValue ? this.lastUpdate.Value : this.createDate;
    }
}
