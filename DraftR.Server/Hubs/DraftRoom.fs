namespace DraftR.Server.Hubs

open Microsoft.AspNetCore.SignalR

open DraftR.Shared.Library

type DraftRoom() = 
    inherit Hub()

    member this.SendMessage (user: string) (message: string) =
        this.Clients.All.SendAsync ("ReceiveMessage", user, message) 
        |> awaitTask
