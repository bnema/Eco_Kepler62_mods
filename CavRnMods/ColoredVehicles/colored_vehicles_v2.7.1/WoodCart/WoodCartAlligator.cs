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
    [LocDisplayName("Wood Cart Alligator")]
    [Weight(15000)]
    [Ecopedia("CavRnMods", "Colored Vehicles", createAsSubPage: true)]
    [Tag("ColoredWoodCart")]
    public partial class WoodCartAlligatorItem : WorldObjectItem<WoodCartAlligatorObject>
    {
        public override LocString DisplayDescription { get { return Localizer.DoStr("Small alligator cart for hauling small loads."); } }
        [Serialized, SyncToView, TooltipChildren] public object PersistentData { get; set; }
    }

    public class PaintWoodCartAlligatorRecipe : RecipeFamily
    {
        public PaintWoodCartAlligatorRecipe()
        {
            this.Recipes = new List<Recipe>
            {
                new Recipe(
                    "Paint Wood Cart Alligator",
                    Localizer.DoStr("Paint Wood Cart Alligator"),
                    new IngredientElement[]
                    {
                        new IngredientElement(typeof(WoodCartItem), 1, true),
                        new IngredientElement(typeof(KelpItem), 18, typeof(BasicEngineeringSkill), typeof(BasicEngineeringLavishResourcesTalent)),
                        new IngredientElement(typeof(AlligatorCarcassItem), 2, typeof(BasicEngineeringSkill), typeof(BasicEngineeringLavishResourcesTalent)),
                    },
                    new CraftingElement<WoodCartAlligatorItem>()
                )
            };
            this.ExperienceOnCraft = 0.1f;  
            this.LaborInCalories = CreateLaborInCaloriesValue(250, typeof(BasicEngineeringSkill)); 
            this.CraftMinutes = CreateCraftTimeValue(typeof(PaintWoodCartAlligatorRecipe), 5, typeof(BasicEngineeringSkill));    

            this.Initialize(Localizer.DoStr("Paint Wood Cart Alligator"), typeof(PaintWoodCartAlligatorRecipe));
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
    public partial class WoodCartAlligatorObject : PhysicsWorldObject, IRepresentsItem
    {
        static WoodCartAlligatorObject()
        {
            WorldObject.AddOccupancy<WoodCartAlligatorObject>(new List<BlockOccupancy>(0));
        }

        public override TableTextureMode TableTexture => TableTextureMode.Wood;
        public override LocString DisplayName { get { return Localizer.DoStr("Wood Cart Alligator"); } }
        public Type RepresentedItemType { get { return typeof(WoodCartAlligatorItem); } }


        private WoodCartAlligatorObject() { }

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
