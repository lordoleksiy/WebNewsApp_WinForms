using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebNewsApp.BLL.DTO;

namespace WebNewsApp.BLL.Interfaces
{
    public interface IAuthorizationService
    {
        UserDTO Login(string login, string password);
        UserDTO Register(UserDTO user);
    }
}
