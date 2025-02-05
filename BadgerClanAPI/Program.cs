using BadgerClan.Logic;
using BadgerClan.api;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddSingleton<ScatterBot>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    //app.MapPost("/", (MoveRequest request) =>
    //{
    //    MoveResponse m = new MoveResponse(new List<Move>());
    //    return m;

    //});
    app.MapPost("/", async (MoveRequest request,ScatterBot scatterBot) =>
    {
       

        var moves = await scatterBot.PlanedMovesAsync(request);

        return new MoveResponse(moves);
    });
    app.MapGet("/change/{value}", (string value, ScatterBot bot) =>
    {
        app.Logger.LogInformation("Adjusted Strategy to: " + value);
        bot.Strategy = value;
    });
    app.MapGet("/", () => "hello World");
    

    app.UseHttpsRedirection();

    app.UseAuthorization();

    app.MapControllers();

    app.Run();
}
