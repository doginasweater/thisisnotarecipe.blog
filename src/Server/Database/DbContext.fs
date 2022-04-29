module DbContext

open Microsoft.EntityFrameworkCore
open EntityFrameworkCore.FSharp.Extensions

open Shared

type ThisIsNotAContext =
  inherit DbContext

  [<DefaultValue>]
  val mutable authors: DbSet<Author>

  member this.Authors
    with get () = this.authors
    and set v = this.authors <- v

  [<DefaultValue>]
  val mutable categories: DbSet<Category>

  member this.Categories
    with get () = this.categories
    and set v = this.categories <- v

  [<DefaultValue>]
  val mutable ingredients: DbSet<Ingredient>

  member this.Ingredients
    with get () = this.ingredients
    and set v = this.ingredients <- v

  [<DefaultValue>]
  val mutable recipes: DbSet<Recipe>

  member this.Recipes
    with get () = this.recipes
    and set v = this.recipes <- v

  [<DefaultValue>]
  val mutable steps: DbSet<Step>

  member this.Steps
    with get () = this.steps
    and set v = this.steps <- v

  [<DefaultValue>]
  val mutable tags: DbSet<Tag>

  member this.Tags
    with get () = this.tags
    and set v = this.tags <- v

  [<DefaultValue>]
  val mutable todos: DbSet<Todo>

  member this.Todos
    with get () = this.todos
    and set v = this.todos <- v

  [<DefaultValue>]
  val mutable versions: DbSet<Version>

  member this.Versions
    with get () = this.versions
    and set v = this.versions <- v

  override _.OnModelCreating builder =
    builder.RegisterOptionTypes()
    builder.RegisterSingleUnionCases()

  new() = { inherit DbContext() }
  new(options: DbContextOptions<ThisIsNotAContext>) = { inherit DbContext(options) }