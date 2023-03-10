// Copyright (c) Strange Loop Games. All rights reserved.
// See LICENSE file in the project root for full license information.
// <auto-generated />

namespace Eco.Mods.TechTree
{
    using System.Collections.Generic;
    using Eco.Core.Items;
    using Eco.Gameplay.Components;
    using Eco.Gameplay.Items;
    using Eco.Gameplay.Players;
    using Eco.Gameplay.Skills;
    using Eco.Gameplay.Systems.TextLinks;
    using Eco.Shared.Localization;
    using Eco.Shared.Serialization;
    using Eco.Shared.Utils;
    using Eco.Core.Controller;

    [Serialized]
    [LocDisplayName("Papaya Smoothie")]
    [MaxStackSize(100)]
    [Weight(1)]
    [Ecopedia("Food", "Cooking", createAsSubPage: true)]
    public partial class PapayaSmoothieItem : FoodItem
    {
        
        public override LocString DisplayDescription { get { return Localizer.DoStr("A refreshing smoothie."); } }
        
        public override float Calories                  => 950;
        public override Nutrients Nutrition             => new Nutrients() { Carbs = 15, Fat = 14, Protein = 12, Vitamins = 20};
        protected override int BaseShelfLife            => (int)TimeUtil.HoursToSeconds(96);
    }

    [RequiresSkill(typeof(AdvancedCookingSkill), 3)]
    public partial class PapayaSmoothieRecipe :
        RecipeFamily
    {
        public PapayaSmoothieRecipe()
        {
            var product = new Recipe(
                "PapayaSmoothie",
                Localizer.DoStr("Papaya Smoothie"),
                new IngredientElement[]
                {
                    new IngredientElement(typeof(FreshMilkItem), 6, typeof(AdvancedCookingSkill), typeof(AdvancedCookingLavishResourcesTalent)), 
                    new IngredientElement(typeof(PapayaItem), 6, typeof(AdvancedCookingSkill), typeof(AdvancedCookingLavishResourcesTalent)), 
                    new IngredientElement(typeof(SugarItem), 4, typeof(AdvancedCookingSkill), typeof(AdvancedCookingLavishResourcesTalent)),  
                },
                new CraftingElement<PapayaSmoothieItem>(1)
                );

            this.Recipes = new List<Recipe> { product };
            this.LaborInCalories = CreateLaborInCaloriesValue(20, typeof(AdvancedCookingSkill));
            this.CraftMinutes = CreateCraftTimeValue(typeof(PapayaSmoothieRecipe), 6, typeof(AdvancedCookingSkill), typeof(AdvancedCookingFocusedSpeedTalent), typeof(AdvancedCookingParallelSpeedTalent));
            this.ModsPreInitialize();
            this.Initialize(Localizer.DoStr("Papaya Smoothie"), typeof(PapayaSmoothieRecipe));
            this.ModsPostInitialize();
            CraftingComponent.AddRecipe(typeof(KitchenObject), this);
        }

        /// <summary>Hook for mods to customize RecipeFamily before initialization. You can change recipes, xp, labor, time here.</summary>
        partial void ModsPreInitialize();
        /// <summary>Hook for mods to customize RecipeFamily after initialization, but before registration. You can change skill requirements here.</summary>
        partial void ModsPostInitialize();
    }
}
