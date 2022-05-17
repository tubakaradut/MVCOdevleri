using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCNorthWindn.Models
{
    public class Users
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "kullanıcı adı boş geçilemez!")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Şifre boş geçilemez!")]
        public string Password { get; set; }
    }
}