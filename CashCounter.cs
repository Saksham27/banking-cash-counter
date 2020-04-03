using System;
using System.Collections;
using System.Collections.Generic;

namespace BankingCashCounter
{
    class CashCounter
    {
        private const int STARTING_BALANCE = 5000;
        private int balance;
        public CashCounter()
        {
            this.balance = STARTING_BALANCE;
        }

        void Bank()
        {

            Queue accountNo = new Queue();
            Queue name = new Queue();
            Dictionary<int, int> database = new Dictionary<int, int>();
            int money;

        doTransAgain:
            Console.WriteLine("\n1. Add new Customer ");
            Console.WriteLine("\n2. Attend a customer ");
            Console.WriteLine("----------------------------------------------------");
            int outer = Convert.ToInt32(Console.ReadLine());

            switch (outer)
            {
                case 1:
                    Customer c = new Customer();
                    c.setName();
                    c.setAccountNo();

                    accountNo.Enqueue(c.accountNo);
                    name.Enqueue(c.customerName);
                    goto doTransAgain;

                case 2:
                    if (accountNo.Count > 0 && name.Count > 0)
                    {
                        Console.WriteLine("\n======= Select your Transaction From (1-3) ==========");
                        Console.WriteLine("1. Deposit Money ");
                        Console.WriteLine("2. Withdraw Money ");
                        Console.WriteLine("3. Print Passbook ");

                        Console.WriteLine("-------------------------------------------------------\n");
                        int inner = Convert.ToInt32(Console.ReadLine());
                        switch (inner)
                        {
                            case 1://Deposit Money
                                Console.WriteLine("\nPlease go to Counter :(A)\n");
                                Console.Write("Enter the Amount to be Deposit: ");
                                money = Convert.ToInt32(Console.ReadLine());
                                balance += money;
                                Console.WriteLine("\n------------- Cash Deposit Reciept -----------");
                                database[Convert.ToInt32(accountNo.Peek())] = money;
                                Console.WriteLine("\n\tCash Deposited :   {0}\n\tAccount No :  {1}\n\tCust Name :   {2}\n", money, accountNo.Dequeue(), name.Dequeue()) ;

                                Console.WriteLine("------------  ---------------------------------");
                                goto doTransAgain;

                            case 2://Withdrwal

                                Console.WriteLine("\nPlease go to Counter :(B)\n");
                                Console.Write("Enter the Amount to be Withdraw: ");
                                money = Convert.ToInt32(Console.ReadLine());
                                balance -= money;
                                
                                Console.WriteLine("\n------------- Cash Withdraw Reciept -----------");
                                Console.WriteLine("\n\tCash Withdraw :   {0}\n\tAccount No :   {1}\n\tCust Name :    {2}\n", money, accountNo.Dequeue(), name.Dequeue());

                                Console.WriteLine("----------- ---------------------------------");
                                goto doTransAgain;

                            case 3://Print Passbook

                                Console.WriteLine("\nYour Token No. {0} Please Attend at Counter :(C)\n");
                                Console.Write("Enter Money in Your Account : ");
                                money = Convert.ToInt32(Console.ReadLine());

                                Console.WriteLine("\n\t\t-----  Printing Pass Book ----- ");
                                Console.WriteLine("-------------------------------------------\n");
                                Console.WriteLine("\n\t\tAccount number :  {0}\n\t\tAccount Holder Name :{1}\n\t\tTotal Amount :  {2}\n", accountNo.Dequeue(), name.Dequeue(), money);

                                Console.WriteLine("--------------------------------------------\n");
                                goto doTransAgain;

                        }//Innser Switch case end

                    }//if end

                    else
                    {
                        Console.WriteLine("There is no Customer Available Right now...\n");
                        Console.WriteLine("Press 1 To go to add customer panel.");
                        Console.WriteLine("Press 2 to exit bank.");
                        var exitChoice = Console.ReadLine();
                        switch (exitChoice)
                        {
                            case "1":
                                goto doTransAgain;
                            case "2":
                                break;
                        }
                    }
                    break;//outer case 2 end

            }//outer switch case end

        }

        static void Main(string[] args)
        {
            CashCounter counter = new CashCounter();
            counter.Bank();
        }
    }
}
