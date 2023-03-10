// Copyright (c) Strange Loop Games. All rights reserved.
// See LICENSE file in the project root for full license information.
// <auto-generated />

namespace Eco.Mods.TechTree

{ 
// [DoNotLocalize]
using System;
using System.Collections.Generic;
using Eco.Gameplay.Components;
using Eco.Gameplay.Items;
using Eco.Gameplay.Skills;
using Eco.Gameplay.Systems.TextLinks;
using Eco.Gameplay.Systems.Tooltip;
using Eco.Shared.Localization;
using Eco.Shared.Serialization;

    [Serialized]
    [LocDisplayName("Wooden Handle")]
    [MaxStackSize(200)]
    [Weight(500)]      
    
    public partial class WoodenHandleItem : Item                                    
    {
        public override LocString DisplayNamePlural { get { return Localizer.DoStr("Wooden Handles"); } } 
        public override LocString DisplayDescription { get { return Localizer.DoStr("A shaped wooden handle used to make a stamp."); } }

        static WoodenHandleItem()
        {

        }
    }

    [RequiresSkill(typeof(CarpentrySkill), 4)]
    public partial class WoodenHandleRecipe : RecipeFamily
    {
        public WoodenHandleRecipe()
        {
            this.Recipes = new List<Recipe>
                {
                    new Recipe(
                        "Wooden Handle",
                        Localizer.DoStr("Wooden Handle"),
                        new IngredientElement[]
                        {
                            new IngredientElement("Lumber", 3, typeof(CarpentrySkill), typeof(CarpentryLavishResourcesTalent)),
                        },
                        new CraftingElement [] { new CraftingElement<WoodenHandleItem>() }
                        )
                };

            this.ExperienceOnCraft = 0;
            this.LaborInCalories = CreateLaborInCaloriesValue(100);
            this.CraftMinutes = CreateCraftTimeValue(typeof(WoodenHandleRecipe), 2, typeof(CarpentrySkill), typeof(CarpentryFocusedSpeedTalent), typeof(CarpentryParallelSpeedTalent));
            this.Initialize(Localizer.DoStr("Wooden Handle"), typeof(WoodenHandleRecipe));

            CraftingComponent.AddRecipe(typeof(CarpentryTableObject), this);
        }
    }
}
