class Band
{
    private List<Album> albums = new List<Album>();
    public string Name { get; set; }

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