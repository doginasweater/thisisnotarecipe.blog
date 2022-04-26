module App

open Saturn

open Api
open DbContext

let ctx = new ThisIsNotAContext()
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