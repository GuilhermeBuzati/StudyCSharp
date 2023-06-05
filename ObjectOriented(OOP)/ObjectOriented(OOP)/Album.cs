class Album
{
    private List<Music> musics = new List<Music>();
    public string Name { get; set; }

    public int TotalDuration { get; set; } 
    public void AddMusic(Music music)
    {

        musics.Add(music);

    }
}