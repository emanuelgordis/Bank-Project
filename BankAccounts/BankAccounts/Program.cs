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
            if (newUserOrNah == "Yes" || newUserOrNah == "yes")
            {
                Console.WriteLine("Please enter your name");
                string enteredName = Console.ReadLine();


                if (File.Exists("C:/Users/Emanuel/Documents/BankProject/accountbalance.txt") == true)
                {
                    //opening the needed files
                    string[] userNameContentsByLine = File.ReadAllLines("C:/Users/Emanuel/Documents/BankProject/UserName.csv");
                    while (userNameContentsByLine.Contains(enteredName) == false)
                    {
                        Console.WriteLine("Sorry, that is not a registered user, please try again");
                        enteredName = Console.ReadLine();
                    }
                    passedUserName = true;
                    Console.WriteLine("Please enter your password");
                    string enteredPassword = Console.ReadLine();
                    string[] passwordContentsByLine = File.ReadAllLines("C:/Users/Emanuel/Documents/BankProject/passwords.csv");
                    while (passwordContentsByLine.Contains(enteredPassword) != true)
                    {
                        Console.WriteLine("Sorry, that is incorrect \nPlease Try again");
                        enteredPassword = Console.ReadLine();
                    }
                    passedPassword = true;
                }

                else if (File.Exists("C:/Users/Emanuel/Documents/BankProject/accountbalance.txt") == false)
                {
                    while (File.Exists("C:/Users/Emanuel/Documents/BankProject/UserName.csv") == false)
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
                    string[] userNameContentsByLine = File.ReadAllLines("C:/Users/Emanuel/Documents/BankProject/UserName.csv");
                    while (userNameContentsByLine.Contains(enteredName) == false)
                    {
                        Console.WriteLine("Sorry, that is not a registered user, please try again");

                    }
                    passedUserName = true;
                    Console.WriteLine("Please enter your password");
                    string enteredPassword = Console.ReadLine();
                    string[] passwordContentsByLine = File.ReadAllLines("C:/Users/Emanuel/Documents/BankProject/passwords.csv");
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

                if (Directory.Exists("C:/Users/Emanuel/Documents/BankProject") != true)
                {
                    Directory.CreateDirectory("C:/Users/Emanuel/Documents/BankProject");
                }
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
                string[] userNameContentsByLine = File.ReadAllLines("C:/Users/Emanuel/Documents/BankProject/UserName.csv");
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
                string[] passwordContentsByLine = File.ReadAllLines("C:/Users/Emanuel/Documents/BankProject/passwords.csv");
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
                while (whatUserWants == "1" || whatUserWants == "2" || whatUserWants == "3")
                {

                    if (whatUserWants == "1")
                    {
                        //opening files
                        string[] arrayBalance = File.ReadAllLines("C:/Users/Emanuel/Documents/BankProject/accountbalance.txt");

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

                if (whatUserWants != "1" || whatUserWants != "2" || whatUserWants != "3")
                {
                    Console.WriteLine("That is not an option! Please choose a valid option... \nTo check account balance, press 1 \nTo withdraw money press 2 \nTo deposit money press 3");
                    whatUserWants = Console.ReadLine();

                }
            }

           
        }
    }
}
