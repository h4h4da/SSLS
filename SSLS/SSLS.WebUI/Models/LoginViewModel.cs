﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SSLS.WebUI.Models
{
    public class LoginViewModel
    {
        [Required]
        public int UserName { get; set; }
        [Required]
        public string PassWord { get; set; }

        public string ValidateCode { get; set; }
    }
}