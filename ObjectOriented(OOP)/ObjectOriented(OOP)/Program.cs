Music music1 = new Music();

music1.name = "Lost";
music1.artist = "Linkin Park";
music1.duration = 240;
music1.WriteAvailable(true);

Music music2 = new Music();
music2.name = "Paradise";
music2.artist = "Coldplay";
music2.duration = 264;
music1.WriteAvailable(false);


music1.ShowDataSheet();
music2.ShowDataSheet();