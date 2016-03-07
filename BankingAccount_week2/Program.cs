using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.IO;


namespace BankingAccount_week2
{
    class Program
    {
        static void Main(string[] args)
        {
            // Stringbuilder to create account numbers for checking, savings and reserve - each then assigned to the class

            StringBuilder act = new StringBuilder();

            Clients clientName = new Clients();
            bool restart = true;

            CheckingAccount CheckingAccountNbr = new CheckingAccount();
            CheckingAccountNbr.CheckingAccountNbr = (CheckingAccountNbr.getAccountNbr());
            Thread.Sleep(20);

            ReserveAccount ReserveAccountNbr = new ReserveAccount();
            ReserveAccountNbr.ReserveAccountNbr = (ReserveAccountNbr.getAccountNbr());
            Thread.Sleep(20);

            SavingsAccount SavingsAccountNbr = new SavingsAccount();
            SavingsAccountNbr.SavingsAccountNbr = (SavingsAccountNbr.getAccountNbr());
            Thread.Sleep(20);

            // Create export files for user - checking, savings, reserve & All Transactions
            StreamWriter writer = new StreamWriter("AccountSummary.txt");
            using (writer)
            {
                writer.WriteLine("Transaction Summary");
                writer.WriteLine("Client Name: " + clientName.GetFullName());
                writer.WriteLine("KEY: (SB=Start Balance) (TT=Trans Type) (TA=Trans Amt) (EB=End Balance)\r\n     (CA=Checking Account) (SA=Savings Account) (RA=Reserve Account)");
            }

            writer = new StreamWriter("CheckingAccountSummary.txt");
            using (writer)
            {
                writer.WriteLine(CheckingAccountNbr.AccountType + " Transaction Summary");
                writer.WriteLine("Client Name: " + clientName.GetFullName());
                writer.WriteLine("Client Account Number: " + CheckingAccountNbr.CheckingAccountNbr);
                writer.WriteLine("KEY: (SB=Start Balance) (TT=Trans Type) (TA=Trans Amt) (EB=End Balance)\r\n");

            }

            writer = new StreamWriter("SavingsAccountSummary.txt");
            using (writer)
            {
                writer.WriteLine(SavingsAccountNbr.AccountType + " Transaction Summary");
                writer.WriteLine("Client Name: " + clientName.GetFullName());
                writer.WriteLine("Client Account Number: " + SavingsAccountNbr.SavingsAccountNbr);
                writer.WriteLine("KEY: (SB=Start Balance) (TT=Trans Type) (TA=Trans Amt) (EB=End Balance)\r\n");
            }
            writer = new StreamWriter("ReserveAccountSummary.txt");
            using (writer)
            {
                writer.WriteLine(ReserveAccountNbr.AccountType + " Transaction Summary");
                writer.WriteLine("Client Name: " + clientName.GetFullName());
                writer.WriteLine("Client Account Number: " + ReserveAccountNbr.ReserveAccountNbr);
                writer.WriteLine("KEY: (SB=Start Balance) (TT=Trans Type) (TA=Trans Amt) (EB=End Balance)\r\n");
            }


            {
                while (restart == true)
                {
                    Header();
                    {
                        Console.WriteLine("\nEnter Menu Item Number");
                        string menuItem = Console.ReadLine();
                        int userInput;
                        userInput = NumberCheck(menuItem);
                        int caseRestart = 0;
                        while (caseRestart == 0)
                        {
                            switch (userInput)
                            {
                                case 1: //View Client Information
                                    do
                                    {
                                        Console.Clear();
                                        Header();

                                        Console.WriteLine("Client Information:\n");
                                        Console.Write("Client Full Name: ");
                                        Console.WriteLine(clientName.GetFullName());
                                        Console.Write("Client First Name: ");
                                        Console.WriteLine(clientName.ClientFirstName);
                                        Console.WriteLine("Client Last Name: " + clientName.ClientLastName);
                                        Console.WriteLine("Client Phone: " + clientName.ClientContactPhone);
                                        userInput = DoNext(menuItem);
                                        Console.Clear();
                                        Header();
                 
                                    }
                                    while (userInput == 1);
                                    break;

                                case 2: //View Account Balance
                                    do
                                    {
                                        Console.Clear();
                                        Header();

                                        Console.WriteLine(CheckingAccountNbr.AccountType);
                                        Console.WriteLine("Account Number: " + CheckingAccountNbr.CheckingAccountNbr);
                                        string CheckingAccountAsCurrency = string.Format("${0:n}", CheckingAccountNbr.GetAccountBalance());
                                        Console.WriteLine("Account Balance: " + CheckingAccountAsCurrency);
                                        Console.WriteLine(CheckingAccountNbr.getCheckingTransactionWarning());

                                        Console.WriteLine("\n" + SavingsAccountNbr.AccountType);
                                        Console.WriteLine("Account Number: " + SavingsAccountNbr.SavingsAccountNbr);
                                        string SavingsAccountAsCurrency = string.Format("${0:n}", SavingsAccountNbr.GetAccountBalance());
                                        Console.WriteLine("Account Balance: " + SavingsAccountAsCurrency);
                                        Console.WriteLine(SavingsAccountNbr.getSavingsTransactionNbrWarning());

                                        Console.WriteLine("\n" + ReserveAccountNbr.AccountType);
                                        Console.WriteLine("Account Number: " + ReserveAccountNbr.ReserveAccountNbr);
                                        string ReserveAccountAsCurrency = string.Format("${0:n}", ReserveAccountNbr.GetAccountBalance());
                                        Console.WriteLine("Account Balance: " + ReserveAccountAsCurrency);
                                        if ((ReserveAccountNbr.getBalanceWarning()) == true)
                                        {
                                            Console.WriteLine("Account Status: Minimum Balance Warning");
                                        }
                                        else
                                        {
                                            Console.WriteLine("Account Status: Over Minimum Balance");
                                        }
                                        userInput = DoNext(menuItem);
                                        Console.Clear();
                                        Header();

                                    }
                                    while (userInput == 2);
                                    break;

                                case 3://Deposit Funds
                                    do
                                    {

                                        Console.Clear();
                                        Header();
                                        int AccountTypeInput;
                                        string userinput;
                                        decimal usercheck;
                                        decimal deposit;
                                        string depositAsCurrency;

                                        Console.WriteLine("Choose An Account To Access: \n1: Checking Account\n2: Savings Account\n3: Reserve Account");
                                        string AccountInput = Console.ReadLine();
                                        AccountTypeInput = NumberCheck(AccountInput);
                                        switch (AccountTypeInput)
                                        {
                                            case 1:
                                                Console.Clear();

                                                Header();

                                                Console.WriteLine("Client Full Name: " + (clientName.GetFullName()));
                                                Console.WriteLine("Account Type: " + CheckingAccountNbr.AccountType);
                                                Console.WriteLine("Account Nbr: " + CheckingAccountNbr.CheckingAccountNbr);
                                                Console.WriteLine("Current Account Balance: " + string.Format("${0:n}", CheckingAccountNbr.GetAccountBalance()));

                                                Console.WriteLine("\nHow Much Money Would You Like To Deposit?");

                                                userinput = Console.ReadLine();
                                                NullOrWhiteSpace(userinput);
                                                usercheck = NumberCheckDec(userinput);
                                                deposit = Convert.ToDecimal(usercheck);

                                                CheckingAccountNbr.TransactionAmount = deposit;

                                                depositAsCurrency = string.Format("${0:n}", deposit);

                                                CheckingAccountNbr.Deposit();

                                                Console.WriteLine("\nThe Completed Transaction Has Been Printed To Your Account Summary");

                                                Console.WriteLine("Current Account Balance: " + string.Format("${0:n}", CheckingAccountNbr.GetAccountBalance()));

                                                File.AppendAllText("AccountSummary.txt", "\r\n" + DateTime.Now);
                                                File.AppendAllText("AccountSummary.txt", "  CA ");
                                                File.AppendAllText("AccountSummary.txt", "  SB: " + string.Format("${0:n}", (CheckingAccountNbr.Balance - deposit)));
                                                File.AppendAllText("AccountSummary.txt", "  TT: (+)  ");
                                                File.AppendAllText("AccountSummary.txt", "  TA: " + depositAsCurrency);
                                                File.AppendAllText("AccountSummary.txt", "  EB: " + string.Format("${0:n}", CheckingAccountNbr.GetAccountBalance()) + "\r\n");
                                                writer.Close();

                                                File.AppendAllText("CheckingAccountSummary.txt", "\r\n" + DateTime.Now);
                                                File.AppendAllText("CheckingAccountSummary.txt", "  SB: " + string.Format("${0:n}", (CheckingAccountNbr.Balance - deposit)));
                                                File.AppendAllText("CheckingAccountSummary.txt", "  TT: (+)  ");
                                                File.AppendAllText("CheckingAccountSummary.txt", "  TA: " + depositAsCurrency);
                                                File.AppendAllText("CheckingAccountSummary.txt", "  EB: " + string.Format("${0:n}", CheckingAccountNbr.GetAccountBalance()) + "\r\n");
                                                writer.Close();

                                                userInput = DoNext(menuItem);
                                                Console.Clear();
                                                Header();
                                                break;

                                            case 2:
                                                Console.Clear();
                                                Header();
                                                Console.WriteLine("Client Full Name: " + (clientName.GetFullName()));
                                                Console.WriteLine("Account Type: " + SavingsAccountNbr.AccountType);
                                                Console.WriteLine("Account Nbr: " + SavingsAccountNbr.SavingsAccountNbr);
                                                Console.WriteLine("Current Account Balance: " + string.Format("${0:n}", SavingsAccountNbr.GetAccountBalance()));
                                                Console.WriteLine("\nHow Much Money Would You Like To Deposit?");
                                                Console.WriteLine(SavingsAccountNbr.getSavingsTransactionNbrWarning());

                                                userinput = Console.ReadLine();
                                                NullOrWhiteSpace(userinput);
                                                usercheck = NumberCheckDec(userinput);
                                                deposit = Convert.ToDecimal(usercheck);
                                                SavingsAccountNbr.TransactionAmount = deposit;
                                                depositAsCurrency = string.Format("${0:n}", deposit);
                                                SavingsAccountNbr.Deposit();

                                                Console.WriteLine("\nThe Completed Transaction Has Been Printed To Your Account Summary");
                                                Console.WriteLine("Current Account Balance: " + string.Format("${0:n}", SavingsAccountNbr.GetAccountBalance()));

                                                File.AppendAllText("SavingsAccountSummary.txt", "\r\n" + DateTime.Now);
                                                File.AppendAllText("SavingsAccountSummary.txt", "  SB: " + string.Format("${0:n}", (SavingsAccountNbr.Balance - deposit)));
                                                File.AppendAllText("SavingsAccountSummary.txt", "  TT: (+)  ");
                                                File.AppendAllText("SavingsAccountSummary.txt", "  TA: " + depositAsCurrency);
                                                File.AppendAllText("SavingsAccountSummary.txt", "  EB: " + string.Format("${0:n}", SavingsAccountNbr.GetAccountBalance()) + "\r\n");
                                                writer.Close();

                                                File.AppendAllText("AccountSummary.txt", "\r\n" + DateTime.Now);
                                                File.AppendAllText("AccountSummary.txt", "  SA ");
                                                File.AppendAllText("AccountSummary.txt", "  SB: " + string.Format("${0:n}", (SavingsAccountNbr.Balance - deposit)));
                                                File.AppendAllText("AccountSummary.txt", "  TT: (+)  ");
                                                File.AppendAllText("AccountSummary.txt", "  TA: " + depositAsCurrency);
                                                File.AppendAllText("AccountSummary.txt", "  EB: " + string.Format("${0:n}", SavingsAccountNbr.GetAccountBalance()) + "\r\n");
                                                writer.Close();

                                                userInput = DoNext(menuItem);
                                                Console.Clear();
                                                Header();
                                      
                                                break;

                                            case 3:
                                                Console.Clear();
                                                Header();
                                         
                                                Console.WriteLine("Client Full Name: " + (clientName.GetFullName()));
                                                Console.WriteLine("Account Type: " + ReserveAccountNbr.AccountType);
                                                Console.WriteLine("Account Nbr: " + ReserveAccountNbr.ReserveAccountNbr);
                                                Console.WriteLine("Current Account Balance: " + string.Format("${0:n}", ReserveAccountNbr.GetAccountBalance()));
                                              
                                          
                                                if ((ReserveAccountNbr.getBalanceWarning()) == true)
                                                {
                                                    Console.WriteLine("Account Status: Minimum Balance Warning");
                                                        }
                                                else
                                                {
                                                    Console.WriteLine("Account Status: Over Minimum Balance");
                                                        }

                                                Console.WriteLine("\nHow Much Money Would You Like To Deposit?");
                                                userinput = Console.ReadLine();
                                                NullOrWhiteSpace(userinput);
                                                usercheck = NumberCheckDec(userinput);
                                                deposit = Convert.ToDecimal(usercheck);

                                                ReserveAccountNbr.TransactionAmount = deposit;
                                                depositAsCurrency = string.Format("${0:n}", deposit);
                                            
                                                ReserveAccountNbr.Deposit();
                                           
                                                Console.WriteLine("\nThe Completed Transaction Has Been Printed To Your Account Summary");
                                                Console.WriteLine("Current Account Balance: " + string.Format("${0:n}", ReserveAccountNbr.GetAccountBalance()));

                                                File.AppendAllText("AccountSummary.txt", "\r\n" + DateTime.Now);
                                                File.AppendAllText("AccountSummary.txt", "  RA ");
                                                File.AppendAllText("AccountSummary.txt", "  SB: " + string.Format("${0:n}", (ReserveAccountNbr.Balance - deposit)));
                                                File.AppendAllText("AccountSummary.txt", "  TT: (+)  ");
                                                File.AppendAllText("AccountSummary.txt", "  TA: " + depositAsCurrency);
                                                File.AppendAllText("AccountSummary.txt", "  EB: " + string.Format("${0:n}", ReserveAccountNbr.GetAccountBalance()) + "\r\n");
                                                writer.Close();

                                                File.AppendAllText("ReserveAccountSummary.txt", "\r\n" + DateTime.Now);
                                                File.AppendAllText("ReserveAccountSummary.txt", "  SB: " + string.Format("${0:n}", (ReserveAccountNbr.Balance - deposit)));
                                                File.AppendAllText("ReserveAccountSummary.txt", "  TT: (+)  ");
                                                File.AppendAllText("ReserveAccountSummary.txt", "  TA: " + depositAsCurrency);
                                                File.AppendAllText("ReserveAccountSummary.txt", "  EB: " + string.Format("${0:n}", ReserveAccountNbr.GetAccountBalance()) + "\r\n");
                                                writer.Close();

                                                userInput = DoNext(menuItem);
                                                Console.Clear();
                                                Header();
                                                break;

                                            default:
                                                Console.WriteLine("That is not a valid entry");
                                                Header();
                                                userInput = DoNext(menuItem);
                                                continue;
                                        }

                                    }
                                    while (userInput == 3);
                                    break;


                                case 4:// Withdraw Funds
                                    do
                                    {
                                        Console.Clear();
                                        Header();
                                        int AccountTypeInput;
                                        string userinput;
                                        decimal usercheck;
                                        decimal deposit;
                                        string depositAsCurrency;

                                        Console.WriteLine("Choose An Account To Access: \n1: Checking Account\n2: Savings Account\n3: Reserve Account");
                                        string AccountInput = Console.ReadLine();
                                        AccountTypeInput = NumberCheck(AccountInput);
                                        switch (AccountTypeInput)
                                        {
                                            case 1:
                                                Console.Clear();

                                                Header();

                                                Console.WriteLine("Client Full Name: " + (clientName.GetFullName()));
                                                Console.WriteLine("Account Type: " + CheckingAccountNbr.AccountType);
                                                Console.WriteLine("Account Nbr: " + CheckingAccountNbr.CheckingAccountNbr);
                                                Console.WriteLine("Current Account Balance: " + string.Format("${0:n}", CheckingAccountNbr.GetAccountBalance()));
                                                Console.WriteLine(CheckingAccountNbr.getCheckingTransactionWarning());
                                                Console.WriteLine("\nHow Much Money Would You Like To Withdraw?");

                                                userinput = Console.ReadLine();
                                                NullOrWhiteSpace(userinput);
                                                usercheck = NumberCheckDec(userinput);
                                                deposit = Convert.ToDecimal(usercheck);

                                                CheckingAccountNbr.TransactionAmount = deposit;
                                                depositAsCurrency = string.Format("${0:n}", deposit);

                                                if (CheckingAccountNbr.Balance >= deposit)
                                                {
                                                    CheckingAccountNbr.Withdraw();
                                                    CheckingAccountNbr.CheckingTransactionNbr++;
                                                    Console.WriteLine("\nThe Completed Transaction Has Been Printed To Your Account Summary");
                                                    Console.WriteLine("Current Account Balance: " + string.Format("${0:n}", CheckingAccountNbr.GetAccountBalance()));

                                                    File.AppendAllText("AccountSummary.txt", "\r\n" + DateTime.Now);
                                                    File.AppendAllText("AccountSummary.txt", "  CA ");
                                                    File.AppendAllText("AccountSummary.txt", "  SB: " + string.Format("${0:n}", (CheckingAccountNbr.Balance + deposit)));
                                                    File.AppendAllText("AccountSummary.txt", "  TT: (-)  ");
                                                    File.AppendAllText("AccountSummary.txt", "  TA: " + depositAsCurrency);
                                                    File.AppendAllText("AccountSummary.txt", "  EB: " + string.Format("${0:n}", CheckingAccountNbr.GetAccountBalance()) + "\r\n");
                                                    writer.Close();

                                                    File.AppendAllText("CheckingAccountSummary.txt", "\r\n" + DateTime.Now);
                                                    File.AppendAllText("CheckingAccountSummary.txt", "  SB: " + string.Format("${0:n}", (CheckingAccountNbr.Balance + deposit)));
                                                    File.AppendAllText("CheckingAccountSummary.txt", "  TT: (-)  ");
                                                    File.AppendAllText("CheckingAccountSummary.txt", "  TA: " + depositAsCurrency);
                                                    File.AppendAllText("CheckingAccountSummary.txt", "  EB: " + string.Format("${0:n}", CheckingAccountNbr.GetAccountBalance()) + "\r\n");
                                                    writer.Close();

                                                    userInput = DoNext(menuItem);
                                                    Console.Clear();
                                                    Header();

                                                    break;
                                                }
                                                else
                                                {
                                                    Console.WriteLine("\nYou Do Not Have The Funds To Complete This Transaction");
                                                    userInput = DoNext(menuItem);
                                                    Console.Clear();
                                                    Header();
                                                    continue;
                                                }

                                            case 2:
                                                Console.Clear();
                                                Header();

                                                Console.WriteLine("Client Full Name: " + (clientName.GetFullName()));
                                                Console.WriteLine("Account Type: " + SavingsAccountNbr.AccountType);
                                                Console.WriteLine("Account Nbr: " + SavingsAccountNbr.SavingsAccountNbr);
                                                Console.WriteLine("Current Account Balance: " + string.Format("${0:n}", SavingsAccountNbr.GetAccountBalance()));
                                                Console.WriteLine("\nHow Much Money Would You Like To Withdraw?");

                                                Console.WriteLine(SavingsAccountNbr.getSavingsTransactionNbrWarning()) ;

                                              

                                                userinput = Console.ReadLine();
                                                NullOrWhiteSpace(userinput);
                                                usercheck = NumberCheckDec(userinput);
                                                deposit = Convert.ToDecimal(usercheck);

                                                SavingsAccountNbr.TransactionAmount = deposit;

                                                depositAsCurrency = string.Format("${0:n}", deposit);
                                                if (SavingsAccountNbr.Balance >= deposit)
                                                {
                                                    SavingsAccountNbr.Withdraw();
                                                    SavingsAccountNbr.SavingsTransactionNbr++;

                                                Console.WriteLine("\nThe Completed Transaction Has Been Printed To Your Account Summary");
                                                Console.WriteLine("Current Account Balance: " + string.Format("${0:n}", SavingsAccountNbr.GetAccountBalance()));

                                                File.AppendAllText("AccountSummary.txt", "\r\n" + DateTime.Now);
                                                File.AppendAllText("AccountSummary.txt", "  SA ");
                                                File.AppendAllText("AccountSummary.txt", "  SB: " + string.Format("${0:n}", (SavingsAccountNbr.Balance + deposit)));
                                                File.AppendAllText("AccountSummary.txt", "  TT: (-)  ");
                                                File.AppendAllText("AccountSummary.txt", "  TA: " + depositAsCurrency);
                                                File.AppendAllText("AccountSummary.txt", "  EB: " + string.Format("${0:n}", SavingsAccountNbr.GetAccountBalance()) + "\r\n");
                                                writer.Close();

                                                File.AppendAllText("SavingsAccountSummary.txt", "\r\n" + DateTime.Now);
                                                File.AppendAllText("SavingsAccountSummary.txt", "  SB: " + string.Format("${0:n}", (SavingsAccountNbr.Balance + deposit)));
                                                File.AppendAllText("SavingsAccountSummary.txt", "  TT: (-)  ");
                                                File.AppendAllText("SavingsAccountSummary.txt", "  TA: " + depositAsCurrency);
                                                File.AppendAllText("SavingsAccountSummary.txt", "  EB: " + string.Format("${0:n}", SavingsAccountNbr.GetAccountBalance()) + "\r\n");
                                                writer.Close();

                                                userInput = DoNext(menuItem);
                                                Console.Clear();
                                                Header();
                                                break;

                                                    }
                                                else
                                                {
                                                    Console.WriteLine("\nYou Do Not Have The Funds To Complete This Transaction");
                                                    userInput = DoNext(menuItem);
                                                    Console.Clear();
                                                    Header();
                                                    continue;
                                                }

                                            case 3:
                                                Console.Clear();
                                                Header();
                                                Console.WriteLine("Client Full Name: " + (clientName.GetFullName()));
                                                Console.WriteLine("Account Type: " + ReserveAccountNbr.AccountType);
                                                Console.WriteLine("Account Nbr: " + ReserveAccountNbr.ReserveAccountNbr);
                                                Console.WriteLine("Current Account Balance: " + string.Format("${0:n}", ReserveAccountNbr.GetAccountBalance()));

                                                if ((ReserveAccountNbr.getBalanceWarning()) == true)
                                                {
                                                    Console.WriteLine("Account Status: Minimum Balance Warning");
                                                }
                                                else
                                                {
                                                    Console.WriteLine("Account Status: Over Minimum Balance");
                                                }
                                                Console.WriteLine("\nHow Much Money Would You Like To Withdraw?");

                                                userinput = Console.ReadLine();
                                                NullOrWhiteSpace(userinput);
                                                usercheck = NumberCheckDec(userinput);
                                                deposit = Convert.ToDecimal(usercheck);
                                                ReserveAccountNbr.TransactionAmount = deposit;
                                                depositAsCurrency = string.Format("${0:n}", deposit);

                                                if (ReserveAccountNbr.Balance >= deposit)
                                                {
                                                
                                                ReserveAccountNbr.Withdraw();

                                                Console.WriteLine("\nThe Completed Transaction Has Been Printed To Your Account Summary");
                                                Console.WriteLine("Current Account Balance: " + string.Format("${0:n}", ReserveAccountNbr.GetAccountBalance()));

                                                File.AppendAllText("AccountSummary.txt", "\r\n" + DateTime.Now);
                                                File.AppendAllText("AccountSummary.txt", "  RA ");
                                                File.AppendAllText("AccountSummary.txt", "  SB: " + string.Format("${0:n}", (ReserveAccountNbr.Balance + deposit)));
                                                File.AppendAllText("AccountSummary.txt", "  TT: (-)  ");
                                                File.AppendAllText("AccountSummary.txt", "  TA: " + depositAsCurrency);
                                                File.AppendAllText("AccountSummary.txt", "  EB: " + string.Format("${0:n}", ReserveAccountNbr.GetAccountBalance()) + "\r\n");
                                                writer.Close();

                                                File.AppendAllText("ReserveAccountSummary.txt", "\r\n" + DateTime.Now);
                                                File.AppendAllText("ReserveAccountSummary.txt", "  SB: " + string.Format("${0:n}", (ReserveAccountNbr.Balance + deposit)));
                                                File.AppendAllText("ReserveAccountSummary.txt", "  TT: (-)  ");
                                                File.AppendAllText("ReserveAccountSummary.txt", "  TA: " + depositAsCurrency);
                                                File.AppendAllText("ReserveAccountSummary.txt", "  EB: " + string.Format("${0:n}", ReserveAccountNbr.GetAccountBalance()) + "\r\n");
                                                writer.Close();

                                                userInput = DoNext(menuItem);
                                                Console.Clear();
                                                Header();
                                                break;
                                                }
                                                else
                                                {
                                                    Console.WriteLine("\nYou Do Not Have The Funds To Complete This Transaction");
                                                    userInput = DoNext(menuItem);
                                                    Console.Clear();
                                                    Header();
                                                    continue;
                                                }
                                            default:
                                                Console.WriteLine("That is not a valid entry");
                                                Header();
                                                userInput = DoNext(menuItem);
                                                continue;
                                        }
                                    }
                                    while (userInput == 4);
                                    break;

                                case 5:
                                       
                                        do
                                    {
                                        Console.WriteLine("Choose An Account To Access: \n1: Checking Account\n2: Savings Account\n3: Reserve Account\n4: All Transactions");
                                        string AccountInput = Console.ReadLine();
                                        int AccountTypeInput = NumberCheck(AccountInput);

                                        switch (AccountTypeInput)
                                        {
                                            case 1:
                                                Console.Clear();
                                                Console.WriteLine("\nFile Export Preview\n");
                                                using (StreamReader sr = File.OpenText("CheckingAccountSummary.txt"))
                                                {
                                                    string s = "";
                                                    while ((s = sr.ReadLine()) != null)
                                                    {
                                                        Console.WriteLine(s);
                                                    }

                                                    Header();
                                                    userInput = DoNext(menuItem);
                                                    continue;
                                                }

                                            case 2:
                                                Console.Clear();
                                                Console.WriteLine("\nFile Export Preview\n");
                                                using (StreamReader sr = File.OpenText("SavingsAccountSummary.txt"))
                                                {
                                                    string s = "";
                                                    while ((s = sr.ReadLine()) != null)
                                                    {
                                                        Console.WriteLine(s);
                                                    }

                                                    Header();
                                                    userInput = DoNext(menuItem);
                                                    continue;
                                                }
                                            case 3:
                                                Console.Clear();
                                                Console.WriteLine("\nFile Export Preview\n");
                                                using (StreamReader sr = File.OpenText("ReserveAccountSummary.txt"))
                                                {
                                                    string s = "";
                                                    while ((s = sr.ReadLine()) != null)
                                                    {
                                                        Console.WriteLine(s);
                                                    }

                                                    Header();
                                                    userInput = DoNext(menuItem);
                                                    continue;
                                                }
                                            case 4:
                                                Console.Clear();

                                                Console.WriteLine("\nFile Export Preview\n");
                                                using (StreamReader sr = File.OpenText("AccountSummary.txt"))
                                                {
                                                    string s = "";
                                                    while ((s = sr.ReadLine()) != null)
                                                    {
                                                        Console.WriteLine(s);
                                                    }

                                                    Header();
                                                    userInput = DoNext(menuItem);
                                                    continue;
                                                }
                                            default:
                                                Console.WriteLine("That is not a valid entry");
                                                Header();
                                                userInput = DoNext(menuItem);
                                                continue;
                                        }
                                    }
                                    while (userInput == 5);
                                    break;

                                case 6://Exit
                                    {
                                        Console.WriteLine("\nAre you sure you want to exit? \nPress \"N\" to restart program\nPress any other key to exit");
                                        string restartAsString = Console.ReadLine();

                                        if (restartAsString.Equals("n", StringComparison.CurrentCultureIgnoreCase))
                                        {
                                            caseRestart++;
                                            Console.Clear();
                                            break;
                                        }
                                        else
                                        {
                                            restart = false;
                                            Console.Clear();
                                            Console.WriteLine("GoodBye");
                                            Thread.Sleep(1000);
                                            Environment.Exit(0);
                                        }
                                        break;

                                    }
                                default:
                                    {
                                        Console.WriteLine("\nThat is not a Valid Entry");
                                        userInput = DoNext(menuItem);
                                        Console.Clear();
                                        Header();

                                        break;
                                    }
                            }
                        }

                    }
                }
            }
        }

        /// //////////////////////////////////////////////////////////Null or WhiteSpace

        static void NullOrWhiteSpace(string stringInput)
        {
            bool a;

            a = string.IsNullOrWhiteSpace(stringInput);

            if (a == true)
            {
                Console.WriteLine("Error: Request Unavailable");

            }

        }

        ///////////////////////////////////////////////////////////////////Number Check Method///////////////////////////////////////////

        static int NumberCheck(string input)
        {
            int menuItem;

            do
            {

                bool numVer = int.TryParse(input, out menuItem);
                if ((menuItem != 0))
                {
                    return menuItem;
                }
                else if (menuItem == 0)
                {
                    Console.WriteLine("That is not a valid entry, please enter a number");
                    input = Console.ReadLine();
                }
            }
            while (menuItem == 0);
            return menuItem;
        }

        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        //////////////////////////////////////////HEADER METHOD/////////////////////////////////////////////////////////////////
        static void Header()
        {
            // Console.Clear();
            StringBldrLine();
            string title = "Banking Account";
            Console.SetCursorPosition((Console.WindowWidth - title.Length) / 2, Console.CursorTop);
            Console.WriteLine(title + "\n\n", Console.Title);

            Console.WriteLine("Main Menu");
            Console.WriteLine("1: View Client Information");
            Console.WriteLine("2: View Account Balance");
            Console.WriteLine("3: Deposit Funds");
            Console.WriteLine("4: Withdraw Funds");
            Console.WriteLine("5: View Transaction History");
            Console.WriteLine("6: Exit");
            StringBldrLine();
        }
        //////////////////////////////////////////Do Next METHOD/////////////////////////////////////////////////////////////////
        static int DoNext(string menuItem)

        {
            int userInput;
            Console.WriteLine("\nWhat would you like to do next? Enter a menu number:");
            menuItem = Console.ReadLine();

            userInput = NumberCheck(menuItem);

            return userInput;

        }

        //////////////////////////////////////////StringBldrLine METHOD/////////////////////////////////////////////////////////////////
        static void StringBldrLine()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("*");
            for (int i = 1; i <= 79; i++)
            {
                sb.Append("*");
            }
            Console.WriteLine(sb);
        }


        ///////////////////////////////////////////////////////////////////Number Check Method - Decimal///////////////////////////////////////////

        static decimal NumberCheckDec(string input)
        {

            decimal userinput;
            do
            {
                
                bool numVer = decimal.TryParse(input, out userinput);
                if ((userinput != 0) && (userinput>=0)) 
                {
                    return userinput;
                }
                else if ((userinput == 0) || (userinput<0))
                {
                    Console.WriteLine("That is not a valid entry, please enter a dollar amount");
                    input = Console.ReadLine();
                }
            }
            while ((userinput == 0) || (userinput < 0));
            return userinput;
        }

    }
}
