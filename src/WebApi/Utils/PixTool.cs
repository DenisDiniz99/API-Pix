using System.Globalization;
using System.Text;
using WebApi.Models;

namespace WebApi.Utils
{
    public static class PixTool
    {
        private const string ID_PAYLOAD_FORMAT_IDICATOR = "00";
        private const string SIZE_PAYLOAD_FORMAT_IDICATOR = "02";
        private const string VALUE_PAYLOAD_FORMAT_INDICATOR = "01";
        private const string ID_MERCHANT_ACCOUNT_INFORMATION = "26";
        private const string ID_GUI = "00";
        private const string ID_KEY = "01";
        private const string ID_MERCHANT_CATEGORY_CODE = "52";
        private const string ID_TRANSACTION_CURRENCY = "53";
        private const string ID_TRANSACTION_AMOUNT = "54";
        private const string ID_COUNTRY_CODE = "58";
        private const string ID_MERCHANT_NAME = "59";
        private const string ID_MERCHANT_CITY = "60";
        private const string ID_ADDTIONAL_DATA_FIELD_TEMPLATE = "62";
        private const string ID_TXID = "05";
        private const string ID_CRC16 = "63";


        public static string GeneratePix(StaticPix data)
        {
            var fullSize = 0;
            var pix = new StringBuilder();
            var crc = "";

            if (data == null)
                return "";
            
            //Payload format indicator
            pix.Append(ID_PAYLOAD_FORMAT_IDICATOR).Append(SIZE_PAYLOAD_FORMAT_IDICATOR).Append(VALUE_PAYLOAD_FORMAT_INDICATOR);

            //Merchant Account Information
            fullSize = (data.Gui.Length + 4) + (data.Key.Length + 4);
            pix.Append(ID_MERCHANT_ACCOUNT_INFORMATION).Append(string.Format("{0:D2}", fullSize)).Append(ID_GUI).Append(string.Format("{0:D2}", data.Gui.Length)).Append(data.Gui).Append(ID_KEY).Append(string.Format("{0:D2}", data.Key.Length)).Append(data.Key);

            //Merchant Catregory
            pix.Append(ID_MERCHANT_CATEGORY_CODE).Append(string.Format("{0:D2}", data.MerchantCategoryCode.Length)).Append(data.MerchantCategoryCode);

            //Transaction Currency
            pix.Append(ID_TRANSACTION_CURRENCY).Append(string.Format("{0:D2}", data.TransactionCurrency.Length)).Append(data.TransactionCurrency);
            
            //Transaction Amount
            pix.Append(ID_TRANSACTION_AMOUNT).Append(string.Format("{0:D2}", data.Total.ToString().Length)).Append(data.Total.ToString("F2", CultureInfo.InvariantCulture));

            //Country Code
            pix.Append(ID_COUNTRY_CODE).Append(string.Format("{0:D2}", data.CountryCode.Length)).Append(data.CountryCode);

            //Merchant Name
            pix.Append(ID_MERCHANT_NAME).Append(string.Format("{0:D2}", data.MerchantName.Length)).Append(data.MerchantName);

            //Merchant City
            pix.Append(ID_MERCHANT_CITY).Append(string.Format("{0:D2}", data.MerchantCity.Length)).Append(data.MerchantCity);

            //Additional Data Field Template
            pix.Append(ID_ADDTIONAL_DATA_FIELD_TEMPLATE).Append("07").Append("05").Append("03").Append("***");

            //CRC16
            pix.Append(ID_CRC16).Append("04");
            crc = Crc16(pix.ToString());

            pix.Append(crc);

            return pix.ToString();
        }

        
        private static string Crc16(string emv)
        {
            var crc = 0xFFFF;
            var polynomial = 0x1021;
            byte[] bytes = System.Text.Encoding.ASCII.GetBytes(emv);
        
            foreach (byte b in bytes) {
                for (var i = 0; i < 8; i++) {
                    bool bit = ((b >> (7-i) & 1) == 1);
                    bool c15 = ((crc >> 15 & 1) == 1);
                    crc <<= 1;
                    if (c15 ^ bit) 
                        crc ^= polynomial;
                }
            }
            crc &= 0xffff;
            return crc.ToString("X").PadLeft(4, '0');
        }
    }
}