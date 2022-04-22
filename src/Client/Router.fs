module Router

[<RequireQualifiedAccess>]
type Route =
    | Todo
    | Recipes

let toUrl (route: Route) =
    match route with
    | Route.Todo -> ""
    | Route.Recipes -> "recipes"

open Elmish.UrlParser

let routeParser: Parser<Route -> Route, Route> =
    oneOf [
        map Route.Todo top
        map Route.Recipes (s "recipes")
    ]