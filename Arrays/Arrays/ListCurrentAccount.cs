using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arrays
{
    public class ListCurrentAccount
    {
        private Account[] _items = null;
        public int _nextIndex = 0;

        //definir valor default do construtor  \/
        public ListCurrentAccount(int initLength = 5)
        {
            _items = new Account[initLength];
        }

        public void Add(Account account)
        {

            Console.WriteLine($"Adding item at position {_nextIndex}");
            VerifyLength(_nextIndex + 1);
            _items[_nextIndex] = account;
            _nextIndex++;
        }

        private void VerifyLength(int lengthRequired)
        {
            if(_items.Length >= lengthRequired)
            {
                return;
            }

            Console.WriteLine("Add a slot in array!");

            Account[] newArray = new Account[lengthRequired];

            for(int i = 0; i < _items.Length; i++)
            {
                newArray[i] = _items[i];
            }

            _items = newArray;
        }
    }
}
