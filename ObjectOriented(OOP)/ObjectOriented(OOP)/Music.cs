class Music
{
    private string name;
    private string artist;
    private int duration;
    private bool available;

    public void WriteAvailable(bool value)
    {
        available = value;
    }

    public bool ReadAvailable() 
    { 
        return available; 
    }

    public void ShowDataSheet()
    {
        Console.WriteLine($"Name: {name}");
        Console.WriteLine($"Artist: {artist}");
        Console.WriteLine($"Duration: {duration}");

        if (available) Console.WriteLine($"Available"); else Console.WriteLine("Not Available");
    }
}