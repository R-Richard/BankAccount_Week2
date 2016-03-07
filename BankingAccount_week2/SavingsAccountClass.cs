using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingAccount_week2
{
    class SavingsAccount : Account
    {

        private int savingsTransactionNbr;
        private string savingsAccountNbr;


        public SavingsAccount()
        {

            AccountType = "Savings Account";
            SavingsAccountNbr = savingsAccountNbr;
            SavingsTransactionNbr = 0;
        }


        public string SavingsAccountNbr
        {
            get
            {
                return savingsAccountNbr;
            }
            set
            {
                savingsAccountNbr = value;
            }
        }


        public int SavingsTransactionNbr
        {
            get
            {
                return savingsTransactionNbr;
            }
            set
            {
                savingsTransactionNbr = value;
            }
        }


        // provide alert if more than 3 transactions completed
        public string getSavingsTransactionNbrWarning()

        {
            if (SavingsTransactionNbr > 3)
            {
                string x = ("Alert: More Than Three Savings Withdraws Completed Today");
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
