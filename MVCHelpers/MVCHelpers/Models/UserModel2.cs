using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCHelpers.Models
{
    public class UserModel2
    {
        public TeaType SelectTeaType { get; set; }

        public enum TeaType
        {
            Tea, Coffee, GreenTea, BlackTea
        }
    }
}