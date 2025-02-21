namespace WebApi.Models
{
    public class StaticPix : Pix
    {
        public StaticPix(string key, string merchantName, string merchantCity, decimal total)
        {
            Key = key;
            MerchantName = merchantName;
            MerchantCity = merchantCity;
            Total = total;
        }
        
        public string Key { get; private set; }
        public string MerchantName {get; private set;}
        public string MerchantCity {get; private set;}
        public decimal Total {get; private set;}
    }
}