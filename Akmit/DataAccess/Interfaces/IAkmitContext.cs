using Akmit.DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Akmit.DataAccess.Interfaces
{
    public interface IAkmitContext : IDisposable, IAsyncDisposable
    {
        DbSet<UserRto> Users { get; set; }
        DbSet<ClassRto> Classes { get; set; }
        DbSet<DayRto> Days { get; set; }
        DbSet<LessonRto> Lessons { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
