using BadgerClan.Logic;
using BadgerClan.Logic.Bot;
namespace BadgerClan.api;

public class ScatterBot
{
    public string Strategy = "";

    public Task<List<Move>> PlanedMovesAsync(MoveRequest request)
    {
        return Strategy switch
        {
            "MoveLeft" => MoveLeft(request),
            "MoveRight" => MoveRight(request),
            "Nothing" => Nothing(request),
            "DownLeft" => MoveDownLeft(request),
            "DownRight" => MoveDownRight(request),
            "UpRight" => MoveUpRight(request),
            "UpLeft" => MoveUpLeft(request),
            _ => Task.FromResult(new List<Move>())
        };
    }

    public void SwitchStrategy(string newStrategy)
    {
        switch (newStrategy)
        {
            case "MoveLeft":
                Strategy = "MoveLeft";
                break;
            case "MoveRight":
                Strategy = "MoveRight";
                break;
            case "Nothing":
                Strategy = "Nothing";
                break;
            case "DownLeft":
                Strategy = "DownLeft";
                break;
            case "DownRight":
                Strategy = "DownRight";
                break;
            case "UpRight":
                Strategy = "UpRight";
                break;
            case "UpLeft":
                Strategy = "UpLeft";
                break;
            default:
                Strategy = "";
                break;
        }
    }
    private Task<List<Move>> MoveLeft(MoveRequest request)
    {
        var moves = new List<Move>();

        foreach (var unit in request.Units.Where(u => u.Team == request.YourTeamId))
        {
            var newLocation = unit.Location.MoveWest(1);

            if (newLocation.Q >= 0)
            {
                moves.Add(new Move(MoveType.Walk, unit.Id, newLocation));
            }
        }

        return Task.FromResult(moves);
    }

    private Task<List<Move>> MoveRight(MoveRequest request)
    {
        var moves = new List<Move>();

        foreach (var unit in request.Units.Where(u => u.Team == request.YourTeamId))
        {
            var newLocation = unit.Location.MoveEast(1);

            if (newLocation.Q >= 0)
            {
                moves.Add(new Move(MoveType.Walk, unit.Id, newLocation));
            }
        }

        return Task.FromResult(moves);
    }
    private Task<List<Move>> MoveDownRight(MoveRequest request)
    {
        var moves = new List<Move>();

        foreach (var unit in request.Units.Where(u => u.Team == request.YourTeamId))
        {
            var newLocation = unit.Location.MoveSouthEast(1);

            if (newLocation.Q >= 0)
            {
                moves.Add(new Move(MoveType.Walk, unit.Id, newLocation));
            }
        }

        return Task.FromResult(moves);
    }
    private Task<List<Move>> MoveDownLeft(MoveRequest request)
    {
        var moves = new List<Move>();

        foreach (var unit in request.Units.Where(u => u.Team == request.YourTeamId))
        {
            var newLocation = unit.Location.MoveSouthWest(1);

            if (newLocation.Q >= 0)
            {
                moves.Add(new Move(MoveType.Walk, unit.Id, newLocation));
            }
        }

        return Task.FromResult(moves);
    }
    private Task<List<Move>> MoveUpRight(MoveRequest request)
    {
        var moves = new List<Move>();

        foreach (var unit in request.Units.Where(u => u.Team == request.YourTeamId))
        {
            var newLocation = unit.Location.MoveNorthEast(1);

            if (newLocation.Q >= 0)
            {
                moves.Add(new Move(MoveType.Walk, unit.Id, newLocation));
            }
        }

        return Task.FromResult(moves);
    }
    private Task<List<Move>> MoveUpLeft(MoveRequest request)
    {
        var moves = new List<Move>();

        foreach (var unit in request.Units.Where(u => u.Team == request.YourTeamId))
        {
            var newLocation = unit.Location.MoveNorthWest(1);

            if (newLocation.Q >= 0)
            {
                moves.Add(new Move(MoveType.Walk, unit.Id, newLocation));
            }
        }

        return Task.FromResult(moves);
    }
    private Task<List<Move>> Nothing(MoveRequest request)
    {
        var moves = new List<Move>();
        return Task.FromResult(moves);

    }
    //private Task<List<Move>> RunAndGun(MoveRequest request)
    //{

    //    var moves = new List<Move>();
    //    foreach (var unit in request.Units.Where(u => u.Team == request.YourTeamId))
    //    {
    //        var enemies = request.Units.Where(u => u.Team != request.YourTeamId);
    //        var closest = enemies.OrderBy(u => u.Location.Distance(unit.Location)).FirstOrDefault();
    //        if (closest != null)
    //        {

    //            if (closest.Location.Distance(unit.Location) <= unit.AttackDistance)
    //            {
    //                moves.Add(SharedMoves.AttackClosest(unit, closest));
    //                moves.Add(SharedMoves.AttackClosest(unit, closest));
    //            }
    //            else if (request.Medpacs > 0 && unit.Health < unit.MaxHealth)
    //            {
    //                moves.Add(new Move(MoveType.Medpac, unit.Id, unit.Location));
    //            }
    //            else
    //            {
    //                moves.Add(SharedMoves.StepToClosest(unit, closest, request));
    //            }
    //        }
    //    }
    //    return Task.FromResult(moves);
    //}
}