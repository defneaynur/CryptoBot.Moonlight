using Binance.Net.Clients;
using CryptoBot.Moonlight.Library.Models.Request;
using CryptoExchange.Net.Authentication;
using System;

public static class CryptoSignalService
{
    private static readonly BinanceRestClient binanceClient;

    // Static constructor for initializing Binance client
    static CryptoSignalService()
    {
        binanceClient = new BinanceRestClient();
    }

    /// <summary>
    /// Gets the price of the specified cryptocurrency.
    /// </summary>
    /// <param name="coinPrice">The coin symbol request model.</param>
    /// <returns>The current price of the cryptocurrency.</returns>
    public static async Task<decimal> GetCoinPriceAsync(CoinPriceRequestModel coinPrice)
    {
        if (string.IsNullOrEmpty(coinPrice.CoinSymbol))
        {
            throw new ArgumentException("Coin symbol cannot be null or empty.", nameof(coinPrice.CoinSymbol));
        }

        var result = await binanceClient.SpotApi.ExchangeData.GetPriceAsync(coinPrice.CoinSymbol);

        if (!result.Success || result.Data == null)
        {
            var errorMessage = result.Error != null
                ? $"API Error: {result.Error.Message}"
                : "API returned an unknown error.";
            throw new Exception(errorMessage);
        }

        return result.Data.Price;
    }
}
