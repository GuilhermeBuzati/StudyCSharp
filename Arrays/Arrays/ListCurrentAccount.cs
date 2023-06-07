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

        public void Delete(Account account)
        {
            int indexItem = -1;

            for(int i = 0; i < _nextIndex; i++)
            {
                Account accountActual = _items[i];

                if(accountActual == account)
                {
                    indexItem = i; 
                    break;
                }
            }

            for(int i = indexItem; i < _nextIndex-1; i++) {

                _items[i] = _items[i + 1];
            }

            _nextIndex--;
            _items[_nextIndex] = null;
        }

        public void ShowList()
        {
            Console.WriteLine("=======================");
            for (int i = 0; i< _items.Length;i++)
            {
                if (_items[i] != null)
                {
                    var account = _items[i];
                    Console.WriteLine($"Index[{i}] = Account: {account.number_account}");

                }
            }
        }

        public Account GetAccountIndex(int index)
        {
            if(index < 0  || index >= _nextIndex)
            {
                throw new ArgumentOutOfRangeException(nameof(index));
            }

            return _items[index];
        }

        public int Size { get {
                return _nextIndex;
            } }   

        public Account this[int index]
        {
            get
            {
                return GetAccountIndex(index);
            }
        }
    }
}
