using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using Ultility;

namespace Utility
{
    public class SLL : ILinkedListADT
    {
        private Node head;
        private Node tail;
        private int listSize;

        public SLL()
        {
            head = null;
            tail = null;
            listSize = 0;
        }

        public bool IsEmpty() => listSize == 0;

        public void Clear()
        {
            head = tail = null;
            listSize = 0;
        }

        public int Size() => listSize;

        public void Append(object data)
        {
            Node newNode = new Node(data);
            if (IsEmpty())
            {
                head = tail = newNode;
            }
            else
            {
                tail.Next = newNode;
                tail = newNode;
            }
            listSize++;
        }

        public void Prepend(object data)
        {
            Node newNode = new Node(data, head);
            head = newNode;
            if (tail == null) tail = head;
            listSize++;
        }

        public void Insert(object data, int index)
        {
            if (index < 0 || index > listSize)
                throw new IndexOutOfRangeException("Invalid index.");

            if (index == 0) { Prepend(data); return; }
            if (index == listSize) { Append(data); return; }

            Node prev = GetNode(index - 1);
            Node newNode = new Node(data, prev.Next);
            prev.Next = newNode;
            listSize++;
        }

        public void Replace(object data, int index)
        {
            if (index < 0 || index >= listSize)
                throw new IndexOutOfRangeException("Invalid index.");

            GetNode(index).Data = data;
        }

        public object Retrieve(int index)
        {
            if (index < 0 || index >= listSize)
                throw new IndexOutOfRangeException("Invalid index.");

            return GetNode(index).Data;
        }

        public int IndexOf(object data)
        {
            int index = 0;
            for (Node current = head; current != null; current = current.Next, index++)
            {
                if (current.Data.Equals(data))
                    return index;
            }
            return -1;
        }

        public bool Contains(object data) => IndexOf(data) != -1;

        public void Delete(int index)
        {
            if (index < 0 || index >= listSize)
                throw new IndexOutOfRangeException("Invalid index.");

            if (index == 0)
            {
                head = head.Next;
                if (head == null) tail = null;
            }
            else
            {
                Node prev = GetNode(index - 1);
                prev.Next = prev.Next.Next;
                if (prev.Next == null) tail = prev;
            }
            listSize--;
        }

        private Node GetNode(int index)
        {
            Node current = head;
            for (int i = 0; i < index; i++)
            {
                current = current.Next;
            }
            return current;
        }
    }
}

