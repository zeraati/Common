using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;

namespace Telegram.Bot;
public static class TelegramBotClientExtension
{
    public static async Task<Message?> SendButton(this ITelegramBotClient bot, SendButtonCommand command)
    {
        //var button = new InlineKeyboardButton(command.Text);
        //var inlineMarkup = new InlineKeyboardMarkup(button);
        var inlineMarkup = new InlineKeyboardMarkup().AddButton(command.Text, command.Data);
        var sent = await bot.SendTextMessageAsync(command.ChatId, command.Title, replyMarkup: inlineMarkup);
        return sent;
    }
}

public record SendButtonCommand(long ChatId, string Title, string Text, string Data);
