
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
    [LocDisplayName("Focused Workflow: Mixology")]
    public partial class MixologyFocusedWorkflowTalentGroup : TalentGroup
    {
        public override LocString DisplayDescription { get { return Localizer.DoStr("Doubles the speed of related tables when alone."); } }
        public MixologyFocusedWorkflowTalentGroup()
        {
            Talents = new Type[]
            {

                typeof(MixologyFocusedSpeedTalent),


            };
            this.OwningSkill = typeof(MixologySkill);
            this.Level = 3;
        }
    }


    [Serialized]
    public partial class MixologyFocusedSpeedTalent : FocusedWorkflowTalent
    {
        public override bool Base { get { return false; } }
        public override Type TalentGroupType { get { return typeof(MixologyFocusedWorkflowTalentGroup); } }
        public MixologyFocusedSpeedTalent()
        {
            this.Value = 0.5f;
        }
    }

}