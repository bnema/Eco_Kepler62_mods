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

    [RequiresSkill(typeof(PaperMillingSkill), 6)]
    [Ecopedia("Upgrade Modules", "Research Upgrades", subPageName: "ResearchUpgradeLvl4 Item")]
    public partial class ResearchUpgradeLvl4Recipe : RecipeFamily
    {
        public ResearchUpgradeLvl4Recipe()
        {
            var recipe = new Recipe();
            recipe.Init(
                name: "ResearchUpgradeLvl4",
                displayName: Localizer.DoStr("Research Upgrade 4"),
                ingredients: new List<IngredientElement>
                {
                    new IngredientElement(typeof(CharcoalItem), 10, true),
                    new IngredientElement(typeof(GearboxItem), 10, true),
                    new IngredientElement(typeof(ClothItem), 100, true),
                    new IngredientElement(typeof(ResearchUpgradeLvl3Item), 1, true),
                },
                items: new List<CraftingElement> { new CraftingElement<ResearchUpgradeLvl4Item>() }
            );
            this.Recipes = new List<Recipe> { recipe };
            this.ExperienceOnCraft = 15;
            this.LaborInCalories = CreateLaborInCaloriesValue(400, typeof(PaperMillingSkill));


            this.CraftMinutes = CreateCraftTimeValue(
                beneficiary: typeof(ResearchUpgradeLvl4Recipe),
                start: 6,
                skillType: typeof(PaperMillingSkill)
            );

            this.Initialize(
                displayText: Localizer.DoStr("Research Upgrade 4"),
                recipeType: typeof(ResearchUpgradeLvl4Recipe)
            );

            CraftingComponent.AddRecipe(tableType: typeof(CarpentryTableObject), recipe: this);
        }
    }

    [Serialized]
    [LocDisplayName("Research Upgrade 4")]
    [Weight(1)]
    [Ecopedia("Upgrade Modules", "Research Upgrades", createAsSubPage: true)]
    [Tag("Upgrade", 1)]
    [Tag("ResearchUpgrade", 1)]
    public partial class ResearchUpgradeLvl4Item : EfficiencyModule
    {
        public override LocString DisplayNamePlural => Localizer.DoStr("Research Upgrade 4");

        public override LocString DisplayDescription =>
            Localizer.DoStr("Research Upgrade that increases crafting efficiency.");

        public ResearchUpgradeLvl4Item()
            : base(ModuleTypes.ResourceEfficiency | ModuleTypes.SpeedEfficiency, 0.6f)
        {
        }
    }
}