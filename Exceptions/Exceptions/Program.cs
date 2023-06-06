
using Exceptions;

double amount = 100;
void CreateAccount()
{
    Console.WriteLine("Type account: ");
    int account = int.Parse(Console.ReadLine()!);

    if (account <= 0 ) throw new ArgumentException("Account must be greater than zero!", nameof(account));

}

void DebitAmount(double toDebit)
{
    if (toDebit <= amount)
    {
        amount -= toDebit;
    }
    else
    {
        throw new NotAmountException("Insufficient amount to complemente the action!");
    }
    

}

void GetAmount()
{
    Console.WriteLine($"Your amount is : {amount}");
}


try
{
    CreateAccount();

}
catch (ArgumentException ex) 
{
    Console.WriteLine("Error param: " + ex.ParamName);
    Console.WriteLine("It is not possible create account less than zero");
    Console.WriteLine(ex.StackTrace);
    Console.WriteLine(ex.Message);
}
catch (NotAmountException ex)
{
    Console.WriteLine("Amount insufficient");
    Console.WriteLine(ex.Message);
}