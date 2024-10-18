using Binance.Net.Clients;
using CryptoExchange.Net.Authentication;

public static class CryptoSignalService
{
    public static async Task<decimal> GetBitcoinPrice()
    {
        var apiCredentials = new ApiCredentials("vmPUZE6mv9SD5VNHk4HlWFsOr6aKE2zvsw0MuIgwCIPy6utIco14y7Ju91duEh8A",
                                                "NhqPtmdSJYdKjVHjA7PZj4Mge3R5YNiP1e3UZjInClVN65XAbvqqM6A7H5fATj0j");


        using var binanceClient = new BinanceRestClient(options =>
        {
            options.ApiCredentials = apiCredentials;
        });

        var result = await binanceClient.SpotApi.ExchangeData.GetPriceAsync("BTCUSDT");


        if (result.Success)
        {
            return result.Data.Price;
        }
        else
        {
            throw new Exception($"API Error: {result.Error.Message}");
        }
    }
}
