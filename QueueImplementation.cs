using System;
using System.Collections.Generic;
using System.Text;

namespace BankingCashCounter
{
    class QueueImplementation<T>
    {
        private static int front;
        private static int rear;
        public int length;
        private static T[] queue;

        /// <summary>
        /// constructor method to initialize a queue
        /// </summary>
        /// <param name="size"> max size of queue </param>
        public QueueImplementation(int size)
        {
            front = default;
            rear = default;
            queue = new T[size];
        }

        /// <summary>
        /// method to add a element to the rear end of queue
        /// </summary>
        /// <param name="value"> value of the element to be added </param>
        internal void Enqueue(T value)
        {
            queue[rear++] = value;
            length++;
        }

        /// <summary>
        /// method to remove a element to the front end of queue
        /// </summary>
        /// <returns> value of removed element </returns>
        internal T Dequeue()
        {
            if(front == rear)
            {
                Console.WriteLine("Queue is empty");
                return default;
            }
            else
            {
                T temp = queue[front];
                for(int i = front; i < rear - 1 ; i++)
                {
                    queue[i] = queue[i + 1];
                }

                if (rear < length)
                {
                    queue[rear] = default;
                }

                rear--;
                length--;
                return temp;
            }
           
        }

        /// <summary>
        /// method to view front element of queue
        /// </summary>
        /// <returns> front element value of queue </returns>
        internal T Peek()
        {
            if (front == rear)
            {
                return default;
            }
            return queue[front];
        }

    }
}
