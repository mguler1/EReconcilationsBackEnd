using Core.Entities;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    public class CompanyDto
    {
        public int UserId { get; set; }
        public Companies Companies { get; set; }
    }
}
