﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebNewsApp.BLL.DTO
{
    public class UserDTO
    {
        public int Id { get; set; }
        public string Password { get; set; }
        public string Login { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Description { get; set; }
        public DateTime RegisterDate { get; set; }
        public IEnumerable<ArticleDTO> ArticleDTOs { get; set; }
    }
}
