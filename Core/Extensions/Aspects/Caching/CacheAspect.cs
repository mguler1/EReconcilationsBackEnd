using Castle.DynamicProxy;
using Core.CrossCuttingConcems.Caching;
using Core.Utilities.Interceptons;
using Core.Utilities.IoC;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Extensions.Aspects.Caching
{
    public class CacheAspect:MethodInterCeption
    {
        private int _duration;
        private ICacheManager _cacheManager;
        public CacheAspect(int duration=60)
        {
            _duration = duration;
            _cacheManager=ServiceTool.serviceProvider.GetService<ICacheManager>();
        }
        public override void Intercept(IInvocation invcation)
        {
           var methodName= string.Format($"{invcation.Method.ReflectedType.FullName}.{invcation.Method.Name }");
            var arguments = invcation.Arguments.ToList();
            var key = $"{methodName}({string.Join(", ", arguments.Select(x => x?.ToString() ?? "<Null"))})";
            if (_cacheManager.IsAdd(key))
            {
                invcation.ReturnValue = _cacheManager.Get(key);
                return;
            }
            invcation.Proceed();
            _cacheManager.Add(key, invcation.ReturnValue,_duration);
        }
    }
}
