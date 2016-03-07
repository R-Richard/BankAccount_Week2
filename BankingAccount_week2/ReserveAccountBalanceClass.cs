using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingAccount_week2
{
    class ReserveAccount : Account
    {
        private bool balanceWarning;
        private string reserveAccountNbr;

        public ReserveAccount()
        {
            AccountType = "Reserve Account";
            BalanceWarning = balanceWarning;
            ReserveAccountNbr = reserveAccountNbr;
        }



        public string ReserveAccountNbr
        {
            get
            {
                return reserveAccountNbr;
            }
            set
            {
                reserveAccountNbr = value;
            }
        }

        public bool BalanceWarning
        {
            get
            {
                return balanceWarning;
            }
            set
            {
                balanceWarning = value;
            }

        }
        // provide alert if Reserve Balance is below $200 
        public bool getBalanceWarning()
        {
            if (this.balance < 200)
            {
                balanceWarning = true;
                    }
            else
            {
                balanceWarning = false;
            }
           
            return balanceWarning;

        }


       
    }
}

