
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
    [LocDisplayName("Pineapple Juice")]
    [MaxStackSize(250)]
    [Weight(200)]
    [Ecopedia("Food", "Cooking", createAsSubPage: true)]
    public partial class PineappleJuiceItem : FoodItem
    {
        public override LocString DisplayDescription { get { return Localizer.DoStr("One of the most popular fruit juices around and it doesn't get better than being made by this Mixologist."); } }
        public override float Calories => 400;
        public override Nutrients Nutrition => new Nutrients() { Carbs = 6, Fat = 3, Protein = 4, Vitamins = 12 };
        protected override int BaseShelfLife => (int)TimeUtil.HoursToSeconds(72);
    }


    [RequiresSkill(typeof(MixologySkill), 1)]
    [ForceCreateView]
    public partial class PineappleJuiceRecipe : RecipeFamily
    {
        public PineappleJuiceRecipe()
        {
            var recipe = new Recipe();
            recipe.Init(
                "Pineapple Juice",  //noloc
                Localizer.DoStr("Pineapple Juice"),
                new List<IngredientElement>
                {
                    new IngredientElement(typeof(PineappleItem), 3, typeof(MixologySkill), typeof(MixologyLavishResourcesTalent)),
                },
                new List<CraftingElement>
                {
                    new CraftingElement<PineappleJuiceItem>(1)
                });
            this.Recipes = new List<Recipe> { recipe };
            this.ExperienceOnCraft = 1;
            this.LaborInCalories = CreateLaborInCaloriesValue(80, typeof(MixologySkill));
            this.CraftMinutes = CreateCraftTimeValue(typeof(PineappleJuiceRecipe), 1, typeof(MixologySkill), typeof(MixologyFocusedSpeedTalent), typeof(MixologyParallelSpeedTalent));
            this.ModsPreInitialize();
            this.Initialize(Localizer.DoStr("Pineapple Juice"), typeof(PineappleJuiceRecipe));
            this.ModsPostInitialize();
            CraftingComponent.AddRecipe(typeof(BlenderTableObject), this);
        }

        /// <summary>Hook for mods to customize RecipeFamily before initialization. You can change recipes, xp, labor, time here.</summary>
        partial void ModsPreInitialize();
        /// <summary>Hook for mods to customize RecipeFamily after initialization, but before registration. You can change skill requirements here.</summary>
        partial void ModsPostInitialize();
    }
}