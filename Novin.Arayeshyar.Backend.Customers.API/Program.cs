using Microsoft.EntityFrameworkCore;
using Novin.Arayeshyar.Backend.API.Infrastructure;
using Novin.Arayeshyar.Backend.Core.Entities;
using Novin.Arayeshyar.Backend.DB.Database;

var builder = WebApplication.CreateBuilder(args);
AppConfiguration.AddServices(builder);
var app = builder.Build();
AppConfiguration.UseServices(app);


app.MapGet("/list", (ArayeshyarDB db) =>
{
    return db.Customers.ToList();
});

app.MapPost("/create", (ArayeshyarDB db,Customer customer) =>
{
    db.Add(customer);
    db.SaveChanges();
});

app.MapPut("/update", (ArayeshyarDB db, Customer customer) =>
{
    db.Entry(customer).State = EntityState.Modified;
    db.SaveChanges();
});

app.MapDelete("/delete{mobileNumber}", (ArayeshyarDB db,string mobileNumber) =>
{
    var customer=db.Customers.FirstOrDefault(x => x.MobileNumber == mobileNumber);
    db.Customers.Remove(customer);
    db.SaveChanges();
});
app.Run();

