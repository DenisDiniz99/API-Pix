namespace WebApi.Models
{
    public abstract class Pix
    {
        public Pix()
        {
            Id = Guid.NewGuid();
            Gui = "br.gov.bcb.pix";
            TransactionCurrency = "986";
            CountryCode = "BR";
            MerchantCategoryCode = "0000";
        }

        public virtual Guid Id {get; init;}
        public virtual string Gui {get; }
        public virtual string TransactionCurrency {get; }
        public virtual string CountryCode {get; }
        public string MerchantCategoryCode {get; }
    }
}