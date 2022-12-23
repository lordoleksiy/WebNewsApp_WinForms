using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using WebNewsApp.BLL.Interfaces;
using WebNewsApp.BLL.Services;

namespace WebNewsApp.BLL.Infrastructure
{
    public class Services
    {
        private static IServiceCollection _services;
        public static IServiceCollection addDependencyInjection()
        {
            _services.AddScoped<IAuthorizationService, AuthorizationService>();
            _services.AddScoped<IArticleManagerService, ArticleManagerService>();
            return _services;
        }
    }
}
