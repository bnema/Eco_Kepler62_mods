
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
    [LocDisplayName("Tomato Juice")]
    [MaxStackSize(250)]
    [Weight(200)]
    [Ecopedia("Food", "Cooking", createAsSubPage: true)]
    public partial class TomatoJuiceItem : FoodItem
    {
        
        public override LocString DisplayDescription { get { return Localizer.DoStr("A delicious drink consisting of purely tomatoes."); } }
        public override float Calories => 450;
        public override Nutrients Nutrition => new Nutrients() { Carbs = 4, Fat = 2, Protein = 10, Vitamins = 12 };
        protected override int BaseShelfLife => (int)TimeUtil.HoursToSeconds(72);
    }


    [RequiresSkill(typeof(MixologySkill), 1)]
    [ForceCreateView]
    public partial class TomatoJuiceRecipe : RecipeFamily
    {
        public TomatoJuiceRecipe()
        {
            var recipe = new Recipe();
            recipe.Init(
                "Tomato Juice",  //noloc
                Localizer.DoStr("Tomato Juice"),
                new List<IngredientElement>
                {
                    new IngredientElement(typeof(TomatoItem), 12, typeof(MixologySkill), typeof(MixologyLavishResourcesTalent)),
                },
                new List<CraftingElement>
                {
                    new CraftingElement<TomatoJuiceItem>(1)
                });
            this.Recipes = new List<Recipe> { recipe };
            this.ExperienceOnCraft = 1;
            this.LaborInCalories = CreateLaborInCaloriesValue(80, typeof(MixologySkill));
            this.CraftMinutes = CreateCraftTimeValue(typeof(TomatoJuiceRecipe), 1, typeof(MixologySkill), typeof(MixologyFocusedSpeedTalent), typeof(MixologyParallelSpeedTalent));
            this.ModsPreInitialize();
            this.Initialize(Localizer.DoStr("Tomato Juice"), typeof(TomatoJuiceRecipe));
            this.ModsPostInitialize();
            CraftingComponent.AddRecipe(typeof(BlenderTableObject), this);
        }

        /// <summary>Hook for mods to customize RecipeFamily before initialization. You can change recipes, xp, labor, time here.</summary>
        partial void ModsPreInitialize();
        /// <summary>Hook for mods to customize RecipeFamily after initialization, but before registration. You can change skill requirements here.</summary>
        partial void ModsPostInitialize();
    }
}