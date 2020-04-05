using System;
using System.Collections;
using System.Collections.Generic;

namespace BankingCashCounter
{
    class CashCounter
    {
        private const int STARTING_BALANCE = 5000;
        private int balance;
        
        /// <summary>
        /// method to add new customer to the queue
        /// </summary>
        /// <param name="accountNo"></param>
        /// <param name="name"></param>
        public void AddNewCustomer(QueueImplementation<int> accountNo, QueueImplementation<string> name)
        {
            Customer customer = new Customer();
            customer.SetName();
            customer.SetAccountNo();

            accountNo.Enqueue(customer.accountNo);
            name.Enqueue(customer.customerName);
        }

        /// <summary>
        /// method to display cash counter panel, add customer or attend customer
        /// </summary>
        /// <returns> user input </returns>
        public int CashCounterPanel()
        {
            Console.WriteLine("\n1. Add new Customer ");
            Console.WriteLine("\n2. Attend a customer ");
            Console.WriteLine("----------------------------------------------------");
            return Convert.ToInt32(Console.ReadLine());
        }

        /// <summary>
        /// method to display trsaction panel, Deposit and withdraw
        /// </summary>
        /// <returns> user input </returns>
        public int TransactionPanel()
        {
            Console.WriteLine("\n======= Select your Transaction From (1-3) ==========");
            Console.WriteLine("1. Deposit Money ");
            Console.WriteLine("2. Withdraw Money ");

            Console.WriteLine("-------------------------------------------------------\n");
            return Convert.ToInt32(Console.ReadLine());
        }

        /// <summary>
        /// method to deposit money to cash counter
        /// </summary>
        /// <param name="accountNo"> account no of customer </param>
        /// <param name="name"> name of customer </param>
        /// <param name="money"> amount to be deposited </param>
        public void DepositMoney(QueueImplementation<int> accountNo, QueueImplementation<string> name, int money)
        {
            Console.WriteLine("\nPlease go to Counter :(A)\n");
            Console.Write("Enter the Amount to be Deposit: ");
            money = Convert.ToInt32(Console.ReadLine());
            balance += money;
            Console.WriteLine("\n------------- Cash Deposit Reciept -----------");
            database[Convert.ToInt32(accountNo.Peek())] = money;
            Console.WriteLine("\n\tCash Deposited :   {0}\n\tAccount No :  {1}\n\tCust Name :   {2}\n", money, accountNo.Dequeue(), name.Dequeue());

            Console.WriteLine("------------  ---------------------------------");
        }

        /// <summary>
        /// method to withdraw money from cash counter
        /// </summary>
        /// <param name="accountNo"> account no of customer </param>
        /// <param name="name"> name of customer </param>
        /// <param name="money"> amount to be withdrawn </param>
        public void WithdrawMoney(QueueImplementation<int> accountNo, QueueImplementation<string> name, int money)
        {
            Console.WriteLine("\nPlease go to Counter :(B)\n");
            Console.Write("Enter the Amount to be Withdraw: ");
            money = Convert.ToInt32(Console.ReadLine());
            balance -= money;

            Console.WriteLine("\n------------- Cash Withdraw Reciept -----------");
            Console.WriteLine("\n\tCash Withdraw :   {0}\n\tAccount No :   {1}\n\tCust Name :    {2}\n", money, accountNo.Dequeue(), name.Dequeue());

            Console.WriteLine("----------- ---------------------------------");
        }

        /// <summary>
        /// method to open cash counter , add new customer and attend customer
        /// </summary>
        void OpenCashCounter()
        {
            this.balance = STARTING_BALANCE;
            QueueImplementation<int> accountNo = new QueueImplementation<int>(10);
            QueueImplementation<string> name = new QueueImplementation<string>(10);
            int money = default;

            while (true)
            {  
                int outer = CashCounterPanel();
                switch (outer)
                {
                    case 1:
                        AddNewCustomer(accountNo, name);
                        continue;

                    case 2:
                        if (accountNo.length > 0 && name.length > 0)
                        {
                            int inner = TransactionPanel();
                            switch (inner)
                            {
                                // Deposit Money
                                case 1:
                                    DepositMoney(accountNo, name, money, database);
                                    continue;
                                
                                // Withdrwal
                                case 2:
                                    WithdrawMoney(accountNo, name, money);
                                    continue;
                            }
                        }
                        else
                        {
                            Console.WriteLine("There is no Customer Available Right now...\n");
                            Console.WriteLine("Press 1 To go to add customer panel.");
                            Console.WriteLine("Press 2 to exit bank.");
                            var exitChoice = Console.ReadLine();
                            switch (exitChoice)
                            {
                                case "1":
                                    continue;
                                case "2":
                                    break;
                            }
                        }
                        break;
                }
                break;
            }

        }

        static void Main(string[] args)
        {
            CashCounter counter = new CashCounter();
            counter.OpenCashCounter();
        }
    }
}
