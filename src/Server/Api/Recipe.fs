module Recipe

open Shared
open DbContext
open EntityFrameworkCore.FSharp.DbContextHelpers

let getRecipes (ctx: ThisIsNotAContext) =
    fun () -> async { return! toListAsync ctx.Recipes }

let getRecipe (ctx: ThisIsNotAContext) =
    fun id -> async { return! ctx.Recipes.TryFirstAsync(fun x -> x.Id = id) }

let addRecipe (ctx: ThisIsNotAContext) =
    fun recipe ->
        async {
            do! recipe |> addEntityAsync ctx
            do! saveChangesAsync ctx
            return recipe
        }

let recipesReader =
    reader {
        let! ctx = resolve<ThisIsNotAContext> ()

        return
            { getRecipes = getRecipes ctx
              getRecipe = getRecipe ctx
              addRecipe = addRecipe ctx }
    }