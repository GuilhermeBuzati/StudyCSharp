class Album
{
    private List<Music> musics = new List<Music>();

    public Album(string name)
    {
        Name = name;
    }

    public string Name { get; }

    public int TotalDuration => musics.Sum(m => m.Duration);
    public void AddMusic(Music music)
    {

        musics.Add(music);

    }

    public void ShowMusicsInAlbum()
    {
        Console.WriteLine($"List of musics - {Name}\n");
        foreach (Music music in musics)
        {
            Console.WriteLine($"Music: {music.Name}");
        }

        Console.WriteLine($"Total duration {TotalDuration}");
    }
}