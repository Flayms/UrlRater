namespace UrlRaterApi.Models.Entities {
  public class UrlInfo {
    public string Address { get; }
    public int Likes { get; }
    public int Dislikes { get; }

    public UrlInfo(string address, int likes, int dislikes) {
      this.Address = address;
      this.Likes = likes;
      this.Dislikes = dislikes;
    }

    public static UrlInfo Empty(string address) => new UrlInfo(address, 0, 0);
  }
}
