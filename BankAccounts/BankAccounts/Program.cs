using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using BankAccounts.Data;

namespace BankAccounts
{
    class Program
    {
        static void Main(string[] args)
        {

            using (var dbContext = new BankProjectEntities())

            {

                Console.WriteLine("There are currently {0} accounts in the database", dbContext.Accounts.Count());

            }
            bool passedUserName = false;
            bool passedPassword = false;
            //making a new account or logging in
            Console.WriteLine("Welcome to Emanuel's bank! \nDo you have an account already? Yes/No");
            string newUserOrNah = Console.ReadLine();
            // Jeff: you can use newUserOrNah.ToLower() == "yes" to simplify and do a single check regardless or capitalization
            if (newUserOrNah.ToLower() == "yes")
            {

                BankProjectEntities accounts = new BankProjectEntities();
                int accountQuantity = accounts.Accounts.Count();
                Console.WriteLine("Please enter your name");
                string enteredName = Console.ReadLine();
                if (accountQuantity != 0)
                    {
                    //opening the needed files
                    User user = new User();
                    string realUserName = user.Username;
                    while (enteredName != realUserName)
                    {
                        Console.WriteLine("Sorry, that is not a registered user, please try again");
                        enteredName = Console.ReadLine();
                    }

                    passedUserName = true;
                        Console.WriteLine("Please enter your password");
                        string enteredPassword = Console.ReadLine();
                        string realUserPassword = user.Password;
                        while ((realUserPassword == enteredPassword) != true)
                        {
                            Console.WriteLine("Sorry, that is incorrect \nPlease Try again");
                            enteredPassword = Console.ReadLine();
                        }
                        passedPassword = true;
                    }
                    else if (accountQuantity == 0)
                    {
                            Console.WriteLine("There are no registered users! Please Sign up first!");
                            //Writing to file
                            Console.WriteLine("Please enter your name...");
                            //UserInfo.MakingUserNames();


                            //making the password
                            Console.WriteLine("Please Enter a password...");
                            // UserInfo.MakingPasswords();

                            //Setting the balance
                            Account account1 = new Account();
                            account1.SetNewBalance();


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
                Console.WriteLine("Please enter your name");
                string enteredName = Console.ReadLine();
                //making the password
                Console.WriteLine("Please Enter a password...");
                string enteredPassword = Console.ReadLine();
                using (var dbContext = new BankProjectEntities())

                {

                    var user = new User

                    {

                        Username = enteredName,

                        Password = enteredPassword

                    };




                    //Setting the balance
                    Account account = new Account();
                    Console.WriteLine("How much money would you like to open your account with?");
                    decimal enteredAccountBalance = Convert.ToDecimal(Console.ReadLine());
                    var account2 = new Data.Account

                    {

                        Balance = enteredAccountBalance,

                        CreatedDate = DateTime.Now,

                        ModifiedDate = DateTime.Now,

                        User = user

                    };

                    dbContext.Accounts.Add(account2);
                    dbContext.SaveChanges();



                    //logging in
                    string realUserName = user.Username;
                    Console.WriteLine("Thank you for signing up for Emanuel's Bank! \nTo login please enter your name");
                    string enteredName1 = Console.ReadLine();
                    while ((enteredName1 == realUserName) != true)
                    {
                        Console.WriteLine("Sorry, that is not a registered user, please try again");
                        enteredName = Console.ReadLine();
                    }
                    passedUserName = true;
                    Console.WriteLine("Please enter your password");
                    string enteredPassword1 = Console.ReadLine();
                    string realUserPassword = user.Password;
                    while ((enteredPassword == realUserPassword) != true)
                    {
                        Console.WriteLine("Sorry, that is incorrect \nPlease try again");
                        enteredPassword = Console.ReadLine();
                    }
                    passedPassword = true;
                }
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
