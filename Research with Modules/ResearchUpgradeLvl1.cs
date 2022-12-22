namespace Eco.Mods.TechTree
{
    using System.Collections.Generic;
    using Eco.Gameplay.Components;
    using Eco.Gameplay.Items;
    using Eco.Gameplay.Modules;
    using Eco.Gameplay.Skills;
    using Eco.Shared.Localization;
    using Eco.Shared.Serialization;
    using Eco.Core.Items;

    [RequiresSkill(typeof(PaperMillingSkill), 2)]
    [Ecopedia("Upgrade Modules", "Research Upgrades", subPageName: "ResearchUpgradeLvl1 Item")]
    public partial class ResearchUpgradeLvl1Recipe : RecipeFamily
    {
        public ResearchUpgradeLvl1Recipe()
        {
            var recipe = new Recipe();
            recipe.Init(
                name: "ResearchUpgradeLvl1",
                displayName: Localizer.DoStr("Research Upgrade 1"),
                ingredients: new List<IngredientElement>
                {
                    new IngredientElement(typeof(PaperItem), 30, true),
                    new IngredientElement(typeof(CottonThreadItem), 10, true),
                    new IngredientElement("HewnLog", 10, true),
                    new IngredientElement("NaturalFiber", 50, true),
                },
                items: new List<CraftingElement> { new CraftingElement<ResearchUpgradeLvl1Item>() }
            );

            this.Recipes = new List<Recipe> { recipe };
            this.ExperienceOnCraft = 5;
            this.LaborInCalories = CreateLaborInCaloriesValue(300, typeof(PaperMillingSkill));
            this.CraftMinutes = CreateCraftTimeValue(
                beneficiary: typeof(ResearchUpgradeLvl1Recipe),
                start: 2,
                skillType: typeof(PaperMillingSkill)
            );

            this.Initialize(
                displayText: Localizer.DoStr("Research Upgrade 1"),
                recipeType: typeof(ResearchUpgradeLvl1Recipe)
            );

            CraftingComponent.AddRecipe(tableType: typeof(CarpentryTableObject), recipe: this);
        }
    }

    [Serialized]
    [LocDisplayName("Research Upgrade 1")]
    [Weight(1)]
    [Ecopedia("Upgrade Modules", "Research Upgrades", createAsSubPage: true)]
    [Tag("Upgrade", 1)]
    [Tag("ResearchUpgrade", 1)]
    public partial class ResearchUpgradeLvl1Item : EfficiencyModule
    {
        public override LocString DisplayNamePlural => Localizer.DoStr("Research Upgrade 1");

        public override LocString DisplayDescription =>
            Localizer.DoStr("Research Upgrade that increases crafting efficiency.");

        public ResearchUpgradeLvl1Item() : base(ModuleTypes.ResourceEfficiency | ModuleTypes.SpeedEfficiency, 0.9f)
        {
        }
    }
}