class Music
{
    //digite prop + tab (atalho para criação de atributo)
    public string Name { get; set; }

    public string Artist { get; set; }

    public int Duration { get; set; }

    public bool Available { get; set; }

    public string FullName { get; set; }

    public void ShowDataSheet()
    {
        Console.WriteLine($"Name: {Name}");
        Console.WriteLine($"Artist: {Artist}");
        Console.WriteLine($"Duration: {Duration}");

        if (Available) Console.WriteLine($"Available"); else Console.WriteLine("Not Available");
    }
}