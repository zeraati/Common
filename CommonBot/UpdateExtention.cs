using Telegram.Bot.Types;

namespace Telegram.Bot;
public static partial class UpdateExtention
{
    public static MessageInfoResult Info(this Update update)
    {
        var result=new MessageInfoResult();

        if (update.CallbackQuery != null)
        {
            result.ChatId = long.Parse(update.CallbackQuery!.ChatInstance);
            result.Data = update.CallbackQuery.Data ?? "";
        }

        return result;
    }
}
