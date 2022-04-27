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

let renderBody model dispatch =
    match model.ActivePage with
    | Page.NotFound -> str "Page not found?"
    | Page.TodosPage todoModel -> Todo.view todoModel (TodoMsg >> dispatch)
    | Page.RecipesPage recipesModel -> Recipe.view recipesModel (RecipesMsg >> dispatch)

open Feliz
open Fable.Core.JsInterop

importAll "./style.css"

let themePicker =
    Html.select [
        prop.classes [
            "select"
            "select-bordered"
        ]
        prop.custom ("data-choose-theme", true)
        prop.children [
            Html.option [
                prop.value "dark"
                prop.text "Dark"
            ]
            Html.option [
                prop.value "synthwave"
                prop.text "Synthwave"
            ]
            Html.option [
                prop.value "night"
                prop.text "Night"
            ]
            Html.option [
                prop.value "cupcake"
                prop.text "Cupcake"
            ]
        ]
    ]

let view (model: Model) (dispatch: Dispatch<Msg>) =
    React.fragment [
        Html.header [
            prop.classes [
                "p-8"
                "border-b"
                "border-gray-400"
                "prose"
                "dark:prose-invert"
                "max-w-none"
            ]
            prop.children [
                Html.div [
                    prop.classes [
                        "flex"
                        "justify-between"
                    ]
                    prop.children [
                        Html.a [
                            prop.href "/"
                            prop.classes [ "block"; "no-underline" ]
                            prop.children [
                                Html.h1 [
                                    prop.classes [ "mb-0" ]
                                    prop.text "This Is Not a Recipe Blog"
                                ]
                            ]
                        ]
                        themePicker
                    ]
                ]
            ]
        ]

        Html.div [
            prop.classes [
                "left-side"
                "border-r"
                "border-gray-400"
                "p-8"
                "prose"
                "dark:prose-invert"
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
                        "justify-between"
                        "prose"
                        "dark:prose-invert"
                        "max-w-none"
                    ]
                    prop.children [
                        Html.div "this is a footer"
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