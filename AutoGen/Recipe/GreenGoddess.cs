
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
    [LocDisplayName("Green Goddess")]
    [MaxStackSize(250)]
    [Weight(300)]
    [Ecopedia("Food", "Cooking", createAsSubPage: true)]
    public partial class GreenGoddessItem : FoodItem
    {
        public override LocString DisplayDescription { get { return Localizer.DoStr("This drink was truly made by the gods. We promise."); } }
        public override float Calories => 1100;
        public override Nutrients Nutrition => new Nutrients() { Carbs = 8, Fat = 8, Protein = 8, Vitamins = 12 };
        protected override int BaseShelfLife => (int)TimeUtil.HoursToSeconds(72);
    }


    [RequiresSkill(typeof(MixologySkill), 3)]
    [ForceCreateView]
    public partial class GreenGoddessRecipe : RecipeFamily
    {
        public GreenGoddessRecipe()
        {
            var recipe = new Recipe();
            recipe.Init(
                "Green Goddess",  //noloc
                Localizer.DoStr("Green Goddess"),
                new List<IngredientElement>
                {
                    new IngredientElement(typeof(PricklyPearPasteItem), 2, typeof(MixologySkill), typeof(MixologyLavishResourcesTalent)),
                    new IngredientElement(typeof(BeansItem), 5, typeof(MixologySkill), typeof(MixologyLavishResourcesTalent)),
                    new IngredientElement(typeof(CornMilkItem), 2, typeof(MixologySkill), typeof(MixologyLavishResourcesTalent)),
                },
                new List<CraftingElement>
                {
                    new CraftingElement<GreenGoddessItem>(1)
                });
            this.Recipes = new List<Recipe> { recipe };
            this.ExperienceOnCraft = 1;
            this.LaborInCalories = CreateLaborInCaloriesValue(150, typeof(MixologySkill));
            this.CraftMinutes = CreateCraftTimeValue(typeof(GreenGoddessRecipe), 4, typeof(MixologySkill), typeof(MixologyFocusedSpeedTalent), typeof(MixologyParallelSpeedTalent));
            this.ModsPreInitialize();
            this.Initialize(Localizer.DoStr("Green Goddess"), typeof(GreenGoddessRecipe));
            this.ModsPostInitialize();
            CraftingComponent.AddRecipe(typeof(MixologyTableObject), this);
        }

        /// <summary>Hook for mods to customize RecipeFamily before initialization. You can change recipes, xp, labor, time here.</summary>
        partial void ModsPreInitialize();
        /// <summary>Hook for mods to customize RecipeFamily after initialization, but before registration. You can change skill requirements here.</summary>
        partial void ModsPostInitialize();
    }
}