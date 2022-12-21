namespace Eco.Mods.TechTree
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Linq;
    using Eco.Core.Items;
    using Eco.Core.Utils;
    using Eco.Core.Utils.AtomicAction;
    using Eco.Gameplay.Blocks;
    using Eco.Gameplay.Components;
    using Eco.Gameplay.DynamicValues;
    using Eco.Gameplay.Items;
    using Eco.Gameplay.Players;
    using Eco.Gameplay.Property;
    using Eco.Gameplay.Skills;
    using Eco.Gameplay.Systems;
    using Eco.Gameplay.Systems.TextLinks;
    using Eco.Shared.Localization;
    using Eco.Shared.Serialization;
    using Eco.Shared.Services;
    using Eco.Shared.Utils;
    using Gameplay.Systems.Tooltip;

   
    [Serialized]
    [LocDisplayName("Mixology")]
    [Ecopedia("Professions", "Chef", createAsSubPage: true)]
    [RequiresSkill(typeof(ChefSkill), 0), Tag("Chef Specialty"), Tier(2)]
    [Tag("Specialty")]
    [Tag("Teachable")]
    public partial class MixologySkill : Skill
    {
        public override LocString DisplayDescription { get { return Localizer.DoStr("This Mixologist knows how to make some of the best drinks this world has ever seen."); } }
        
        public override void OnLevelUp(User user)
        {
            user.Skillset.AddExperience(typeof(SelfImprovementSkill), 20, Localizer.DoStr("for leveling up another specialization."));
        }


        public static MultiplicativeStrategy MultiplicativeStrategy =
            new MultiplicativeStrategy(new float[] {
                1,
                1 - 0.5f,
                1 - 0.55f,
                1 - 0.6f,
                1 - 0.65f,
                1 - 0.7f,
                1 - 0.75f,
                1 - 0.8f,
            });
        public override MultiplicativeStrategy MultiStrategy => MultiplicativeStrategy;

        public static AdditiveStrategy AdditiveStrategy =
            new AdditiveStrategy(new float[] {
                0,
                0.5f,
                0.55f,
                0.6f,
                0.65f,
                0.7f,
                0.75f,
                0.8f,
            });
        public override AdditiveStrategy AddStrategy => AdditiveStrategy;
        public override int MaxLevel { get { return 7; } }
        public override int Tier { get { return 2; } }
    }

    [Serialized]
    [LocDisplayName("Mixology Skill Book")]
    [Ecopedia("Items", "Skill Books", createAsSubPage: true)]
    public partial class MixologySkillBook : SkillBook<MixologySkill, MixologySkillScroll> { }

    [Serialized]
    [LocDisplayName("Mixology Skill Scroll")]
    public partial class MixologySkillScroll : SkillScroll<MixologySkill, MixologySkillBook> { }


    [RequiresSkill(typeof(CampfireCookingSkill), 3)]
    public partial class MixologySkillBookRecipe : RecipeFamily
    {
        public MixologySkillBookRecipe()
        {
            var recipe = new Recipe();
            recipe.Init(
                "Mixology",  //noloc
                Localizer.DoStr("Mixology Skill Book"),
                new List<IngredientElement>
                {
                    new IngredientElement(typeof(CulinaryResearchPaperBasicItem), 6, typeof(CampfireCookingSkill)),
                },
                new List<CraftingElement>
                {
                    new CraftingElement<MixologySkillBook>()
                });
            this.Recipes = new List<Recipe> { recipe };
            this.LaborInCalories = CreateLaborInCaloriesValue(1000, typeof(CampfireCookingSkill));
            this.CraftMinutes = CreateCraftTimeValue(typeof(MixologySkillBookRecipe), 6, typeof(CampfireCookingSkill));
            this.ModsPreInitialize();
            this.Initialize(Localizer.DoStr("Mixology Skill Book"), typeof(MixologySkillBookRecipe));
            this.ModsPostInitialize();
            CraftingComponent.AddRecipe(typeof(ResearchTableObject), this);
        }

        /// <summary>Hook for mods to customize RecipeFamily before initialization. You can change recipes, xp, labor, time here.</summary>
        partial void ModsPreInitialize();
        /// <summary>Hook for mods to customize RecipeFamily after initialization, but before registration. You can change skill requirements here.</summary>
        partial void ModsPostInitialize();
    }
}
