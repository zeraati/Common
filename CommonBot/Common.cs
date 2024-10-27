using Telegram.Bot;

namespace NozarfBot;
public class Common
{
    public static void SetBot(
        ref TelegramBotClient bot, 
        string token,
        TelegramBotClient.OnMessageHandler messageHandler,
        TelegramBotClient.OnUpdateHandler updateHandler)
    {
        if (bot == null)
        {
            var option = new TelegramBotClientOptions(token, "https://tapi.bale.ai/");
            bot = new TelegramBotClient(option);
        }

        bot.OnMessage += messageHandler;
        bot.OnUpdate += updateHandler;
    }

}
