module Pages.RecipeList

open Elmish
open Elmish.Navigation
open Fable.Remoting.Client
open Shared
open Components

type Model =
  { Recipes: Recipe list
    AddingRecipe: bool
    TitleInput: string
    DescriptionInput: string }

type Msg =
  | GotRecipes of Recipe list
  | AddRecipe
  | CancelAddRecipe
  | SetTitleInput of string
  | SetDescriptionInput of string

let recipesApi =
  Remoting.createApi ()
  |> Remoting.withRouteBuilder Route.builder
  |> Remoting.buildProxy<IRecipeApi>

let init () : Model * Cmd<Msg> =
  let model =
    { Recipes = []
      AddingRecipe = false
      TitleInput = ""
      DescriptionInput = "" }

  let cmd = Cmd.OfAsync.perform recipesApi.getRecipes () GotRecipes

  model, cmd

let update (msg: Msg) (model: Model) =
  match msg with
  | GotRecipes recipes -> { model with Recipes = recipes }, Cmd.none
  | AddRecipe -> model, Navigation.newUrl "/recipe"
  | CancelAddRecipe ->
    { model with
        AddingRecipe = false
        TitleInput = ""
        DescriptionInput = "" },
    Cmd.none
  | SetTitleInput value -> { model with TitleInput = value }, Cmd.none
  | SetDescriptionInput value -> { model with DescriptionInput = value }, Cmd.none

open Feliz

let renderAddingRecipe dispatch =
  Html.div [
    prop.classes [
      "flex"
      "flex-col"
      "gap-4"
      "mb-4"
    ]
    prop.children [
      Html.div [
        prop.text "adding"
        prop.classes [ "flex"; "gap-4" ]
        prop.children [
          input {
            label "Title"
            onChange (fun x -> SetTitleInput x |> dispatch)
          }
          input {
            label "Description"
            onChange (fun x -> SetDescriptionInput x |> dispatch)
          }
          button {
            btnType Secondary
            classes [ "self-end" ]
            text "Cancel"
            onClick (fun _ -> CancelAddRecipe |> dispatch)
          }
          button {
            btnType Primary
            classes [ "self-end" ]
            onClick (fun _ -> CancelAddRecipe |> dispatch)
            text "Add"
          }
        ]
      ]
    ]
  ]

let view model dispatch =
  let addRecipeButton =
    button {
      onClick (fun _ -> AddRecipe |> dispatch)
      btnType Primary
      text "Add recipe"
    }

  Html.div [
    if model.AddingRecipe then
      renderAddingRecipe dispatch
    else if model.Recipes.Length = 0 then
      Html.div "No recipes to display"
      addRecipeButton
    else
      Html.ol [
        for recipe in model.Recipes do
          Html.li recipe.Description
      ]

      addRecipeButton
  ]