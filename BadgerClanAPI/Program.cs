using BadgerClan.Logic;
using BadgerClan.api;
using ProtoBuf.Grpc.Server;
using GrpcLogic;
using System.Security.Cryptography.X509Certificates;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddSingleton<ScatterBot>();
builder.Services.AddCodeFirstGrpc();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
   
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

    app.MapGrpcService<ScatterBotService>();

    app.UseHttpsRedirection();

    app.UseAuthorization();

    app.MapControllers();

    app.Run();

}
