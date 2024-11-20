using Telegram.Bot.Types.ReplyMarkups;

namespace Telegram.Bot;
public static partial class ClientExtention
{
    public static async Task RequestUserContact(this ITelegramBotClient bot, long chatId)
    {
        var button = new KeyboardButton("اشتراک‌گذاری شماره موبایل")
        {
            RequestContact = true
        };

        var replyKeyboardMarkup = new ReplyKeyboardMarkup(new[]
        {new[] { button }}){ResizeKeyboard = true,OneTimeKeyboard = true};

        await bot.SendMessage(
            chatId: chatId,
            text: "برای اشتراگ گذاری دکمه پایین چت را گلیگ کنید",
            replyMarkup: replyKeyboardMarkup
        );
    }
}


