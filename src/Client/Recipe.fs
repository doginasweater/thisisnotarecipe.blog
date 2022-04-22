module Recipe

open Elmish
open Fable.Remoting.Client
open Shared

type Model = { Recipes: Recipe list }

type Msg = GotRecipes of Recipe list

let recipesApi =
    Remoting.createApi ()
    |> Remoting.withRouteBuilder Route.builder
    |> Remoting.buildProxy<IRecipeApi>

let init () : Model * Cmd<Msg> =
    let model = { Recipes = [] }
    let cmd = Cmd.OfAsync.perform recipesApi.getRecipes () GotRecipes

    model, cmd

let update msg model =
    match msg with
    | GotRecipes recipes -> { model with Recipes = recipes }, Cmd.none

open Feliz
open Feliz.Bulma

let view model dispatch = Bulma.container [ prop.text "recipes" ]