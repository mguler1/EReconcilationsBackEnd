using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    public class UserForRegister:IDto
    {
        public string Name { get; set; }
        public string EMail { get; set; }
        public string Password { get; set; }
    }
}
