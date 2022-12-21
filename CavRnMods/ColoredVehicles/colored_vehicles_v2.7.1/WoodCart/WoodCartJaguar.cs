namespace Eco.Mods.TechTree
{
    using System;
    using System.Collections.Generic;
    using Eco.Core.Items;
    using Eco.Gameplay.Components;
    using Eco.Gameplay.Components.Auth;
    using Eco.Gameplay.Items;
    using Eco.Gameplay.Objects;
    using Eco.Shared.Math;
    using Eco.Shared.Localization;
    using Eco.Shared.Serialization;
    using Eco.Shared.Items;
    using Eco.Core.Controller;
    using Eco.Gameplay.Systems.NewTooltip;
    using Eco.Gameplay.Systems.Tooltip;

    [Serialized]
    [LocDisplayName("Wood Cart Jaguar")]
    [Weight(15000)]
    [Ecopedia("CavRnMods", "Colored Vehicles", createAsSubPage: true)]
    [Tag("ColoredWoodCart")]
    public partial class WoodCartJaguarItem : WorldObjectItem<WoodCartJaguarObject>
    {
        public override LocString DisplayDescription { get { return Localizer.DoStr("Small jaguar cart for hauling small loads."); } }
        [Serialized, SyncToView, TooltipChildren] public object PersistentData { get; set; }
    }

    public class PaintWoodCartJaguarRecipe : RecipeFamily
    {
        public PaintWoodCartJaguarRecipe()
        {
            this.Recipes = new List<Recipe>
            {
                new Recipe(
                    "Paint Wood Cart Jaguar",
                    Localizer.DoStr("Paint Wood Cart Jaguar"),
                    new IngredientElement[]
                    {
                        new IngredientElement(typeof(WoodCartItem), 1, true),
                        new IngredientElement(typeof(SandstoneItem), 12, typeof(BasicEngineeringSkill), typeof(BasicEngineeringLavishResourcesTalent)),
                        new IngredientElement(typeof(PineappleItem), 4, typeof(BasicEngineeringSkill), typeof(BasicEngineeringLavishResourcesTalent)),
                        new IngredientElement(typeof(ShaleItem), 4, typeof(BasicEngineeringSkill), typeof(BasicEngineeringLavishResourcesTalent)),
                    },
                    new CraftingElement<WoodCartJaguarItem>()
                )
            };
            this.ExperienceOnCraft = 0.1f;  
            this.LaborInCalories = CreateLaborInCaloriesValue(250, typeof(BasicEngineeringSkill)); 
            this.CraftMinutes = CreateCraftTimeValue(typeof(PaintWoodCartJaguarRecipe), 5, typeof(BasicEngineeringSkill));    

            this.Initialize(Localizer.DoStr("Paint Wood Cart Jaguar"), typeof(PaintWoodCartJaguarRecipe));
            CraftingComponent.AddRecipe(typeof(PrimitivePaintingTableObject), this);
        }
    }

    [Serialized]
    [RequireComponent(typeof(StandaloneAuthComponent))]
    [RequireComponent(typeof(PublicStorageComponent))]
    [RequireComponent(typeof(MovableLinkComponent))]
    [RequireComponent(typeof(VehicleComponent))]
    [RequireComponent(typeof(CustomTextComponent))]
    [RequireComponent(typeof(ModularStockpileComponent))]
    [RequireComponent(typeof(TailingsReportComponent))]
    public partial class WoodCartJaguarObject : PhysicsWorldObject, IRepresentsItem
    {
        static WoodCartJaguarObject()
        {
            WorldObject.AddOccupancy<WoodCartJaguarObject>(new List<BlockOccupancy>(0));
        }

        public override TableTextureMode TableTexture => TableTextureMode.Wood;
        public override LocString DisplayName { get { return Localizer.DoStr("Wood Cart Jaguar"); } }
        public Type RepresentedItemType { get { return typeof(WoodCartJaguarItem); } }


        private WoodCartJaguarObject() { }

        protected override void Initialize()
        {
            base.Initialize();

            this.GetComponent<CustomTextComponent>().Initialize(200);
            this.GetComponent<PublicStorageComponent>().Initialize(12, 2100000);           
            this.GetComponent<VehicleComponent>().Initialize(12, 1, 1);
            this.GetComponent<VehicleComponent>().HumanPowered(1);           
            this.GetComponent<StockpileComponent>().Initialize(new Vector3i(2,1,2));  
        }
    }
}
