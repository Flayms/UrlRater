using System.Linq;
using Microsoft.EntityFrameworkCore;
using UrlRaterApi.Models.DbEntities;

namespace UrlRaterApi.Services.Db {
  public class DbManager : UrlRaterDbContext {
    public DbManager(DbContextOptions<UrlRaterDbContext> options) : base(options) { }

  }
}
