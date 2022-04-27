module App

open Microsoft.EntityFrameworkCore
open EntityFrameworkCore.FSharp.Extensions
open Saturn

open Api
open DbContext
open Microsoft.Extensions.DependencyInjection

let configureServices (services: IServiceCollection) =
  services.AddDbContext<ThisIsNotAContext> (fun opt ->
    opt
      .UseSqlite("Data Source=recipes.db")
      .UseFSharpTypes()
    |> ignore)

let app =
  application {
    service_config configureServices
    url "http://0.0.0.0:8085"
    use_router webApp
    memory_cache
    use_static "public"
    use_gzip
  }

run app