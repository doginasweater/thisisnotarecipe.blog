module Router

[<RequireQualifiedAccess>]
type Route =
    | Todo
    | Recipes

open Elmish.UrlParser

let routeParser: Parser<Route -> Route, Route> =
    oneOf [
        map Route.Todo (s "todos")
        map Route.Recipes top
    ]