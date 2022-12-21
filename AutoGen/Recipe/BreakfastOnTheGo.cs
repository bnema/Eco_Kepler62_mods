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
    [LocDisplayName("Breakfast On The Go")]
    [MaxStackSize(250)]
    [Weight(500)]
    [Ecopedia("Food", "Cooking", createAsSubPage: true)]
    public partial class BreakfastOnTheGoItem : FoodItem
    {
        public override LocString DisplayDescription { get { return Localizer.DoStr("Looking to start your day quickly? grab a breakfast on the go to fill up your calories."); } }
        public override float Calories => 1100;
        public override Nutrients Nutrition => new Nutrients() { Carbs = 10, Fat = 5, Protein = 15, Vitamins = 9 };
        protected override int BaseShelfLife => (int)TimeUtil.HoursToSeconds(96);
    }


    [RequiresSkill(typeof(MixologySkill), 3)]
    [ForceCreateView]
    public partial class BreakfastOnTheGoRecipe : RecipeFamily
    {
        public BreakfastOnTheGoRecipe()
        {
            var recipe = new Recipe();
            recipe.Init(
                "Breakfast On The Go",  //noloc
                Localizer.DoStr("Breakfast On The Go"),
                new List<IngredientElement>
                {
                    new IngredientElement(typeof(WheatItem), 3, typeof(MixologySkill), typeof(MixologyLavishResourcesTalent)),
                    new IngredientElement(typeof(TomatoJuiceItem), 1, typeof(MixologySkill), typeof(MixologyLavishResourcesTalent)),
                    new IngredientElement(typeof(PumpkinPasteItem), 2, typeof(MixologySkill), typeof(MixologyLavishResourcesTalent)),
                },
                new List<CraftingElement>
                {
                    new CraftingElement<BreakfastOnTheGoItem>(1)
                });
            this.Recipes = new List<Recipe> { recipe };
            this.ExperienceOnCraft = 1;
            this.LaborInCalories = CreateLaborInCaloriesValue(150, typeof(MixologySkill));
            this.CraftMinutes = CreateCraftTimeValue(typeof(BreakfastOnTheGoRecipe), 1, typeof(MixologySkill), typeof(MixologyFocusedSpeedTalent), typeof(MixologyParallelSpeedTalent));
            this.ModsPreInitialize();
            this.Initialize(Localizer.DoStr("Breakfast On The Go"), typeof(BreakfastOnTheGoRecipe));
            this.ModsPostInitialize();
            CraftingComponent.AddRecipe(typeof(MixologyTableObject), this);
        }

        /// <summary>Hook for mods to customize RecipeFamily before initialization. You can change recipes, xp, labor, time here.</summary>
        partial void ModsPreInitialize();
        /// <summary>Hook for mods to customize RecipeFamily after initialization, but before registration. You can change skill requirements here.</summary>
        partial void ModsPostInitialize();
    }
}