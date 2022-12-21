
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
    [LocDisplayName("Papaya Paradise")]
    [MaxStackSize(250)]
    [Weight(300)]
    [Ecopedia("Food", "Cooking", createAsSubPage: true)]
    public partial class PapayaParadiseItem : FoodItem
    {
        public override LocString DisplayDescription { get { return Localizer.DoStr("Been spending most my life, living in Papaya Paradise."); } }
        public override float Calories => 1100;
        public override Nutrients Nutrition => new Nutrients() { Carbs = 4, Fat = 6, Protein = 13, Vitamins = 11 };
        protected override int BaseShelfLife => (int)TimeUtil.HoursToSeconds(72);
    }


    [RequiresSkill(typeof(MixologySkill), 3)]
    [ForceCreateView]
    public partial class PapayaParadiseRecipe : RecipeFamily
    {
        public PapayaParadiseRecipe()
        {
            var recipe = new Recipe();
            recipe.Init(
                "Papaya Paradise",  //noloc
                Localizer.DoStr("Papaya Paradise"),
                new List<IngredientElement>
                {
                    new IngredientElement(typeof(PapayaPasteItem), 2, typeof(MixologySkill), typeof(MixologyLavishResourcesTalent)),
                    new IngredientElement(typeof(CoffeePowderItem), 1, typeof(MixologySkill), typeof(MixologyLavishResourcesTalent)),
                    new IngredientElement(typeof(CornMilkItem), 2, typeof(MixologySkill), typeof(MixologyLavishResourcesTalent)),
                },
                new List<CraftingElement>
                {
                    new CraftingElement<PapayaParadiseItem>(1)
                });
            this.Recipes = new List<Recipe> { recipe };
            this.ExperienceOnCraft = 1;
            this.LaborInCalories = CreateLaborInCaloriesValue(150, typeof(MixologySkill));
            this.CraftMinutes = CreateCraftTimeValue(typeof(PapayaParadiseRecipe), 4, typeof(MixologySkill), typeof(MixologyFocusedSpeedTalent), typeof(MixologyParallelSpeedTalent));
            this.ModsPreInitialize();
            this.Initialize(Localizer.DoStr("Papaya Paradise"), typeof(PapayaParadiseRecipe));
            this.ModsPostInitialize();
            CraftingComponent.AddRecipe(typeof(MixologyTableObject), this);
        }

        /// <summary>Hook for mods to customize RecipeFamily before initialization. You can change recipes, xp, labor, time here.</summary>
        partial void ModsPreInitialize();
        /// <summary>Hook for mods to customize RecipeFamily after initialization, but before registration. You can change skill requirements here.</summary>
        partial void ModsPostInitialize();
    }
}