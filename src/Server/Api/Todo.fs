module Todo

open DbContext
open EntityFrameworkCore.FSharp.DbContextHelpers
open Shared

let emptyTodo =
    { Id = (System.Guid.NewGuid())
      Description = "" }

let getTodos (ctx: ThisIsNotAContext) =
    fun _ -> async { return ctx.Todos |> List.ofSeq }

let addTodo (ctx: ThisIsNotAContext) =
    fun todo ->
        async {
            do! todo |> addEntityAsync ctx
            do! saveChangesAsync ctx

            return todo
        }

let todosReader =
    reader {
        let! ctx = resolve<ThisIsNotAContext> ()

        return
            { getTodos = getTodos ctx
              addTodo = addTodo ctx }
    }