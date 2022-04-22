module Storage

open Shared
open LiteDB.FSharp
open LiteDB

type Storage() =
    let database =
        let mapper = FSharpBsonMapper()
        let connStr = "Filename=recipes.db;mode=Exclusive"
        new LiteDatabase(connStr, mapper)

    let todos = database.GetCollection<Todo> "todos"

    member _.GetTodos() = todos.FindAll() |> List.ofSeq

    member _.AddTodo(todo: Todo) =
        if Todo.isValid todo.Description then
            todos.Insert todo |> ignore
            Ok()
        else
            Error "Invalid todo"

let storage = Storage()