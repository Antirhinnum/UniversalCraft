using System.ComponentModel;
using Terraria.ModLoader.Config;

namespace UniversalCraft.Common.Configs;

/// <summary>
/// Allows users to configure this mod's features.
/// </summary>
[Label("$Mods.UniversalCraft.Config.Header")]
public sealed class UniversalCraftConfig : ModConfig
{
	public override ConfigScope Mode => ConfigScope.ServerSide;

	[DefaultValue(true)]
	[Label("$Mods.UniversalCraft.Config.AutoUnlockStations.Label")]
	[Tooltip("$Mods.UniversalCraft.Config.AutoUnlockStations.Tooltip")]
	public bool AutoUnlockStations { get; set; }
}