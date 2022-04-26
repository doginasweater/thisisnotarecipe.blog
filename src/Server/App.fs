module App

open Fable.Remoting.Server
open Fable.Remoting.Giraffe
open Saturn

open Shared
open TodoApi
open RecipeApi
open DbContext

open Giraffe

let recipeApp =
    Remoting.createApi ()
    |> Remoting.withRouteBuilder Route.builder
    |> Remoting.fromValue recipesApi
    |> Remoting.buildHttpHandler

let todoApp =
    Remoting.createApi ()
    |> Remoting.withRouteBuilder Route.builder
    |> Remoting.fromValue todosApi
    |> Remoting.buildHttpHandler

let webApp = choose [ recipeApp; todoApp ]

ctx.Database.EnsureCreated() |> ignore

let app =
    application {
        url "http://0.0.0.0:8085"
        use_router webApp
        memory_cache
        use_static "public"
        use_gzip
    }

run app