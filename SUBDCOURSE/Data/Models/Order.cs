using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SUBDCOURSE.Data.Models
{
    public class Order
    {
        [BindNever]
        public int Id { get; set; }
        [Display(Name = "Имя")]
        [StringLength(15)]
        [Required(ErrorMessage = "Длина имени не привышает 15 символов")]
        public string Name { get; set; }
        [Display(Name = "Фамилия")]
        [StringLength(20)]
        [Required(ErrorMessage = "Длина фамилии не привышает 20 символов")]
        public string SurName { get; set; }
        [Display(Name = "Адрес")]
        [StringLength(50)]
        [Required(ErrorMessage = "Длина адреса не привышает 50 символов")]
        public string Adress { get; set; }
        [Display(Name = "Email")]
        [DataType(DataType.EmailAddress)]
        [StringLength(30)]
        [Required(ErrorMessage = "Длина email не привышает 30 символов")]
        public string Email { get; set; }
        [Display(Name = "Телефон")]
        [DataType(DataType.PhoneNumber)]
        [StringLength(15)]
        [Required(ErrorMessage = "Длина номера телефона не привышает 15 символов")]
        public string Phone { get; set; }
        [BindNever]
        public DateTime OrderTime { get; set; }
        public List<OrderDetails> OrderDetails { get; set; }
    }
}
