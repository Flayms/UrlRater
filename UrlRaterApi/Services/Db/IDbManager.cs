using UrlRaterApi.Models.DbEntities;

namespace UrlRaterApi.Services.Db {
  public interface IDbManager {
    DbUser[] GetAllUsers();
  }
}
