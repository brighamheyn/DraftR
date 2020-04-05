namespace DraftR.Shared

open System

type WeatherForecast() =

    member val Date: DateTime = DateTime() with get, set
    member val TemperatureC: int = 1 with get, set
    member val Summary: string = "weather" with get, set

    member this.TemperatureF =
        32 + (int (float this.TemperatureC / 0.5556))

module Library = 

    let awaitTask (task: System.Threading.Tasks.Task) = 
        async {
            do! task |> Async.AwaitIAsyncResult |> Async.Ignore
        } |> Async.StartAsTask :> System.Threading.Tasks.Task
