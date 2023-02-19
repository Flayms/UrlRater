using System.ComponentModel.DataAnnotations.Schema;

namespace UrlRaterApi.Models.DbEntities {

  [Table("Url")]
  public class DbUrl {
    public int Id { get; set; }
    public string Address { get; set; }
  }
}
