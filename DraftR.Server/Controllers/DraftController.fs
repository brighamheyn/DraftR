namespace DraftR.Server.Controllers

open System
open System.Collections.Generic
open System.Linq
open System.Threading.Tasks
open Microsoft.AspNetCore.Mvc
open Microsoft.Extensions.Logging
open DraftR.Server
open DraftR.Shared

[<ApiController>]
[<Route("api/[controller]")>]
type DraftController (logger : ILogger<DraftController>) =
    inherit ControllerBase()

    [<HttpGet>]
    [<Route("players")>]
    member __.Players() : string[] = 
        [| "Player 1"; "Player 2"; "Player 3" |]
