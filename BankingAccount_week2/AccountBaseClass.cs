using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingAccount_week2
{
     class Account
    {
        //instance variables - private modifier - store component of AccountsClass
        protected decimal balance;
        protected string accountType;
        protected double accountNbr;
        protected decimal transactionAmount;

        public Account(double accountNbr, Clients clients, string accountType)
        {
            Clients = clients;
            Balance = 0m;
            TransactionAmount = transactionAmount;
            AccountNbr = accountNbr;


        }

        public Account(Clients clients)
        {
            Clients = clients;
            Balance = 0m;
            TransactionAmount = transactionAmount;
            AccountNbr = accountNbr;

        }

    
        public Account()
        {

            Balance = 0m;
            TransactionAmount = transactionAmount;
            AccountNbr = accountNbr;

        }

        public Account(CheckingAccount checkingAccount, Clients clients)
        {
            Clients = clients;
            CheckingAccount = checkingAccount;
            Balance = 0m;
            TransactionAmount = transactionAmount;
            AccountNbr = accountNbr;
        }


        //Properties
        public Clients Clients { get; set; }
        public CheckingAccount CheckingAccount { get; set; }

        public decimal TransactionAmount
        {
            get
            {
                return transactionAmount;
            }
            set
            {
                transactionAmount = value;
            }
        }

        public decimal Balance
        {
            get
            {
                return balance;
            }
            set
            {
                balance = value;
            }
        }

        public string AccountType
        {
            get
            {
                return accountType;
            }
            set
            {
                accountType = value;

            }
        }



        public double AccountNbr
        {
            get
            {
                return accountNbr;
            }
            private set
            {
                accountNbr = value;
            }
        }


        //Methods

        public decimal GetAccountBalance()
        {
            return balance;
        }


        public decimal Withdraw()
        {
            if (balance >= transactionAmount)
                balance = balance - transactionAmount;
            return balance;

        }

        public decimal Deposit()
        {
            balance = balance + transactionAmount;
            return balance;

        }


        public string CreateAccountNbr()
        {
            StringBuilder act = new StringBuilder();
            Random rand = new Random();
            for (int i = 1; i <= 10; i++)
            {
                act.Append(rand.Next(9));
            }
            string x = (act.ToString());
            return x;
        }


        public string getAccountNbr()
        {
            string x = CreateAccountNbr();
            return x;
        }

        public double GetAccountNbr()
        {
            return accountNbr;
        }
    }


}
