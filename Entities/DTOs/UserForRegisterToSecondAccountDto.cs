﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    public class UserForRegisterToSecondAccountDto:UserForRegisterDto
    {
        public int CompanyId { get; set; }  
    }
}
