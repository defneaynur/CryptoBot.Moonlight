# Crypto Price Signal Bot for Telegram

Bu proje, belirli bir kripto paranın fiyatını Binance API'den alıp, Telegram kanalınıza sinyal olarak gönderen bir .NET Console uygulamasıdır.

## Özellikler

- **Kripto Fiyat Alma**: `CryptoSignalService` kullanarak belirlenen kripto paranın güncel fiyatını alır.
- **Telegram Kanalına Mesaj Gönderme**: `Telegram.Bot` kütüphanesi aracılığıyla bir Telegram kanalına kripto fiyat sinyali gönderir.

## Gereksinimler

- .NET Core SDK (6.0 veya üstü)
- [Telegram.Bot](https://github.com/TelegramBots/Telegram.Bot) NuGet paketi
- [CryptoBot.Moonlight.Library](#) gibi kripto fiyat verilerini almak için bir kütüphane

## Kurulum

1. Projeyi klonlayın:
   ```bash
   git clone <repo-link>
   cd <project-directory>
   
2. Gerekli NuGet paketlerini yükleyin:
- dotnet add package Telegram.Bot

4. API anahtarlarını ayarlayın:
- TelegramBotClient için kendi Telegram bot token'inizi kullanın.
- Kripto fiyat verisini alabilmek için CryptoBot.Moonlight.Library içerisindeki API ayarlarınızı yapılandırın.
