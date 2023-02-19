using Microsoft.AspNetCore.Mvc;
using UrlRaterApi.Models.DbEntities;
using UrlRaterApi.Models.Entities;
using UrlRaterApi.Services.Db;

namespace UrlRaterApi.Controllers {

  [ApiController]
  [Route("[controller]")]
  public class UrlController : AController {
    public UrlController(UrlRaterDbContext context) : base(context) { }

    [HttpGet]
    public UrlInfo GetUrlInfo(string url) => this.Context.GetUrlInfo(url);

    //public void Like(string url, DbUser user) { }
    //public void Dislike(string url, DbUser user) { }

  }
}
