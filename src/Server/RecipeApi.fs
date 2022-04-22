module RecipeApi

open Shared
open Storage

let recipesApi =
    { getRecipes = fun () -> async { return [] }
      getRecipe =
        fun id ->
            async {
                return
                    Some
                        { Id = System.Guid.NewGuid()
                          Description = ""
                          Category = "" }
            }
      addRecipe = fun recipe -> async { return recipe } }