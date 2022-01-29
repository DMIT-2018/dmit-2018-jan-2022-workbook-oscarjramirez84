<Query Kind="Statements">
  <Connection>
    <ID>0f8f6835-7f1d-4924-a9cd-be8e89396f28</ID>
    <NamingServiceVersion>2</NamingServiceVersion>
    <Persist>true</Persist>
    <Server>localhost</Server>
    <AllowDateOnlyTimeOnly>true</AllowDateOnlyTimeOnly>
    <Database>GroceryList</Database>
  </Connection>
</Query>

/*QUERY 1*/

var resulq1 = Products
.Where(p => p.OrderLists.Count()>0)
.OrderByDescending(p => p.OrderLists.Count())
.ThenBy(p => p.Description)
.Select(p => new{
					Product = p.Description,
					TimesPurchased = p.OrderLists.Count()
					});
					

var resultq11=
OrderLists
.GroupBy(o => o.ProductID)
.Select(g=> new {
					ProductID=g.Key,
					ProductName = g.Max(o => o.Product.Description),
					ProductCount = g.Count()
				})
.OrderByDescending(g => g.ProductCount);

//QUERY 2

var resultq2=Stores
.Select(s => new{
				Location = s.Location,
				Clients = s.Orders.Select(
											o => new{
												address = o.Customer.Address,
												city = o.Customer.City,
												province = o.Customer.Province
												
											}
											).Distinct()
				
				})
.OrderBy(s => s.Location);

/*QUERY 3*/

Stores
	.Select(s => new
	{
		city=s.City,
		Location = s.Location,
		sales = s.Orders.GroupBy(s => s.OrderDate)
						.Select(
								o => new{
									Date = o.Key,
									numoforders = o.Count(),
									productsales = o.Sum(o => o.SubTotal),
									gst = o.Sum(o => o.GST)
									
								}
								)
						
		
	})
	.OrderBy(s => s.city)


/*QUERY 4*/

OrderLists
.Where(ol => ol.OrderID==33)
.OrderBy(ol => ol.Product.Category.Description)
.GroupBy(ol => ol.Product.Category.Description)
.Select(
		g => new {
			Category = g.Key,
			OrderProducts = g.Select(op => new{
												Product = op.Product.Description,
												Price = op.Price,
												PickedQty = op.QtyPicked,
												Discount = op.Discount,
												Subtotal = (op.Price*(decimal)op.QtyPicked)-op.Discount,
												Tax = (op.Product.Taxable == true ? ((op.Price*(decimal)op.QtyPicked)-op.Discount) * (decimal)0.05 : 0),
												Total = (op.Product.Taxable == true ? ((op.Price*(decimal)op.QtyPicked)-op.Discount) * (decimal)1.05 : ((op.Price*(decimal)op.QtyPicked)-op.Discount))
												})

		}
		)

/*QUERY 5*/


Orders
	.GroupBy(g=> g.Store.Location)
	.Select (g => new {
						Location = g.Key,
						Orders = g.Count(),
						AvgSize = g.Average(g => g.OrderLists.Count()),
						AvgRevenue = g.Average(g => g.SubTotal)
						})
						
from o in Orders
where o.Store.Location.Contains("Cherry Hill")
select o
	
/*QUERy 6*/

from o in Orders
where o.CustomerID == 1
group o by new { o.Customer.LastName, o.Customer.FirstName } into g
select new
{
	Customer = g.Key.LastName + ", " + g.Key.FirstName,
	OrdersCount = g.Count(),
	//Itemsasd = g.GroupBy(it => it.OrderLists)
	Items = g.Select(it => it.OrderLists.GroupBy(it => it.ProductID))
			 
}

from c in Customers
where c.CustomerID ==1
select new {
				Customer = c.LastName + ", " + c.FirstName,
				OrdersCount = c.Orders.Count(),
				Items = c.Orders.SelectMany(i => i.OrderLists											
													.Select(p => new{
																	Description = p.Product.Description
																	})
														
															).GroupBy(x => x.Description)
															 .Select(x => new{
																				Description = x.Key,
																				NumItems = x.Count()
																				})
															.OrderByDescending (x => x.NumItems)
															
				}


/*
from o in Orders
join l in OrderLists on o.OrderID equals l.OrderID
where o.CustomerID==1
group o by new { o.CustomerID, l.OrderID} into g
select new {
			Customer = g.Select(g=>g.OrderLists)
			
}*/



						