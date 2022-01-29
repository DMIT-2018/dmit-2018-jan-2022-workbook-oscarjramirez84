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
	var result=GetAllQ(2000);
	result.Dump();

	var result2 = GetAllM(2000);
	result2.Dump();

}

// You can define other methods, fields, classes and namespaces here

public List<Albums> GetAllQ(int year)
{

	var resultsq = from x in Albums
				   where x.ReleaseYear == year
				   select x;
				   return resultsq.ToList();
				   
}


public List<Albums> GetAllM(int year)
{

	var res = Albums
		.Where(x => x.ReleaseYear == 2000)
		.Select(x => x)
		.Dump();
		
		return res.ToList();
}
