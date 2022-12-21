Put any user custom code in this folder. It will be compiled together with other Mods source files.
You can use this directory for existing classes customization (with partial method implementations) or for new objects.

#### For example, you want to change the Computer Lab recipe.

1. Create a file ComputerLab.cs
2. Copy namespace, "using" part and partial class name from the original file
3. Place changes for the recipe and other parameters under the ModsPreInitialize()method

Or just copy the original file and delete everything except namespace, using and ModsPreInitialize().

Then you need to overwrite the original recipe. You have a bunch of ways to do that:

- Overwrite a recipe's ingredients

```csharp
namespace Eco.Mods.TechTree
{
    using Eco.Gameplay.Items;

    public partial class ComputerLabRecipe
    {
        partial void ModsPreInitialize()
        {
            var ingredients = this.Recipes[0].Ingredients;
            ingredients.Clear();
            ingredients.AddRange(
                new IngredientElement[]
                {
                new IngredientElement(typeof(FramedGlassItem), 7500, true), 
                new IngredientElement(typeof(DendrologyResearchPaperBasicItem), 3000, true),
                new IngredientElement(typeof(ModernUpgradeLvl4Item), 250, true)
                });
            this.LaborInCalories = CreateLaborInCaloriesValue(50000, typeof(ElectronicsSkill));
            this.CraftMinutes = CreateCraftTimeValue(1440);
        }
    }
}
```

-  Make a new recipe (do not forget to add it to the recipes list)

```csharp
namespace Eco.Mods.TechTree
{
    using System.Collections.Generic;
    using Eco.Gameplay.Items; 
    using Eco.Shared.Localization;	

    public partial class ComputerLabRecipe
    {
        partial void ModsPreInitialize()
        {
            var product = new Recipe(
                "ComputerLab",
                Localizer.DoStr("Computer Lab"),
                new IngredientElement[]
                {
                 new IngredientElement(typeof(FramedGlassItem), 7500, true),
                 new IngredientElement(typeof(DendrologyResearchPaperBasicItem), 3000, true),
                 new IngredientElement(typeof(ModernUpgradeLvl4Item), 250, true),
                },
                new CraftingElement<ComputerLabItem>()
             );
              this.Recipes = new List<Recipe> { product };
              this.LaborInCalories = CreateLaborInCaloriesValue(50000, typeof(ElectronicsSkill));
              this.CraftMinutes = CreateCraftTimeValue(1440);
        }
    }
}
```

- Create and add a recipe to the list at the same time

```csharp
namespace Eco.Mods.TechTree
{
    using System.Collections.Generic;
    using Eco.Gameplay.Items; 
    using Eco.Shared.Localization;	

    public partial class ComputerLabRecipe
    {
        partial void ModsPreInitialize()
        {
            this.Recipes = new List<Recipe>
            {
                new Recipe(
                    "ComputerLab",
                    Localizer.DoStr("ComputerLab"),
                    new IngredientElement[]
                    {
                        new IngredientElement(typeof(FramedGlassItem), 7500, true),
                        new IngredientElement(typeof(DendrologyResearchPaperBasicItem), 3000, true),
                        new IngredientElement(typeof(ModernUpgradeLvl4Item), 250, true),
                    },
                    new CraftingElement<ComputerLabItem>()
                )
            };
            this.LaborInCalories = CreateLaborInCaloriesValue(50000, typeof(ElectronicsSkill));
            this.CraftMinutes = CreateCraftTimeValue(1440);
        }
    }
}
```

If you need to completely override definition from `__core__` then you need to create file with same path and add suffix `.override` to it's name (before .cs). 
In example for core file:
	`__core__\AutoGen\Blocks\AsphaltBlock.cs`
you may create override file:
	`UserCode\AutoGen\Blocks\AsphaltBlock.override.cs`
with will be loaded instead of original file.