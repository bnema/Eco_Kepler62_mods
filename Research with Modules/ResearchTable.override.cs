namespace Eco.Mods.TechTree
{
    using Eco.Gameplay.Components;
    using Eco.Gameplay.Modules;
    using Eco.Gameplay.Objects;

    [RequireComponent(typeof(PluginModulesComponent))]
    public partial class ResearchTableObject
    {
    }

    [AllowPluginModules(Tags = new[] { "ResearchUpgrade" }, ItemTypes = new[] { typeof(TerminusUpgradeItem) })]
    public partial class ResearchTableItem
    {
    }
}