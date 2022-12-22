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

    [RequiresSkill(typeof(PaperMillingSkill), 7)]
    [Ecopedia("Upgrade Modules", "Research Upgrades", subPageName: "TerminusUpgrade Item")]
    public partial class TerminusUpgradeRecipe : RecipeFamily
    {
        public TerminusUpgradeRecipe()
        {
            var recipe = new Recipe();
            recipe.Init(
                name: "TerminusUpgrade",
                displayName: Localizer.DoStr("Terminus Upgrade"),
                ingredients: new List<IngredientElement>
                {
                    new IngredientElement(typeof(ReinforcedConcreteItem), 10, true),
                    new IngredientElement(typeof(CorrugatedSteelItem), 10, true),
                    new IngredientElement(typeof(SteelBarItem), 10, true),
                    new IngredientElement(typeof(ResearchUpgradeLvl4Item), 1, true),
                },
                items: new List<CraftingElement> { new CraftingElement<TerminusUpgradeItem>() }
            );
            this.Recipes = new List<Recipe> { recipe };
            this.ExperienceOnCraft = 20;
            this.LaborInCalories = CreateLaborInCaloriesValue(1000, typeof(PaperMillingSkill));


            this.CraftMinutes = CreateCraftTimeValue(
                beneficiary: typeof(TerminusUpgradeRecipe),
                start: 7,
                skillType: typeof(PaperMillingSkill)
            );

            this.Initialize(
                displayText: Localizer.DoStr("Terminus Upgrade"),
                recipeType: typeof(TerminusUpgradeRecipe)
            );

            CraftingComponent.AddRecipe(tableType: typeof(CarpentryTableObject), recipe: this);
        }
    }

    [Serialized]
    [LocDisplayName("Terminus Upgrade")]
    [Weight(1)]
    [Ecopedia("Upgrade Modules", "Research Upgrades", createAsSubPage: true)]
    [Tag("Upgrade", 1)]
    [Tag("ResearchUpgrade", 1)]
    public partial class TerminusUpgradeItem : EfficiencyModule
    {
        public override LocString DisplayNamePlural => Localizer.DoStr("Terminus Upgrade");

        public override LocString DisplayDescription =>
            Localizer.DoStr("Research Upgrade that increases crafting efficiency.");

        public TerminusUpgradeItem()
            : base(ModuleTypes.ResourceEfficiency | ModuleTypes.SpeedEfficiency, 0.5f)
        {
        }
    }
}