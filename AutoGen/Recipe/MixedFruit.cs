
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
    [LocDisplayName("Mixed Fruit")]
    [MaxStackSize(250)]
    [Weight(300)]
    [Ecopedia("Food", "Cooking", createAsSubPage: true)]
    public partial class MixedFruitItem : FoodItem
    {
        public override LocString DisplayDescription { get { return Localizer.DoStr("Who knew mixing fruits together could taste so good!"); } }
        public override float Calories => 1100;
        public override Nutrients Nutrition => new Nutrients() { Carbs = 0, Fat = 4, Protein = 12, Vitamins = 15 };
        protected override int BaseShelfLife => (int)TimeUtil.HoursToSeconds(72);
    }


    [RequiresSkill(typeof(MixologySkill), 3)]
    [ForceCreateView]
    public partial class MixedFruitRecipe : RecipeFamily
    {
        public MixedFruitRecipe()
        {
            var recipe = new Recipe();
            recipe.Init(
                "Mixed Fruit",  //noloc
                Localizer.DoStr("Mixed Fruit"),
                new List<IngredientElement>
                {
                    new IngredientElement(typeof(PumpkinPasteItem), 2, typeof(MixologySkill), typeof(MixologyLavishResourcesTalent)),
                    new IngredientElement(typeof(GiantCactusFruitPasteItem), 2, typeof(MixologySkill), typeof(MixologyLavishResourcesTalent)),
                    new IngredientElement(typeof(TreeSapJuiceItem), 2, typeof(MixologySkill), typeof(MixologyLavishResourcesTalent)),
                },
                new List<CraftingElement>
                {
                    new CraftingElement<MixedFruitItem>(1)
                });
            this.Recipes = new List<Recipe> { recipe };
            this.ExperienceOnCraft = 1;
            this.LaborInCalories = CreateLaborInCaloriesValue(150, typeof(MixologySkill));
            this.CraftMinutes = CreateCraftTimeValue(typeof(MixedFruitRecipe), 3, typeof(MixologySkill), typeof(MixologyFocusedSpeedTalent), typeof(MixologyParallelSpeedTalent));
            this.ModsPreInitialize();
            this.Initialize(Localizer.DoStr("Mixed Fruit"), typeof(MixedFruitRecipe));
            this.ModsPostInitialize();
            CraftingComponent.AddRecipe(typeof(MixologyTableObject), this);
        }

        /// <summary>Hook for mods to customize RecipeFamily before initialization. You can change recipes, xp, labor, time here.</summary>
        partial void ModsPreInitialize();
        /// <summary>Hook for mods to customize RecipeFamily after initialization, but before registration. You can change skill requirements here.</summary>
        partial void ModsPostInitialize();
    }
}