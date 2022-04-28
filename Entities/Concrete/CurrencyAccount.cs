﻿using Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class CurrencyAccount:IEntity
    {
        [Key]
        public int CurrencyAccountId { get; set; }
        public int CompanyId { get; set; }
        public string Code { get; set; }
        public string CurrencyAccountName { get; set; }
        public string Address { get; set; }
        public string TaxDepartment { get; set; }
        public string? TaxIdNumber { get; set; }
        public string? IdentityNumber { get; set; }
        public string? EMail { get; set; }
        public string? Authorized { get; set; }
        public DateTime AddedAt { get; set; }
        public bool IsActive { get; set; }
    }
}
