namespace Eco.Mods.TechTree
{ 
// [DoNotLocalize]
using System;
using System.Collections.Generic;
using Eco.Gameplay.Components;
using Eco.Gameplay.Items;
using Eco.Gameplay.Skills;
using Eco.Gameplay.Systems.TextLinks;
using Eco.Gameplay.Systems.Tooltip;
using Eco.Shared.Localization;
using Eco.Shared.Serialization;

[Serialized]
[LocDisplayName("Charcoal Powder")]
[MaxStackSize(200)]
[Weight(1000)]                                                                             
public partial class CharcoalPowderItem : Item                                   
{
    public override LocString DisplayDescription { get { return Localizer.DoStr("Charcoal crushed in an arrastra, used for crafting ink"); } }

    static CharcoalPowderItem() { }
   }

    [RequiresSkill(typeof(MiningSkill), 1)]
    public partial class CharcoalPowderRecipe : RecipeFamily
    {
        public CharcoalPowderRecipe()
        {
            this.Recipes = new List<Recipe>
            {
                new Recipe(
                        "Charcoal Powder",
                        Localizer.DoStr("Charcoal Powder"),
                        new IngredientElement[]
                        {
                        new IngredientElement(typeof(CharcoalItem), 10, typeof(MiningSkill)),
                        },
                        new CraftingElement [] { new CraftingElement<CharcoalPowderItem>() }
                    )
            };

            this.ExperienceOnCraft = 0;
            this.LaborInCalories = CreateLaborInCaloriesValue(100);
            this.CraftMinutes = CreateCraftTimeValue(typeof(CharcoalPowderRecipe), 1, typeof(MiningSkill));
            this.Initialize(Localizer.DoStr("Charcoal Powder"), typeof(CharcoalPowderRecipe));

            CraftingComponent.AddRecipe(typeof(ArrastraObject), this);
        }
    }
}
