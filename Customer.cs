using System;
using System.Collections.Generic;
using System.Text;

namespace BankingCashCounter
{
    public class Customer
    {
        public int accountNo;
        public string customerName;
        
        public void setAccountNo()
        {
            Console.Write("Enter your account No. : ");
            this.accountNo  = Convert.ToInt32(Console.ReadLine());
            
        }

        public void setName()
        {
            Console.Write("Enter Your name : ");
            this.customerName =  Console.ReadLine();
        }
    }
}
