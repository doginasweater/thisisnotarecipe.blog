module Pages.Recipe

open Elmish
open Fable.Remoting.Client
open System
open Shared
open Components

type RecipeLoadingState =
  | NewRecipe
  | Loading
  | Loaded
  | NotFound

type Model =
  { Recipe: Recipe option
    LoadingState: RecipeLoadingState }

type Msg = GotRecipe of Recipe option

let recipesApi =
  Remoting.createApi ()
  |> Remoting.withRouteBuilder Route.builder
  |> Remoting.buildProxy<IRecipeApi>

let init (id: string option) : Model * Cmd<Msg> =
  let model =
    { Recipe = None
      LoadingState = NewRecipe }

  match id with
  | None -> model, Cmd.none
  | Some id ->
    match Guid.TryParse id with
    | true, recipeId -> model, Cmd.OfAsync.perform recipesApi.getRecipe (RecipeId recipeId) GotRecipe
    | false, _ -> { model with LoadingState = NotFound }, Cmd.none

let update (msg: Msg) (model: Model) : Model * Cmd<Msg> =
  match msg with
  | GotRecipe recipe -> { model with Recipe = recipe }, Cmd.none

open Feliz

let title model =
  match model.Recipe with
  | Some r -> Html.h1 r.Title
  | None -> Html.h1 "New Recipe"

let view (model: Model) dispatch =
  Html.div [
    title model
    input { label "Title" }
    input { label "Description" }
    input { label "Source" }
    input { label "Author" }
  ]