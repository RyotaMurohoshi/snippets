module FsUnity

type Direction =
  | Up
  | Down
  | Right
  | Left

let directions = [|Up; Down; Right; Left|]

let reverse direction =
  match direction with
    | Up -> Down
    | Down -> Up
    | Right -> Left
    | Left -> Right

type Point = { X: int; Y: int }

let move point direction =
  match direction with
    | Up -> { point with Y = point.Y + 1 }
    | Down -> { point with Y = point.Y - 1 }
    | Right -> { point with X = point.X + 1 }
    | Left -> { point with X = point.X - 1 }
let distance p0 p1 = abs(p0.X - p1.X) + abs(p0.Y - p1.Y)
let isNext p0 p1 = distance p0 p1 = 1

type Side =
  | Player
  | Enemy

let anotherSide side =
  match side with
    | Player -> Enemy
    | Enemy -> Player

type Character =
    {
        Id : int
        Side : Side
        CurrentPoint : Point
        CurrentHP : int
        MaxHP : int
        Attack : int
        MoveStep : int
    }

let moveTo point character  = { character with CurrentPoint = point }
let addDamage damage character =
    let nextHP = if character.CurrentHP - damage < 0 then 0 else character.CurrentHP - damage
    { character with CurrentHP = nextHP }

type Field =
    {
        Points : array<Point>
        Characters : array<Character>
    }

let findCharacterById id field = field.Characters |> Array.find (fun c -> c.Id = id)

let aliveCharacters side field = field.Characters |> Array.filter (fun c -> c.Side = side && c.CurrentHP > 0)

let updateCharacter field character =
    {field with Characters = field.Characters |> Array.map (fun c -> if c.Id = character.Id then character else c)}

let moveCharacter field character point =
    moveTo point character |> updateCharacter field

let battle field first second =
    let updatedSecond = addDamage first.Attack second
    let updatedField = updateCharacter field updatedSecond

    if updatedSecond.CurrentHP > 0 then
        addDamage updatedSecond.Attack first |> updateCharacter field
    else
        updatedField

type Route = { Points: array<Point>}

let fromFirstStep firstStep = { Points = [|firstStep|]}
let head route = route.Points |> Array.toSeq |> Seq.head
let last route = route.Points |> Array.toSeq |> Seq.last
let appendPoint route direction = {Points = Array.append route.Points [|move (last route) direction|]}

let calculateRoutes field character =
    let expandRoutes route : array<Route> = directions |> Array.map (appendPoint route)
    let filterValidRoutes prevRoutes newRoutes =
        let lastPoints = prevRoutes |> Array.map last |> Seq.distinct |> Seq.toArray
        let isValid route = not (lastPoints |> Array.exists ((=) (last route)))
        Array.filter isValid newRoutes
    let calculateRoutes transitabplePoints notReachablePoints from step =
        let nonMoveRoute = fromFirstStep from
        let mutable result = [|nonMoveRoute|]
        let mutable prevStepResult = [|nonMoveRoute|]
        
        3

    3
        (*
        static List<Route> CalculateRoutes(List<Point> transitablePoints, List<Point> notReachablePoints, Point from, int step)
        {
            Route nonMoveRoute = Route.FromFirstStep(from);
            List<Route> result = new List<Route> { nonMoveRoute };
            List<Route> prevStepRouteList = new List<Route> { nonMoveRoute };

            for (int i = 1; i <= step; i++)
            {
                List<Route> thisStepRouteList = ExpandNextStepRoutes(prevStepRouteList, transitablePoints).ToList();
                List<Route> filteredRoutes = FilterValidRoutes(prevStepRouteList, thisStepRouteList);

                result.AddRange(filteredRoutes);
                prevStepRouteList = filteredRoutes;
            }

            return result
                .Where(route => !notReachablePoints.Contains(route.LastPoint))
                .ToList();
        }
        *)