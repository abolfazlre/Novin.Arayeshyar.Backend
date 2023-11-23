using Microsoft.EntityFrameworkCore;
using Novin.Arayeshyar.Backend.API.Infrastructure;
using Novin.Arayeshyar.Backend.Core.Entities;
using Novin.Arayeshyar.Backend.DB.Database;

var builder = WebApplication.CreateBuilder(args);
AppConfiguration.AddServices(builder);
var app = builder.Build();
AppConfiguration.UseServices(app);

app.MapPost("/create", (ArayeshyarDB db,BarberShopOwner barberShopOwner) =>
{
    db.Add(barberShopOwner);
    db.SaveChanges();
});

app.MapGet("/list", (ArayeshyarDB db) =>
{
    return db.BarberShopOwners.ToList();
});

app.MapPut("/update", (ArayeshyarDB db, BarberShopOwner barberShopOwner) =>
{
    db.Entry(barberShopOwner).State = EntityState.Modified;
    db.SaveChanges();
});

app.MapDelete("/delete{mobileNumber}", (ArayeshyarDB db,string mobileNumber) =>
{
    var barbeShopOwner=db.BarberShopOwners.FirstOrDefault(b=>b.MobileNumber==mobileNumber); 
    db.BarberShopOwners.Remove(barbeShopOwner);
    db.SaveChanges();
});

app.Run();
