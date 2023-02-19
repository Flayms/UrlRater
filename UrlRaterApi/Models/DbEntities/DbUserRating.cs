using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace UrlRaterApi.Models.DbEntities {

  [Keyless]
  [Table("UserRating")]
  public class DbUserRating {
    public int UrlId { get; set; }
    public int UserId { get; set; }
    public bool IsLiked { get; set; }
  }
}
