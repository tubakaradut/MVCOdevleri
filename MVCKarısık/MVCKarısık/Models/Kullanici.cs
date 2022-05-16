using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCKarısık.Models
{
    public class Kullanici
    {
        private readonly List<Cinsiyet> Cinsiyetler = new List<Cinsiyet>
    {
        new Cinsiyet{Id=1,Ad="Erkek"},
        new Cinsiyet{Id=2,Ad="Kadın"},
    };
        public int Id { get; set; }
        public string Username { get; set; }
        public string MedeniDurum { get; set; }
        public string Cinsiyet { get; set; }
        public bool Ehliyet { get; set; }

        public IEnumerable<SelectListItem> CinsiyetSecim
        {
            get
            {
                return new SelectList(Cinsiyetler, "Id", "Ad");
            }

        }
    }
}