
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
    [LocDisplayName("Teabag")]
    [MaxStackSize(250)]
    [Weight(100)]
    [Ecopedia("Food", "Cooking", createAsSubPage: true)]
    public partial class TeabagItem : FoodItem
    {
        
        public override LocString DisplayDescription { get { return Localizer.DoStr("Teabag straight from the heart of yorkshire."); } }

        public override float Calories => 0;
        public override Nutrients Nutrition => new Nutrients() { Carbs = 0, Fat = 0, Protein = 0, Vitamins = 0 };
        protected override int BaseShelfLife => (int)TimeUtil.HoursToSeconds(72);
    }


    [RequiresSkill(typeof(MixologySkill), 5)]
    [ForceCreateView]
    public partial class TeabagRecipe : RecipeFamily
    {
        public TeabagRecipe()
        {
            var recipe = new Recipe();
            recipe.Init(
                "Teabag",  //noloc
                Localizer.DoStr("Teabag"),
                new List<IngredientElement>
                {
                    new IngredientElement(typeof(CamasBulbItem), 4, typeof(MixologySkill), typeof(MixologyLavishResourcesTalent)),
                    new IngredientElement(typeof(WheatItem), 6, typeof(MixologySkill), typeof(MixologyLavishResourcesTalent)),
                },
                new List<CraftingElement>
                {
                    new CraftingElement<TeabagItem>(2)
                });
            this.Recipes = new List<Recipe> { recipe };
            this.ExperienceOnCraft = 1;
            this.LaborInCalories = CreateLaborInCaloriesValue(125, typeof(MixologySkill));
            this.CraftMinutes = CreateCraftTimeValue(typeof(TeabagRecipe), 1, typeof(MixologySkill), typeof(MixologyFocusedSpeedTalent), typeof(MixologyParallelSpeedTalent));
            this.ModsPreInitialize();
            this.Initialize(Localizer.DoStr("Teabag"), typeof(TeabagRecipe));
            this.ModsPostInitialize();
            CraftingComponent.AddRecipe(typeof(BlenderTableObject), this);
        }

        /// <summary>Hook for mods to customize RecipeFamily before initialization. You can change recipes, xp, labor, time here.</summary>
        partial void ModsPreInitialize();
        /// <summary>Hook for mods to customize RecipeFamily after initialization, but before registration. You can change skill requirements here.</summary>
        partial void ModsPostInitialize();
    }
}