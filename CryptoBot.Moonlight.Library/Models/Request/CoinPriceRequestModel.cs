namespace CryptoBot.Moonlight.Library.Models.Request;
public class CoinPriceRequestModel
{
    private string coinSymbol = "BTCUSDT";
    public string CoinSymbol
    {
        get { return coinSymbol; }
        set { coinSymbol = value; }
    }
}

