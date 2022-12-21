using System.Collections.Generic;
using Eco.Core.Controller;
using Eco.Core.Items;
using Eco.Gameplay.Modules;
using Eco.Gameplay.Systems.NewTooltip;
using Eco.Gameplay.Systems.Tooltip;
using Eco.Shared.Items;
using Eco.Shared.Math;
using Eco.Shared.Utils;

namespace Eco.Mods.TechTree
{
    using System;
    using Gameplay.Components;
    using Gameplay.Components.Auth;
    using Gameplay.Items;
    using Gameplay.Objects;
    using Gameplay.Skills;
    using Shared.Localization;
    using Shared.Serialization;

    [Serialized]
    [RequireComponent(typeof(OnOffComponent))]
    [RequireComponent(typeof(PropertyAuthComponent))]
    [RequireComponent(typeof(MinimapComponent))]
    [RequireComponent(typeof(LinkComponent))]
    [RequireComponent(typeof(CraftingComponent))]
    [RequireComponent(typeof(SolidAttachedSurfaceRequirementComponent))]
    [RequireComponent(typeof(PluginModulesComponent))]
    public class AdvancedPaintingTableObject : WorldObject, IRepresentsItem
    {
        public override LocString DisplayName => Localizer.DoStr("AdvancedPaintingTable");

        public override TableTextureMode TableTexture => TableTextureMode.Metal;

        public virtual Type RepresentedItemType => typeof(AdvancedPaintingTableItem);

        protected override void Initialize()
        {
            GetComponent<MinimapComponent>().SetCategory(Localizer.DoStr("Crafting"));
        }

        static AdvancedPaintingTableObject()
        {
            AddOccupancy<AdvancedPaintingTableObject>(new List<BlockOccupancy>()
            {
                new BlockOccupancy(new Vector3i(-1, 0, 0)),
                new BlockOccupancy(new Vector3i(0, 0, 0)),
                new BlockOccupancy(new Vector3i(1, 0, 0)),
                new BlockOccupancy(new Vector3i(-1, 1, 0)),
                new BlockOccupancy(new Vector3i(0, 1, 0)),
                new BlockOccupancy(new Vector3i(1, 1, 0)),
            });
        }
    }

    [Serialized]
    [LocDisplayName("Advanced Painting Table")]
    [Ecopedia("CavRnMods", "Colored Vehicles", createAsSubPage: true)]
    [AllowPluginModules(Tags = new[] {"AdvancedUpgrade", "ModernUpgrade"}, ItemTypes = new[] {typeof(MechanicsAdvancedUpgradeItem), typeof(IndustryUpgradeItem)})]
    public class AdvancedPaintingTableItem : WorldObjectItem<AdvancedPaintingTableObject>
    {
        public override LocString DisplayDescription { get { return Localizer.DoStr("A table used to paint steam trucks and trucks"); } }

        public override DirectionAxisFlags RequiresSurfaceOnSides { get;} = 0 | DirectionAxisFlags.Down;

        [Serialized, SyncToView, TooltipChildren] public object PersistentData { get; set; }
    }

    [RequiresSkill(typeof(SmeltingSkill), 3)]
    public class AdvancedPaintingTableRecipe : RecipeFamily
    {
        public AdvancedPaintingTableRecipe()
        {
            var product = new Recipe(
                "AdvancedPaintingTable",
                Localizer.DoStr("Advanced Painting Table"),
                new IngredientElement[]
                {
                    new IngredientElement(typeof(IronBarItem), 30, typeof(SmeltingSkill), typeof(SmeltingLavishResourcesTalent)),
                    new IngredientElement("Lumber", 10, typeof(SmeltingSkill), typeof(SmeltingLavishResourcesTalent)),
                },
                new CraftingElement<AdvancedPaintingTableItem>()
            );
            this.Recipes = new List<Recipe> {product};
            this.LaborInCalories = CreateLaborInCaloriesValue(300);
            this.CraftMinutes = CreateCraftTimeValue(15);
            this.Initialize(Localizer.DoStr("Advanced Painting Table"), typeof(AdvancedPaintingTableRecipe));
            CraftingComponent.AddRecipe(typeof(AnvilObject), this);
        }
    }
}
