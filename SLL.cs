using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Assignment_3_skeleton
{
    [Serializable]
    public class SLL : ILinkedListADT
    {
        private Node head;
        private Node tail;
        private int listSize;

        public Node Head { get => head; set => head = value; }
        public Node Tail { get => tail; set => tail = value; }
        public int ListSize { get => listSize; set => listSize = value; }

        public void Append(object data)
        {
            if (IsEmpty())
            {
                head = tail = new Node(data);
                listSize = 1;
                return;
            }
            tail.Next = new Node(data);
            tail = tail.Next;
            listSize++;
        }

        public void Clear()
        {
            head = tail = null;
            listSize = 0;
        }

        public bool Contains(object data)
        {
            return IndexOf(data) != -1;
        }

        public void Delete(int targetIndex)
        {
            if (targetIndex < 0 || targetIndex >= listSize)
                throw new IndexOutOfRangeException(Exceptions.IndexOutOfRangeException());

            if (targetIndex == 0)
            {
                head = head.Next;
                if (head == null)
                    tail = null;
                listSize--;
                return;
            }

            Node current = head;
            for (int i = 0; i < targetIndex - 1; i++)
                current = current.Next;

            current.Next = current.Next.Next;
            if (current.Next == null)
                tail = current;
            listSize--;
        }

        public int IndexOf(object data)
        {
            Node current = head;
            for (int i = 0; i < listSize; i++)
            {
                if (current.Data.Equals(data))
                    return i;
                current = current.Next;
            }
            return -1;
        }

        public void Insert(object data, int targetIndex)
        {
            if (targetIndex < 0 || targetIndex > listSize)
                throw new IndexOutOfRangeException(Exceptions.IndexOutOfRangeException());

            if (targetIndex == 0)
            {
                Prepend(data);
                return;
            }

            if (targetIndex == listSize)
            {
                Append(data);
                return;
            }

            Node current = head;
            for (int i = 0; i < targetIndex - 1; i++)
                current = current.Next;

            current.Next = new Node(data, current.Next);
            listSize++;
        }

        public bool IsEmpty()
        {
            return listSize == 0;
        }

        public void Prepend(object data)
        {
            Node newNode = new Node(data, head);
            head = newNode;
            if (listSize == 0)
                tail = head;
            listSize++;
        }

        public void Replace(object data, int targetIndex)
        {
            if (targetIndex < 0 || targetIndex >= listSize)
                throw new IndexOutOfRangeException(Exceptions.IndexOutOfRangeException());

            Node current = head;
            for (int i = 0; i < targetIndex; i++)
                current = current.Next;
            current.Data = data;
        }

        public object Retrieve(int targetIndex)
        {
            if (targetIndex < 0 || targetIndex >= listSize)
                throw new IndexOutOfRangeException(Exceptions.IndexOutOfRangeException());

            Node current = head;
            for (int i = 0; i < targetIndex; i++)
                current = current.Next;
            return current.Data;
        }

        public int Size()
        {
            return listSize;
        }

        // Additional method to reverse the linked list
        public void Reverse()
        {
            Node prev = null;
            Node current = head;
            tail = head;
            while (current != null)
            {
                Node next = current.Next;
                current.Next = prev;
                prev = current;
                current = next;
            }
            head = prev;
        }
    }
}
