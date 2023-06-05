class Music
{
    public Music(Band artist) {
        
        Artist = artist;
    
    }

    //digite prop + tab (atalho para criação de atributo)
    public string Name { get; set; }

    public Band Artist { get; }

    public int Duration { get; set; }

    public bool Available { get; set; }

    public string Resume => $"The music {Name} belongs the band {Artist}";

    public void ShowDataSheet()
    {
        Console.WriteLine($"Name: {Name}");
        Console.WriteLine($"Artist: {Artist}");
        Console.WriteLine($"Duration: {Duration}");

        if (Available) Console.WriteLine($"Available"); else Console.WriteLine("Not Available");
    }
}