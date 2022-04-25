module RecipeApi

open Shared
open DbContext
open EntityFrameworkCore.FSharp.DbContextHelpers
open System.Linq

let recipesApi =
    { getRecipes = fun () -> async { return! toListAsync ctx.Recipes }
      getRecipe = fun id -> async { return! ctx.Recipes.TryFirstAsync(fun x -> x.Id = id) }
      addRecipe =
        fun recipe ->
            async {
                do! recipe |> addEntityAsync ctx
                do! saveChangesAsync ctx
                return recipe
            } }