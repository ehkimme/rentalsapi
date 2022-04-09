var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSqlite<RentalsApi.sakilaContext>("data source=sakila.db");
builder.Services.AddInstantAPIs();

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.MapInstantAPIs<RentalsApi.sakilaContext>();

app.Run();
