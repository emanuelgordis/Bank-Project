using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace BankAccounts
{
    class UserInfo
    {

        public static void MakingUserNames()
        {
            string userInput = Console.ReadLine();
            Account account = new Account();
            account.SetName = userInput;
                var folder = Directory.CreateDirectory("C:/Users/Emanuel/Documents/BankProject");
                List<string> listOfNames = new List<string>();
                listOfNames.Add(userInput);


                string[] namesInArray = listOfNames.ToArray();

                File.WriteAllLines("C:/Users/Emanuel/Documents/BankProject/UserName.csv", namesInArray);
            
            
        }
        public static void MakingPasswords()
        {
            string userInput = Console.ReadLine();
            var folder = Directory.CreateDirectory("C:/Users/Emanuel/Documents/BankProject/");
            List<string> listOfPasswords = new List<string>();
            listOfPasswords.Add(userInput);

            Account account = new Account();
            string[] passwordsInArray = listOfPasswords.ToArray();
            File.WriteAllLines("C:/Users/Emanuel/Documents/BankProject/passwords.csv", passwordsInArray);
        }
    }
}
