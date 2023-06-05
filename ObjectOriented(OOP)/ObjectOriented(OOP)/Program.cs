Band coldplay = new Band("Coldplay");

Album albumColdplay = new Album("Music of the Spheres");

Music music1 = new Music(coldplay, "High Power")
{
    Duration = 230,
    Available = true,
};

Music music2 = new Music(coldplay, "My Universe")
{
    Duration = 223,
    Available = false,
};

albumColdplay.AddMusic(music1);
albumColdplay.AddMusic(music2);

coldplay.AddAlbum(albumColdplay);

music1.ShowDataSheet();
music2.ShowDataSheet();
albumColdplay.ShowMusicsInAlbum();  
coldplay.ShowDiscography();