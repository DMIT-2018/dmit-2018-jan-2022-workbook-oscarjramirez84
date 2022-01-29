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

from irc in Albums
where irc.ReleaseYear == 2000
select irc




Albums
   .Where(x => (x.ReleaseYear == 2000))
   .Select(x => x.Title)