module Todo

open DbContext
open EntityFrameworkCore.FSharp.DbContextHelpers
open Shared

let ctx = new ThisIsNotAContext()

let emptyTodo =
    { Id = (System.Guid.NewGuid())
      Description = "" }

let todosApi =
    { getTodos = fun () -> async { return ctx.Todos |> List.ofSeq }
      addTodo =
        fun todo ->
            async {
                do! todo |> addEntityAsync ctx
                do! saveChangesAsync ctx

                return todo
            } }