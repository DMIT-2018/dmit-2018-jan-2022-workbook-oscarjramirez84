<Query Kind="Program">
  <Connection>
    <ID>0f8f6835-7f1d-4924-a9cd-be8e89396f28</ID>
    <NamingServiceVersion>2</NamingServiceVersion>
    <Persist>true</Persist>
    <Server>localhost</Server>
    <AllowDateOnlyTimeOnly>true</AllowDateOnlyTimeOnly>
    <Database>Chinook2018 (2)</Database>
  </Connection>
</Query>

void Main()
{
	var alist = Albums
		.Where(a => a.Tracks.Count()>=25)
		.Select(a => new Track {
							Title = a.Title,
							Artist = a.Artist.Name,
							Songs = a.Tracks.Select( t=>new SongItem{
															Song = t.Name,
															Playtime = t.Milliseconds / 1000
															}
													).ToList()
							});
							
	alist.Dump();
		
}

public class SongItem
{
	public string Song { get; set; }
	public double Playtime { get; set; }
}

public class Track{
	public string Title { get; set; }
	public string Artist { get; set; }

	public List<SongItem> Songs { get; set; }
}

// You can define other methods, fields, classes and namespaces here