module DbContext

open Microsoft.EntityFrameworkCore
open EntityFrameworkCore.FSharp.Extensions

open Shared

type ThisIsNotAContext =
    inherit DbContext

    [<DefaultValue>]
    val mutable todos: DbSet<Todo>

    member this.Todos
        with get () = this.todos
        and set v = this.todos <- v

    [<DefaultValue>]
    val mutable recipes: DbSet<Recipe>

    member this.Recipes
        with get () = this.recipes
        and set v = this.recipes <- v

    override _.OnModelCreating builder = builder.RegisterOptionTypes()

    // override __.OnConfiguring(options: DbContextOptionsBuilder) : unit =
    //     options
    //         .UseSqlite("Data Source=recipes.db")
    //         .UseFSharpTypes()
    //     |> ignore

    new() = { inherit DbContext() }
    new(options: DbContextOptions<ThisIsNotAContext>) = { inherit DbContext(options) }