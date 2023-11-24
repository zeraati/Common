namespace Common;
public class JWTInfo
{
    public long UserId { get; set; }
    public string UserName { get; set; }
    public string Mobile { get; set; }
    public int Role { get; set; }
    public int LoginType { get; set; }
    public DateTime ExpirationDate { get; set; }
}
