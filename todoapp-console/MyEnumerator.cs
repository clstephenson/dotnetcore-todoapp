using System;
using System.Collections.Generic;

namespace todoapp
{
    class MyEnumerator<T> : IEnumerator<T>
        {
            public List<T> items;
            int position = -1;

            public MyEnumerator(List<T> list) => items = list;

            private IEnumerator<T> GetEnumerator() => (IEnumerator<T>)this;

            public bool MoveNext()
            {
                position++;
                return (position < items.Count);
            }

            public void Reset() => position = -1;

        public void Dispose()
        {
            position = -1;
        }

        public Object Current
        {
            get 
            {
                try
                {
                    return items[position];
                }
                catch (IndexOutOfRangeException)
                {
                    throw new InvalidOperationException();
                }
            }
        }

        T IEnumerator<T>.Current
        {
            get 
            {
                try
                {
                    return items[position];
                }
                catch (IndexOutOfRangeException)
                {
                    throw new InvalidOperationException();
                }
            }
        }
    }
    
}