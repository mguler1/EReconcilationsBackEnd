using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class BaBsReconcilationsDetails:IEntity
    {
        public int BaBsReconcilationsDetailsId { get; set; }
        public int BaBsReconcilationsId { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public decimal Amount { get; set; }
    }
}
