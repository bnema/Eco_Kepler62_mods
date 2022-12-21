using Eco.Gameplay.Items;
using Eco.Shared.Localization;
using Eco.Shared.Utils;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Eco.Mods.TechTree
{
    public static class NMBSettings
    {
        // How many scrolls should be created per craft
        public const int OutputAmount = 1;
    }

    public partial class AdvancedBakingSkillBookRecipe
    {
        partial void ModsPreInitialize()
        {
            Recipes[0].Items.Clear();
            Recipes[0].Items.Add(new CraftingElement<AdvancedBakingSkillScroll>(NMBSettings.OutputAmount));
        }

        partial void ModsPostInitialize()
        {
            RecipeName = $"{Recipes[0].Name.AddSpacesBetweenCapitals()} Skill Scroll";
        }
    }

    public partial class AdvancedCookingSkillBookRecipe
    {
        partial void ModsPreInitialize()
        {

            Recipes[0].Items.Clear();
            Recipes[0].Items.Add(new CraftingElement<AdvancedCookingSkillScroll>(NMBSettings.OutputAmount));
        }

        partial void ModsPostInitialize()
        {
            RecipeName = $"{Recipes[0].Name.AddSpacesBetweenCapitals()} Skill Scroll";
        }
    }

    public partial class AdvancedMasonrySkillBookRecipe
    {
        partial void ModsPreInitialize()
        {
            Recipes[0].Items.Clear();
            Recipes[0].Items.Add(new CraftingElement<AdvancedMasonrySkillScroll>(NMBSettings.OutputAmount));
        }

        partial void ModsPostInitialize()
        {
            RecipeName = $"{Recipes[0].Name.AddSpacesBetweenCapitals()} Skill Scroll";
        }
    }

    public partial class AdvancedSmeltingSkillBookRecipe
    {
        partial void ModsPreInitialize()
        {
            Recipes[0].Items.Clear();
            Recipes[0].Items.Add(new CraftingElement<AdvancedSmeltingSkillScroll>(NMBSettings.OutputAmount));
        }

        partial void ModsPostInitialize()
        {
            RecipeName = $"{Recipes[0].Name.AddSpacesBetweenCapitals()} Skill Scroll";
        }
    }

    public partial class BakingSkillBookRecipe
    {
        partial void ModsPreInitialize()
        {
            Recipes[0].Items.Clear();
            Recipes[0].Items.Add(new CraftingElement<BakingSkillScroll>(NMBSettings.OutputAmount));
        }

        partial void ModsPostInitialize()
        {
            RecipeName = $"{Recipes[0].Name.AddSpacesBetweenCapitals()} Skill Scroll";
        }
    }

    public partial class BasicEngineeringSkillBookRecipe
    {
        partial void ModsPreInitialize()
        {
            Recipes[0].Items.Clear();
            Recipes[0].Items.Add(new CraftingElement<BasicEngineeringSkillScroll>(NMBSettings.OutputAmount));
        }

        partial void ModsPostInitialize()
        {
            RecipeName = $"{Recipes[0].Name.AddSpacesBetweenCapitals()} Skill Scroll";
        }
    }

    public partial class ButcherySkillBookRecipe
    {
        partial void ModsPreInitialize()
        {
            Recipes[0].Items.Clear();
            Recipes[0].Items.Add(new CraftingElement<ButcherySkillScroll>(NMBSettings.OutputAmount));
        }

        partial void ModsPostInitialize()
        {
            RecipeName = $"{Recipes[0].Name.AddSpacesBetweenCapitals()} Skill Scroll";
        }
    }

    public partial class CarpentrySkillBookRecipe
    {
        partial void ModsPreInitialize()
        {
            Recipes[0].Items.Clear();
            Recipes[0].Items.Add(new CraftingElement<CarpentrySkillScroll>(NMBSettings.OutputAmount));
        }

        partial void ModsPostInitialize()
        {
            RecipeName = $"{Recipes[0].Name.AddSpacesBetweenCapitals()} Skill Scroll";
        }
    }

    public partial class CompositesSkillBookRecipe
    {
        partial void ModsPreInitialize()
        {
            Recipes[0].Items.Clear();
            Recipes[0].Items.Add(new CraftingElement<CompositesSkillScroll>(NMBSettings.OutputAmount));
        }

        partial void ModsPostInitialize()
        {
            RecipeName = $"{Recipes[0].Name.AddSpacesBetweenCapitals()} Skill Scroll";
        }
    }

    public partial class CookingSkillBookRecipe
    {
        partial void ModsPreInitialize()
        {
            Recipes[0].Items.Clear();
            Recipes[0].Items.Add(new CraftingElement<CookingSkillScroll>(NMBSettings.OutputAmount));
        }

        partial void ModsPostInitialize()
        {
            RecipeName = $"{Recipes[0].Name.AddSpacesBetweenCapitals()} Skill Scroll";
        }
    }

    public partial class CuttingEdgeCookingSkillBookRecipe
    {
        partial void ModsPreInitialize()
        {
            Recipes[0].Items.Clear();
            Recipes[0].Items.Add(new CraftingElement<CuttingEdgeCookingSkillScroll>(NMBSettings.OutputAmount));
        }

        partial void ModsPostInitialize()
        {
            RecipeName = $"{Recipes[0].Name.AddSpacesBetweenCapitals()} Skill Scroll";
        }
    }

    public partial class ElectronicsSkillBookRecipe
    {
        partial void ModsPreInitialize()
        {
            Recipes[0].Items.Clear();
            Recipes[0].Items.Add(new CraftingElement<ElectronicsSkillScroll>(NMBSettings.OutputAmount));
        }

        partial void ModsPostInitialize()
        {
            RecipeName = $"{Recipes[0].Name.AddSpacesBetweenCapitals()} Skill Scroll";
        }
    }

    public partial class FarmingSkillBookRecipe
    {
        partial void ModsPreInitialize()
        {
            Recipes[0].Items.Clear();
            Recipes[0].Items.Add(new CraftingElement<FarmingSkillScroll>(NMBSettings.OutputAmount));
        }

        partial void ModsPostInitialize()
        {
            RecipeName = $"{Recipes[0].Name.AddSpacesBetweenCapitals()} Skill Scroll";
        }
    }

    public partial class FertilizersSkillBookRecipe
    {
        partial void ModsPreInitialize()
        {
            Recipes[0].Items.Clear();
            Recipes[0].Items.Add(new CraftingElement<FertilizersSkillScroll>(NMBSettings.OutputAmount));
        }

        partial void ModsPostInitialize()
        {
            RecipeName = $"{Recipes[0].Name.AddSpacesBetweenCapitals()} Skill Scroll";
        }
    }

    public partial class GlassworkingSkillBookRecipe
    {
        partial void ModsPreInitialize()
        {
            Recipes[0].Items.Clear();
            Recipes[0].Items.Add(new CraftingElement<GlassworkingSkillScroll>(NMBSettings.OutputAmount));
        }

        partial void ModsPostInitialize()
        {
            RecipeName = $"{Recipes[0].Name.AddSpacesBetweenCapitals()} Skill Scroll";
        }
    }

    public partial class IndustrySkillBookRecipe
    {
        partial void ModsPreInitialize()
        {
            Recipes[0].Items.Clear();
            Recipes[0].Items.Add(new CraftingElement<IndustrySkillScroll>(NMBSettings.OutputAmount));
        }

        partial void ModsPostInitialize()
        {
            RecipeName = $"{Recipes[0].Name.AddSpacesBetweenCapitals()} Skill Scroll";
        }
    }

    public partial class MasonrySkillBookRecipe
    {
        partial void ModsPreInitialize()
        {
            Recipes[0].Items.Clear();
            Recipes[0].Items.Add(new CraftingElement<MasonrySkillScroll>(NMBSettings.OutputAmount));
        }

        partial void ModsPostInitialize()
        {
            RecipeName = $"{Recipes[0].Name.AddSpacesBetweenCapitals()} Skill Scroll";
        }
    }

    public partial class MechanicsSkillBookRecipe
    {
        partial void ModsPreInitialize()
        {
            Recipes[0].Items.Clear();
            Recipes[0].Items.Add(new CraftingElement<MechanicsSkillScroll>(NMBSettings.OutputAmount));
        }

        partial void ModsPostInitialize()
        {
            RecipeName = $"{Recipes[0].Name.AddSpacesBetweenCapitals()} Skill Scroll";
        }
    }

    public partial class MillingSkillBookRecipe
    {
        partial void ModsPreInitialize()
        {
            Recipes[0].Items.Clear();
            Recipes[0].Items.Add(new CraftingElement<MillingSkillScroll>(NMBSettings.OutputAmount));
        }

        partial void ModsPostInitialize()
        {
            RecipeName = $"{Recipes[0].Name.AddSpacesBetweenCapitals()} Skill Scroll";
        }
    }

    public partial class OilDrillingSkillBookRecipe
    {
        partial void ModsPreInitialize()
        {
            Recipes[0].Items.Clear();
            Recipes[0].Items.Add(new CraftingElement<OilDrillingSkillScroll>(NMBSettings.OutputAmount));
        }

        partial void ModsPostInitialize()
        {
            RecipeName = $"{Recipes[0].Name.AddSpacesBetweenCapitals()} Skill Scroll";
        }
    }

    public partial class PaperMillingSkillBookRecipe
    {
        partial void ModsPreInitialize()
        {
            Recipes[0].Items.Clear();
            Recipes[0].Items.Add(new CraftingElement<PaperMillingSkillScroll>(NMBSettings.OutputAmount));
        }

        partial void ModsPostInitialize()
        {
            RecipeName = $"{Recipes[0].Name.AddSpacesBetweenCapitals()} Skill Scroll";
        }
    }

    public partial class PotterySkillBookRecipe
    {
        partial void ModsPreInitialize()
        {
            Recipes[0].Items.Clear();
            Recipes[0].Items.Add(new CraftingElement<PotterySkillScroll>(NMBSettings.OutputAmount));
        }

        partial void ModsPostInitialize()
        {
            RecipeName = $"{Recipes[0].Name.AddSpacesBetweenCapitals()} Skill Scroll";
        }
    }

    public partial class SmeltingSkillBookRecipe
    {
        partial void ModsPreInitialize()
        {
            Recipes[0].Items.Clear();
            Recipes[0].Items.Add(new CraftingElement<SmeltingSkillScroll>(NMBSettings.OutputAmount));
        }

        partial void ModsPostInitialize()
        {
            RecipeName = $"{Recipes[0].Name.AddSpacesBetweenCapitals()} Skill Scroll";
        }
    }

    public partial class TailoringSkillBookRecipe
    {
        partial void ModsPreInitialize()
        {
            Recipes[0].Items.Clear();
            Recipes[0].Items.Add(new CraftingElement<TailoringSkillScroll>(NMBSettings.OutputAmount));
        }

        partial void ModsPostInitialize()
        {
            RecipeName = $"{Recipes[0].Name.AddSpacesBetweenCapitals()} Skill Scroll";
        }
    }
}
