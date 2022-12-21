namespace Eco.Mods.TechTree
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using Eco.Core.Items;
    using Eco.Gameplay.Components;
    using Eco.Gameplay.Components.Auth;
    using Eco.Gameplay.Components.VehicleModules;
    using Eco.Gameplay.DynamicValues;
    using Eco.Gameplay.Items;
    using Eco.Gameplay.Objects;
    using Eco.Gameplay.Players;
    using Eco.Gameplay.Skills;
    using Eco.Gameplay.Systems.TextLinks;
    using Eco.Shared.Math;
    using Eco.Shared.Networking;
    using Eco.Shared.Localization;
    using Eco.Shared.Serialization;
    using Eco.Shared.Utils;
    using Eco.Shared.Items;
    using Eco.Gameplay.Systems.Tooltip;
    using Eco.Gameplay.Systems.NewTooltip;
    using Eco.Core.Controller;
    using Eco.Core.Utils;
    using Eco.Gameplay.Aliases;
    using Eco.Gameplay.Economy;
    using Eco.Gameplay.GameActions;
    using Eco.Gameplay.Property;

    [Serialized]
    [LocDisplayName("Wood Shop Cart Black")]
    [Weight(15000)]
    [Tag("ColoredWoodShopCart")]
    [Ecopedia("CavRnMods", "Colored Vehicles", createAsSubPage: true)]
    public partial class WoodShopCartBlackItem : WorldObjectItem<WoodShopCartBlackObject>, IPersistentData
    {
        public override LocString DisplayDescription { get { return Localizer.DoStr("A store in a Black wooden cart, very useful when your customers are far away."); } }
        [Serialized, SyncToView, TooltipChildren] public object PersistentData { get; set; }
    }

    public class PaintWoodShopCartBlackRecipe : RecipeFamily
    {
        public PaintWoodShopCartBlackRecipe()
        {
            this.Recipes = new List<Recipe>
            {
                new Recipe(
                    "Paint Wood Shop Cart Black",
                    Localizer.DoStr("Paint Wood Shop Cart Black"),
                    new IngredientElement[]
                    {
                        new IngredientElement(typeof(WoodShopCartItem), 1, true),
                        new IngredientElement(typeof(ShaleItem), 40, typeof(BasicEngineeringSkill), typeof(BasicEngineeringLavishResourcesTalent)),
                    },
                    new CraftingElement<WoodShopCartBlackItem>()
                )
            };
            this.ExperienceOnCraft = 0.1f;
            this.LaborInCalories = CreateLaborInCaloriesValue(500, typeof(BasicEngineeringSkill));
            this.CraftMinutes = CreateCraftTimeValue(typeof(PaintWoodShopCartBlackRecipe), 10, typeof(BasicEngineeringSkill));

            this.Initialize(Localizer.DoStr("Paint Wood Shop Cart Black"), typeof(PaintWoodShopCartBlackRecipe));
            CraftingComponent.AddRecipe(typeof(PrimitivePaintingTableObject), this);
        }
    }

    [Serialized]
    [RequireComponent(typeof(StandaloneAuthComponent))]
    [RequireComponent(typeof(CustomTextComponent))]
    [RequireComponent(typeof(PublicStorageComponent))]
    [RequireComponent(typeof(MovableLinkComponent))]
    [RequireComponent(typeof(VehicleComponent))]
    [RequireComponent(typeof(ModularStockpileComponent))]
    [RequireComponent(typeof(TailingsReportComponent))]
    public partial class WoodShopCartBlackObject : PhysicsWorldObject, IRepresentsItem
    {
        static WoodShopCartBlackObject()
        {
            WorldObject.AddOccupancy<WoodShopCartBlackObject>(new List<BlockOccupancy>(0));
        }

        public override TableTextureMode TableTexture => TableTextureMode.Wood;
        public override LocString DisplayName { get { return Localizer.DoStr("Wood Shop Cart Black"); } }
        public Type RepresentedItemType { get { return typeof(WoodShopCartBlackItem); } }


        private WoodShopCartBlackObject() { }

        protected override void Initialize()
        {
            base.Initialize();

            this.GetComponent<CustomTextComponent>().Initialize(200);
            this.GetComponent<PublicStorageComponent>().Initialize(12, 2100000);
            this.GetComponent<VehicleComponent>().Initialize(10, 1, 1);
            this.GetComponent<VehicleComponent>().HumanPowered(2);
            this.GetComponent<StockpileComponent>().Initialize(new Vector3i(2,1,2));
        }
    }

    /// <summary> This represents wood shop cart. It's a special shop which you can move by pulling it. Implements IFreezable, so when nobody pull it, it won't move anyway. </summary>
        [RequireComponent(typeof(StoreComponent))]
        public partial class WoodShopCartBlackObject : PhysicsWorldObject, INullCurrencyAllowed, IGameActionAware, IFreezable
        {
    #region IFreezable
            public bool Frozen { get; set; } //Current state, whatever store is frozen or not. Should be frozen when nobody pulls it, so it can't be pushed away by physics.
            public NetPhysicsEntity NetEntity => (NetPhysicsEntity)this.netEntity;
            public float GroundDistance { get; set; } //Used if ground is goes away from store so it can wake up and fall.
            #endregion
            protected override void PostInitialize()
            {
                base.PostInitialize();
                this.GetComponent<VehicleComponent>().SetDrivableFunc(this.Drivable);
            }

            //Store is drivable when it's in deactivated mode.
            bool Drivable() => this.GetComponent<OnOffComponent>().On == false;
            void NotifyDrivingChange() => this.GetComponent<VehicleComponent>().Changed(nameof(VehicleComponent.Drivable));
            protected override void OnCreatePostInitialize()
            {
                base.OnCreatePostInitialize();
                this.GetComponent<OnOffComponent>().SetOnOff(null, false); //Shop truck starts in mode vehicle, user must to explicitly put it as store
                this.GetComponent<OnOffComponent>().Subscribe(nameof(OnOffComponent.On), this.NotifyDrivingChange);
            }

            //Allow everybody to access shop cart. Only costumers will be able to drive or access storage.
            public LazyResult ShouldOverrideAuth(IAlias alias, IOwned property, GameAction action)
            {
                //This is done this way because for now it's impossible to have freedom in auth setuping. Customer by default means access to storage, to vehicle etc.
                //So before auth refactoring is done, it allows to buy to anybody, so you dont have to put people as a customer giving them too much access. TODO: rework after auth refactoring https://github.com/StrangeLoopGames/Eco/pull/10620
                if (action is QueryAction || action is OpenAction || action is TradeAction)
                    return LazyResult.Succeeded;
                return LazyResult.FailedNoMessage;
            }

            public void ActionPerformed(GameAction action) { }
        }
}
