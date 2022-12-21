
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
    [LocDisplayName("Lavish Workspace: Mixology")]
    public partial class MixologyLavishWorkspaceTalentGroup : TalentGroup
    {
        public override LocString DisplayDescription { get { return Localizer.DoStr("Increases the tier requirement of tables by 0.2, but reduces the resources needed by 5 percent."); } }
        public MixologyLavishWorkspaceTalentGroup()
        {
            Talents = new Type[]
            {

            typeof(MixologyLavishResourcesTalent),

            typeof(MixologyLavishReqTalent),

            };
            this.OwningSkill = typeof(MixologySkill);
            this.Level = 6;
        }
    }


    [Serialized]
    public partial class MixologyLavishResourcesTalent : LavishWorkspaceTalent
    {
        public override bool Base { get { return false; } }
        public override Type TalentGroupType { get { return typeof(MixologyLavishWorkspaceTalentGroup); } }
        public MixologyLavishResourcesTalent()
        {
            this.Value = 0.95f;
        }
    }

    [Serialized]
    public partial class MixologyLavishReqTalent : LavishWorkspaceTalent
    {
        public override bool Base { get { return false; } }
        public override Type TalentGroupType { get { return typeof(MixologyLavishWorkspaceTalentGroup); } }
        public MixologyLavishReqTalent()
        {
            this.Value = 0.2f;
        }
    }

}
