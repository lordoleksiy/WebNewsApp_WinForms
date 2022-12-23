using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebNewsApp.DAL;

namespace WebNewsApp.DAL.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Password { get; set; }
        public string Login { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Description { get; set; }
        public DateTime RegisterDate { get; set; }
        public virtual ICollection<Article> Articles { get; set; }
    }
}
