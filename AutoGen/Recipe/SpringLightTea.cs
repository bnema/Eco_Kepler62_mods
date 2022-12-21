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
    [LocDisplayName("Spring Light Tea")]
    [MaxStackSize(250)]
    [Weight(500)]
    [Ecopedia("Food", "Baking", createAsSubPage: true)]
    public partial class SpringLightTeaItem : FoodItem
    {
        public override LocString DisplayDescription { get { return Localizer.DoStr("A drink inspired by an amazing lady and mother. One drink of this will leave you feeling warm and fuzzy!"); } }
        public override float Calories => 900;
        public override Nutrients Nutrition => new Nutrients() { Carbs = 5, Fat = 5, Protein = 8, Vitamins = 12 };
        protected override int BaseShelfLife => (int)TimeUtil.HoursToSeconds(72);
    }


    [RequiresSkill(typeof(MixologySkill), 5)]
    [ForceCreateView]
    public partial class SpringLightTeaRecipe : RecipeFamily
    {
        public SpringLightTeaRecipe()
        {
            var recipe = new Recipe();
            recipe.Init(
                "Spring Light Tea",  //noloc
                Localizer.DoStr("Spring Light Tea"),
                new List<IngredientElement>
                {
                    new IngredientElement(typeof(PumpkinJuiceItem), 1, typeof(MixologySkill), typeof(MixologyLavishResourcesTalent)),
                    new IngredientElement(typeof(CornMilkItem), 2, typeof(MixologySkill), typeof(MixologyLavishResourcesTalent)),
                    new IngredientElement(typeof(TeabagItem), 1, typeof(MixologySkill), typeof(MixologyLavishResourcesTalent)),
                },
                new List<CraftingElement>
                {
                    new CraftingElement<SpringLightTeaItem>(1)
                });
            this.Recipes = new List<Recipe> { recipe };
            this.ExperienceOnCraft = 1;
            this.LaborInCalories = CreateLaborInCaloriesValue(120, typeof(MixologySkill));
            this.CraftMinutes = CreateCraftTimeValue(typeof(SpringLightTeaRecipe), 1.5f, typeof(MixologySkill), typeof(MixologyFocusedSpeedTalent), typeof(MixologyParallelSpeedTalent));
            this.ModsPreInitialize();
            this.Initialize(Localizer.DoStr("Spring Light Tea"), typeof(SpringLightTeaRecipe));
            this.ModsPostInitialize();
            CraftingComponent.AddRecipe(typeof(MixologyTableObject), this);
        }

        /// <summary>Hook for mods to customize RecipeFamily before initialization. You can change recipes, xp, labor, time here.</summary>
        partial void ModsPreInitialize();
        /// <summary>Hook for mods to customize RecipeFamily after initialization, but before registration. You can change skill requirements here.</summary>
        partial void ModsPostInitialize();
    }
}