using Castle.DynamicProxy;
using Core.Utilities.Interceptons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Core.Extensions.Aspects.Autofact.Transation
{
    public class TransactionScopeAspect:MethodInterCeption
    {
        public override void Intercept(IInvocation invcation)
        {
            using (TransactionScope transactionScope =new TransactionScope())
            {
                try
                {
                    invcation.Proceed();
                    transactionScope.Complete();
                }
                catch (Exception)
                {
                    transactionScope.Dispose();
                    throw;
                }
            }
        }
    }
}
