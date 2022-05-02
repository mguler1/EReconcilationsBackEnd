
using Castle.DynamicProxy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Interceptons
{
    public class MethodInterCeption:MethodInterceptionBaseAttribute
    {
        protected virtual void OnBefore(IInvocation invocation) { }
        protected virtual void OnAfter(IInvocation invocation) { }
        protected virtual void OnExcepiton(IInvocation invocation,Exception e) { }
        protected virtual void OnSuccess(IInvocation invocation) { }

        public override void Intercept(IInvocation invcation)
        {
            var isSuccess = true;
            OnBefore(invcation);
            try
            {
                invcation.Proceed();
            }
            catch (Exception e)
            {

                isSuccess = false;
                OnExcepiton(invcation, e);
                throw;
            }
            finally
            {
                if (isSuccess)
                {
                    OnSuccess(invcation);
                }
            }
            OnAfter(invcation);
        }
    }
}
