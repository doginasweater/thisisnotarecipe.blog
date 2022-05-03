﻿// <auto-generated />
namespace Server.Migrations

open System
open Microsoft.EntityFrameworkCore
open Microsoft.EntityFrameworkCore.Infrastructure
open Microsoft.EntityFrameworkCore.Metadata
open Microsoft.EntityFrameworkCore.Migrations
open Microsoft.EntityFrameworkCore.Storage.ValueConversion

[<DbContext(typeof<DbContext.ThisIsNotAContext>)>]
type ThisIsNotAContextModelSnapshot() =
    inherit ModelSnapshot()

    override this.BuildModel(modelBuilder: ModelBuilder) =
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

            b.Property<Guid>("RecipeId")
                .IsRequired(true)
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

            b.Property<string>("Text")
                .IsRequired(true)
                .HasColumnType("TEXT")
                |> ignore

            b.HasKey("Id")
                |> ignore


            b.HasIndex("RecipeId")
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

            b.Property<Guid>("RecipeId")
                .IsRequired(true)
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
            b.HasOne("Shared.Recipe", "Recipe")
                .WithMany("Ingredients")
                .HasForeignKey("RecipeId")
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
                .HasForeignKey("RecipeId")
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

