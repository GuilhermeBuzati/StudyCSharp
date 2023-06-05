class Band
{
    private List<Album> albums = new List<Album>();

    public Band(string name)
    {
        Name = name;
    }

    public string Name { get; }

    public void AddAlbum(Album album)
    {
        albums.Add(album); 
    }

    public void ShowDiscography()
    {
        Console.WriteLine($"Discography of the band {Name}");

        foreach(Album album in albums)
        {
            Console.WriteLine($"Album: {album.Name} ({album.TotalDuration})");
        }
    }
}