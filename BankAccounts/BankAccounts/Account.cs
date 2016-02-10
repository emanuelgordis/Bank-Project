using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace BankAccounts
{
    class Account
    {
        private string userName;
       private string userPassword;
       private Int32 accountNumber;
       private Double accountBalance;

        


        public string GetName
        
        {
            get
            {
                return userName;
            }
        }

        public string SetName
        {
            set
            {
                userName = value;
            }
        }
        public Double GetBalance()
        {
            return accountBalance;
        }
        public void SetNewBalance()
        {
            
                Console.WriteLine("How much money would you like to open your account with?");
                accountBalance = Convert.ToDouble(Console.ReadLine());
                FileStream fileStream = File.OpenWrite("./accountbalance.txt");
                TextWriter textWriter = new StreamWriter(fileStream);
                textWriter.Write(accountBalance);

                textWriter.Flush();
                textWriter.Close();     
        }

        public void WithDrawSetBalance()
        {
            string[] arrayBalance = File.ReadAllLines("./accountbalance.txt");
            int amount = Convert.ToInt32(arrayBalance[0]);
            Console.WriteLine("How mucch money would you like to withdraw? ");
            int amountWithDrawn = Convert.ToInt32(Console.ReadLine());
            int newBalance = amount - amountWithDrawn;
            string balanceToBeWritten = Convert.ToString(newBalance);
            File.WriteAllText("./accountbalance.txt", balanceToBeWritten);
            Account account = new Account();
            string fileContents = File.ReadAllText("./accountbalance.txt");
            Console.WriteLine("Thank you, your new balance is $" + fileContents);
        }

        public void DepositSetBalance()
        {
            string[] arrayBalance = File.ReadAllLines("./accountbalance.txt");
            int amount = Convert.ToInt32(arrayBalance[0]);
            Console.WriteLine("How mucch money would you like to deposit? ");
            int amountAdded = Convert.ToInt32(Console.ReadLine());
            int newBalance = amount + amountAdded;
            string balanceToBeWritten = Convert.ToString(newBalance);
            File.WriteAllText("./accountbalance.txt", balanceToBeWritten);
            Account account = new Account();
            string fileContents = File.ReadAllText("./accountbalance.txt");
            Console.WriteLine("Thank you, your new balance is $" + fileContents);

        }
    }
}
