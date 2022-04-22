module TodoApi

open Shared
open Storage

let todosApi =
    { getTodos = fun () -> async { return storage.GetTodos() }
      addTodo =
        fun todo ->
            async {
                match storage.AddTodo todo with
                | Ok () -> return todo
                | Error e -> return failwith e
            } }

if storage.GetTodos() |> Seq.isEmpty then
    storage.AddTodo(Todo.create "Create new SAFE project")
    |> ignore

    storage.AddTodo(Todo.create "Write your app")
    |> ignore

    storage.AddTodo(Todo.create "Ship it !!!")
    |> ignore