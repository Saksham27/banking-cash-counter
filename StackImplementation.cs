using System;
using System.Collections.Generic;
using System.Text;

namespace BankingCashCounter
{
    /// <summary>
    /// class to implement stack using array
    /// </summary>
    /// <typeparam name="T"> data type of the values of the stack </typeparam>
    class StackImplementation<T>
    {
        const int MAX = 100;
        int top;
        T[] stack = new T[MAX];

        /// <summary>
        /// constructor which initializes an empty stack when called.
        /// </summary>
        StackImplementation()
        {
            top = -1;
        }

        /// <summary>
        /// method to check if stack is empty or not
        /// </summary>
        /// <returns> true or false </returns>
        bool IsEmpty()
        {
            if(top < 0)
            {
                return true;
            }
            return false;
        }
        
        /// <summary>
        /// method to push add element at the top of the stack
        /// </summary>
        /// <param name="value"> value of the element to be added </param>
        /// <returns> true </returns>
        bool Push(T value)
        {
            if (top >= MAX)
            {
                Console.WriteLine("Stack Overflow");
                return false;
            }
            else
            {
                stack[++top] = value;
                return true;
            }
        }

        /// <summary>
        /// method to remove topmost elements of the stack
        /// </summary>
        /// <returns> value of the topmost element of stack </returns>
        T Pop()
        {
            if (top < 0)
            {
                Console.WriteLine("Stack Underflow");
                return default;
            }
            else
            {
                T value = stack[top--];
                return value;
            }
        }
        
        /// <summary>
        /// method to view the topmost element of the stack
        /// </summary>
        /// <returns> value of topmost element </returns>
        T Peek()
        {
            if (top < 0)
            {
                Console.WriteLine("Stack Underflow");
                return default;
            }
            else
                return stack[top];
        }
    }
}
