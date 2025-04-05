using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utility
{
    public interface ILinkedListADT
    {
        // Checks if the list is empty.
        bool IsEmpty();

        // Clears the list.
        void Clear();

        // Adds an item to the end of the list.
        void Append(object data);

        // Adds an item to the beginning of the list.
        void Prepend(object data);

        // Inserts an item at a specific index.
        // Throws IndexOutOfRangeException if the index is out of bounds.
        void Insert(object data, int index);

        // Replaces the data at the specified index.
        // Throws IndexOutOfRangeException if the index is out of bounds.
        void Replace(object data, int index);

        // Returns the number of elements in the list.
        int Size();

        // Removes an item at a specific index.
        // Throws IndexOutOfRangeException if the index is out of bounds.
        void Delete(int index);

        // Retrieves the data at the specified index.
        // Throws IndexOutOfRangeException if the index is out of bounds.
        object Retrieve(int index);

        // Gets the first index of an element containing the specified data.
        // Returns -1 if the data is not found.
        int IndexOf(object data);

        // Checks if the list contains an element with the specified data.
        bool Contains(object data);
    }
}
