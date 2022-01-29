<Query Kind="Expression">
  <Connection>
    <ID>0f8f6835-7f1d-4924-a9cd-be8e89396f28</ID>
    <NamingServiceVersion>2</NamingServiceVersion>
    <Persist>true</Persist>
    <Server>localhost</Server>
    <AllowDateOnlyTimeOnly>true</AllowDateOnlyTimeOnly>
    <Database>Chinook2018 (2)</Database>
  </Connection>
</Query>

//Albums
//.Where (x => x.ReleaseYear==2000)
//.Select(x=>x)
//
//Albums
//.Where(x => (x.ReleaseYear >=1990 && x.ReleaseYear<2000))
//.Select(x => x)

//


//Albums
//.Where(x => x.Artist.Name.Contains ("Queen"))
//.Select(x => x);
//
//Albums
//.Where(x => x.ReleaseLabel == null)
//.Select(x => x)


//Albums
//.Where(x => (x.ReleaseYear >=1990 && x.ReleaseYear<2000))
//.OrderBy(x=>x.ReleaseYear)
//.ThenBy(x=>x.Title)
//.Select(x => x)

//query syntax
from x in Albums
where (x.ReleaseYear >=1990 && x.ReleaseYear<2000)
orderby x.ReleaseYear, x.Title
select new
{
	Year = x.ReleaseYear,
	Title = x.Title,
	Artist = x.Artist.Name,
	Label = x.ReleaseLabel
}

//method syntax
Albums
.Where(x => (x.ReleaseYear >=1990 && x.ReleaseYear<2000))
.OrderBy(x=>x.Artist.Name)
.ThenBy(x => x.ReleaseYear)
.ThenByDescending(x => x.Title)
.Select (x =>
		new
			{
				Year = x.ReleaseYear,
				Title = x.Title,
				Artist = x.Artist.Name,
				Label = x.ReleaseLabel
				
			}
			)


Albums
.OrderBy(x => x.ReleaseLabel)
.Select(x =>
	   new
	   {
		   Title = x.Title,
		   Label = x.ReleaseLabel == null ? "Unknown" : x.ReleaseLabel,
		   Artist = x.Artist.Name
		 
	   })




Albums
.Select(x =>
	   new
	   {
		   Title = x.Title,
		   Label = x.ReleaseLabel == null ? "Unknown" : x.ReleaseLabel,
		   Artist = x.Artist.Name

	   })
	   .OrderBy(x => x.Label)



Albums
.Select(x =>
	   new
	   {
		   Title = x.Title,
		   Artist = x.Artist.Name,
		   Year = x.ReleaseYear,
		   Decade = x.ReleaseYear<1970 ? "Oldies" : x.ReleaseYear<1980 ? "70s" : x.ReleaseYear<1990 ? "80s" : x.ReleaseYear<2000 ? "90s" : "Modern"

	   })
	   .OrderBy(x => x.Year)



