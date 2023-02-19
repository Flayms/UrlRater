using System.ComponentModel.DataAnnotations.Schema;

namespace UrlRaterApi.Models.DbEntities {

  [Table("User")]
  public class DbUser {
    public int Id { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }
    public string Email { get; set; }
  }
}
