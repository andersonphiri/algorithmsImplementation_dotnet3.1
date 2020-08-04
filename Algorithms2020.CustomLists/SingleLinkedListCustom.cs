using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms2020.CustomLists
{
    public class SingleLinkedListCustom<T>
    {
        public Node<T> Head { get; set; }
        private long size = 0;
        public SingleLinkedListCustom()
        {
            Head = null;
        }

        /// <summary>
        /// this method will insert at the end of this list
        /// </summary>
        /// <param name="item"></param>
        public void InsertDefault(T item)
        {
            var node = new Node<T>(item);

            if (Head is null)
            {
                Head = node;
                return;
            }
            else
            {
                var lastNode = this.Head;
                while(lastNode.Next != null)
                {
                    lastNode = lastNode.Next;
                }
                lastNode.Next = node;
            }
            size++;

        }
        public void InsertBegining(T item)
        {
            Node<T> newNode = new Node<T>(item);
            newNode.Next = Head;
            Head = newNode;
            
            size++;
        }
        public Node<T> DeleteFirst()
        {
            if (Head.Next is null)
            {
                //list is empty
                Head = null;
                size--;
                return Head;
            }
            var currentHead = Head;
            Head = Head.Next;
            size--;
            return currentHead;
        }

        public Node<T> DeleteLast()
        {
            if (Head.Next is null)
            {
                //list is empty
                size--;
                return Head;
            }
            var currentHead = Head;
            while (currentHead.Next.Next != null)
                currentHead.Next = currentHead.Next.Next;
            var neededHead = currentHead.Next;
            currentHead.Next = null;
            size--;
            return neededHead;
        }

        public Node<T> DeletePosition(int positionNotIndex)
        {
            if (positionNotIndex < 1)
                throw new ArgumentOutOfRangeException(nameof(positionNotIndex), message: "please specify a valid position, ");
            if (Head is null)
            {
                size--;
                return null;
            }

            Node<T> current = Head;
            if (positionNotIndex==1)
            {
                Head = Head.Next;
                size--;
                return (current.Next = null);
            }

            for (int i = 0; current != null && i <positionNotIndex; i++)
                current = current.Next;
            var toDelete = current.Next;
            current.Next = current.Next.Next;
            size--;
            return (toDelete.Next = null);
        }

        public Node<T> GetValueAt(int positionNotIndex)
        {
            if (positionNotIndex < 1)
                throw new ArgumentOutOfRangeException(nameof(positionNotIndex), message: "please specify a valid position, ");
            if (Head is null)
            {
                return null;
            }

            Node<T> current = Head;
            if (positionNotIndex == 1)
            {
                return (current );
            }

            for (int i = 0;  i < positionNotIndex-1; i++)
                 current = current.Next;
            return current;
        }
        public long GetLongSize() => size;

        //traversal
        public void PrintLinkedList()
        {
            Node<T> node = Head;
            Console.WriteLine("############# Begining list ############");
            while (node!=null)
            {
                System.Console.WriteLine($"The value is: {node.Data}");
                node = node.Next;
            }
        }
    }
}
