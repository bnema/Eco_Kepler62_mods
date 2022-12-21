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
    [LocDisplayName("Quill Pen")]
    [MaxStackSize(200)]
    [Weight(10)]                                                                           
    public partial class QuillPenItem : Item       
    {
        public override LocString DisplayNamePlural { get { return Localizer.DoStr("Quill Pens"); } } 
        public override LocString DisplayDescription { get { return Localizer.DoStr("A pen fashioned from the quill of a large bird. Flimsy and proned to breaking."); } }

        static QuillPenItem()
        {

        }
    }

    [RequiresSkill(typeof(HuntingSkill), 2)]
    public partial class QuillPenRecipe : RecipeFamily
    {
        public QuillPenRecipe()
        {
            this.Recipes = new List<Recipe>
                {
                    new Recipe(
                        "Quill Pen",
                        Localizer.DoStr("Quill Pen"),
                        new IngredientElement[]
                        {
                            new IngredientElement(typeof(TurkeyCarcassItem), 1, true),
                        },
                        new CraftingElement [] { new CraftingElement<QuillPenItem>() }
                        )
                };

            this.ExperienceOnCraft = 0;
            this.LaborInCalories = CreateLaborInCaloriesValue(100);
            this.CraftMinutes = CreateCraftTimeValue(typeof(QuillPenRecipe), 1, typeof(HuntingSkill));
            this.Initialize(Localizer.DoStr("Quill Pen"), typeof(QuillPenRecipe));

            CraftingComponent.AddRecipe(typeof(ButcheryTableObject), this);
        }
    }
}