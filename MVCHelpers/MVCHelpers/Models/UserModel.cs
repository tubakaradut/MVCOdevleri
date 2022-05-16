using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCHelpers.Models
{
    public class UserModel
    {
        public bool Tea { get; set; }
        public bool Loundry { get; set; }
        public bool Breakfast { get; set; }
        public object SelectTeaType { get; internal set; }
        public object HotelType { get; internal set; }
        public object TeaTypee { get; internal set; }
        public dynamic UserId { get; internal set; }
        public dynamic UserName { get; internal set; }
    }
}