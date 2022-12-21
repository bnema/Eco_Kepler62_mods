// Copyright (c) Strange Loop Games. All rights reserved.
// See LICENSE file in the project root for full license information.

namespace Eco.Mods.TechTree
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Linq;
    using Eco.Core.Controller;
    using Eco.Gameplay.DynamicValues;
    using Eco.Gameplay.GameActions;
    using Eco.Gameplay.Interactions;
    using Eco.Gameplay.Items;
    using Eco.Gameplay.Systems.TextLinks;
    using Eco.Gameplay.Systems.Tooltip;
    using Eco.Shared.Items;
    using Eco.Shared.Localization;
    using Eco.Shared.Utils;
    using Eco.World.Blocks;
    using Eco.Gameplay.Objects;
    using Eco.Core.Items;

    public partial class PickaxeItem : ToolItem
    {

        bool AutoCollect = true; //Enable auto collect?
        int AutoCollectLevel = 7; //At which level its auto collect allowed?
        bool LuckyBreak = true; //Lucky break enabled?
        int LuckyBreakLevel = 0; //at which level is lucky break allowed?
        //if you set level to 0, everyone are allowed to use it.


        private static SkillModifiedValue caloriesBurn = CreateCalorieValue(20, typeof(MiningSkill), typeof(PickaxeItem));
        static PickaxeItem() { }

        public override IDynamicValue CaloriesBurn                  => caloriesBurn;

        public override ClientPredictedBlockAction LeftAction       => ClientPredictedBlockAction.Mine;
        public override LocString LeftActionDescription             => Localizer.DoStr("Mine");

        public override              Item          RepairItem       => Item.Get<StoneItem>();
        [SyncToView] public virtual  float         Damage           => 1.0f;      // damage per tier level
        [SyncToView] public override IDynamicValue Tier             => base.Tier; // tool tier, overriden to have SyncToView only for pickaxe
        public override              int           FullRepairAmount => 1;

        public override InteractResult OnActLeft(InteractionContext context)
        {
            if (context.HasBlock && context.Block.Is<Minable>())
            {
                var user = context.Player.User;
                var item = context.Block is IRepresentsItem ? Item.Get((IRepresentsItem)context.Block) : null;

                var totalDamageToTarget = user.BlockHitCache.MemorizeHit(context.Block.GetType(), context.BlockPosition.Value, this.Tier.GetCurrentValue(context.Player.User) * this.Damage);
                if (context.Block.Get<Minable>().Hardness <= totalDamageToTarget)
                {
                    var result = AtomicActions.DeleteBlockNow(this.CreateMultiblockContext(context, false), spawnRubble: false);    // Use the tool, but do not trigger an AddExperience call for destroying blocks.
                    var miningSkill = user.Skillset.GetSkill(typeof(MiningSkill));
                    //Spawn the rubble if needed
                    if (result.Success)
                    {
                        bool pickupItems = false;
                        if (AutoCollect) {
                            pickupItems = (miningSkill.Level >= AutoCollectLevel) ? user.Inventory.Carried.TryAddItems(item.GetType(), 4).Success : false;
                        }
                        var addition = item != null ? " " + item.UILink() : string.Empty;
                        if (!pickupItems)
                        {
                            var forced = (miningSkill.Level >= LuckyBreakLevel && LuckyBreak) ? 4 : -1;
                            if (RubbleObject.TrySpawnFromBlock(context.Player, context.Block.GetType(), context.BlockPosition.Value, forced))
                            {
                                this.AddExperience(user, 1f, new LocString(Localizer.Format("mining") + addition));                     // Add experience based on the tool's experience rate (altered in the EcoTechTree.csv).
                                user.UserUI.OnCreateRubble.Invoke(item.DisplayName.NotTranslated);
                                user.BlockHitCache.ForgetHit(context.BlockPosition.Value);
                            }
                        }
                        else
                        {
                            this.AddExperience(user, 1f, new LocString(Localizer.Format("mining") + addition));
                            user.BlockHitCache.ForgetHit(context.BlockPosition.Value);
                        }
                    }

                    return (InteractResult)result;
                }
                else return (InteractResult) AtomicActions.UseToolNow(this.CreateMultiblockContext(context, false));                // Use the tool, but do not trigger an AddExperience call for damaging blocks.
            }
            else if (context.Target is RubbleObject)
            {
                var rubble = (RubbleObject)context.Target;
                if (rubble.IsBreakable)
                {
                    using var pack = new GameActionPack();
                    pack.UseTool(this.CreateMultiblockContext(context, false));                                                     // Break the rubble, but do not trigger an AddExperience call.
                    pack.AddPostEffect(() => rubble.Breakup(context.Player));
                    return (InteractResult)pack.TryPerform(false);
                }
                
                return InteractResult.NoOp;
            }

            if (context.Target is WorldObject) return this.BasicToolOnWorldObjectCheck(context);

            return base.OnActLeft(context);
        }
    }
}
