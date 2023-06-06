
using Exception;
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

    ReadFile file = new ReadFile("contas.txt");
    file.ReadNextLine();
    file.ReadNextLine();
    file.Close();
}
catch (IOException)
{
    Console.WriteLine("Error reading file");

}