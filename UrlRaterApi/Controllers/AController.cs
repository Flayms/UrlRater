using UrlRaterApi.Services.Db;

namespace UrlRaterApi.Controllers {
  public abstract class AController {

    protected UrlRaterDbContext Context { get; }

    protected AController(UrlRaterDbContext context) {
      this.Context = context;
    }
  }
}
