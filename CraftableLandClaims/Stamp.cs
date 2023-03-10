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
    [LocDisplayName("Stamp")]
    [MaxStackSize(200)]
    [Weight(1000)]                                                                             
    public partial class StampItem : Item                                    
    {
        public override LocString DisplayNamePlural { get { return Localizer.DoStr("Stamps"); } } 
        public override LocString DisplayDescription { get { return Localizer.DoStr("A stamp used to make official seals with wax."); } }

        static StampItem()
        {

        }
    }

    [RequiresSkill(typeof(BasicEngineeringSkill), 5)]
    public partial class StampRecipe : RecipeFamily
    {
        public StampRecipe()
        {
            this.Recipes = new List<Recipe>
                {
                    new Recipe(
                        "Stamp",
                        Localizer.DoStr("Stamp"),
                        new IngredientElement[]
                        {
                        new IngredientElement(typeof(IronBarItem), 1),
                        new IngredientElement("Lumber", 1),
                        new IngredientElement(typeof(WoodenHandleItem), 1),
                        },
                        new CraftingElement [] { new CraftingElement<StampItem>()}
                        )
                };

            this.ExperienceOnCraft = 0;
            this.LaborInCalories = CreateLaborInCaloriesValue(100);
            this.CraftMinutes = CreateCraftTimeValue(typeof(StampRecipe), 3, typeof(BasicEngineeringSkill), typeof(BasicEngineeringFocusedSpeedTalent), typeof(BasicEngineeringParallelSpeedTalent));
            this.Initialize(Localizer.DoStr("Stamp"), typeof(StampRecipe));

            CraftingComponent.AddRecipe(typeof(WorkbenchObject), this);
        }
    }
}