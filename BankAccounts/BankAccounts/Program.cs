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

           



            bool passedUserName = false;
            bool passedPassword = false;
            int loggedUserId = 0;
            //making a new account or logging in
            Console.WriteLine("Welcome to Emanuel's bank! \nDo you have an account already? Yes/No");
            string newUserOrNah = Console.ReadLine();
            if (newUserOrNah.ToLower() == "yes")
            {
                BankProjectEntities accounts = new BankProjectEntities();
                int accountQuantity = accounts.Accounts.Count();
                Console.WriteLine("Please enter your name");
                string enteredName = Console.ReadLine();
                if (accountQuantity != 0)
                {
                    using (var dbContext = new BankProjectEntities())
                    {
                        //opening the needed files
                        User user = new User();
                        Console.WriteLine("Please enter your password");
                        string enteredPassword = Console.ReadLine();
                        var userNameAndPassword = dbContext.Users.FirstOrDefault(x => x.Password == enteredPassword && x.Username == enteredName);

                        while (userNameAndPassword == null)
                        {
                            Console.WriteLine("Sorry, username or password is incorrect \nPlease Try again");
                            enteredName = Console.ReadLine();
                            Console.WriteLine("Please enter your password");
                            enteredPassword = Console.ReadLine();
                            userNameAndPassword = dbContext.Users.FirstOrDefault(x => x.Password == enteredPassword && x.Username == enteredName);
                        }
                        passedUserName = true;
                        passedPassword = true;

                        loggedUserId = userNameAndPassword.UserId;
                    }
                }
                else if (accountQuantity == 0)
                {
                    Console.WriteLine("There are no registered user! \n To sign up please enter your name");
                    string name = Console.ReadLine();
                    //making the password
                    Console.WriteLine("Please Enter a password...");
                    string enteredPassword = Console.ReadLine();
                    using (var dbContext = new BankProjectEntities())

                    {

                        var user = new User

                        {

                            Username = name,

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


                    }

                    Console.WriteLine("Thank you for logging in today");



                  }

                }

                else if (newUserOrNah == "No" || newUserOrNah == "no")
                {
                    Console.WriteLine("Please enter your name");
                    string name = Console.ReadLine();
                    //making the password
                    Console.WriteLine("Please Enter a password...");
                    string enteredPassword = Console.ReadLine();
                    using (var dbContext = new BankProjectEntities())

                    {

                        var user = new User

                        {

                            Username = name,

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
                        
                        Console.WriteLine("Thank you for signing up for Emanuel's Bank! \nTo login please enter your name");
                        string enteredName1 = Console.ReadLine();
                        using (var dbContext2 = new BankProjectEntities())
                        {
                            //opening the needed files
                            User user2 = new User();
                            Console.WriteLine("Please enter your password");
                            string enteredPassword2 = Console.ReadLine();
                            var userNameAndPassword = dbContext.Users.FirstOrDefault(x => x.Password == enteredPassword2 && x.Username == enteredName1);

                            while (userNameAndPassword == null)
                            {
                                Console.WriteLine("Sorry, username or password is incorrect \nPlease Try again");
                                enteredName1 = Console.ReadLine();
                                Console.WriteLine("Please enter your password");
                                enteredPassword = Console.ReadLine();
                                userNameAndPassword = dbContext.Users.FirstOrDefault(x => x.Password == enteredPassword2 && x.Username == enteredName1);
                            }
                            passedUserName = true;
                            passedPassword = true;

                            loggedUserId = userNameAndPassword.UserId;
                        }
                    }
                }

                else
                {
                    if(newUserOrNah.ToLower() != "Yes" || newUserOrNah.ToLower() != "No")

                        Console.WriteLine("That is not a valid answer, are you a new user?");
                        newUserOrNah = Console.ReadLine();
                }

                if (passedUserName == true && passedPassword == true)
                {
                    //What does the user want to do?
                    Console.WriteLine("To check account balance, press 1 \nTo withdraw money press 2 \nTo deposit money press 3 \nTo transfer money to another account press 4");
                    string whatUserWants = Console.ReadLine();
                    while (whatUserWants == "1" || whatUserWants == "2" || whatUserWants == "3" || whatUserWants == "4" || whatUserWants == "7")
                    {

                        if (whatUserWants == "1")
                        {
                            using (var dbContext = new BankProjectEntities())
                            {  
                                var account2 = dbContext.Accounts.FirstOrDefault(x => x.AccountId == loggedUserId);
                                if (account2 != null)
                                {
                                    
                                    decimal balance = account2.Balance;
                                    Console.WriteLine("Your balance is $" + balance);
                                  
                                }
                            }
                            
                        }

                        else if (whatUserWants == "2")
                        {
                            Account account = new Account();
                            Console.WriteLine("How much money would you like to withdraw from your account?");
                            decimal withDrawAmount = Convert.ToDecimal(Console.ReadLine());
                            using(var dbContext = new BankProjectEntities())
                            {
                                int accountId = loggedUserId;
                                var account2 = dbContext.Accounts.FirstOrDefault(x => x.AccountId == accountId);
                                if(account2 != null)
                                {
                                    Account anotherAccount = new Account();
                                    decimal newBalance = anotherAccount.Balance - withDrawAmount;
                                    Console.WriteLine("Thank you, your new balance is $" + newBalance);
                                    anotherAccount.Balance = newBalance;
                                }
                            }
                            
                        }

                        else if (whatUserWants == "3")
                        {
                            Account account = new Account();
                            Console.WriteLine("How much money would you like to deposit in your account?");
                            decimal depositAmount = Convert.ToDecimal(Console.ReadLine());
                            using (var dbContext = new BankProjectEntities())
                            {
                                int accountId = loggedUserId;
                                var account2 = dbContext.Accounts.FirstOrDefault(x => x.AccountId == accountId);
                                if (account2 != null)
                                {
                                    Account anotherAccount = new Account();
                                    decimal newBalance = anotherAccount.Balance + depositAmount;
                                    Console.WriteLine("Thank you, your new balance is $" + newBalance);
                                    anotherAccount.Balance = newBalance;
                                }
                            }
                        }
                        
                        else if(whatUserWants == "4")
                    {
                        Console.WriteLine("Please enter the username to which you'd like to send money to");
                        string accountName = Console.ReadLine();
                        Console.WriteLine("How much money would you like to send to " + accountName + "?");
                        decimal amountTransfered = Convert.ToDecimal(Console.ReadLine());
                        using (var dbContext = new BankProjectEntities())
                        {
                            var fromUser = dbContext.Users.FirstOrDefault(x => x.UserId == loggedUserId);
                            var fromAccount = dbContext.Accounts.FirstOrDefault(x => x.AccountId == loggedUserId);
                            var toUser = dbContext.Users.FirstOrDefault(x => x.Username== accountName);
                            var accountId = toUser.UserId;
                            var toAccount = dbContext.Accounts.FirstOrDefault(x => x.AccountId == accountId);
                            fromAccount.Balance = fromAccount.Balance - amountTransfered;
                            toAccount.Balance = toAccount.Balance + amountTransfered;
                            var transactionNumber = new Transaction();
                            var transaction = new Data.Transaction
                            {

                                Transaction_Date = DateTime.Now,
                                Transaction_Amount = amountTransfered,
                                Transaction_Number = transactionNumber.Transaction_Number + 1,
                                
                            };
                            dbContext.Transactions.Add(transaction);
                            dbContext.SaveChanges();
                        }
                        
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
