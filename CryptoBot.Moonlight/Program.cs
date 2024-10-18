using Telegram.Bot;

var botClient = new TelegramBotClient("8030439322:AAELZT29CNxHadtjejDx6G1yei1gWKrNf6U");
var price =await  CryptoSignalService.GetBitcoinPrice();

// Mesaj göndereceğiniz kanalın ID'sini girin (örneğin @kanal_adı veya kanalın numeric ID'si)
var chatId = "@Test_MoonChannel";
var messageText = "Bu bir kripto sinyali! BTC şu an " + price.ToString();

await botClient.SendTextMessageAsync(
    chatId: chatId,
    text: messageText
);

Console.WriteLine("Mesaj gönderildi.");