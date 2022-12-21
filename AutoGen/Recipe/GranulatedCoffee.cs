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
    [LocDisplayName("Granulated Coffee")]
    [MaxStackSize(250)]
    [Weight(100)]
    [Ecopedia("Food", "Cooking", createAsSubPage: true)]
    public partial class GranulatedCoffeeItem : FoodItem
    {
        public override LocString DisplayDescription { get { return Localizer.DoStr("Granulated Coffee is used to make those delicious caffeinated drinks you all love!"); } }
        public override float Calories => 0;
        public override Nutrients Nutrition => new Nutrients() { Carbs = 0, Fat = 0, Protein = 0, Vitamins = 0 };
        protected override int BaseShelfLife => (int)TimeUtil.HoursToSeconds(72);
    }


    [RequiresSkill(typeof(MixologySkill), 5)]
    [ForceCreateView]
    public partial class GranulatedCoffeeRecipe : RecipeFamily
    {
        public GranulatedCoffeeRecipe()
        {
            var recipe = new Recipe();
            recipe.Init(
                "Granulated Coffee",  //noloc
                Localizer.DoStr("Granulated Coffee"),
                new List<IngredientElement>
                {
                    new IngredientElement(typeof(AcornItem), 10, typeof(MixologySkill), typeof(MixologyLavishResourcesTalent)),
                },
                new List<CraftingElement>
                {
                    new CraftingElement<GranulatedCoffeeItem>(2)
                });
            this.Recipes = new List<Recipe> { recipe };
            this.ExperienceOnCraft = 1;
            this.LaborInCalories = CreateLaborInCaloriesValue(100, typeof(MixologySkill));
            this.CraftMinutes = CreateCraftTimeValue(typeof(GranulatedCoffeeRecipe), 1.5f, typeof(MixologySkill), typeof(MixologyFocusedSpeedTalent), typeof(MixologyParallelSpeedTalent));
            this.ModsPreInitialize();
            this.Initialize(Localizer.DoStr("Granulated Coffee"), typeof(GranulatedCoffeeRecipe));
            this.ModsPostInitialize();
            CraftingComponent.AddRecipe(typeof(BlenderTableObject), this);
        }

        /// <summary>Hook for mods to customize RecipeFamily before initialization. You can change recipes, xp, labor, time here.</summary>
        partial void ModsPreInitialize();
        /// <summary>Hook for mods to customize RecipeFamily after initialization, but before registration. You can change skill requirements here.</summary>
        partial void ModsPostInitialize();
    }
}