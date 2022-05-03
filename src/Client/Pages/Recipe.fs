module Pages.Recipe

open Elmish
open Elmish.Navigation
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

type Msg =
  | GotRecipe of Recipe option
  | Cancel
  | AddIngredient
  | AddStep

let recipesApi =
  Remoting.createApi ()
  |> Remoting.withRouteBuilder Route.builder
  |> Remoting.buildProxy<IRecipeApi>

let init (id: string option) : Model * Cmd<Msg> =
  let model =
    { Recipe = None
      LoadingState = NewRecipe }

  match id with
  | None -> { model with Recipe = Some(Recipe.makeEmptyRecipe ()) }, Cmd.none
  | Some id ->
    match Guid.TryParse id with
    | true, recipeId -> model, Cmd.OfAsync.perform recipesApi.getRecipe (RecipeId recipeId) GotRecipe
    | false, _ -> { model with LoadingState = NotFound }, Cmd.none

let update (msg: Msg) (model: Model) : Model * Cmd<Msg> =
  match msg with
  | GotRecipe recipe -> { model with Recipe = recipe }, Cmd.none
  | Cancel -> model, Navigation.newUrl "/"
  | AddIngredient ->
    let newRecipe =
      model.Recipe
      |> Option.bind (fun r ->
        let ingredients =
          r.Ingredients
          @ [ { Id = IngredientId Guid.Empty
                Recipe = r
                Text = ""
                Type = "" } ]

        Some { r with Ingredients = ingredients })

    { model with Recipe = newRecipe }, Cmd.none
  | AddStep ->
    let newRecipe =
      model.Recipe
      |> Option.bind (fun r ->
        let steps =
          r.Steps
          @ [ { Id = StepId Guid.Empty
                Recipe = r
                Order = 0
                Text = "" } ]

        Some { r with Steps = steps })

    { model with Recipe = newRecipe }, Cmd.none

open Feliz

let title model =
  match model.Recipe with
  | Some r ->
    if r.Id = (RecipeId Guid.Empty) then
      Html.h1 "New Recipe"
    else
      Html.h1 r.Title
  | None -> Html.h1 "New Recipe"

let view (model: Model) dispatch =
  Html.div [
    prop.classes [
      "flex"
      "gap-8"
      "flex-col"
    ]
    prop.children [
      title model
      Html.div [
        prop.classes [ "flex"; "gap-8" ]
        prop.children [
          input {
            label "Title"
            classes [ "flex-1" ]
          }
          input {
            label "Source"
            classes [ "flex-1" ]
          }
          input {
            label "Author(s)"
            classes [ "flex-1" ]
          }
        ]
      ]
      Html.div [
        prop.classes [ "flex"; "gap-8" ]
        prop.children [
          textarea {
            label "Description"
            classes [ "flex-1"; "h-24" ]
          }
        ]
      ]
      Html.div [
        prop.classes [
          "flex"
          "gap-8"
          "flex-col"
        ]
        prop.children [
          Html.div [
            prop.classes [ "flex"; "gap-4" ]
            prop.children [
              Html.h2 [
                prop.classes [ "m-0" ]
                prop.text "Ingredients"
              ]
              button {
                btnType Primary
                text "Add ingredient"
                onClick (fun _ -> AddIngredient |> dispatch)
                classes [ "self-end" ]
                size Small
              }
            ]
          ]
          match model.Recipe with
          | None -> Html.text "buh"
          | Some r ->
            yield!
              r.Ingredients
              |> List.map (fun x ->
                input {
                  label "Ingredient"
                  value x.Text
                  classes [ "flex-1" ]
                })
        ]
      ]
      Html.div [
        prop.classes [
          "flex"
          "gap-8"
          "flex-col"
        ]
        prop.children [
          Html.div [
            prop.classes [ "flex"; "gap-4" ]
            prop.children [
              Html.h2 [
                prop.text "Steps"
                prop.classes [ "m-0" ]
              ]
              button {
                btnType Primary
                text "Add step"
                onClick (fun _ -> AddStep |> dispatch)
                size Small
                classes [ "self-end" ]
              }
            ]
          ]
          match model.Recipe with
          | None -> Html.text "buh"
          | Some r ->
            yield!
              r.Steps
              |> List.map (fun x ->
                input {
                  label "Step"
                  value x.Text
                  classes [ "flex-1" ]
                })
        ]
      ]
      Html.div [
        prop.classes [ "flex"; "gap-4" ]
        prop.children [
          button {
            text "Cancel"
            btnType Secondary
            onClick (fun _ -> Cancel |> dispatch)
          }
          button {
            text "Save"
            btnType Primary
          }
        ]
      ]
    ]
  ]