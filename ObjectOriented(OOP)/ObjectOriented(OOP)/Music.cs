class Music
{
    public string name;
    public string artist;
    public int duration;
    public bool available;

    public void ShowDataSheet()
    {
        Console.WriteLine($"Name: {name}");
        Console.WriteLine($"Artist: {artist}");
        Console.WriteLine($"Duration: {duration}");

        if (available) Console.WriteLine($"Available"); else Console.WriteLine("Not Available");
    }
}