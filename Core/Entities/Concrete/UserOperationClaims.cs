using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities.Concrete
{
    public class UserOperationClaims:IEntity
    {
        [Key]
        public int UserOperationClaimsId { get; set; }
        public int UserId { get; set; }
        public int OperationClaimsId { get; set; }
        public int CompanyId { get; set; }
        public DateTime AddedAt { get; set; }
        public bool IsActive { get; set; }
    }
}
