namespace rec Shared

open System

[<CLIMutable>]
type Recipe =
  { Id: Guid
    Title: string
    Description: string
    Ingredients: Ingredient list
    Steps: Step list
    Categories: Category list
    Tags: Tag list }

[<CLIMutable>]
type Step =
  { Id: Guid
    RecipeId: Guid
    Recipe: Recipe
    Order: int
    Text: string }

[<CLIMutable>]
type Ingredient =
  { Id: Guid
    RecipeId: Guid
    Recipe: Recipe
    Text: string
    Type: string }

module Recipe =
  let isValid (description: string) =
    String.IsNullOrWhiteSpace description |> not

type IRecipeApi =
  { getRecipes: unit -> Async<Recipe list>
    getRecipe: Guid -> Async<Recipe option>
    addRecipe: Recipe -> Async<Recipe> }