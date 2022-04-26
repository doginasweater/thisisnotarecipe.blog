module Recipe

open Shared
open DbContext
open EntityFrameworkCore.FSharp.DbContextHelpers

let ctx = new ThisIsNotAContext()

let getRecipes () =
    async { return! toListAsync ctx.Recipes }

let getRecipe id =
    async { return! ctx.Recipes.TryFirstAsync(fun x -> x.Id = id) }

let addRecipe recipe =
    async {
        do! recipe |> addEntityAsync ctx
        do! saveChangesAsync ctx
        return recipe
    }

let recipesApi =
    { getRecipes = getRecipes
      getRecipe = getRecipe
      addRecipe = addRecipe }