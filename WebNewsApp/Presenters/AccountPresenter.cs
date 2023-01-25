using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebNewsApp.Models;

namespace WebNewsApp.Controllers
{
    public static class AccountPresenter
    {
        private static UserViewModel _account;
        public static void Set(UserViewModel account)
        {
            _account = account;
        }

        public static void Reset()
        {
            _account = null;
        }

        public static UserViewModel Get()
        {
            return _account;
        }
    }
}
