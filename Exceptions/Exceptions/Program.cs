double TaxOperation = 0;
int TotalAccount = 0;


try
{
    TaxOperation = 30 / TotalAccount;
}
catch(DivideByZeroException) {
    Console.WriteLine("Error: Divided by zero!");
}


Console.WriteLine(TaxOperation);