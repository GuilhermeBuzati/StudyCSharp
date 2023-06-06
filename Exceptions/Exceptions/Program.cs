﻿
void CreateAccount()
{
    Console.WriteLine("Type account: ");
    int account = int.Parse(Console.ReadLine()!);

    if (account <= 0 ) throw new ArgumentException("Account must be greater than zero!", nameof(account));

}


try
{
    CreateAccount();

}
catch (ArgumentException ex) 
{
    Console.WriteLine("Error param: " + ex.ParamName);
    Console.WriteLine("It is not possible create account less than zero");
    Console.WriteLine(ex.Message);
}