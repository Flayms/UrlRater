using System;
using Microsoft.AspNetCore.Mvc;
using UrlRaterApi.Models.DbEntities;
using UrlRaterApi.Services.Db;

namespace UrlRaterApi.Controllers {

  [ApiController]
  [Route("[controller]")]
  public class UserController : AController {
    public UserController(UrlRaterDbContext context) : base(context) { }

    [HttpGet]
    public DbUser Login(string name, string password) {
      if (name.IsNullOrEmpty() || password.IsNullOrEmpty())
        return null;

      var user = name.Contains('@')
        ? this.Context.GetUserByEmail(name, password)
        : this.Context.GetUserByUsername(name, password);

      return user;
    }
  }
}
