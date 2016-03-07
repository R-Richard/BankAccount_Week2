using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingAccount_week2
{
    class CheckingAccount : Account
    {// check nbr and list not used yet
        protected List<int> checkLog = new List<int>();
        protected int checkNbr;
        protected int checkingTransactionNbr;
        protected string checkingAccountNbr;
         
        public CheckingAccount()
        {
            AccountType = "Checking Account";
            CheckingAccountNbr = checkingAccountNbr;
            CheckNbr = 100;
            CheckingTransactionNbr = 0;
        }

        public string CheckingAccountNbr
        {
            get
            {
                return checkingAccountNbr;
            }
            set
            {
                checkingAccountNbr = value;
            }
        }

        public int CheckNbr
        {
            get
            {
                return checkNbr;
            }
            set
            {
                checkNbr = value;
            }
        }

        public List<int> CheckLog = new List<int>();

        public int CheckingTransactionNbr
        {
            get
            {
                return checkingTransactionNbr;
            }
            set
            {
                checkingTransactionNbr = value;
            }
        }

        // provide alert if more than 3 transactions completed
        public string getCheckingTransactionWarning()

        {
            if (CheckingTransactionNbr > 3)
            {
                string x = ("Alert: More Than Three Checking Withdraws Completed Today");
                return x;
            }
            else
            {
                string x = null;
                return x;
            }
        }

    }

}