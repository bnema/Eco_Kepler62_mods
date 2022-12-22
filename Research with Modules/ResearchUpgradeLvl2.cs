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

    [RequiresSkill(typeof(PaperMillingSkill), 4)]
    [Ecopedia("Upgrade Modules", "Research Upgrades", subPageName: "ResearchUpgradeLvl2 Item")]
    public partial class ResearchUpgradeLvl2Recipe : RecipeFamily
    {
        public ResearchUpgradeLvl2Recipe()
        {
            var recipe = new Recipe();
            recipe.Init(
                name: "ResearchUpgradeLvl2",
                displayName: Localizer.DoStr("Research Upgrade 2"),
                ingredients: new List<IngredientElement>
                {
                    new IngredientElement(typeof(SlagItem), 20, true),
                    new IngredientElement("WoodBoard", 20, true),
                    new IngredientElement(typeof(RawBaconItem), 20, true),
                    new IngredientElement(typeof(ResearchUpgradeLvl1Item), 1, true),
                },
                items: new List<CraftingElement> { new CraftingElement<ResearchUpgradeLvl2Item>() }
            );
            this.Recipes = new List<Recipe> { recipe };
            this.ExperienceOnCraft = 10;
            this.LaborInCalories = CreateLaborInCaloriesValue(400, typeof(PaperMillingSkill));


            this.CraftMinutes = CreateCraftTimeValue(
                beneficiary: typeof(ResearchUpgradeLvl2Recipe),
                start: 4,
                skillType: typeof(PaperMillingSkill)
            );

            this.Initialize(
                displayText: Localizer.DoStr("Research Upgrade 2"),
                recipeType: typeof(ResearchUpgradeLvl2Recipe)
            );

            CraftingComponent.AddRecipe(tableType: typeof(CarpentryTableObject), recipe: this);
        }
    }

    [Serialized]
    [LocDisplayName("Research Upgrade 2")]
    [Weight(1)]
    [Ecopedia("Upgrade Modules", "Research Upgrades", createAsSubPage: true)]
    [Tag("Upgrade", 1)]
    [Tag("ResearchUpgrade", 1)]
    public partial class ResearchUpgradeLvl2Item : EfficiencyModule
    {
        public override LocString DisplayNamePlural => Localizer.DoStr("Research Upgrade 2");

        public override LocString DisplayDescription =>
            Localizer.DoStr("Research Upgrade that increases crafting efficiency.");

        public ResearchUpgradeLvl2Item()
            : base(ModuleTypes.ResourceEfficiency | ModuleTypes.SpeedEfficiency, 0.8f)
        {
        }
    }
}