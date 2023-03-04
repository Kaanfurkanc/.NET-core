using ContosoPizza.Data;
using ContosoPizza.Models;

using ContosoPizzaContext context = new ContosoPizzaContext();

// Delete a data from database
var margarita = context.Products
                   .Where(p => p.Name == "Margarita Pizza")
                   .FirstOrDefault();

if (margarita is Product)
{
    context.Remove(margarita);
}

context.SaveChanges();

// Update a data from database 

var veggieSpecial = context.Products
                   .Where(p => p.Name == "Veggie Special Pizza")
                   .FirstOrDefault();

if (veggieSpecial is Product)
{
    veggieSpecial.Price = 25.75M;
}


// Lists products from database by sql query

var products = from product in context.Products
               where product.Price >= 10M
               orderby product.Name ascending
               select product;

foreach(var product in products)
{
    Console.WriteLine($"Id :{product.ProductId}\nName: {product.Name}\nPrice: {product.Price}");
    Console.WriteLine(new string("-"),20);
}



// Product and customer created . Added to database . 

//Product VeggieSpecial = new Product()
//{
//    Name= "Veggie Special Pizza",
//    Price = 14.75M
//};

//context.Products.Add(VeggieSpecial);

//Product DeluxeMeat = new Product()
//{
//    Name= "Deluxe Meat Pizza ",
//    Price = 17.75M
//};
//context.Products.Add(DeluxeMeat);

//Product Margarita = new Product()
//{
//    Name = "Margarita Pizza",
//    Price = 9.69M
//};

//context.Products.Add(Margarita);

//Customer customer = new Customer()
//{
//    FirstName = "Kaan Furkan",
//    LastName = "Çakıroğlu",
//    Address = "İstanbul",
//    Email = "Kfc0737@gmail.com",
//    Phone = "0555111222333444",
//};

//context.Customers.Add(customer);

//context.SaveChanges();

