using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninject.Modules;
using WebNewsApp.BLL.Interfaces;
using WebNewsApp.BLL.Services;

namespace WebNewsApp.BLL.Infrastructure
{
    public class NinjectDependency: NinjectModule
    {
        public override void Load()
        {
            Bind<IAuthorizationService>().To<AuthorizationService>();
            Bind<IArticleManagerService>().To<ArticleManagerService>();
            Bind<IUserManagerService>().To<UserManagerService>();
            Bind<IPublishManagerService>().To<PublishManagerService>();
        }
    }
}
