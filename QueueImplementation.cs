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

        public QueueImplementation(int size)
        {
            front = default;
            rear = default;
            queue = new T[size];
        }

        internal void Enqueue(T value)
        {
            queue[rear++] = value;
            length++;
        }

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
