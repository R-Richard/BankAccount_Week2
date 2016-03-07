using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingAccount_week2
{
    class Clients
    { //instance variables - private modifier
        private string clientFirstName;
        private string clientLastName;
        private string clientContactPhone;
        // private int accountNbr;

        //constructor- method to make it member of class - made public so peoploe outside class able to create client info
        //constructor - always same name as class, no return type
        //assign value in method parameter to instance variable --using this.

        public Clients()
        {
            ClientContactPhone = "216-555-5555";
            ClientFirstName = "Tester";
            ClientLastName = "McTesterson";
        }

        //constructor 2 - for use if parameters entered within main program for name
        public Clients(string clientFirstName, string clientLastName)
        {
            this.clientFirstName = clientFirstName;
            this.clientLastName = clientLastName;
        }


        //Methods - public methods
        public string GetFullName()
        {
            return (ClientFirstName + " " + ClientLastName);
        }

        public string GetClientContactPhone()
        {
            return (clientContactPhone);
        }

        public void SetClientContactPhone(string clientContactPhone)
        {
            this.clientContactPhone = clientContactPhone;
        }


        //Properties


        public string ClientFirstName
        {
            get
            {
                return clientFirstName;
            }
            set
            {
                clientFirstName = value;
            }
        }

        public string ClientLastName
        {
            get
            {
                return clientLastName;
            }
            set
            {
                clientLastName = value;
            }
        }
        public string ClientContactPhone
        {
            get
            {
                return clientContactPhone;
            }
            set
            {
                clientContactPhone = value;
            }
        }

    }

}

