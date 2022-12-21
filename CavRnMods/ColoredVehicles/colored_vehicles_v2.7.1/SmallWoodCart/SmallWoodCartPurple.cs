namespace Eco.Mods.TechTree
{
    using System;
    using System.Collections.Generic;
    using Eco.Core.Items;
    using Eco.Gameplay.Components;
    using Eco.Gameplay.Components.Auth;
    using Eco.Gameplay.Items;
    using Eco.Gameplay.Objects;
    using Eco.Shared.Localization;
    using Eco.Shared.Serialization;
    using Eco.Shared.Items;
    using Eco.Core.Controller;
    using Eco.Gameplay.Systems.NewTooltip;
    using Eco.Gameplay.Systems.Tooltip;

    [Serialized]
    [LocDisplayName("Small Wood Cart Purple")]
    [Weight(5000)]
    [Ecopedia("CavRnMods", "Colored Vehicles", true)]    
    [Tag("ColoredSmallWoodCart")]
    public partial class SmallWoodCartPurpleItem : WorldObjectItem<SmallWoodCartPurpleObject>
    {
        public override LocString DisplayDescription { get { return Localizer.DoStr("Small purple cart for hauling small loads."); } }
        [Serialized, SyncToView, TooltipChildren, ] public object PersistentData { get; set; }
    }

    public class PaintSmallWoodCartPurpleRecipe : RecipeFamily
    {
        public PaintSmallWoodCartPurpleRecipe()
        {
            this.Recipes = new List<Recipe>
            {
                new Recipe(
                    "Paint Small Wood Cart Purple",
                    Localizer.DoStr("Paint Small  Cart Purple"),
                    new IngredientElement[]
                    {
                        new IngredientElement(typeof(SmallWoodCartItem), 1, true),
                        new IngredientElement(typeof(BeetItem), 10, typeof(CarpentrySkill), typeof(CarpentryLavishResourcesTalent)),
                    },
                    new CraftingElement<SmallWoodCartPurpleItem>()
                )
            };
            this.ExperienceOnCraft = 0.05f;
            this.LaborInCalories = CreateLaborInCaloriesValue(125, typeof(BasicEngineeringSkill));
            this.CraftMinutes = CreateCraftTimeValue(typeof(PaintSmallWoodCartPurpleRecipe), 2.5f, typeof(BasicEngineeringSkill));

            this.Initialize(Localizer.DoStr("Paint Small Wood Cart Purple"), typeof(PaintSmallWoodCartPurpleRecipe));
            CraftingComponent.AddRecipe(typeof(PrimitivePaintingTableObject), this);
        }
    }

    [Serialized]
    [RequireComponent(typeof(StandaloneAuthComponent))]
    [RequireComponent(typeof(PublicStorageComponent))]
    [RequireComponent(typeof(MovableLinkComponent))]
    [RequireComponent(typeof(VehicleComponent))]
    [RequireComponent(typeof(CustomTextComponent))]
    [RequireComponent(typeof(TailingsReportComponent))]
    public partial class SmallWoodCartPurpleObject : PhysicsWorldObject, IRepresentsItem
    {
        static SmallWoodCartPurpleObject()
        {
            WorldObject.AddOccupancy<SmallWoodCartPurpleObject>(new List<BlockOccupancy>(0));
        }

        public override TableTextureMode TableTexture => TableTextureMode.Wood;
        public override LocString DisplayName { get { return Localizer.DoStr("Small Wood Cart Purple"); } }
        public Type RepresentedItemType { get { return typeof(SmallWoodCartPurpleItem); } }


        private SmallWoodCartPurpleObject() { }

        protected override void Initialize()
        {
            base.Initialize();

            this.GetComponent<CustomTextComponent>().Initialize(200);
            this.GetComponent<PublicStorageComponent>().Initialize(8, 1400000);           
            this.GetComponent<VehicleComponent>().Initialize(10, 1, 1);
            this.GetComponent<VehicleComponent>().HumanPowered(0.5f);           
        }
    }
}
