using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCMail.Models
{
    public class UserVM
    {
        [Required(ErrorMessage = "kullanıcı adı boş geçilemez!")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Şifre boş geçilemez!")]

        public string Password { get; set; }
    }
}