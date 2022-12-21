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
    [LocDisplayName("Coffee")]
    [MaxStackSize(250)]
    [Weight(300)]
    [Ecopedia("Food", "Cooking", createAsSubPage: true)]
    public partial class CoffeeItem : FoodItem
    {
        public override LocString DisplayDescription { get { return Localizer.DoStr("One of the most common drinks to wake up too!"); } }
        public override float Calories => 800;
        public override Nutrients Nutrition => new Nutrients() { Carbs = 5, Fat = 5, Protein = 2, Vitamins = 10 };
        protected override int BaseShelfLife => (int)TimeUtil.HoursToSeconds(72);
    }


    [RequiresSkill(typeof(MixologySkill), 3)]
    [ForceCreateView]
    public partial class CoffeeRecipe : RecipeFamily
    {
        public CoffeeRecipe()
        {
            var recipe = new Recipe();
            recipe.Init(
                "Coffee",  //noloc
                Localizer.DoStr("Coffee"),
                new List<IngredientElement>
                {
                    new IngredientElement(typeof(GranulatedCoffeeItem), 1, typeof(MixologySkill), typeof(MixologyLavishResourcesTalent)),
                    new IngredientElement(typeof(CornMilkItem), 2, typeof(MixologySkill), typeof(MixologyLavishResourcesTalent)),
                    new IngredientElement(typeof(TreeSapJuiceItem), 2, typeof(MixologySkill), typeof(MixologyLavishResourcesTalent)),
                },
                new List<CraftingElement>
                {
                    new CraftingElement<CoffeeItem>(1)
                });
            this.Recipes = new List<Recipe> { recipe };
            this.ExperienceOnCraft = 1;
            this.LaborInCalories = CreateLaborInCaloriesValue(80, typeof(MixologySkill));
            this.CraftMinutes = CreateCraftTimeValue(typeof(CoffeeRecipe), 2, typeof(MixologySkill), typeof(MixologyFocusedSpeedTalent), typeof(MixologyParallelSpeedTalent));
            this.ModsPreInitialize();
            this.Initialize(Localizer.DoStr("Coffee"), typeof(CoffeeRecipe));
            this.ModsPostInitialize();
            CraftingComponent.AddRecipe(typeof(MixologyTableObject), this);
        }

        /// <summary>Hook for mods to customize RecipeFamily before initialization. You can change recipes, xp, labor, time here.</summary>
        partial void ModsPreInitialize();
        /// <summary>Hook for mods to customize RecipeFamily after initialization, but before registration. You can change skill requirements here.</summary>
        partial void ModsPostInitialize();
    }
}