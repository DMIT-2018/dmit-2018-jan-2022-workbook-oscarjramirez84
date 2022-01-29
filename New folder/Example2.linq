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

//Statements IDE

var year = 2000;
var res = from x in Albums 
			where x.ReleaseYear == year
			select x;
			
res.Dump();

Albums
	.Where(x=> x.ReleaseYear ==2000)
	.Select(x=>x)
	.Dump();

