using Akmit.DataAccess.Interfaces;
using Akmit.DataAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace Akmit.DataAccess.Contexts
{
    public class AkmitContext : DbContext, IAkmitContext
    {
        public AkmitContext(DbContextOptions<AkmitContext> options) : base(options) { }
        public DbSet<UserRto> Users { get; set; }
        public DbSet<ClassRto> Classes { get; set; }
        public DbSet<DayRto> Days{ get; set; }
        public DbSet<LessonRto> Lessons { get; set; }
    }
}
