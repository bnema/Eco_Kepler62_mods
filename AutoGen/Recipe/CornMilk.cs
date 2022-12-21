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
    [LocDisplayName("Corn Milk")]
    [MaxStackSize(250)]
    [Weight(200)]
    [Ecopedia("Food", "Cooking", createAsSubPage: true)]
    public partial class CornMilkItem : FoodItem
    {
        public override LocString DisplayDescription { get { return Localizer.DoStr("A creamy sweet corn drink or additive for other delicious recipes!"); } }
        public override float Calories => 350;
        public override Nutrients Nutrition => new Nutrients() { Carbs = 3, Fat = 0, Protein = 6, Vitamins = 10 };
        protected override int BaseShelfLife => (int)TimeUtil.HoursToSeconds(72);
    }


    [RequiresSkill(typeof(MixologySkill), 1)]
    [ForceCreateView]
    public partial class CornMilkRecipe : RecipeFamily
    {
        public CornMilkRecipe()
        {
            var recipe = new Recipe();
            recipe.Init(
                "Corn Milk",  //noloc
                Localizer.DoStr("Corn Milk"),
                new List<IngredientElement>
                {
                    new IngredientElement(typeof(CornItem), 5, typeof(MixologySkill), typeof(MixologyLavishResourcesTalent)),
                },
                new List<CraftingElement>
                {
                    new CraftingElement<CornMilkItem>(1)
                });
            this.Recipes = new List<Recipe> { recipe };
            this.ExperienceOnCraft = 1;
            this.LaborInCalories = CreateLaborInCaloriesValue(80, typeof(MixologySkill));
            this.CraftMinutes = CreateCraftTimeValue(typeof(CornMilkRecipe), 1, typeof(MixologySkill), typeof(MixologyFocusedSpeedTalent), typeof(MixologyParallelSpeedTalent));
            this.ModsPreInitialize();
            this.Initialize(Localizer.DoStr("Corn Milk"), typeof(CornMilkRecipe));
            this.ModsPostInitialize();
            CraftingComponent.AddRecipe(typeof(BlenderTableObject), this);
        }

        /// <summary>Hook for mods to customize RecipeFamily before initialization. You can change recipes, xp, labor, time here.</summary>
        partial void ModsPreInitialize();
        /// <summary>Hook for mods to customize RecipeFamily after initialization, but before registration. You can change skill requirements here.</summary>
        partial void ModsPostInitialize();
    }
}