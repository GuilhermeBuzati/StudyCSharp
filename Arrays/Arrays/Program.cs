
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

TestSearchWord();