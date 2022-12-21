using System.Collections.Generic;
using Eco.Gameplay.Components;
using Eco.Gameplay.Items;
using Eco.Shared.Localization;

namespace Eco.Mods.TechTree
{
    public class WashWoodShopCartRecipe : RecipeFamily
    {
        public WashWoodShopCartRecipe()
        {
            this.Recipes = new List<Recipe>
            {
                new Recipe(
                    "Wash Wood Shop Cart Colored",
                    Localizer.DoStr("Wash Wood Shop Cart Colored"),
                    new IngredientElement[]
                    {
                        new IngredientElement("ColoredWoodShopCart", 1, true),
                        new IngredientElement(typeof(PlantFibersItem), 30, typeof(BasicEngineeringSkill), typeof(BasicEngineeringLavishResourcesTalent)),
                    },
                    new CraftingElement<WoodCartItem>()
                )
            };
            this.ExperienceOnCraft = 0.1f;
            this.LaborInCalories = CreateLaborInCaloriesValue(200, typeof(BasicEngineeringSkill));
            this.CraftMinutes = CreateCraftTimeValue(typeof(WashWoodShopCartRecipe), 2, typeof(BasicEngineeringSkill));

            this.Initialize(Localizer.DoStr("Wash Wood Shop Cart Colored"), typeof(WashWoodShopCartRecipe));
            CraftingComponent.AddRecipe(typeof(PrimitivePaintingTableObject), this);
        }
    }
}
