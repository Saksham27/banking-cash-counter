using System;
using System.Collections.Generic;
using System.Text;

namespace BankingCashCounter
{
    public class Customer
    {
        public int accountNo;
        public string customerName;
        
        /// <summary>
        /// method to enter account number by customer
        /// </summary>
        public void SetAccountNo()
        {
            Console.Write("Enter your account No. : ");
            this.accountNo  = Convert.ToInt32(Console.ReadLine());
            
        }

        /// <summary>
        /// method to enter name by customer
        /// </summary>
        public void SetName()
        {
            Console.Write("Enter Your name : ");
            this.customerName =  Console.ReadLine();
        }
    }
}
