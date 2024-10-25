using Telegram.Bot.Types;

namespace Telegram.Bot;
public static partial class MessageExtention
{
    public static MessageInfoResult Info(this Message message)
    {
        var result = new MessageInfoResult();

        result.ChatId = message.Chat.Id;

        return result;
    }
}

public class MessageInfoResult
{
    public long ChatId { get; set; }
    public string Data { get; set; } = "";
}
