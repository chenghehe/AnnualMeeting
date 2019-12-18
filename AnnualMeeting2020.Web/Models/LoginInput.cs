using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AnnualMeeting2020.Web.Models
{
    public class LoginInput
    {
        [Required]
        public string UserName { get; set; }

        [Required]
        public string Phone { get; set; }
    }
}