// Eco Russian Comumnity

namespace Eco.Mods.TechTree
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using Eco.Core.Items;
    using Eco.Gameplay.Blocks;
    using Eco.Gameplay.Components;
    using Eco.Gameplay.Components.Auth;
    using Eco.Gameplay.DynamicValues;
    using Eco.Gameplay.Economy;
    using Eco.Gameplay.Housing;
    using Eco.Gameplay.Interactions;
    using Eco.Gameplay.Items;
    using Eco.Gameplay.Modules;
    using Eco.Gameplay.Minimap;
    using Eco.Gameplay.Objects;
    using Eco.Gameplay.Players;
    using Eco.Gameplay.Property;
    using Eco.Gameplay.Skills;
    using Eco.Gameplay.Systems.TextLinks;
    using Eco.Gameplay.Pipes.LiquidComponents;
    using Eco.Gameplay.Pipes.Gases;
    using Eco.Gameplay.Systems.Tooltip;
    using Eco.Shared;
    using Eco.Shared.Math;
    using Eco.Shared.Localization;
    using Eco.Shared.Serialization;
    using Eco.Shared.Utils;
    using Eco.Shared.View;
    using Eco.Shared.Items;
    using Eco.Gameplay.Pipes;
    using Eco.World.Blocks;
    using Eco.Gameplay.Housing.PropertyValues;
    using Eco.Gameplay.Civics.Objects;

    [Serialized]
    [RequireComponent(typeof(OnOffComponent))]
    [RequireComponent(typeof(PropertyAuthComponent))]
	[RequireComponent(typeof(CustomTextComponent))]
    [RequireComponent(typeof(SolidAttachedSurfaceRequirementComponent))]
    public partial class ERCGateCSFRightObject : WorldObject, IRepresentsItem
    {
        public virtual Type RepresentedItemType => typeof(ERCGateCSFRightItem);
        public override LocString DisplayName => Localizer.DoStr("Corrugated Steel Fence Gate - Right");
        public override TableTextureMode TableTexture => TableTextureMode.Metal;
        public override bool HasTier => true;
        public override int Tier => 3;
		protected override void PostInitialize() => LargeDoorUtils.InitializeDoor(this);

        protected override void Initialize()
        {
            this.ModsPreInitialize();
			
			this.GetComponent<CustomTextComponent>().Initialize(700);
						
            this.ModsPostInitialize();
        }

		static ERCGateCSFRightObject()
        {
            WorldObject.AddOccupancy<ERCGateCSFRightObject>(new List<BlockOccupancy>(){
            new BlockOccupancy(new Vector3i(0, 0, -6)),
            new BlockOccupancy(new Vector3i(0, 1, -6)),
            new BlockOccupancy(new Vector3i(0, 2, -6)),
            new BlockOccupancy(new Vector3i(0, 0, -5)),
            new BlockOccupancy(new Vector3i(0, 1, -5)),
            new BlockOccupancy(new Vector3i(0, 2, -5)),
            new BlockOccupancy(new Vector3i(0, 0, -4)),
            new BlockOccupancy(new Vector3i(0, 1, -4)),
            new BlockOccupancy(new Vector3i(0, 2, -4)),
            new BlockOccupancy(new Vector3i(0, 0, -3)),
            new BlockOccupancy(new Vector3i(0, 1, -3)),
            new BlockOccupancy(new Vector3i(0, 2, -3)),
            new BlockOccupancy(new Vector3i(0, 0, -2)),
            new BlockOccupancy(new Vector3i(0, 1, -2)),
            new BlockOccupancy(new Vector3i(0, 2, -2)),
            new BlockOccupancy(new Vector3i(0, 0, -1)),
            new BlockOccupancy(new Vector3i(0, 1, -1)),
            new BlockOccupancy(new Vector3i(0, 2, -1)),
            new BlockOccupancy(new Vector3i(0, 0, 0)),
            new BlockOccupancy(new Vector3i(0, 1, 0)),
            new BlockOccupancy(new Vector3i(0, 2, 0)),
            new BlockOccupancy(new Vector3i(0, 0, 1)),
            new BlockOccupancy(new Vector3i(0, 1, 1)),
            new BlockOccupancy(new Vector3i(0, 2, 1)),
            new BlockOccupancy(new Vector3i(0, 0, 2)),
            new BlockOccupancy(new Vector3i(0, 1, 2)),
            new BlockOccupancy(new Vector3i(0, 2, 2)),
            new BlockOccupancy(new Vector3i(0, 0, 3)),
            new BlockOccupancy(new Vector3i(0, 1, 3)),
            new BlockOccupancy(new Vector3i(0, 2, 3)),
            new BlockOccupancy(new Vector3i(0, 0, 4)),
            new BlockOccupancy(new Vector3i(0, 1, 4)),
            new BlockOccupancy(new Vector3i(0, 2, 4)),
            new BlockOccupancy(new Vector3i(0, 0, 5)),
            new BlockOccupancy(new Vector3i(0, 1, 5)),
            new BlockOccupancy(new Vector3i(0, 2, 5)),
            new BlockOccupancy(new Vector3i(0, 0, 6)),
            new BlockOccupancy(new Vector3i(0, 1, 6)),
            new BlockOccupancy(new Vector3i(0, 2, 6)),
            });
        }

        /// <summary>Hook for mods to customize WorldObject before initialization. You can change housing values here.</summary>
        partial void ModsPreInitialize();
        /// <summary>Hook for mods to customize WorldObject after initialization.</summary>
        partial void ModsPostInitialize();
    }

    [Serialized]
    [LocDisplayName("Corrugated Steel Fence Gate - Right")]
    [Tier(3)]
	
        public partial class ERCGateCSFRightItem : WorldObjectItem<ERCGateCSFRightObject>
    {
        public override LocString DisplayDescription => Localizer.DoStr("A large corrugated steel fence gate.");

        public override DirectionAxisFlags RequiresSurfaceOnSides { get;} = 0 | DirectionAxisFlags.Down;
    }

    [RequiresSkill(typeof(AdvancedSmeltingSkill), 5)]
    public partial class ERCGateCSFRightRecipe : RecipeFamily
    {
        public ERCGateCSFRightRecipe()
        {
            var recipe = new Recipe();
            recipe.Init(
                "ERCGateCSFRight",  //noloc
                Localizer.DoStr("Corrugated Steel Fence Gate - Right"),
                new List<IngredientElement>
                {
                    new IngredientElement(typeof(CorrugatedSteelItem), 40, typeof(AdvancedSmeltingSkill), typeof(AdvancedSmeltingLavishResourcesTalent)),
                },
                new List<CraftingElement>
                {
                    new CraftingElement<ERCGateCSFRightItem>()
                });
            this.Recipes = new List<Recipe> { recipe };
            this.ExperienceOnCraft = 5;
            this.LaborInCalories = CreateLaborInCaloriesValue(480, typeof(AdvancedSmeltingSkill));
            this.CraftMinutes = CreateCraftTimeValue(typeof(ERCGateCSFRightRecipe), 10, typeof(AdvancedSmeltingSkill), typeof(AdvancedSmeltingFocusedSpeedTalent), typeof(AdvancedSmeltingParallelSpeedTalent));
            this.ModsPreInitialize();
            this.Initialize(Localizer.DoStr("Corrugated Steel Fence Gate - Right"), typeof(ERCGateCSFRightRecipe));
            this.ModsPostInitialize();
            CraftingComponent.AddRecipe(typeof(RollingMillObject), this);
        }

        /// <summary>Hook for mods to customize RecipeFamily before initialization. You can change recipes, xp, labor, time here.</summary>
        partial void ModsPreInitialize();
        /// <summary>Hook for mods to customize RecipeFamily after initialization, but before registration. You can change skill requirements here.</summary>
        partial void ModsPostInitialize();
    }
}
