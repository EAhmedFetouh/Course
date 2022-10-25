using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TranningApp.API.Dtos
{
    public class UserRegisterDto
    {
        [Required (ErrorMessage ="لابد من ادخال اسم المستخدم")]
        public string  UserName { get; set; }

        [MaxLength(8,ErrorMessage ="لابد ان لا تزيد كلمة المرور عن 8 احرف وارقام")]
       
        [Required (ErrorMessage ="لابد من ادخال كلمة المرور")]
        public string Password { get; set; }
    }
}