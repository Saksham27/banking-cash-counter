using System;
using System.Collections.Generic;
using System.Text;

namespace BankingCashCounter
{
    /// <summary>
    /// a node of linked list
    /// </summary>
    /// <typeparam name="T"> data type of node </typeparam>
    class Node<T>
    {
        
        internal T value;
        internal Node<T> next;

        /// <summary>
        /// Node constructor
        /// </summary>
        /// <param name="value"> node value </param>
        public Node(T value)
        {
            this.value = value;
            this.next = null;
        }
    }

    /// <summary>
    /// linked list impementation 
    /// </summary>
    /// <typeparam name="T"> type of data link list will store</typeparam>
    class LinkedListImplementation<T>
    {
        const int START = 0;
        Node<T> head;
        Node<T> tail;
        internal int count;

        /// <summary>
        /// constructor which initializes an empty linked list when called.
        /// </summary>
        internal LinkedListImplementation()
        {
            this.head = null;
            this.tail = null;
            this.count = 0;
        }

        /// <summary>
        /// method to add a node to the LinkedList
        /// </summary>
        /// <param name="value"> value of node which is to be added </param>
        /// <returns> true </returns>
        internal bool Append(T value)
        {
            this.tail.next = new Node<T>(value);
            this.tail = this.tail.next;
            this.count++;
            return true;
        }

        /// <summary>
        /// method to add node at the beginning of the LinkedList
        /// </summary>
        /// <param name="value"> value of node which is to be added </param>
        /// <returns> true </returns>
        internal bool Prepend(T value)
        {
            Node<T> tempNode = new Node<T>(value);
            tempNode.next = this.head;
            this.head = tempNode;
            this.count++;
            return true;
        }

        /// <summary>
        /// method to add element at given position
        /// </summary>
        /// <param name="position"> position at which node will be added </param>
        /// <param name="value"> value of node to be added </param>
        /// <returns> true </returns>
        internal bool InsertNode(int position, T value)
        {
            Node<T> node = new Node<T>(value);
            if (position <= START)
            {
                return this.Prepend(value);
            }
            else if (position >= this.count)
            {
                return this.Append(value);
            }
            else
            {
                Node<T> tempNode = this.head;
                for (int i = START; i < position - START; i++)
                {
                    tempNode = tempNode.next;
                }
                node.next = tempNode.next;
                tempNode.next = node;
                this.count++;
                return true;
            }
            
        }

        /// <summary>
        /// method to delete node from the given position
        /// </summary>
        /// <param name="position"> position from which node to be deleted </param>
        /// <returns> node value </returns>
        internal T DeleteNode(int position)
        {
            Node<T> tempNode = this.head;

            if (position == START)
            {
                this.head = tempNode.next;
                Node<T> temp = tempNode;
            }
            else if (position == this.count)
            { 
                for (int i = START; i < position - START; i++)
                {
                    tempNode = tempNode.next;
                }

                Node<T> temp = tempNode.next;
                tempNode.next = null;
                this.tail = tempNode;
            }
            else
            {
                for (int i = START; i < position - START; i++)
                {
                    tempNode = tempNode.next;
                }

                Node<T> temp = tempNode.next.next;
                tempNode.next = temp;
            }
            this.count--;
            return tempNode.value;
        }

    }
}
