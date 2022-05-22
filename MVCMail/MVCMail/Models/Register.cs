using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVCMail.Models
{
    public class Register
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Boş Geçilemez!")]
        [Display(Name = "İsim Soyİsim")]
        public string FullName { get; set; }

        [Required(ErrorMessage = "Boş Geçilemez!")]
        [Display(Name = "Kullanıcı Adı")]
        public string Username { get; set; }


        [Required(ErrorMessage = "Boş Geçilemez!")]
        [Display(Name = "EPosta")]
        [EmailAddress(ErrorMessage = "Email formatında bir adres girin!")]
        public string Email { get; set; }


        [Required(ErrorMessage = "Boş Geçilemez!")]
        [Display(Name = "Şifre")]
        public string Password { get; set; }

        public Guid ActivationCode { get; set; }
        [DefaultValue("false")]
        public bool IsActive { get; set; }
    }
}