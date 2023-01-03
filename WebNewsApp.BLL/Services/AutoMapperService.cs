﻿using System;
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
        private static MapperConfiguration articleDalConfig = new MapperConfiguration(cfg => cfg.CreateMap<ArticleDTO, Article>()
        .ForPath(a => a.ArticleText.Text, opt=>opt.MapFrom(aDTO => aDTO.Text))
        .ForPath(a => a.Authors, opt=>opt.MapFrom(aDTO => aDTO.AuthorDTOs))
        .ForPath(a => a.Tags, opt=>opt.MapFrom(aDTO => aDTO.TagDTOs))
        .ForPath(a => a.Categories, opt=>opt.MapFrom(aDTO => aDTO.CategoryDTOs)));
        private static MapperConfiguration articleConfig = new MapperConfiguration(cfg => cfg.CreateMap<Article, ArticleDTO>()
        .ForMember( a => a.AuthorDTOs, opt => opt.MapFrom(aDTO => aDTO.Authors))
        .ForMember( a => a.TagDTOs, opt => opt.MapFrom(aDTO => aDTO.Tags))
        .ForMember( a => a.CategoryDTOs, opt => opt.MapFrom(aDTO => aDTO.Categories))
        .ForMember( a => a.Text, opt => opt.MapFrom(aDTO => aDTO.ArticleText)));
        public static Mapper UserMapper = new Mapper(userMapperConfig);
        public static Mapper UserDalMapper = new Mapper(userDalConfig);
        public static Mapper ArticleDalMapper = new Mapper(articleDalConfig);
        public static Mapper ArticleMapper = new Mapper(articleConfig);
    }
}
