using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using WebNewsApp.BLL.DTO;
using WebNewsApp.DAL.Models;

namespace WebNewsApp.BLL.Services
{
    public class AutoMapperService
    {
        private static MapperConfiguration userMapperConfig = new MapperConfiguration(cfg => cfg.CreateMap<User, UserDTO>());
        private static MapperConfiguration userDalConfig = new MapperConfiguration(cfg => cfg.CreateMap<UserDTO, User>());
        public static Mapper UserMapper = new Mapper(userMapperConfig);
        public static Mapper UserDalMapper = new Mapper(userDalConfig);
    }
}
