namespace rec Shared

open System

type AuthorId = AuthorId of Guid

[<CLIMutable>]
type Author =
  { Id: AuthorId
    FirstName: string
    LastName: string
    Email: string }

type CategoryId = CategoryId of Guid

[<CLIMutable>]
type Category =
  { Id: CategoryId
    Name: string
    Recipes: Recipe list }

type RecipeId = RecipeId of Guid

[<CLIMutable>]
type Recipe =
  { Id: RecipeId
    Title: string
    Description: string
    Source: string option
    Author: Author list
    Ingredients: Ingredient list
    Steps: Step list
    Categories: Category list
    Tags: Tag list }

type StepId = StepId of Guid

[<CLIMutable>]
type Step =
  { Id: StepId
    Recipe: Recipe
    Order: int
    Text: string }

type IngredientId = IngredientId of Guid

[<CLIMutable>]
type Ingredient =
  { Id: IngredientId
    Recipe: Recipe
    Amount: string
    Unit: string
    Text: string
    Type: string }

type VersionId = VersionId of Guid

[<CLIMutable>]
type Version =
  { Id: VersionId
    Title: string
    Iterations: Recipe list }

module Recipe =
  let isValid (description: string) =
    String.IsNullOrWhiteSpace description |> not

  let makeEmptyRecipe () : Recipe =
    { Id = RecipeId Guid.Empty
      Title = ""
      Description = ""
      Source = None
      Author = []
      Ingredients = []
      Steps = []
      Categories = []
      Tags = [] }

type IRecipeApi =
  { getRecipes: unit -> Async<Recipe list>
    getRecipe: RecipeId -> Async<Recipe option>
    addRecipe: Recipe -> Async<Recipe> }