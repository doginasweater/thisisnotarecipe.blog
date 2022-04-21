module Router

type Route =
    | Todo
    | Recipes

let toUrl (route: Route) =
    match route with
    | Todo -> ""
    | Recipes -> "recipes"

open Elmish.UrlParser

let routeParser: Parser<Route -> Route, Route> =
    oneOf [
        map Route.Todo top
        map Route.Recipes (s "recipes")
    ]