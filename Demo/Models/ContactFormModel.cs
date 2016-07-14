using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Demo.Models
{
    public class ContactFormModel
    {
        [Required, Display(Name = "姓名")]
        public string FromName { get; set; }

        [Required, Display(Name = "Email"), EmailAddress]
        public string FromEmail { get; set; }

        [Required, Display(Name ="內容")]
        public string Message { get; set; }
    }
}