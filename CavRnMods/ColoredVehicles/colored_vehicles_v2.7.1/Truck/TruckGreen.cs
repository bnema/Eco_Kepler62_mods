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
    [LocDisplayName("Truck Green")]
    [Weight(25000)]  
    [AirPollution(0.5f)] 
    [Ecopedia("CavRnMods", "Colored Vehicles", true)]                  
    [Tag("ColoredTruck")]
    public partial class TruckGreenItem : WorldObjectItem<TruckGreenObject>
    {
        public override LocString DisplayDescription { get { return Localizer.DoStr("Modern green truck for hauling sizable loads."); } }
        [Serialized, SyncToView, TooltipChildren] public object PersistentData { get; set; }
    }
    
      
    public class PaintTruckGreenRecipe : RecipeFamily
    {
        public PaintTruckGreenRecipe()
        {
            this.Recipes = new List<Recipe>
            {
                new Recipe(
                    "Paint Truck Green",
                    Localizer.DoStr("Paint Truck Green"),
                    new IngredientElement[]
                    {
                        new IngredientElement(typeof(TruckItem), 1, true), 
                        new IngredientElement(typeof(KelpItem), 60, typeof(IndustrySkill), typeof(IndustryLavishResourcesTalent)),
                    },
                    new CraftingElement<TruckGreenItem>()
                )
            };
            this.ExperienceOnCraft = 0.1f;  
            this.LaborInCalories = CreateLaborInCaloriesValue(750, typeof(IndustrySkill)); 
            this.CraftMinutes = CreateCraftTimeValue(typeof(PaintTruckGreenRecipe), 15, typeof(IndustrySkill));    

            this.Initialize(Localizer.DoStr("Paint Truck Green"), typeof(PaintTruckGreenRecipe));
            CraftingComponent.AddRecipe(typeof(AdvancedPaintingTableObject), this);
        }
    }

    [Serialized]
    [RequireComponent(typeof(StandaloneAuthComponent))]
    [RequireComponent(typeof(FuelSupplyComponent))]              
    [RequireComponent(typeof(FuelConsumptionComponent))]         
    [RequireComponent(typeof(PublicStorageComponent))]      
    [RequireComponent(typeof(MovableLinkComponent))]
    [RequireComponent(typeof(VehicleComponent))]
    [RequireComponent(typeof(AirPollutionComponent))]       
    [RequireComponent(typeof(VehicleComponent))]
    [RequireComponent(typeof(CustomTextComponent))]
    [RequireComponent(typeof(ModularStockpileComponent))]   
    [RequireComponent(typeof(TailingsReportComponent))]     
    public partial class TruckGreenObject : PhysicsWorldObject, IRepresentsItem
    {
        static TruckGreenObject()
        {
            WorldObject.AddOccupancy<TruckGreenObject>(new List<BlockOccupancy>(0));
        }

        public override TableTextureMode TableTexture => TableTextureMode.Metal;
        public override LocString DisplayName { get { return Localizer.DoStr("Truck Green"); } }
        public Type RepresentedItemType { get { return typeof(TruckGreenItem); } }

        private static string[] fuelTagList = new string[]
        {
            "Liquid Fuel"
        };

        private TruckGreenObject() { }

        protected override void Initialize()
        {
            base.Initialize();

            this.GetComponent<CustomTextComponent>().Initialize(200);
            this.GetComponent<PublicStorageComponent>().Initialize(36, 8000000);           
            this.GetComponent<FuelSupplyComponent>().Initialize(2, fuelTagList);           
            this.GetComponent<FuelConsumptionComponent>().Initialize(25);    
            this.GetComponent<AirPollutionComponent>().Initialize(0.5f);            
            this.GetComponent<VehicleComponent>().Initialize(20, 2, 2);
            this.GetComponent<StockpileComponent>().Initialize(new Vector3i(2,2,3));  
        }
    }
}
