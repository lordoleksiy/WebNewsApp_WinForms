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
        private static MapperConfiguration tagsConfig = new MapperConfiguration(cfg => cfg.CreateMap<ArticleTag, ArticleTagDTO>());
        private static MapperConfiguration categoriesConfig = new MapperConfiguration(cfg => cfg.CreateMap<ArticleCategory, ArticleCategoryDTO>());
        private static MapperConfiguration articleDalConfig = new MapperConfiguration(cfg => cfg.CreateMap<ArticleDTO, Article>()
        .ForPath(a => a.ArticleText.Text, opt=>opt.MapFrom(aDTO => aDTO.Text))
        .ForPath(a => a.Authors, opt=>opt.MapFrom(aDTO => UserMapper.Map<IEnumerable<UserDTO>, IEnumerable<User>>(aDTO.AuthorDTOs)))
        .ForPath(a => a.Tags, opt=>opt.MapFrom(aDTO => TagsMapper.Map<IEnumerable<ArticleTagDTO>, IEnumerable<ArticleTag>>(aDTO.TagDTOs)))
        .ForPath(a => a.Categories, opt=>opt.MapFrom(aDTO => CategoryMapper.Map<IEnumerable<ArticleCategoryDTO>, IEnumerable<ArticleCategory>>(aDTO.CategoryDTOs))));

        private static MapperConfiguration articleConfig = new MapperConfiguration(cfg => cfg.CreateMap<Article, ArticleDTO>()
        .ForMember( a => a.AuthorDTOs, opt => opt.MapFrom(aDTO => UserMapper.Map<IEnumerable<User>, IEnumerable<UserDTO>>(aDTO.Authors)))
        .ForMember( a => a.TagDTOs, opt => opt.MapFrom(aDTO => TagsMapper.Map<IEnumerable<ArticleTag>, IEnumerable<ArticleTagDTO>>(aDTO.Tags)))
        .ForMember( a => a.CategoryDTOs, opt => opt.MapFrom(aDTO => CategoryMapper.Map<IEnumerable<ArticleCategory>, IEnumerable<ArticleCategoryDTO>>(aDTO.Categories)))
        .ForMember( a => a.Text, opt => opt.MapFrom(aDTO => aDTO.ArticleText)));

        public static Mapper UserMapper = new Mapper(userMapperConfig);
        public static Mapper CategoryMapper = new Mapper(categoriesConfig);
        public static Mapper TagsMapper = new Mapper(tagsConfig);
        public static Mapper UserDalMapper = new Mapper(userDalConfig);
        public static Mapper ArticleDalMapper = new Mapper(articleDalConfig);
        public static Mapper ArticleMapper = new Mapper(articleConfig);

    }
}
