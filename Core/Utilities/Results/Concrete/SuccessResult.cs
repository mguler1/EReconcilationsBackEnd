using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Results.Concrete
{
    public class SuccessResult : Result
    {
        public SuccessResult() : base(true)
        {
        }

        public SuccessResult(bool success, string message) : base(true, message)
        {
        }
    }
}
