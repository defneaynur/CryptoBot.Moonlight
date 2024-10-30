using CryptoBot.Moonlight.Library.Models.Request;
using CryptoExchange.Net.CommonObjects;
using Microsoft.Extensions.Configuration;
using Telegram.Bot;

public class Program
{
    private static IConfiguration configuration;

    public static async Task Main(string[] args)
    {
        configuration = new ConfigurationBuilder()
            .SetBasePath(AppContext.BaseDirectory)
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .Build();

        var botToken = configuration["Telegram:BotToken"];
        var chatId = configuration["Telegram:ChatId"];

        var botClient = new TelegramBotClient(botToken);

        //Coin Symbols
        var coinSymbols = configuration.GetSection("Crypto:CoinSymbols").Get<List<string>>();

        foreach (var symbol in coinSymbols)
        {
            var messageText = await GetPriceCreateMessageAsync(symbol);
            SendMessage(chatId, messageText, botClient, symbol);
        }
    }

    #region Operation methods
    private static async Task<string> GetPriceCreateMessageAsync(string symbol)
    {
        var price = await CryptoSignalService.GetCoinPriceAsync(new CoinPriceRequestModel { CoinSymbol = symbol });
        var messageText = $"Bu bir kripto sinyali! {symbol} şu an {price} USD.";

        return messageText;
    }

    private static async void SendMessage(string? chatId, string? messageText, TelegramBotClient? botClient, string symbol)
    {
        await botClient.SendTextMessageAsync(
              chatId: chatId,
        text: messageText
        );

        Console.WriteLine($"{symbol} için mesaj gönderildi.");
    }
    #endregion

}
