module Pages.Recipe

open Elmish
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

let update msg model =
  match msg with
  | GotRecipes recipes -> { model with Recipes = recipes }, Cmd.none
  | AddRecipe -> { model with AddingRecipe = true }, Cmd.none
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
          Inputs.text "Title" [ prop.onChange (fun x -> SetTitleInput x |> dispatch) ]
          Inputs.text "Description" [ prop.onChange (fun x -> SetDescriptionInput x |> dispatch) ]
          Html.button [
            prop.classes [
              "btn"
              "btn-secondary"
              "self-end"
            ]
            prop.onClick (fun _ -> CancelAddRecipe |> dispatch)
            prop.text "Cancel"
          ]
          Html.button [
            prop.classes [
              "btn"
              "btn-primary"
              "self-end"
            ]
            prop.onClick (fun _ -> CancelAddRecipe |> dispatch)
            prop.text "Add"
          ]
        ]
      ]
    ]
  ]

let view model dispatch =
  Html.div [
    if model.AddingRecipe then
      renderAddingRecipe dispatch
    else if model.Recipes.Length = 0 then
      Html.div "No recipes to display"

      Html.button [
        prop.onClick (fun _ -> AddRecipe |> dispatch)
        prop.classes [ "btn"; "btn-primary" ]
        prop.text "Add recipe"
      ]
    else
      Html.ol [
        for recipe in model.Recipes do
          Html.li recipe.Description
      ]

      Html.button [
        prop.onClick (fun _ -> AddRecipe |> dispatch)
        prop.classes [ "btn"; "btn-primary" ]
        prop.text "Add recipe"
      ]
  ]