﻿
using Arrays;
using System.Collections;

#region Example Arrays
void TestSearchWord()
{
    string[] arrayWords = new string[5];
    
    for(int i = 0; i < arrayWords.Length; i++)
    {
        Console.Write($"Type {i+1}º Word: ");

        arrayWords[i] = Console.ReadLine()!;
    }

    Console.WriteLine("Type word to search: ");
    var search = Console.ReadLine();

    foreach(string word in arrayWords)
    {
        if (word.Equals(search))
        {
            Console.WriteLine($"Word founded: {search}");
            
            break;
        }
    }
}

Array demo = Array.CreateInstance(typeof(double), 5);

demo.SetValue(5.9, 0);
demo.SetValue(1.8, 1);
demo.SetValue(7.1, 2);
demo.SetValue(10, 3);
demo.SetValue(6.9, 4);

//[5.9][1.8][7.1][10][6.9]

void TestMediana(Array array)
{
    if((array == null) || (array.Length == 0))
    {
        Console.WriteLine("Array is empty");
    }

    double[] orderNumbers = (double[]) array.Clone();
    Array.Sort(orderNumbers);
    //[1.8][5.9][6.9][7.1][10]  

    int length = orderNumbers.Length;
    int mid = length / 2;
    double mediana = (length % 2 != 0) ? orderNumbers[mid] : (orderNumbers[mid] + orderNumbers[mid - 1]) / 2;

    Console.WriteLine($"Mediana = {mediana}");

}

void TestArrayAccount()
{

    ListCurrentAccount listAccount = new ListCurrentAccount();
    listAccount.Add(new Account(874, "129121"));
    listAccount.Add(new Account(875, "421323"));
    listAccount.Add(new Account(876, "888392"));
    listAccount.Add(new Account(876, "999212"));
    listAccount.Add(new Account(876, "100002"));
    listAccount.Add(new Account(876, "603033"));
    listAccount.Add(new Account(876, "203930"));

    var accountExample = new Account(923, "12832-X");

    listAccount.Add(accountExample);

    for (int i = 0; i < listAccount.Size; i++)
    {
        Account account = listAccount[i];
        Console.WriteLine($"Index [{i}]: {account.NumberAccount}");
    }

}
#endregion 

List<Account> _listAccount = new List<Account>(){
    new Account(1, "1235-2")
    {
        BalanceInitital = 900,
        CPF = "123"
    },
    new Account(1, "1321-X")
    {
        BalanceInitital = 200,
        CPF = "321"
    },
    new Account(3, "10912-1")
    {
        BalanceInitital = 50,
        CPF = "012"
    },

};

List<Account> _listAccount2 = new List<Account>(){
    new Account(1, "1235-A")
    {
        BalanceInitital = 900,
    },
    new Account(2, "1321-B")
    {
        BalanceInitital = 200,
    },
    new Account(3, "10912-C")
    {
        BalanceInitital = 50,
    },

};

List<Account> _listAccount3 = new List<Account>(){
    new Account(1, "1235-D")
    {
        BalanceInitital = 900,
    },
    new Account(2, "1321-E")
    {
        BalanceInitital = 200,
    },
    new Account(3, "10912-F")
    {
        BalanceInitital = 50,
    },

};


void SupportClient()
{
    try
    {
        char option = '0';

        while (option != '6')
        {
            Console.Clear();
            Console.WriteLine("===============================");
            Console.WriteLine("===       Support           ===");
            Console.WriteLine("===1 - Register Account     ===");
            Console.WriteLine("===2 - List Account         ===");
            Console.WriteLine("===3 - Remove Account       ===");
            Console.WriteLine("===4 - Order Account        ===");
            Console.WriteLine("===5 - Search Account       ===");
            Console.WriteLine("===6 - Exit                 ===");
            Console.WriteLine("===============================");
            Console.WriteLine("\n\n");
            Console.Write("Choose option you want to: ");

            try
            {
                option = Console.ReadLine()[0];
            }catch(Exception ex)
            {
                throw new HandlerException(ex.Message);
            }

            switch (option)
            {
                case '1':
                    CreateAccount();
                    break;
                case '2':
                    ListAccount();
                    break;
                case '3':
                    RemoveAccount();
                    break;
                case '4':
                    //OrderAccount();
                    Console.WriteLine("Guilherme from future working on that");
                    break;
                case '5':
                    SearchAccount();
                    break;
                case '6':
                    ExitSupport();
                    break;
                default:
                    Console.WriteLine("Option unavailable");
                    break;
            }
        }
    }
    catch (HandlerException ex)
    {
        Console.WriteLine(ex.Message);
    }
    
}

void ExitSupport()
{
    Console.WriteLine("... Leaving supporte ...");
    Console.WriteLine("...     Goodbye =)   ...");
    Console.ReadKey();
}

void ListAccount()
{
    Console.Clear();
    Console.WriteLine("=====================");
    Console.WriteLine("=== List Accounts ===");
    Console.WriteLine("=====================");
    Console.WriteLine("\n");

    if(_listAccount.Count <= 0)
    {
        Console.WriteLine("... List of Account is empty");
        Console.ReadKey();
        return;
    }

    foreach(Account account in _listAccount) {
        Console.WriteLine(account.ToString());
        Console.ReadKey();
    }
}

void CreateAccount()
{
    Console.Clear();
    Console.WriteLine("===============================");
    Console.WriteLine("===   REGISTER ACCOUNT    ===");
    Console.WriteLine("===============================");
    Console.WriteLine("\n");
    Console.WriteLine("=== Type info of Account ===");
    Console.Write("Account Number: ");
    string numberAccount = Console.ReadLine();

    Console.Write("Agency Number: ");
    int numberAgency = int.Parse(Console.ReadLine());

    Account account = new Account(numberAgency, numberAccount);

    Console.Write("Type Balance Initial: ");
    account.BalanceInitital = double.Parse(Console.ReadLine());

    Console.Write("Type name: ");
    account.NameClient = Console.ReadLine();

    Console.Write("Type CPF: ");
    account.CPF = Console.ReadLine();

    Console.Write("Type profession: ");
    account.Profession = Console.ReadLine();

    _listAccount.Add(account);

    Console.WriteLine("... Account successfully made! ...");
    Console.ReadKey();
}

void RemoveAccount()
{
    Console.Clear();
    Console.WriteLine("===============================");
    Console.WriteLine("===      Remove Account     ===");
    Console.WriteLine("===============================");
    Console.WriteLine("\n");
    Console.Write("Type the number account: ");
    string numberAccount = Console.ReadLine();

    Account account = null;
    foreach(var item in _listAccount)
    {
        if (item.NumberAccount.Equals(numberAccount))
        {
            account = item;
        }
    }

    if(account != null)
    {
        _listAccount.Remove(account);
        Console.WriteLine("... Account removed from list ...");
    }
    else
    {
        Console.WriteLine("... Account not founded ...");
    }

    Console.ReadKey();
}

void OrderAccount()
{
    //To order list, you need to implement interface IComparable at Account class. In my case, didn't work to implement =( Bug on IDE;
    //Guilherme from future, you'll can solve that
    //error CS0535: 'Account' does not implement interface member 'IComparable<Account>.CompareTo(Account?)'
    _listAccount.Sort();
    Console.WriteLine("... List of order account ...");
    Console.ReadKey();
}

void SearchAccount()
{
    Console.Clear();
    Console.WriteLine("===============================");
    Console.WriteLine("===     Search Account      ===");
    Console.WriteLine("===============================");
    Console.WriteLine("\n");
    Console.Write("Do you want to search by (1) number account or (2) CPF or (3) number agency? ");
    switch (int.Parse(Console.ReadLine()))
    {
        case 1:
            {
                Console.Write("Type the number account: ");
                string _numberAccount = Console.ReadLine();
                Account account = SearchByNumberAccount(_numberAccount);
                Console.WriteLine(account.ToString());
                Console.ReadKey();
                break;
            }
        case 2:
            {
                Console.Write("Type the CPF: ");
                string _cpf = Console.ReadLine();
                Account account = SearchByCPF(_cpf);
                Console.WriteLine(account.ToString());
                Console.ReadKey();
                break;
            }
        case 3:
            {
                Console.Write("Type the agency: ");
                int _agency = int.Parse(Console.ReadLine());
                var accountByAgency = SearchByAgency(_agency);
                ShowListAccount(accountByAgency);
                Console.ReadKey();
                break;
            }
    }
}

void ShowListAccount(List<Account> accountByAgency)
{
    if(accountByAgency == null)
    {
        Console.WriteLine(" ... The query did not return data ... ");
    }
    else
    {
        foreach(var item in accountByAgency)
        {
            Console.WriteLine(item.ToString());
        }
    }

}

Account SearchByCPF(string? cpf)
{
    return _listAccount.Where(account => account.CPF == cpf).FirstOrDefault();
}

Account SearchByNumberAccount(string? numberAccount)
{
    return _listAccount.Where(account => account.NumberAccount == numberAccount).FirstOrDefault();
}

List<Account> SearchByAgency(int? _agency)
{
    var query = (
            from account in _listAccount
            where account.AgencyId == _agency
            select account).ToList();

    return query;
}


#region Examples Methods List
//Console.WriteLine("Method AddRange and Inverse");

//_listAccount2.AddRange(_listAccount3);
//_listAccount2.Reverse();

//for (int i = 0; i < _listAccount2.Count; i++)
//{
//    Console.WriteLine($"Index[{i}] = Account [{_listAccount2[i].NumberAccount}]");
//}

//Console.WriteLine("\n\nMethod GetRange");

//var range = _listAccount3.GetRange(0, 1);

//for(int i = 0; i < range.Count; i++)
//{
//    Console.WriteLine($"Index[{i}] = Account [{range[i].NumberAccount}]");
//}

//Console.WriteLine("\n\nMethod Clear");

//_listAccount3.Clear();

//for (int i = 0; i < _listAccount3.Count; i++)
//{
//    Console.WriteLine($"Index[{i}] = Account [{range[i].NumberAccount}]");
//}
#endregion


SupportClient();