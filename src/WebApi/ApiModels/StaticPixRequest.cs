namespace WebApi.ApiModels
{
    public class StaticPixRequest
    {
        public string? Key { get;  set; }
        public string? MerchantName {get;  set;}
        public string? MerchantCity {get;  set;}
        public decimal Total {get;  set;}
    }
}