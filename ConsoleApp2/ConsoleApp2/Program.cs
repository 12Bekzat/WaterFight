using System;

namespace ConsoleApp2
{
    public interface Iterator<T>
    {
        public T GetNext();
        public T GetPrev();

        public bool MoveNext();
        public bool MovePrev();
    }

    public class LinkedList<T> : Iterator<T>
    {
        private T CurrentItem { get; set; }
        private T Next { get; set; }
        private T Prev { get; set; }

        public void AddLast(T item)
        {
            Prev = CurrentItem;
            CurrentItem = item;
        }



        public T GetNext()
        {
            return Next;
        }

        public T GetPrev()
        {
            return Prev;
        }

        public bool MoveNext()
        {
            if(CurrentItem == null)
            {
                return false;
            }

            CurrentItem = Next;
            return true;
        }

        public bool MovePrev()
        {
            throw new NotImplementedException();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
           
        }
    }
}
