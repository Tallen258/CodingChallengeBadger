using GrpcLogic;
namespace BadgerClan.api;
using GrpcLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
public class ScatterBotService : IGameBotService
{
    private readonly ScatterBot _scatterBot;

    public ScatterBotService(ScatterBot scatterBot)
    {
        _scatterBot = scatterBot;
    }

    public Task<ScatterResponse> ScatterMove(ScatterRequest request)
    {
        // Handle the ScatterRequest, perform business logic if necessary
        var response = new ScatterResponse
        {
            Status = "Success",
            Message = $"Scatter move requested for team {request.YourTeamId}."
        };

        // Optionally, you can log or process the units and move requests here.

        return Task.FromResult(response);
    }

}

