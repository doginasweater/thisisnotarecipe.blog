namespace Shared

open System

[<CLIMutable>]
type Recipe =
  { Id: Guid
    Title: string
    Description: string
    Category: string }

module Recipe =
  let isValid (description: string) =
    String.IsNullOrWhiteSpace description |> not

type IRecipeApi =
  { getRecipes: unit -> Async<Recipe list>
    getRecipe: Guid -> Async<Recipe option>
    addRecipe: Recipe -> Async<Recipe> }