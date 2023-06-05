Album albumColdplay = new Album();
albumColdplay.Name = "Music of the Spheres";

Music music1 = new Music();
music1.Name = "High Power";
music1.Duration = 230;

Music music2 = new Music();
music2.Name = "My Universe";
music2.Duration = 223;

albumColdplay.AddMusic(music1);
albumColdplay.AddMusic(music2);

albumColdplay.ShowMusicsInAlbum();