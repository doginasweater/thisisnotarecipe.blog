module Main

open Elmish
open Fable.React

[<RequireQualifiedAccess>]
type Page =
    | TodosPage of Todo.Model
    | RecipesPage of Recipe.Model
    | NotFound

type Model =
    { ActivePage: Page
      CurrentRoute: Router.Route option }

type Msg =
    | TodoMsg of Todo.Msg
    | RecipesMsg of Recipe.Msg

let setRoute (optRoute: Router.Route option) model =
    let model = { model with CurrentRoute = optRoute }

    match optRoute with
    | None -> { model with ActivePage = Page.NotFound }, Cmd.none
    | Some Router.Route.Todo ->
        let todoModel, todoCmd = Todo.init ()
        { model with ActivePage = Page.TodosPage todoModel }, Cmd.map TodoMsg todoCmd
    | Some Router.Route.Recipes ->
        let recipeModel, recipeCmd = Recipe.init ()
        { model with ActivePage = Page.RecipesPage recipeModel }, Cmd.map RecipesMsg recipeCmd

let init (location: Router.Route option) =
    setRoute
        location
        { ActivePage = Page.NotFound
          CurrentRoute = None }

let update (msg: Msg) (model: Model) =
    match model.ActivePage, msg with
    | Page.TodosPage todoModel, TodoMsg todoMsg ->
        let todoModel, todoCmd = Todo.update todoMsg todoModel

        { model with ActivePage = Page.TodosPage todoModel }, Cmd.map TodoMsg todoCmd
    | Page.RecipesPage recipesModel, RecipesMsg recipesMsg ->
        let recipesModel, recipesCmd = Recipe.update recipesMsg recipesModel

        { model with ActivePage = Page.RecipesPage recipesModel }, Cmd.map RecipesMsg recipesCmd
    | Page.NotFound, _ -> model, Cmd.none
    | _, _ -> { model with ActivePage = Page.NotFound }, Cmd.none

let view (model: Model) (dispatch: Dispatch<Msg>) =
    match model.ActivePage with
    | Page.NotFound -> str "hello steven!!!"
    | Page.TodosPage todoModel -> Todo.view todoModel (TodoMsg >> dispatch)
    | Page.RecipesPage recipesModel -> Recipe.view recipesModel (RecipesMsg >> dispatch)