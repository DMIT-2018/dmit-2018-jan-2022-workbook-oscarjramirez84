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
	
		string partialSongName = "dance";
		List<SongList> results = SongByPartialName(partialSongName);
		results.Dump();
}
	
List<SongList> SongByPartialName(string partialSongName)
	{
		IEnumerable<SongList> songCollection = Tracks
								.Where(t => t.Name.Contains(partialSongName))
								.Select(t => new SongList{
													Title = t.Album.Title,
													Song = t.Name,
													Artist = t.Album.Artist.Name
												});
		return songCollection.ToList();
	}


public class SongList
{
	public string Title{get;set;}
	public string Song{get;set;}
	public string Artist{get;set;}
}
