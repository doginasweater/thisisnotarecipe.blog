module Router

open System

open Shared

type Route =
  | Todo
  | RecipeList
  | NewRecipe
  | Recipe of string

open Elmish.UrlParser

let routeParser: Parser<Route -> Route, Route> =
  oneOf [
    map Todo (s "todos")
    map NewRecipe (s "recipe")
    map Recipe (s "recipe" </> str)
    map RecipeList top
  ]