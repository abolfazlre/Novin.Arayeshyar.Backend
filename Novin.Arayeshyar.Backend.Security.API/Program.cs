﻿using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Novin.Arayeshyar.Backend.API.Infrastructure;
using Novin.Arayeshyar.Backend.Core.Entities;
using Novin.Arayeshyar.Backend.DB.Database;
using Novin.Arayeshyar.Backend.Security.API.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;


var builder = WebApplication.CreateBuilder(args);
AppConfiguration.AddServices(builder);
var app = builder.Build();
AppConfiguration.UseServices(app);


app.MapPost("/adminlogin", (ArayeshyarDB db, LoginRequestDTO login) =>
{
       if(!db.SystemAdmins.Any())
       {
           var FirstAdmin = new SystemAdmin("admin", "nimda","0918");
           db.SystemAdmins.Add(FirstAdmin);
           db.SaveChanges();
       }
       var result = db.SystemAdmins
       .Where(l => l.Username == login.Username && l.Password == login.Password)
       .FirstOrDefault();
       if(result!=null)
       {
           var claims = new []
           {
               new Claim("Username",result.Username.ToString()),
               new Claim("Fullname",result.Fullname??"".ToString())
           };
           var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["jwt:Key"] ?? ""));
           var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
           var token = new JwtSecurityToken(
               builder.Configuration["jwt:Issuer"],
               builder.Configuration["jwt:Audience"],
               claims,
               expires: DateTime.UtcNow.AddDays(3),
               signingCredentials: signIn);
           return new
           {
               IsOk= true,
               Message = "مدیر جان خوش آمدید",
               Token = new JwtSecurityTokenHandler().WriteToken(token)
           };
       }

       return new
       {
           IsOk = false,
           Message = "ی جای کار میلنگه",
           Token=""
       };


});

app.MapPost("/admins", (ArayeshyarDB db,ClaimsPrincipal user) =>
{
    Console.ForegroundColor = ConsoleColor.Cyan;
    Console.WriteLine(user.Claims.FirstOrDefault(l => l.Type == "Username")?.Value);
    Console.ResetColor();
   return db.SystemAdmins.ToList();
})
    .RequireAuthorization();


app.Run();

