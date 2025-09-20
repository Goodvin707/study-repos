using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.Extensions.DependencyInjection;

namespace WebLabsV05.Services
{
    public static class UrlHelper
    {
        //ActionContext _actionContext;
        static IActionContextAccessor _actionContextAccessor;
        static IUrlHelperFactory _urlHelperFactory;

        //public UrlHelper(IActionContextAccessor contextAccessor,
        //    IUrlHelperFactory urlHelperFactory)
        //{
        //    _actionContextAccessor = contextAccessor;
        //    _urlHelperFactory = urlHelperFactory;
        //}

        public static IUrlHelper GetUrlHelper( IServiceProvider serviceProvider)
        {
            var contextAccessor = serviceProvider.GetRequiredService<IActionContextAccessor>();
            var urlHelperFactory = serviceProvider.GetRequiredService<IUrlHelperFactory>();
            var actionContext = contextAccessor.ActionContext;
            return urlHelperFactory.GetUrlHelper(actionContext);
        }

    }
}
