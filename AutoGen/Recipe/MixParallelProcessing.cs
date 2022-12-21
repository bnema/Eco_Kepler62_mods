
namespace Eco.Mods.TechTree
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Linq;
    using Eco.Gameplay.Components;
    using Eco.Gameplay.Items;
    using Eco.Gameplay.Players;
    using Eco.Gameplay.Skills;
    using Eco.Mods.TechTree;
    using Eco.Shared.Items;
    using Eco.Shared.Localization;
    using Eco.Shared.Serialization;
    using Eco.Shared.Utils;
    using Eco.Shared.View;

    [Serialized]
    [LocDisplayName("Parallel Processing: Mixology")]
    public partial class MixologyParallelProcessingTalentGroup : TalentGroup
    {
        public override LocString DisplayDescription { get { return Localizer.DoStr("Increases the crafting speed of related tables when they share a room with the same tables by 20 percent."); } }
       
        public MixologyParallelProcessingTalentGroup()
        {
            Talents = new Type[]
            {

                typeof(MixologyParallelSpeedTalent),


            };
            this.OwningSkill = typeof(MixologySkill);
            this.Level = 3;
        }
    }


    [Serialized]
    public partial class MixologyParallelSpeedTalent : ParallelProcessingTalent
    {
        public override bool Base { get { return false; } }
        public override Type TalentGroupType { get { return typeof(MixologyParallelProcessingTalentGroup); } }
        public MixologyParallelSpeedTalent()
        {
            this.Value = 0.8f;
        }
    }

}