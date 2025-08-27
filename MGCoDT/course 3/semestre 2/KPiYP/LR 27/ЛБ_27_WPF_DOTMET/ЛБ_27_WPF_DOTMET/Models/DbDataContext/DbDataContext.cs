using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
namespace ЛБ_27_WPF_DOTMET.Models.DbDataContext
{
    class DbDataContext:DbContext
    {
        public DbDataContext() : base("connectionString") { }

        public DbSet<Student> Students { get; set; }
        public DbSet<Session> Sessions { get; set; }
    }
}