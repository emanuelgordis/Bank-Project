using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace BankAccounts
{
    class Program
    {
        static void Main(string[] args)
        {
            //see if this syncs to github....
            bool passedUserName = false;
            bool passedPassword = false;
            //making a new account or logging in
            Console.WriteLine("Welcome to Emanuel's bank! \nDo you have an account already? Yes/No");
            string newUserOrNah = Console.ReadLine();
            // Jeff: you can use newUserOrNah.ToLower() == "yes" to simplify and do a single check regardless or capitalization
            if (newUserOrNah.ToLower() == "yes")
            {
                Console.WriteLine("Please enter your name");
                string enteredName = Console.ReadLine();

                // Jeff: Since File.Exists() returns true or false, you don't need to compare it directly to true
                //  common practice is to use 
                //      if (File.Exists("a")) { ... }
                //  OR
                //      if (!File.Exists("a")) { ... }
                //  the ! means not, so it's checking if the file does not exist
                if (File.Exists("./accountbalance.txt"))
                {
                    //opening the needed files
                    string[] userNameContentsByLine = File.ReadAllLines("./UserName.csv");
                    while (userNameContentsByLine.Contains(enteredName) == false)
                    {
                        Console.WriteLine("Sorry, that is not a registered user, please try again");
                        enteredName = Console.ReadLine();
                    }

                    passedUserName = true;
                    Console.WriteLine("Please enter your password");
                    string enteredPassword = Console.ReadLine();
                    string[] passwordContentsByLine = File.ReadAllLines("./passwords.csv");
                    while (passwordContentsByLine.Contains(enteredPassword) != true)
                    {
                        Console.WriteLine("Sorry, that is incorrect \nPlease Try again");
                        enteredPassword = Console.ReadLine();
                    }
                    passedPassword = true;
                }

                else if (!File.Exists("./accountbalance.txt"))
                {
                    while (File.Exists("./UserName.csv") == false)
                    {
                        Console.WriteLine("There are no registered users! Please Sign up first!");
                        //Writing to file
                        Console.WriteLine("Please enter your name...");
                        UserInfo.MakingUserNames();


                        //making the password
                        Console.WriteLine("Please Enter a password...");
                        UserInfo.MakingPasswords();

                        //Setting the balance
                        Account account = new Account();
                        account.SetNewBalance();
                    }


                    //opening the needed files
                    string[] userNameContentsByLine = File.ReadAllLines("./UserName.csv");
                    while (userNameContentsByLine.Contains(enteredName) == false)
                    {
                        Console.WriteLine("Sorry, that is not a registered user, please try again");

                    }
                    passedUserName = true;
                    Console.WriteLine("Please enter your password");
                    string enteredPassword = Console.ReadLine();
                    string[] passwordContentsByLine = File.ReadAllLines("./passwords.csv");
                    while (passwordContentsByLine.Contains(enteredPassword) != true)
                    {
                        Console.WriteLine("Sorry, that is incorrect \nPlease Try again");
                        enteredPassword = Console.ReadLine();
                    }
                    passedPassword = true;
                }

                Console.WriteLine("Thank you for logging in today");





            }

            else if (newUserOrNah == "No" || newUserOrNah == "no")
            {
                // Jeff: I changed the paths above to be relative (./filename) so that the code is self-contained and we don't have to share the same full paths
                //  therefore we don't need to create directories because it lives where the code is
                //if (Directory.Exists("C:/Users/Emanuel/Documents/BankProject") != true)
                //{
                //    Directory.CreateDirectory("C:/Users/Emanuel/Documents/BankProject");
                //}

                //Writing to file
                Console.WriteLine("Please enter your name...");
                UserInfo.MakingUserNames();


                //making the password
                Console.WriteLine("Please Enter a password...");
                UserInfo.MakingPasswords();

                //Setting the balance
                Account account = new Account();
                account.SetNewBalance();



                //logging in
                string[] userNameContentsByLine = File.ReadAllLines("./UserName.csv");
                Console.WriteLine("Thank you for signing up for Emanuel's Bank! \nTo login please enter your name");
                string enteredName = Console.ReadLine();
                while (userNameContentsByLine.Contains(enteredName) == false)
                {
                    Console.WriteLine("Sorry, that is not a registered user, please try again");
                    enteredName = Console.ReadLine();
                }
                passedUserName = true;
                Console.WriteLine("Please enter your password");
                string enteredPassword = Console.ReadLine();
                string[] passwordContentsByLine = File.ReadAllLines("./passwords.csv");
                while (passwordContentsByLine.Contains(enteredPassword) != true)
                {
                    Console.WriteLine("Sorry, that is incorrect \nPlease try again");
                    enteredPassword = Console.ReadLine();
                }
                passedPassword = true;
            }

            else
            {
                    if(newUserOrNah != "Yes" && newUserOrNah != "yes" && newUserOrNah != "No" && newUserOrNah != "no")
                        
                    Console.WriteLine("That is not a valid answer, are you a new user?");
                        
                    newUserOrNah = Console.ReadLine();
            }

            if (passedUserName == true && passedPassword == true)
            {
                //What does the user want to do?
                Console.WriteLine("To check account balance, press 1 \nTo withdraw money press 2 \nTo deposit money press 3");
                string whatUserWants = Console.ReadLine();
                while (whatUserWants == "1" || whatUserWants == "2" || whatUserWants == "3" || whatUserWants == "7")
                {

                    if (whatUserWants == "1")
                    {
                        //opening files
                        string[] arrayBalance = File.ReadAllLines("./accountbalance.txt");

                        Console.WriteLine("You have $" + arrayBalance[0] + " in your account");
                    }

                    else if (whatUserWants == "2")
                    {
                        Account account = new Account();
                        account.WithDrawSetBalance();
                    }

                    else if (whatUserWants == "3")
                    {
                        Account account = new Account();
                        account.DepositSetBalance();
                    }
                    else if (whatUserWants == "7")
                    {
                        Environment.Exit(1);
                    }

                    Console.WriteLine("To exit press 7 \nTo check account balance, press 1 \nTo withdraw money press 2 \nTo deposit money press 3");
                    whatUserWants = Console.ReadLine();
                }

            }
           
        }
    }
}
