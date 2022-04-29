﻿// <auto-generated />
namespace Server.Migrations

open System
open Microsoft.EntityFrameworkCore
open Microsoft.EntityFrameworkCore.Infrastructure
open Microsoft.EntityFrameworkCore.Metadata
open Microsoft.EntityFrameworkCore.Migrations
open Microsoft.EntityFrameworkCore.Storage.ValueConversion

[<DbContext(typeof<DbContext.ThisIsNotAContext>)>]
[<Migration("20220429004505_morerecipedata")>]
type morerecipedata() =
    inherit Migration()

    override this.Up(migrationBuilder:MigrationBuilder) =
        migrationBuilder.DropForeignKey(
            name = "FK_Categories_Recipes_RecipeId"
            ,table = "Categories"
            ) |> ignore

        migrationBuilder.DropForeignKey(
            name = "FK_Steps_Recipes_RecipeId"
            ,table = "Steps"
            ) |> ignore

        migrationBuilder.DropIndex(
            name = "IX_Steps_RecipeId"
            ,table = "Steps"
            ) |> ignore

        migrationBuilder.DropIndex(
            name = "IX_Categories_RecipeId"
            ,table = "Categories"
            ) |> ignore

        migrationBuilder.DropColumn(
            name = "RecipeId"
            ,table = "Categories"
            ) |> ignore

        migrationBuilder.AddColumn<Guid>(
            name = "RecipeId1"
            ,table = "Steps"
            ,``type`` = "TEXT"
            ,nullable = true
            ) |> ignore

        migrationBuilder.AddColumn<string>(
            name = "Source"
            ,table = "Recipes"
            ,``type`` = "TEXT"
            ,nullable = true
            ) |> ignore

        migrationBuilder.AddColumn<Guid>(
            name = "VersionId"
            ,table = "Recipes"
            ,``type`` = "TEXT"
            ,nullable = false
            ,defaultValue = "Guid(\"00000000-0000-0000-0000-000000000000\")"
            ) |> ignore

        migrationBuilder.AddColumn<Guid>(
            name = "Recipe"
            ,table = "Ingredients"
            ,``type`` = "TEXT"
            ,nullable = false
            ,defaultValue = "Guid(\"00000000-0000-0000-0000-000000000000\")"
            ) |> ignore

        migrationBuilder.CreateTable(
            name = "Authors"
            ,columns = (fun table -> 
            {|
                Id =
                    table.Column<Guid>(
                        nullable = false
                        ,``type`` = "TEXT"
                    )
                FirstName =
                    table.Column<string>(
                        nullable = false
                        ,``type`` = "TEXT"
                    )
                LastName =
                    table.Column<string>(
                        nullable = false
                        ,``type`` = "TEXT"
                    )
                Email =
                    table.Column<string>(
                        nullable = false
                        ,``type`` = "TEXT"
                    )
                RecipeId =
                    table.Column<Guid>(
                        nullable = true
                        ,``type`` = "TEXT"
                    )
            |})
            , constraints =
                (fun table -> 
                    table.PrimaryKey("PK_Authors", (fun x -> (x.Id) :> obj)
                    ) |> ignore
                    table.ForeignKey(
                        name = "FK_Authors_Recipes_RecipeId"
                        ,column = (fun x -> (x.RecipeId) :> obj)
                        ,principalTable = "Recipes"
                        ,principalColumn = "Id"
                        ) |> ignore

                )
        ) |> ignore

        migrationBuilder.CreateTable(
            name = "CategoryRecipe"
            ,columns = (fun table -> 
            {|
                CategoriesId =
                    table.Column<Guid>(
                        nullable = false
                        ,``type`` = "TEXT"
                    )
                RecipesId =
                    table.Column<Guid>(
                        nullable = false
                        ,``type`` = "TEXT"
                    )
            |})
            , constraints =
                (fun table -> 
                    table.PrimaryKey("PK_CategoryRecipe", (fun x -> (x.CategoriesId, x.RecipesId) :> obj)
                    ) |> ignore
                    table.ForeignKey(
                        name = "FK_CategoryRecipe_Categories_CategoriesId"
                        ,column = (fun x -> (x.CategoriesId) :> obj)
                        ,principalTable = "Categories"
                        ,principalColumn = "Id"
                        ,onDelete = ReferentialAction.Cascade
                        ) |> ignore

                    table.ForeignKey(
                        name = "FK_CategoryRecipe_Recipes_RecipesId"
                        ,column = (fun x -> (x.RecipesId) :> obj)
                        ,principalTable = "Recipes"
                        ,principalColumn = "Id"
                        ,onDelete = ReferentialAction.Cascade
                        ) |> ignore

                )
        ) |> ignore

        migrationBuilder.CreateTable(
            name = "Versions"
            ,columns = (fun table -> 
            {|
                Id =
                    table.Column<Guid>(
                        nullable = false
                        ,``type`` = "TEXT"
                    )
                Title =
                    table.Column<string>(
                        nullable = false
                        ,``type`` = "TEXT"
                    )
            |})
            , constraints =
                (fun table -> 
                    table.PrimaryKey("PK_Versions", (fun x -> (x.Id) :> obj)
                    ) |> ignore
                )
        ) |> ignore

        migrationBuilder.CreateIndex(
            name = "IX_Steps_RecipeId1"
            ,table = "Steps"
            ,column = "RecipeId1"
            ) |> ignore

        migrationBuilder.CreateIndex(
            name = "IX_Recipes_VersionId"
            ,table = "Recipes"
            ,column = "VersionId"
            ) |> ignore

        migrationBuilder.CreateIndex(
            name = "IX_Authors_RecipeId"
            ,table = "Authors"
            ,column = "RecipeId"
            ) |> ignore

        migrationBuilder.CreateIndex(
            name = "IX_CategoryRecipe_RecipesId"
            ,table = "CategoryRecipe"
            ,column = "RecipesId"
            ) |> ignore

        migrationBuilder.AddForeignKey(
            name = "FK_Recipes_Versions_VersionId"
            ,table = "Recipes"
            ,column = "VersionId"
            ,principalTable = "Versions"
            ,principalColumn = "Id"
        ) |> ignore

        migrationBuilder.AddForeignKey(
            name = "FK_Steps_Recipes_RecipeId1"
            ,table = "Steps"
            ,column = "RecipeId1"
            ,principalTable = "Recipes"
            ,principalColumn = "Id"
        ) |> ignore


    override this.Down(migrationBuilder:MigrationBuilder) =
        migrationBuilder.DropForeignKey(
            name = "FK_Recipes_Versions_VersionId"
            ,table = "Recipes"
            ) |> ignore

        migrationBuilder.DropForeignKey(
            name = "FK_Steps_Recipes_RecipeId1"
            ,table = "Steps"
            ) |> ignore

        migrationBuilder.DropTable(
            name = "Authors"
            ) |> ignore

        migrationBuilder.DropTable(
            name = "CategoryRecipe"
            ) |> ignore

        migrationBuilder.DropTable(
            name = "Versions"
            ) |> ignore

        migrationBuilder.DropIndex(
            name = "IX_Steps_RecipeId1"
            ,table = "Steps"
            ) |> ignore

        migrationBuilder.DropIndex(
            name = "IX_Recipes_VersionId"
            ,table = "Recipes"
            ) |> ignore

        migrationBuilder.DropColumn(
            name = "RecipeId1"
            ,table = "Steps"
            ) |> ignore

        migrationBuilder.DropColumn(
            name = "Source"
            ,table = "Recipes"
            ) |> ignore

        migrationBuilder.DropColumn(
            name = "VersionId"
            ,table = "Recipes"
            ) |> ignore

        migrationBuilder.DropColumn(
            name = "Recipe"
            ,table = "Ingredients"
            ) |> ignore

        migrationBuilder.AddColumn<Guid>(
            name = "RecipeId"
            ,table = "Categories"
            ,``type`` = "TEXT"
            ,nullable = true
            ) |> ignore

        migrationBuilder.CreateIndex(
            name = "IX_Steps_RecipeId"
            ,table = "Steps"
            ,column = "RecipeId"
            ) |> ignore

        migrationBuilder.CreateIndex(
            name = "IX_Categories_RecipeId"
            ,table = "Categories"
            ,column = "RecipeId"
            ) |> ignore

        migrationBuilder.AddForeignKey(
            name = "FK_Categories_Recipes_RecipeId"
            ,table = "Categories"
            ,column = "RecipeId"
            ,principalTable = "Recipes"
            ,principalColumn = "Id"
        ) |> ignore

        migrationBuilder.AddForeignKey(
            name = "FK_Steps_Recipes_RecipeId"
            ,table = "Steps"
            ,column = "RecipeId"
            ,principalTable = "Recipes"
            ,principalColumn = "Id"
            ,onDelete = ReferentialAction.Cascade
        ) |> ignore


    override this.BuildTargetModel(modelBuilder: ModelBuilder) =
        modelBuilder.HasAnnotation("ProductVersion", "6.0.4") |> ignore

        modelBuilder.Entity("CategoryRecipe", (fun b ->

            b.Property<Guid>("CategoriesId")
                .IsRequired(true)
                .HasColumnType("TEXT")
                |> ignore

            b.Property<Guid>("RecipesId")
                .IsRequired(true)
                .HasColumnType("TEXT")
                |> ignore

            b.HasKey("CategoriesId", "RecipesId")
                |> ignore


            b.HasIndex("RecipesId")
                |> ignore

            b.ToTable("CategoryRecipe") |> ignore

        )) |> ignore

        modelBuilder.Entity("Shared.Author", (fun b ->

            b.Property<Guid>("Id")
                .IsRequired(true)
                .HasColumnType("TEXT")
                |> ignore

            b.Property<string>("Email")
                .IsRequired(true)
                .HasColumnType("TEXT")
                |> ignore

            b.Property<string>("FirstName")
                .IsRequired(true)
                .HasColumnType("TEXT")
                |> ignore

            b.Property<string>("LastName")
                .IsRequired(true)
                .HasColumnType("TEXT")
                |> ignore

            b.Property<Nullable<Guid>>("RecipeId")
                .IsRequired(false)
                .HasColumnType("TEXT")
                |> ignore

            b.HasKey("Id")
                |> ignore


            b.HasIndex("RecipeId")
                |> ignore

            b.ToTable("Authors") |> ignore

        )) |> ignore

        modelBuilder.Entity("Shared.Category", (fun b ->

            b.Property<Guid>("Id")
                .IsRequired(true)
                .HasColumnType("TEXT")
                |> ignore

            b.Property<string>("Name")
                .IsRequired(true)
                .HasColumnType("TEXT")
                |> ignore

            b.HasKey("Id")
                |> ignore


            b.ToTable("Categories") |> ignore

        )) |> ignore

        modelBuilder.Entity("Shared.Ingredient", (fun b ->

            b.Property<Guid>("Id")
                .IsRequired(true)
                .HasColumnType("TEXT")
                |> ignore

            b.Property<Guid>("Recipe")
                .IsRequired(true)
                .HasColumnType("TEXT")
                |> ignore

            b.Property<Guid>("RecipeId")
                .IsRequired(true)
                .HasColumnType("TEXT")
                |> ignore

            b.Property<string>("Text")
                .IsRequired(true)
                .HasColumnType("TEXT")
                |> ignore

            b.Property<string>("Type")
                .IsRequired(true)
                .HasColumnType("TEXT")
                |> ignore

            b.HasKey("Id")
                |> ignore


            b.HasIndex("RecipeId")
                |> ignore

            b.ToTable("Ingredients") |> ignore

        )) |> ignore

        modelBuilder.Entity("Shared.Recipe", (fun b ->

            b.Property<Guid>("Id")
                .IsRequired(true)
                .ValueGeneratedOnAdd()
                .HasColumnType("TEXT")
                |> ignore

            b.Property<string>("Description")
                .IsRequired(true)
                .HasColumnType("TEXT")
                |> ignore

            b.Property<string option>("Source")
                .IsRequired(false)
                .HasColumnType("TEXT")
                |> ignore

            b.Property<string>("Title")
                .IsRequired(true)
                .HasColumnType("TEXT")
                |> ignore

            b.Property<Guid>("VersionId")
                .IsRequired(true)
                .HasColumnType("TEXT")
                |> ignore

            b.HasKey("Id")
                |> ignore


            b.HasIndex("VersionId")
                |> ignore

            b.ToTable("Recipes") |> ignore

        )) |> ignore

        modelBuilder.Entity("Shared.Step", (fun b ->

            b.Property<Guid>("Id")
                .IsRequired(true)
                .HasColumnType("TEXT")
                |> ignore

            b.Property<int>("Order")
                .IsRequired(true)
                .HasColumnType("INTEGER")
                |> ignore

            b.Property<Guid>("RecipeId")
                .IsRequired(true)
                .HasColumnType("TEXT")
                |> ignore

            b.Property<Nullable<Guid>>("RecipeId1")
                .IsRequired(false)
                .HasColumnType("TEXT")
                |> ignore

            b.Property<string>("Text")
                .IsRequired(true)
                .HasColumnType("TEXT")
                |> ignore

            b.HasKey("Id")
                |> ignore


            b.HasIndex("RecipeId1")
                |> ignore

            b.ToTable("Steps") |> ignore

        )) |> ignore

        modelBuilder.Entity("Shared.Tag", (fun b ->

            b.Property<Guid>("Id")
                .IsRequired(true)
                .ValueGeneratedOnAdd()
                .HasColumnType("TEXT")
                |> ignore

            b.Property<string>("Name")
                .IsRequired(true)
                .HasColumnType("TEXT")
                |> ignore

            b.Property<Nullable<Guid>>("RecipeId")
                .IsRequired(false)
                .HasColumnType("TEXT")
                |> ignore

            b.HasKey("Id")
                |> ignore


            b.HasIndex("RecipeId")
                |> ignore

            b.ToTable("Tags") |> ignore

        )) |> ignore

        modelBuilder.Entity("Shared.Todo", (fun b ->

            b.Property<Guid>("Id")
                .IsRequired(true)
                .ValueGeneratedOnAdd()
                .HasColumnType("TEXT")
                |> ignore

            b.Property<string>("Description")
                .IsRequired(true)
                .HasColumnType("TEXT")
                |> ignore

            b.HasKey("Id")
                |> ignore


            b.ToTable("Todos") |> ignore

        )) |> ignore

        modelBuilder.Entity("Shared.Version", (fun b ->

            b.Property<Guid>("Id")
                .IsRequired(true)
                .HasColumnType("TEXT")
                |> ignore

            b.Property<string>("Title")
                .IsRequired(true)
                .HasColumnType("TEXT")
                |> ignore

            b.HasKey("Id")
                |> ignore


            b.ToTable("Versions") |> ignore

        )) |> ignore
        modelBuilder.Entity("CategoryRecipe", (fun b ->
            b.HasOne("Shared.Category", null)
                .WithMany()
                .HasForeignKey("CategoriesId")
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired()
                |> ignore
            b.HasOne("Shared.Recipe", null)
                .WithMany()
                .HasForeignKey("RecipesId")
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired()
                |> ignore

        )) |> ignore
        modelBuilder.Entity("Shared.Author", (fun b ->
            b.HasOne("Shared.Recipe", null)
                .WithMany("Author")
                .HasForeignKey("RecipeId")
                |> ignore

        )) |> ignore
        modelBuilder.Entity("Shared.Ingredient", (fun b ->
            b.HasOne("Shared.Recipe", null)
                .WithMany("Ingredients")
                .HasForeignKey("RecipeId")
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired()
                |> ignore

        )) |> ignore
        modelBuilder.Entity("Shared.Recipe", (fun b ->
            b.HasOne("Shared.Version", null)
                .WithMany("Iterations")
                .HasForeignKey("VersionId")
                |> ignore

        )) |> ignore
        modelBuilder.Entity("Shared.Step", (fun b ->
            b.HasOne("Shared.Recipe", "Recipe")
                .WithMany("Steps")
                .HasForeignKey("RecipeId1")
                |> ignore

        )) |> ignore
        modelBuilder.Entity("Shared.Tag", (fun b ->
            b.HasOne("Shared.Recipe", null)
                .WithMany("Tags")
                .HasForeignKey("RecipeId")
                |> ignore

        )) |> ignore
        modelBuilder.Entity("Shared.Recipe", (fun b ->

            b.Navigation("Author")
            |> ignore

            b.Navigation("Ingredients")
            |> ignore

            b.Navigation("Steps")
            |> ignore

            b.Navigation("Tags")
            |> ignore
        )) |> ignore
        modelBuilder.Entity("Shared.Version", (fun b ->

            b.Navigation("Iterations")
            |> ignore
        )) |> ignore

