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
    public class CacheRemoveAspect: MethodInterCeption
    {
        private string _pattern;
        private ICacheManager _cacheManager;
        public CacheRemoveAspect(string pattern)
        {
            _pattern=pattern;
            _cacheManager = ServiceTool.serviceProvider.GetService<ICacheManager>();
        }
        protected override void OnSuccess(IInvocation invocation)
        {
          _cacheManager.RemoveByPattern(_pattern);
        }
    }
}
