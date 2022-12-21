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
    [LocDisplayName("Berry Burst")]
    [Weight(500)]
    [Ecopedia("Food", "Cooking", createAsSubPage: true)]
    public partial class BerryBurstItem : FoodItem
    {
        public override LocString DisplayDescription { get { return Localizer.DoStr("Berry good, Berry nice!"); } }
        public override float Calories => 1100;
        public override Nutrients Nutrition => new Nutrients() { Carbs = 2, Fat = 4, Protein = 8, Vitamins = 10 };
        protected override int BaseShelfLife => (int)TimeUtil.HoursToSeconds(72);
    }


    [RequiresSkill(typeof(MixologySkill), 3)]
    [ForceCreateView]
    public partial class BerryBurstRecipe : RecipeFamily
    {
        public BerryBurstRecipe()
        {
            var recipe = new Recipe();
            recipe.Init(
                "Berry Burst",  //noloc
                Localizer.DoStr("Berry Burst"),
                new List<IngredientElement>
                {
                    new IngredientElement(typeof(PineapplePasteItem), 2, typeof(MixologySkill), typeof(MixologyLavishResourcesTalent)),
                    new IngredientElement(typeof(HuckleberryPasteItem), 2, typeof(MixologySkill), typeof(MixologyLavishResourcesTalent)),
                    new IngredientElement(typeof(CornMilkItem), 2, typeof(MixologySkill), typeof(MixologyLavishResourcesTalent)),
                },
                new List<CraftingElement>
                {
                    new CraftingElement<BerryBurstItem>(1)
                });
            this.Recipes = new List<Recipe> { recipe };
            this.ExperienceOnCraft = 1;
            this.LaborInCalories = CreateLaborInCaloriesValue(150, typeof(MixologySkill));
            this.CraftMinutes = CreateCraftTimeValue(typeof(BerryBurstRecipe), 1, typeof(MixologySkill), typeof(MixologyFocusedSpeedTalent), typeof(MixologyParallelSpeedTalent));
            this.ModsPreInitialize();
            this.Initialize(Localizer.DoStr("Berry Burst"), typeof(BerryBurstRecipe));
            this.ModsPostInitialize();
            CraftingComponent.AddRecipe(typeof(MixologyTableObject), this);
        }

        /// <summary>Hook for mods to customize RecipeFamily before initialization. You can change recipes, xp, labor, time here.</summary>
        partial void ModsPreInitialize();
        /// <summary>Hook for mods to customize RecipeFamily after initialization, but before registration. You can change skill requirements here.</summary>
        partial void ModsPostInitialize();
    }
}