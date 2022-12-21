
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
    using static Eco.Gameplay.Housing.PropertyValues.HomeFurnishingValue;

    [Serialized]
    [RequireComponent(typeof(OnOffComponent))]
    [RequireComponent(typeof(PropertyAuthComponent))]
    [RequireComponent(typeof(MinimapComponent))]
    [RequireComponent(typeof(LinkComponent))]
    [RequireComponent(typeof(CraftingComponent))]
    [RequireComponent(typeof(HousingComponent))]
    [RequireComponent(typeof(PluginModulesComponent))]
    [RequireComponent(typeof(RoomRequirementsComponent))]
    [RequireRoomContainment]
    [RequireRoomVolume(25)]
    [RequireRoomMaterialTier(0.2f, typeof(MixologyLavishReqTalent))]
    public partial class BlenderTableObject : WorldObject, IRepresentsItem
    {
        public virtual Type RepresentedItemType => typeof(BlenderTableItem);
        public override LocString DisplayName => Localizer.DoStr("Blender");
        public override TableTextureMode TableTexture => TableTextureMode.Wood;

        protected override void Initialize()
        {
            this.ModsPreInitialize();
            this.GetComponent<MinimapComponent>().SetCategory(Localizer.DoStr("Crafting"));
            this.GetComponent<HousingComponent>().HomeValue = BlenderTableItem.HomeValue;
            this.ModsPostInitialize();
        }


        /// <summary>Hook for mods to customize WorldObject before initialization. You can change housing values here.</summary>
        partial void ModsPreInitialize();
        /// <summary>Hook for mods to customize WorldObject after initialization.</summary>
        partial void ModsPostInitialize();
    }

    [Serialized]
    [LocDisplayName("Blender")]
    [Ecopedia("Work Stations", "Craft Tables", createAsSubPage: true)]
    [AllowPluginModules(Tags = new[] { "AdvancedUpgrade" }, ItemTypes = new[] { typeof(MixologyAdvancedUpgradeItem) })] //noloc
    public partial class BlenderTableItem : WorldObjectItem<BlenderTableObject>, IPersistentData
    {
        public override LocString DisplayDescription { get { return Localizer.DoStr("Blend all of your ingredients ready to make your favourite drinks."); } }
        [TooltipChildren] public HomeFurnishingValue HousingTooltip { get { return HomeValue; } }
        public static readonly HomeFurnishingValue HomeValue = new HomeFurnishingValue()
        {
            Category                 = RoomCategory.Kitchen,
            TypeForRoomLimit         = Localizer.DoStr(""),
        };

        [Serialized, TooltipChildren] public object PersistentData { get; set; }
    }

    public partial class BlenderTableRecipe : RecipeFamily
    {
        public BlenderTableRecipe()
        {
            var recipe = new Recipe();
            recipe.Init(
                "Blender",  //noloc
                Localizer.DoStr("Blender"),
                new List<IngredientElement>
                {
                    new IngredientElement(typeof(GraniteItem), 10), 
                    new IngredientElement(typeof(CelluloseFiberItem), 5), 
                    new IngredientElement(typeof(PlantFibersItem), 20),
                },
                new List<CraftingElement>
                {
                    new CraftingElement<BlenderTableItem>()
                });
            this.Recipes = new List<Recipe> { recipe };
            this.LaborInCalories = CreateLaborInCaloriesValue(100);
            this.CraftMinutes = CreateCraftTimeValue(5);
            this.ModsPreInitialize();
            this.Initialize(Localizer.DoStr("Blender"), typeof(BlenderTableRecipe));
            this.ModsPostInitialize();
            CraftingComponent.AddRecipe(typeof(WainwrightTableObject), this);
        }

        /// <summary>Hook for mods to customize RecipeFamily before initialization. You can change recipes, xp, labor, time here.</summary>
        partial void ModsPreInitialize();
        /// <summary>Hook for mods to customize RecipeFamily after initialization, but before registration. You can change skill requirements here.</summary>
        partial void ModsPostInitialize();
    }
}
