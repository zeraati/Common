using Telegram.Bot.Types;

namespace Telegram.Bot;
public static partial class UpdateExtention
{
    public static UpdateInfoResult Info(this Update update)
    {
        var result=new UpdateInfoResult();

        if (update.CallbackQuery != null)
        {
            result.ChatId = long.Parse(update.CallbackQuery!.ChatInstance);
            result.Data = update.CallbackQuery.Data ?? "";
        }

        return result;
    }
}

public class UpdateInfoResult
{
    public long ChatId { get;set; }
    public string Data { get; set; } = "";
}
