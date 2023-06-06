
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


int[] values = { 10, 58, 36, 47 };

for(int i = 0; i < 5; i++)
{
    Console.WriteLine(values[i]);
}