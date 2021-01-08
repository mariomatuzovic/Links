namespace API.Entities
{
  public class AppUser
  {
    // All of these properties need to be public so EF can get and set these properties
    // Because EF is convention over configuration based we need to call this Id if we want it to be recognized as a primary key
    public int Id { get; set; }
    // ASP.NET Identity uses UserName, not Username so we will stick with the former
    public string UserName { get; set; }
    public byte[] PasswordHash { get; set; }
    public byte[] PasswordSalt { get; set; }
  }
}