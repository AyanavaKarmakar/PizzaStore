using Microsoft.OpenApi.Models;
using PizzaStore.DB;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "PizzaStore API",
        Description = "Making the pizzas you love",
        Version = "v1"
    });
});

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "PizzaStore API V1");
});

// routes
app.MapGet("/pizzas/{id}", (int id) => PizzaDB.GetPizza(id));

app.MapGet("/pizzas", () => PizzaDB.GetPizzas());

app.MapPost("/pizzas/{id}", (Pizza pizza) => PizzaDB.CreatePizza(pizza));

app.MapPut("/pizzas", (Pizza pizza) => PizzaDB.UpdatePizza(pizza));

app.MapDelete("/pizzas", (int id) => PizzaDB.RemovePizza(id));

app.Run();
