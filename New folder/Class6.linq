<Query Kind="Statements">
  <Connection>
    <ID>0f8f6835-7f1d-4924-a9cd-be8e89396f28</ID>
    <NamingServiceVersion>2</NamingServiceVersion>
    <Persist>true</Persist>
    <Server>localhost</Server>
    <AllowDateOnlyTimeOnly>true</AllowDateOnlyTimeOnly>
    <Database>Chinook2018 (2)</Database>
  </Connection>
</Query>

Albums
	.GroupBy(x => x.ReleaseYear)
	.Select(g => new{
					Year = g.Key,
					CountAlbums = g.Count(),
					NumTracks = g.Count(e => e.Tracks.Count())
					})

from a in Albums
group a by a.ReleaseYear  into g
orderby g.Key
select (new {
			Year = g.Key,
			Count = g.Count()
				})


Albums
	.GroupBy(x => new { x.ReleaseLabel, x.ReleaseYear})
	.Where(g => g.Count()>=2)
	.OrderBy (g => g.Key.ReleaseLabel)
	.Select(g => new
			{
				
				Year = g.Key.ReleaseYear,
				Label = g.Key.ReleaseLabel,
				Numtracks = g.Sum(g => g.Tracks.Count()),
			
				
				AlbumGroupItems = g.Select(d => new{
													TitleAlbum = d.Title,
													YearAlbum = d.ReleaseYear,
													AlbumId=d.AlbumId,
																									
													}) 
				
				
				
			})


from t in Tracks
where t.AlbumId==30
select t



Albums
	.GroupBy(x => new { x.ReleaseLabel, x.Tracks.Select(x => x.TrackId) })
	.Where(g => g.Count() >= 2)
	.Select(g => new
	{
		Label = g.Key


	})


	