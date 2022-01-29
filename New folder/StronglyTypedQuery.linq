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
	//Nested queries
	//sometimes referred to as subqueries
	//simply put: it is a query within a query [....]
	//List all sales support employees showing their
	//fullname (last, first), title, phone.
	//For each employee, show a list of the customers
	//they support. List the customer fullname (last, first),
	//City and State.


	var results = Employees
						.Where(e => e.Title.Contains("Sales Support"))
						.Select(e => new EmployeeItem
						{
							FullName = e.LastName + " " + e.FirstName,
							Title = e.Title,
							Phone = e.Phone,
							CustomerList = e.SupportRepCustomers
														.Select(c => new CustomerBasicInfo
														{
															FullName = c.FirstName,
															City = c.City,
															State = c.State
														})

						});

	results.Dump();

}


public class CustomerBasicInfo
{
	public string FullName { get; set; }
	public string City { get; set; }
	public string State { get; set; }
}

public class EmployeeItem
{
	public string FullName { get; set; }
	public string Title { get; set; }
	public string Phone { get; set; }
	public IEnumerable<CustomerBasicInfo> CustomerList{get;set;}
}



// You can define other methods, fields, classes and namespaces here