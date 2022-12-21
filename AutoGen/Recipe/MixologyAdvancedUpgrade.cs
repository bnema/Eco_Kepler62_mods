// Copyright (c) Strange Loop Games. All rights reserved.

namespace Eco.Mods.TechTree
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using Eco.Gameplay.Blocks;
    using Eco.Gameplay.Components;
    using Eco.Gameplay.DynamicValues;
    using Eco.Gameplay.Items;
    using Eco.Gameplay.Modules;
    using Eco.Gameplay.Objects;
    using Eco.Gameplay.Players;
    using Eco.Gameplay.Skills;
    using Eco.Gameplay.Systems;
    using Eco.Gameplay.Systems.TextLinks;
    using Eco.Shared.Localization;
    using Eco.Shared.Serialization;
    using Eco.Shared.Utils;
    using Eco.Core.Items;
    using Eco.World;
    using Eco.World.Blocks;
    using Eco.Gameplay.Pipes;

   
    [RequiresSkill(typeof(MixologySkill), 7)]
    public partial class MixologyAdvancedUpgradeRecipe :
        RecipeFamily
    {
        public MixologyAdvancedUpgradeRecipe()
        {
            this.Recipes = new List<Recipe>
            {
                new Recipe(
                    "MixologyAdvancedUpgrade",
                    Localizer.DoStr("Mixology Advanced Upgrade"),
                    new IngredientElement[]
                    {
               new IngredientElement(typeof(AdvancedUpgradeLvl4Item), 1, true),
                    },
                    new CraftingElement[]
                    {
                        new CraftingElement<MixologyAdvancedUpgradeItem>(),
                    }
                )
            };


            this.ExperienceOnCraft = 4;

            this.LaborInCalories = CreateLaborInCaloriesValue(5000, typeof(MixologySkill));
            this.CraftMinutes = CreateCraftTimeValue(typeof(MixologyAdvancedUpgradeRecipe), 10, typeof(MixologySkill), typeof(MixologyFocusedSpeedTalent), typeof(MixologyParallelSpeedTalent));
            this.ModsPreInitialize();
            this.Initialize(Localizer.DoStr("Mixology Advanced Upgrade"), typeof(MixologyAdvancedUpgradeRecipe));
            this.ModsPostInitialize();

            CraftingComponent.AddRecipe(typeof(MixologyTableObject), this);
        }

        /// <summary>Hook for mods to customize RecipeFamily before initialization. You can change recipes, xp, labor, time here.</summary>
        partial void ModsPreInitialize();
        /// <summary>Hook for mods to customize RecipeFamily after initialization, but before registration. You can change skill requirements here.</summary>
        partial void ModsPostInitialize();
    }

    [Serialized]
    [LocDisplayName("Mixology Advanced Upgrade")]
    [Weight(1)]
    [Ecopedia("Upgrade Modules", "Specialty Upgrades", createAsSubPage: true)]
    [Tag("Upgrade", 2)]
    public partial class MixologyAdvancedUpgradeItem :
        EfficiencyModule
    {
        public override LocString DisplayDescription { get { return Localizer.DoStr("Advanced Upgrade that greatly increases efficiency when crafting drink recipes."); } }
        public MixologyAdvancedUpgradeItem() : base(
            ModuleTypes.ResourceEfficiency | ModuleTypes.SpeedEfficiency,
            0.5f + 0.05f,
            typeof(MixologySkill),
            0.5f
        )
        { }
    }
}
