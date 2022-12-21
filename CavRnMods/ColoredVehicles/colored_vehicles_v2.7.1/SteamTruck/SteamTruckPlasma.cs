﻿namespace Eco.Mods.TechTree
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
    [LocDisplayName("Steam Truck Plasma")]
    [Weight(25000)]  
    [AirPollution(0.2f)] 
    [Ecopedia("CavRnMods", "Colored Vehicles", createAsSubPage: true)]  
    [Tag("ColoredSteamTruck", 1)]
    public partial class SteamTruckPlasmaItem : WorldObjectItem<SteamTruckPlasmaObject>
    {
        public override LocString DisplayDescription { get { return Localizer.DoStr("A plasma truck that runs on steam."); } }
        [Serialized, SyncToView, TooltipChildren] public object PersistentData { get; set; }
    }
    
      
    public class PaintSteamTruckPlasmaRecipe : RecipeFamily
    {
        public PaintSteamTruckPlasmaRecipe()
        {
            this.Recipes = new List<Recipe>
            {
                new Recipe(
                    "Paint Steam Truck Plasma",
                    Localizer.DoStr("Paint Steam Truck Plasma"),
                    new IngredientElement[]
                    {
                        new IngredientElement(typeof(SteamTruckItem), 1, true), 
                        new IngredientElement(typeof(CamasBulbItem), 24, typeof(MechanicsSkill), typeof(MechanicsLavishResourcesTalent)),
                        new IngredientElement(typeof(LimestoneItem), 16, typeof(MechanicsSkill), typeof(MechanicsLavishResourcesTalent)),
                    },
                    new CraftingElement<SteamTruckPlasmaItem>()
                )
            };
            this.ExperienceOnCraft = 0.1f;
            this.LaborInCalories = CreateLaborInCaloriesValue(500, typeof(MechanicsSkill)); 
            this.CraftMinutes = CreateCraftTimeValue(typeof(PaintSteamTruckPlasmaRecipe), 10, typeof(MechanicsSkill));    

            this.Initialize(Localizer.DoStr("Paint Steam Truck Plasma"), typeof(PaintSteamTruckPlasmaRecipe));
            CraftingComponent.AddRecipe(typeof(AdvancedPaintingTableObject), this);
        }
    }

    [Serialized]
    [RequireComponent(typeof(StandaloneAuthComponent))]
    [RequireComponent(typeof(FuelSupplyComponent))]              
    [RequireComponent(typeof(FuelConsumptionComponent))]         
    [RequireComponent(typeof(PublicStorageComponent))]      
    [RequireComponent(typeof(MovableLinkComponent))]        
    [RequireComponent(typeof(AirPollutionComponent))]
    [RequireComponent(typeof(VehicleComponent))]
    [RequireComponent(typeof(CustomTextComponent))]
    [RequireComponent(typeof(ModularStockpileComponent))]   
    [RequireComponent(typeof(TailingsReportComponent))]     
    public partial class SteamTruckPlasmaObject : PhysicsWorldObject, IRepresentsItem
    {
        static SteamTruckPlasmaObject()
        {
            WorldObject.AddOccupancy<SteamTruckPlasmaObject>(new List<BlockOccupancy>(0));
        }

        public override TableTextureMode TableTexture => TableTextureMode.Metal;
        public override LocString DisplayName { get { return Localizer.DoStr("Steam Truck Plasma"); } }
        public Type RepresentedItemType { get { return typeof(SteamTruckPlasmaItem); } }

        private static string[] fuelTagList = new string[]
        {
            "Burnable Fuel"
        };

        private SteamTruckPlasmaObject() { }

        protected override void Initialize()
        {
            base.Initialize();

            this.GetComponent<CustomTextComponent>().Initialize(200);
            this.GetComponent<PublicStorageComponent>().Initialize(24, 5000000);           
            this.GetComponent<FuelSupplyComponent>().Initialize(2, fuelTagList);           
            this.GetComponent<FuelConsumptionComponent>().Initialize(25);    
            this.GetComponent<AirPollutionComponent>().Initialize(0.2f);            
            this.GetComponent<VehicleComponent>().Initialize(18, 2, 2);
            this.GetComponent<StockpileComponent>().Initialize(new Vector3i(2,2,3));  
        }
    }
}
