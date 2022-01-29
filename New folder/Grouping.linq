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
	var results = Albums
					.Where(x => x.ReleaseYear >= 1960 && x.ReleaseYear < 1970 && x.Tracks.Count()>0) 
					.Select(a => new {
										Album= a.Title,
										Artist = a.Artist.Name,
										NumTracks = a.Tracks.Count(),
										LongestTrackMins = a.Tracks.Max(a => a.Milliseconds/1000/60) ,
										ShortestTrackMins = a.Tracks.Min(a => a.Milliseconds/1000/60),
										TotalPrice = a.Tracks.Sum(a => a.UnitPrice),
										AverageLengthMins = a.Tracks.Average(a => a.Milliseconds/1000/60)
									
											
									});

	results.Dump();

}

// You can define other methods, fields, classes and namespaces here