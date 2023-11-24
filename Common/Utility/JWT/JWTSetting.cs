namespace Common;
public class JWTSetting
{
    public string Issuer { get; set; }
    public string Audience { get; set; }
    public string Secret { get; set; }
    public string EncryptionKey { get; set; }
}
