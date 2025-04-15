using System.Collections.Generic;
using System.Text.Json;

namespace BankTransferApp
{
    public class BankTransferConfig
    {
        public string lang { get; set; }
        public TransferConfig transfer { get; set; }
        public List<string> methods { get; set; }
        public ConfirmationConfig confirmation { get; set; }

        public class TransferConfig
        {
            public int threshold { get; set; }
            public int low { get; set; }
            public int high_fee { get; set; }
        }

        public class ConfirmationConfig
        {
            public string en { get; set; }
            public string id { get; set; }
        }



        public void loadConfig()
        {

            string jsonString = File.ReadAllText("bank_transfer_config.json");
            BankTransferConfig config = JsonSerializer.Deserialize<BankTransferConfig>(jsonString);

            if (config.lang == "en")
            {
                Console.WriteLine("Please insert the amount of money to transfer:");
            }
            else if (config.lang == "id")
            {
                Console.WriteLine("Masukkan jumlah uang yang akan di-transfer:");
            }
        }
    }
}
 



    