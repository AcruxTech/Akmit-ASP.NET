using Akmit.DataAccess.Interfaces;
using Akmit.DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Akmit.DataAccess.Contexts
{
    public class Context : DbContext, IContext
    {
        public Context(DbContextOptions<Context> options) : base(options) { }
        public DbSet<UserRto> Users { get; set; }
        public DbSet<ClassRto> Classes { get; set; }
        public DbSet<DayRto> Days{ get; set; }
        public DbSet<LessonRto> Lessons { get; set; }
    }
}
