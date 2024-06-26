﻿using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyCashIdentityDTOLayer.DTOs.AppUserDTOs
{
    public class AppUserRegisterDTO
    {
        public string name { get; set; }
        public string surname { get; set; }
        public string email { get; set; }
        public string username { get; set; }
        public IFormFile image { get; set; }
        public string password { get; set; }
        public string confirmpassword { get; set; }
    }
}
