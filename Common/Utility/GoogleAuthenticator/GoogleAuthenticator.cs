using Google.Authenticator;

namespace Common;
public static partial class Utility
{
    public static class GoogleAuthenticator
    {
        public static GoogleAuthenticatorDTO Generator(string issuer, string email, Guid? key)
        {
            key ??= Guid.NewGuid();
            var generator = new TwoFactorAuthenticator();
            var setupInfo = generator.GenerateSetupCode(issuer, email, key.ToString(), false, 3);

            var qrCodeImage = setupInfo.QrCodeSetupImageUrl;
            var manualEntryCode = setupInfo.ManualEntryKey;

            var result = new GoogleAuthenticatorDTO(key.Value, qrCodeImage, manualEntryCode);
            return result;
        }

        public static bool Validator(Guid key, string code)
        {
            var validator = new TwoFactorAuthenticator();
            bool result = validator.ValidateTwoFactorPIN(key.ToString(), code);
            return result;
        }
    }
}
