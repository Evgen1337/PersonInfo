using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PeopleInfo.Models
{
    public class UserViewModel
    {
        [Key]
        public int Id { get; set; }

        
        [Required(ErrorMessage = "Введите имя")]
        [StringLength(100)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Введите фамилию")]
        [StringLength(100)]
        public string LastName { get; set; }

        [StringLength(100)]
        public string FatherName { get; set; }

        [RegularExpression(@"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$", 
            ErrorMessage = "Неккоректный адрес электронной почты")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Неккоректный нормер телефона")]
        public string Number { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime BirthDay { get; set; }

        
        public Gender Gender { get; set; }

        [Required(ErrorMessage = "Введите ИНН")]
        public long Inn { get; set; }

    }
}