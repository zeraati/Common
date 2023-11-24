namespace Common;
public class GoogleAuthenticatorDTO
{
    public GoogleAuthenticatorDTO(Guid key, string qRCodeImage, string manualEntryCode)
    {
        Key = key;
        QRCodeImage = qRCodeImage;
        ManualEntryCode = manualEntryCode;
    }

    public Guid Key { get; }
    public string QRCodeImage { get; }
    public string ManualEntryCode { get;}
}
