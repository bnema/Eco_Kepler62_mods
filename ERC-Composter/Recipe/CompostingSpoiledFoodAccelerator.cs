﻿// Copyright (c) Strange Loop Games. All rights reserved.
// See LICENSE file in the project root for full license information.
// <auto-generated />

namespace Eco.Mods.TechTree
{
    using System;
    using System.Collections.Generic;
    using Eco.Gameplay.Components;
    using Eco.Gameplay.DynamicValues;
    using Eco.Gameplay.Items;
    using Eco.Gameplay.Players;
    using Eco.Gameplay.Skills;
    using Eco.Shared.Utils;
    using Eco.World;
    using Eco.World.Blocks;
    using Gameplay.Systems.TextLinks;
    using Eco.Shared.Localization;
    using Eco.Core.Controller;

    /// <summary>Auto-generated class. Don't modify it! All your changes will be wiped with next update! Use Mods* partial methods instead for customization.</summary>

    [RequiresSkill(typeof(FertilizersSkill), 2)]
    public partial class CompostingSpoiledFoodAcceleratorRecipe : RecipeFamily
    {
        public CompostingSpoiledFoodAcceleratorRecipe()
        {
            var recipe = new Recipe();
            recipe.Init(
                "CompostingSpoiledFoodAccelerator",  //noloc
                Localizer.DoStr("Composting Spoiled Food with Accelerator"),
                new List<IngredientElement>
                {
                    new IngredientElement(typeof(SpoiledFoodItem), 50, true),
					new IngredientElement("Greens", 25, true), //noloc
					new IngredientElement("NaturalFiber", 25, true), //noloc
                    new IngredientElement(typeof(YeastItem), 5, true),
                },
                new List<CraftingElement>
                {
                    new CraftingElement<CompostItem>(2),
                });
            this.Recipes = new List<Recipe> { recipe };
            this.LaborInCalories = CreateLaborInCaloriesValue(25);
            this.CraftMinutes = CreateCraftTimeValue(120f);
            this.ModsPreInitialize();
            this.Initialize(Localizer.DoStr("Composting Spoiled Food with Accelerator"), typeof(CompostingSpoiledFoodAcceleratorRecipe));
            this.ModsPostInitialize();
			CraftingComponent.AddRecipe(typeof(ERCComposterObject), this);
        }

        /// <summary>Hook for mods to customize RecipeFamily before initialization. You can change recipes, xp, labor, time here.</summary>
        partial void ModsPreInitialize();
        /// <summary>Hook for mods to customize RecipeFamily after initialization, but before registration. You can change skill requirements here.</summary>
        partial void ModsPostInitialize();
    }
}
