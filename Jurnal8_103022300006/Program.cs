using System;
using System.IO;
using System.Text.Json;
using System.Globalization;

namespace BankTransferApp
{
    class Program
    {
        static void Main(string[] args)
        {
            BankTransferConfig config   = new BankTransferConfig();
            config.loadConfig();


            int transferAmount = int.Parse(Console.ReadLine());

            
            int transferFee = transferAmount <= config.transfer.threshold ? config.transfer.low : config.transfer.high_fee;
            int totalAmount = transferAmount + transferFee;

         
            if (config.lang == "en")
            {
                Console.WriteLine($"Transfer fee = {transferFee}");
                Console.WriteLine($"Total amount = {totalAmount}");
            }
            else if (config.lang == "id")
            {
                Console.WriteLine($"Biaya transfer = {transferFee}");
                Console.WriteLine($"Total biaya = {totalAmount}");
            }

    
            if (config.lang == "en")
            {
                Console.WriteLine("Select transfer method:");
            }
            else if (config.lang == "id")
            {
                Console.WriteLine("Pilih metode transfer:");
            }

            for (int i = 0; i < config.methods.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {config.methods[i]}");
            }

          
            int methodChoice = int.Parse(Console.ReadLine());

           
            if (config.lang == "en")
            {
                Console.WriteLine($"Please type \"{config.confirmation.en}\" to confirm the transaction:");
            }
            else if (config.lang == "id")
            {
                Console.WriteLine($"Ketik \"{config.confirmation.id}\" untuk mengkonfirmasi transaksi:");
            }

            string confirmationInput = Console.ReadLine();

     
            if ((config.lang == "en" && confirmationInput == config.confirmation.en) ||
                (config.lang == "id" && confirmationInput == config.confirmation.id))
            {
                if (config.lang == "en")
                {
                    Console.WriteLine("The transfer is completed");
                }
                else if (config.lang == "id")
                {
                    Console.WriteLine("Proses transfer berhasil");
                }
            }
            else
            {
                if (config.lang == "en")
                {
                    Console.WriteLine("Transfer is cancelled");
                }
                else if (config.lang == "id")
                {
                    Console.WriteLine("Transfer dibatalkan");
                }
            }
        }
    }
}