using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;

namespace Telegram.Bot;
public static partial class ClientExtention
{
    public static async Task<Message?> SendButton(this ITelegramBotClient bot, ButtonCommand sendButtonCommand)
    {
        var inlineMarkup = new InlineKeyboardMarkup();
        foreach (var buttonCommand in sendButtonCommand.ButtonCommands)
        {
            inlineMarkup
                .AddButton(buttonCommand.Text, buttonCommand.Data)
                .AddNewRow();
        }

        var sent = await bot.SendTextMessageAsync(sendButtonCommand.ChatId, sendButtonCommand.Title, replyMarkup: inlineMarkup);
        return sent;
    }

    public static async Task<Message?> SendRealButton(this ITelegramBotClient bot, ButtonCommand sendButtonCommand)
    {
        var replyMarkup = new ReplyKeyboardMarkup(true);
        foreach (var buttonCommand in sendButtonCommand.ButtonCommands)
        {
            replyMarkup.AddButton(buttonCommand.Text);
        }

        var sent = await bot.SendTextMessageAsync(sendButtonCommand.ChatId,sendButtonCommand.Title, replyMarkup: replyMarkup);
        return sent;
    }



}

public record ButtonCommand(long ChatId, string Title, ButtonEnumItem[] ButtonCommands);
public record ButtonEnumItem(string Text, string Data);