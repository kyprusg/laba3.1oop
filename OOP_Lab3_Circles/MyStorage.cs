using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OOP_Lab3_Circles
{
    internal class MyStorage<T>
    {
        private T[] _items;
        private int _count;

        public MyStorage()
        {
            _items = new T[10];
            _count = 0;
        }
        public int GetCount() {  return _count; }

        public void Add(T item)
        {
            if (_count == _items.Length)
            {
                Resize(_items.Length * 2);
            }

            _items[_count] = item;
            _count++;
        }
        public T GetObject(int index) {  return _items[index]; }
        public void SetObject(int index, T item)
        {
            if (index>=0 && index < _count)
            {
                _items[index] = item;
            }
        }
        public void RemoveAt(int index)
        {
            for (int i = index; i < _count-1; i++)
            {
                _items[i] = _items[i+1];
            }
            _items[_count-1] = default(T);
            _count--;
        }
        private void Resize(int newCapacity)
        {
            T[] newArray = new T[newCapacity];
            for(int i = 0; i < _count; i++)
            {
                newArray[i] = _items[i];
            }
            _items = newArray;
        }
    }
}
