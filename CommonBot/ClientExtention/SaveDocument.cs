using Telegram.Bot.Types;

namespace Telegram.Bot;
public static partial class ClientExtention
{
    public static async Task<string> SaveDocument(this ITelegramBotClient bot, Message message)
    {
        var fileId = message.Document!.FileId;
        var fileInfo = await bot.GetFileAsync(fileId);

        var fileName = fileId + Path.GetExtension(message.Document.FileName);
        var filePath = Path.Combine(Directory.GetCurrentDirectory(), "Document", fileName);
        await using (var fileStream = new FileStream(filePath, FileMode.Create))
        {
            await bot.DownloadFileAsync(fileInfo.FilePath!, fileStream);
        }

        return fileId;
    }
}


