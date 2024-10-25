using Telegram.Bot;

namespace NozarfBot;
public class Common
{
    public static void SetBot(ref TelegramBotClient bot, TelegramBotClient.OnMessageHandler messageHandler, TelegramBotClient.OnUpdateHandler updateHandler)
    {
        if (bot == null)
        {
            var option = new TelegramBotClientOptions("327072116:q5XWiPLYkQMQlhxuCiKz13kYNVzzdssfZ6tLSySM", "https://tapi.bale.ai/");
            bot = new TelegramBotClient(option);
        }

        bot.OnMessage += messageHandler;
        bot.OnUpdate += updateHandler;
    }

}
