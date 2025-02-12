// ScatterRequest Class
using BadgerClan.Logic;
using System.Runtime.Serialization;
using System.ServiceModel;
namespace GrpcLogic;
// ScatterRequest Class modified to handle movement requests
public class ScatterRequest
{
    [DataMember(Order = 1)]
    public string YourTeamId { get; set; }  // Your team ID for context

    [DataMember(Order = 2)]
    public List<Unit> Units { get; set; }  // List of units involved in the move

    [DataMember(Order = 3)]
    public List<MoveRequest> MoveRequests { get; set; }  // Movement requests for units

    public ScatterRequest()
    {
        Units = new List<Unit>();
        MoveRequests = new List<MoveRequest>();  // Initialize the movement request list
    }
}


// Unit Class
public class Unit
{
    [DataMember(Order = 1)]
    public string Id { get; set; }

    [DataMember(Order = 2)]
    public string Team { get; set; }

    [DataMember(Order = 3)]
    public Location Location { get; set; }

    [DataMember(Order = 4)]
    public int Health { get; set; }

    [DataMember(Order = 5)]
    public int MaxHealth { get; set; }

    [DataMember(Order = 6)]
    public int AttackDistance { get; set; }
}

// Location Class
public class Location
{
    [DataMember(Order = 1)]
    public int Q { get; set; }

    [DataMember(Order = 2)]
    public int R { get; set; }

    public Location MoveWest(int distance) => new Location { Q = this.Q - distance, R = this.R };
    public Location MoveEast(int distance) => new Location { Q = this.Q + distance, R = this.R };
    public Location MoveNorth(int distance) => new Location { Q = this.Q, R = this.R - distance };
    public Location MoveSouth(int distance) => new Location { Q = this.Q, R = this.R + distance };
}

// Move Class
public class Move
{
    [DataMember(Order = 1)]
    public string UnitId { get; set; }

    [DataMember(Order = 2)]
    public MoveType MoveType { get; set; }

    [DataMember(Order = 3)]
    public Location Location { get; set; }

    public Move(MoveType moveType, string unitId, Location location)
    {
        MoveType = moveType;
        UnitId = unitId;
        Location = location;
    }
}

// MoveType Enum
public enum MoveType
{
    Walk,
    Attack,
    Medpac
}

// ScatterResponse Class (The response you'll return from gRPC)
public class ScatterResponse
{
    [DataMember(Order = 1)]
    public List<Move> Moves { get; set; }

    public ScatterResponse()
    {
        Moves = new List<Move>();
    }
    public string Status { get; set; }  // Status of the request processing
    public string Message { get; set; }
}

[ServiceContract]
public interface IGameBotService
{
    [OperationContract]
    Task<ScatterResponse> ScatterMove(ScatterRequest request);
}

