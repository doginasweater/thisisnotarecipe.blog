module Main

open Elmish
open Fable.React

open Pages
open Router

[<RequireQualifiedAccess>]
type Page =
  | TodosPage of Todo.Model
  | RecipeListPage of RecipeList.Model
  | RecipePage of Recipe.Model
  | NotFound

type Model =
  { ActivePage: Page
    CurrentRoute: Route option }

type Msg =
  | TodoMsg of Todo.Msg
  | RecipeListMsg of RecipeList.Msg
  | RecipeMsg of Recipe.Msg

let setRoute (optRoute: Route option) model =
  let model = { model with CurrentRoute = optRoute }

  printfn "route %A" optRoute

  match optRoute with
  | None -> { model with ActivePage = Page.NotFound }, Cmd.none
  | Some Todo ->
    let todoModel, todoCmd = Todo.init ()
    { model with ActivePage = Page.TodosPage todoModel }, Cmd.map TodoMsg todoCmd
  | Some NewRecipe ->
    let recipeModel, recipeCmd = Recipe.init None
    { model with ActivePage = Page.RecipePage recipeModel }, Cmd.map RecipeMsg recipeCmd
  | Some (Recipe recipeId) ->
    let recipeModel, recipeCmd = Recipe.init (Some recipeId)
    { model with ActivePage = Page.RecipePage recipeModel }, Cmd.map RecipeMsg recipeCmd
  | Some RecipeList ->
    let recipeListModel, recipeListCmd = RecipeList.init ()
    { model with ActivePage = Page.RecipeListPage recipeListModel }, Cmd.map RecipeListMsg recipeListCmd

let init (location: Route option) =
  setRoute
    location
    { ActivePage = Page.NotFound
      CurrentRoute = None }

let update (msg: Msg) (model: Model) =
  match model.ActivePage, msg with
  | Page.TodosPage todoModel, TodoMsg todoMsg ->
    let todoModel, todoCmd = Todo.update todoMsg todoModel

    { model with ActivePage = Page.TodosPage todoModel }, Cmd.map TodoMsg todoCmd
  | Page.RecipeListPage recipeListModel, RecipeListMsg recipeListMsg ->
    let recipeListModel, RecipeListCmdd =
      RecipeList.update recipeListMsg recipeListModel

    { model with ActivePage = Page.RecipeListPage recipeListModel }, Cmd.map RecipeListMsg RecipeListCmdd
  | Page.RecipePage recipeModel, RecipeMsg recipeMsg ->
    let recipeModel, recipeCmd = Recipe.update recipeMsg recipeModel

    { model with ActivePage = Page.RecipePage recipeModel }, Cmd.map RecipeMsg recipeCmd
  | Page.NotFound, _ -> model, Cmd.none
  | _, _ -> { model with ActivePage = Page.NotFound }, Cmd.none

let renderBody model dispatch =
  match model.ActivePage with
  | Page.NotFound -> str "Page not found?"
  | Page.TodosPage todoModel -> Todo.view todoModel (TodoMsg >> dispatch)
  | Page.RecipePage recipeModel -> Recipe.view recipeModel (RecipeMsg >> dispatch)
  | Page.RecipeListPage recipesModel -> RecipeList.view recipesModel (RecipeListMsg >> dispatch)

open Feliz
open Fable.Core.JsInterop
open Components

importAll "./style.css"

let view (model: Model) (dispatch: Dispatch<Msg>) =
  React.fragment [
    Html.header [ Navbar.navbar ]

    Html.div [
      prop.classes [
        "left-side"
        "border-r"
        "border-gray-400"
        "p-8"
        "prose"
        "dark:prose-invert"
        "bg-base-300"
      ]
      prop.text "i am a left menu"
    ]

    Html.main [
      prop.classes [
        "p-8"
        "prose"
        "dark:prose-invert"
        "max-w-none"
        "flex"
        "flex-col"
      ]
      prop.children [
        Html.div [
          prop.classes [ "flex-1" ]
          prop.children [
            renderBody model dispatch
          ]
        ]
        Html.footer [
          prop.classes [
            "flex-none"
            "flex"
            "justify-end"
            "prose"
            "dark:prose-invert"
            "max-w-none"
          ]
          prop.children [
            Html.div [
              Html.a [
                prop.href "https://github.com/doginasweater/thisisnotarecipe.blog"
                prop.target "_blank"
                prop.classes [
                  "block"
                  "flex"
                  "gap-4"
                  "items-center"
                  "no-underline"
                ]
                prop.children [
                  Html.div "Copyright 2022 - Dog In a Sweater"
                  Html.i [
                    prop.classes [
                      "fab"
                      "fa-github"
                      "block"
                    ]
                  ]
                ]
              ]
            ]
          ]
        ]
      ]
    ]
  ]