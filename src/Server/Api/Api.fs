module Api

open Fable.Remoting.Server
open Fable.Remoting.Giraffe
open Giraffe

open Shared
open Recipe
open Todo

let recipeApp =
    Remoting.createApi ()
    |> Remoting.withRouteBuilder Route.builder
    |> Remoting.fromReader recipesReader
    |> Remoting.buildHttpHandler

let todoApp =
    Remoting.createApi ()
    |> Remoting.withRouteBuilder Route.builder
    |> Remoting.fromReader todosReader
    |> Remoting.buildHttpHandler

let (webApp: HttpFunc -> Microsoft.AspNetCore.Http.HttpContext -> HttpFuncResult) =
    choose [ recipeApp; todoApp ]