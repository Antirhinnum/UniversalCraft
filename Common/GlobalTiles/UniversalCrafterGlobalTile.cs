using System.Linq;
using Terraria;
using Terraria.ModLoader;
using UniversalCraft.Common.Systems;
using UniversalCraft.Content.Tiles;

namespace UniversalCraft.Common.GlobalTiles;

internal sealed class UniversalCrafterGlobalTile : GlobalTile
{
	public override void Load()
	{
		On.Terraria.Recipe.FindRecipes += SpecialRecipeConditions;
	}

	public override void Unload()
	{
		On.Terraria.Recipe.FindRecipes -= SpecialRecipeConditions;
	}

	/// <summary>
	/// Hacky workaround for graveyard &amp; snow requirements.
	/// </summary>
	private static void SpecialRecipeConditions(On.Terraria.Recipe.orig_FindRecipes orig, bool canDelayCheck)
	{
		Player player = Main.LocalPlayer;
		bool oldZoneSnow = player.ZoneSnow;
		bool oldZoneGraveyard = player.ZoneGraveyard;

		if (player.adjTile[ModContent.TileType<UniversalCrafterTile>()])
		{
			player.ZoneSnow = true;
			player.ZoneGraveyard = true;
		}

		orig(canDelayCheck);

		player.ZoneSnow = oldZoneSnow;
		player.ZoneGraveyard = oldZoneGraveyard;
	}

	public override int[] AdjTiles(int type)
	{
		return type == ModContent.TileType<UniversalCrafterTile>() ? UnlockedStationsSystem.UnlockedStations.ToArray() : base.AdjTiles(type);
	}
}