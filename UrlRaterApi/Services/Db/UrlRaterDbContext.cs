using System.Linq;
using Microsoft.EntityFrameworkCore;
using UrlRaterApi.Models.DbEntities;
using UrlRaterApi.Models.Entities;

namespace UrlRaterApi.Services.Db {
  public class UrlRaterDbContext : DbContext {

    public UrlRaterDbContext(DbContextOptions<UrlRaterDbContext> options) : base(options) { }

    public DbSet<DbUser> Users { get; set; }
    public DbSet<DbUrl> Urls { get; set; }
    public DbSet<DbUserRating> UserRatings { get; set; }


    public DbUser[] GetAllUsers() => this.Users.ToArray();

    public DbUser GetUserByUsername(string username, string password)
      => this.Users.FirstOrDefault(u => u.Username == username && u.Password == password);
    
    public DbUser GetUserByEmail(string email, string password)
      => this.Users.FirstOrDefault(u => u.Email == email && u.Password == password);

    public UrlInfo GetUrlInfo(string address) {
      var url = this.Urls.FirstOrDefault(u => u.Address == address);

      if (url == null)
        return UrlInfo.Empty(address);

      var allRatings = this.UserRatings.Where(r => r.UrlId == url.Id);
      var amount = allRatings.Count();
      var likes = allRatings.Count(r => r.IsLiked);
      var disLikes = amount - likes;

      return new UrlInfo(url.Address, likes, disLikes);
    }
  }
}
