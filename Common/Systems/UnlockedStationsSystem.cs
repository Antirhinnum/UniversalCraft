using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.Localization;
using Terraria.Map;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;
using UniversalCraft.Common.Configs;
using UniversalCraft.Custom;

namespace UniversalCraft.Common.Systems;

public sealed class UnlockedStationsSystem : ModSystem
{
	private const string _vanillaModName = "Terraria";
	private const string _saveFormat = "{0}:{1}";

	/// <summary>
	/// A temporary set of all tile IDs unlocked automatically.
	/// </summary>
	private static HashSet<int> _autoUnlockedTiles;

	/// <summary>
	/// The set of all manually-unlocked tile IDs for this world.
	/// </summary>
	private static HashSet<int> _manuallyUnlockedTiles;

	/// <summary>
	/// The set of all manually-unlocked tile IDs for this world that are from unloaded mods.
	/// </summary>
	private static HashSet<string> _unloadedManuallyUnlockedTiles;

	/// <summary>
	/// The set of all tiles used as crafting stations in recipes.
	/// </summary>
	private static HashSet<int> _craftingStations;

	/// <summary>
	/// The set of all tiles that aren't used as crafting stations in recipes, but should still be addable to the Universal Crafter.
	/// </summary>
	private static readonly HashSet<int> _otherStations = new()
	{
		TileID.Extractinator,
		TileID.ChlorophyteExtractinator  
	};

	/// <summary>
	/// The set of all unlocked tile IDs.
	/// </summary>
	public static HashSet<int> UnlockedStations
	{
		get
		{
			ProcessAutoUnlockStations();
			return _autoUnlockedTiles.Union(_manuallyUnlockedTiles).ToHashSet();
		}
	}

	/// <summary>
	/// A list of all auto-unlockable stations.
	/// </summary>
	public static List<StationInfo> StationInfos { get; set; }

	public override void SetStaticDefaults()
	{
		_autoUnlockedTiles = new(TileLoader.TileCount);
		_manuallyUnlockedTiles = new(TileLoader.TileCount);
		_unloadedManuallyUnlockedTiles = new();
		_craftingStations = new();

		StationInfos = new List<StationInfo>()
		{
			new StationInfo(TileID.WorkBenches),
			new StationInfo(TileID.Furnaces),
			new StationInfo(TileID.Anvils),
			new StationInfo(TileID.Bookcases),
			new StationInfo(TileID.Bottles),
			new StationInfo(TileID.Chairs),
			new StationInfo(TileID.Tables),
			new StationInfo(TileID.Tables2),
			new StationInfo(TileID.CookingPots),
			new StationInfo(TileID.Containers),
			new StationInfo(TileID.Containers2),
			new StationInfo(TileID.DemonAltar),
			new StationInfo(TileID.DyeVat),
			new StationInfo(TileID.Extractinator),
			new StationInfo(TileID.GlassKiln),
			new StationInfo(TileID.HeavyWorkBench),
			new StationInfo(TileID.IceMachine),
			new StationInfo(TileID.Kegs),
			new StationInfo(TileID.LivingLoom),
			new StationInfo(TileID.Loom),
			new StationInfo(TileID.Sawmill),
			new StationInfo(TileID.Sinks),
			new StationInfo(TileID.SkyMill),
			new StationInfo(TileID.Tombstones),
			new StationInfo(TileID.Solidifier, () => NPC.downedSlimeKing),
			new StationInfo(TileID.Hellforge, () => NPC.downedBoss2),
			new StationInfo(TileID.BoneWelder, () => NPC.downedBoss3),
			new StationInfo(TileID.AlchemyTable, () => NPC.downedBoss3),
			new StationInfo(TileID.TeaKettle, () => NPC.downedBoss3),
			new StationInfo(TileID.TinkerersWorkbench, () => NPC.savedGoblin),
			new StationInfo(TileID.ImbuingStation, () => NPC.downedQueenBee),
			new StationInfo(TileID.HoneyDispenser, () => NPC.downedQueenBee),
			new StationInfo(TileID.MeatGrinder, () => Main.hardMode),
			new StationInfo(TileID.MythrilAnvil, () => Main.hardMode),
			new StationInfo(TileID.AdamantiteForge, () => Main.hardMode),
			new StationInfo(TileID.CrystalBall, () => NPC.savedWizard),
			new StationInfo(TileID.SteampunkBoiler, () => NPC.downedMechBossAny),
			new StationInfo(TileID.LesionStation, () => NPC.downedMechBossAny),
			new StationInfo(TileID.FleshCloningVat, () => NPC.downedMechBossAny),
			new StationInfo(TileID.Blendomatic, () => NPC.downedMechBossAny),
			new StationInfo(TileID.Autohammer, () => NPC.downedPlantBoss),
			new StationInfo(TileID.LihzahrdFurnace, () => NPC.downedPlantBoss),
			new StationInfo(TileID.LunarCraftingStation, () => NPC.downedAncientCultist)
		};
	}

	public override void PostSetupRecipes()
	{
		_craftingStations = Main.recipe.SelectMany(r => r.requiredTile).ToHashSet();
	}

	/// <summary>
	/// Adds a tile and, optionally, all tiles it counts as.
	/// </summary>
	/// <param name="tileId">The tile to add.</param>
	/// <param name="quiet">If <see langword="true"/>, don't send new tiles anywhere.</param>
	public static void AddTile(int tileId, bool quiet = true)
	{
		int[] before = new int[_manuallyUnlockedTiles.Count];
		_manuallyUnlockedTiles.CopyTo(before);
		HashSet<int> beforeSet = new(before);
		AddTile_Inner(tileId);
		if (beforeSet.Count != _manuallyUnlockedTiles.Count)
		{
			if (!Main.dedServ)
			{
				Main.NewText(Language.GetTextValue("Mods.UniversalCraft.Misc.AddedStation"));
				SoundEngine.PlaySound(SoundID.MaxMana);
			}

			if (!quiet && Main.netMode != NetmodeID.SinglePlayer)
			{
				int[] newTiles = _manuallyUnlockedTiles.Except(before).ToArray();
				ModPacket packet = ModContent.GetInstance<UniversalCraft>().GetPacket();
				packet.Write((byte)UniversalCraft.PacketType.SendNewTilesToServer);
				packet.Write7BitEncodedInt(newTiles.Length);
				foreach (int newTile in newTiles)
				{
					packet.Write7BitEncodedInt(newTile);
				}
				packet.Send(ignoreClient: Main.myPlayer);
			}
		}
		else if (!Main.dedServ)
		{
			Main.NewText(Language.GetTextValue("Mods.UniversalCraft.Misc.NoRecipeStation"));
			SoundEngine.PlaySound(SoundID.Tink);
		}
	}

	/// <inheritdoc cref="AddTile(int)"/>
	private static void AddTile_Inner(int tileId)
	{
		if (!_craftingStations.Contains(tileId) && !_otherStations.Contains(tileId))
		{
			return;
		}

		if (tileId < TileID.Count)
		{
			switch (tileId)
			{
				case TileID.Hellforge:
				case TileID.GlassKiln:
					_manuallyUnlockedTiles.Add(TileID.Furnaces);
					break;

				case TileID.AdamantiteForge:
					_manuallyUnlockedTiles.Add(TileID.Furnaces);
					_manuallyUnlockedTiles.Add(TileID.Hellforge);
					break;

				case TileID.MythrilAnvil:
					_manuallyUnlockedTiles.Add(TileID.Anvils);
					break;

				case TileID.BewitchingTable:
				case TileID.Tables2:
				case TileID.PicnicTable:
					_manuallyUnlockedTiles.Add(TileID.Tables);
					break;

				case TileID.AlchemyTable:
					_manuallyUnlockedTiles.Add(TileID.Bottles);
					_manuallyUnlockedTiles.Add(TileID.Tables);
					break;

				case TileID.ChlorophyteExtractinator:
					_manuallyUnlockedTiles.Add(TileID.Extractinator);
					break; 
			}
		}
		else
		{
			ModTile tile = TileLoader.GetTile(tileId);
			foreach (int id in tile.AdjTiles)
			{
				_manuallyUnlockedTiles.Add(id);
			}
		}

		_manuallyUnlockedTiles.Add(tileId);
	}

	private static void ProcessAutoUnlockStations()
	{
		_autoUnlockedTiles = new(TileLoader.TileCount);

		if (!ModContent.GetInstance<UniversalCraftConfig>().AutoUnlockStations)
		{
			return;
		}

		foreach (StationInfo info in StationInfos)
		{
			if (info.condition?.Invoke() ?? true)
			{
				_autoUnlockedTiles.Add(info.type);
			}
		}
	}

	public static void DisplayStations()
	{
		if (Main.dedServ)
		{
			return;
		}

		HashSet<int> unlockedStations = UnlockedStations;
		List<string> names = unlockedStations.Select(id => MapHelper.TileToLookup(id, 0)).Select(Lang.GetMapObjectName).Where(name => !string.IsNullOrEmpty(name)).Distinct().ToList();
		if (names.Count > 0)
		{
			names.Sort();
			Main.NewTextMultiline(Language.GetTextValue("Mods.UniversalCraft.Misc.TileListing") + ": " + string.Join(", ", names), c: Color.White);
		}
		else
		{
			Main.NewText(Language.GetTextValue("Mods.UniversalCraft.Misc.NoTiles"));
		}

		if (unlockedStations.Contains(TileID.ChlorophyteExtractinator))
		{
			Main.NewText(Language.GetTextValue("Mods.UniversalCraft.Misc.ChlorophyteExtractinatorAllowed"));
		}
		else if (unlockedStations.Contains(TileID.Extractinator))
		{
			Main.NewText(Language.GetTextValue("Mods.UniversalCraft.Misc.ExtractinatorAllowed"));
		}
	}

	public override void NetSend(BinaryWriter writer)
	{
		// Only send manually unlocked tiles.
		// Auto-unlocked should run on each client, and unloaded only matter to the host.
		writer.Write7BitEncodedInt(_manuallyUnlockedTiles.Count);
		foreach (int id in _manuallyUnlockedTiles)
		{
			writer.Write7BitEncodedInt(id);
		}
	}

	public override void NetReceive(BinaryReader reader)
	{
		int count = reader.Read7BitEncodedInt();
		for (int i = 0; i < count; i++)
		{
			_manuallyUnlockedTiles.Add(reader.Read7BitEncodedInt());
		}
	}

	public override void SaveWorldData(TagCompound tag)
	{
		// Data is saved as strings so mod names can be used.
		// Just saving the IDs would lead to potentially unlocking the wrong tile(s) if mods changed.
		List<string> unlockedTiles = new();

		foreach (int id in _manuallyUnlockedTiles)
		{
			string modName = _vanillaModName;
			string persistentId;
			if (id >= TileID.Count)
			{
				ModTile modTile = TileLoader.GetTile(id);
				modName = modTile.Mod.Name;
				persistentId = modTile.Name;
			}
			else
			{
				persistentId = TileID.Search.GetName(id);
			}

			unlockedTiles.Add(string.Format(_saveFormat, modName, persistentId));
		}

		unlockedTiles.AddRange(_unloadedManuallyUnlockedTiles);

		tag.Add(nameof(unlockedTiles), unlockedTiles);
	}

	public override void LoadWorldData(TagCompound tag)
	{
		_manuallyUnlockedTiles = new(TileLoader.TileCount);
		_unloadedManuallyUnlockedTiles = new();
		IList<string> unlockedTiles = tag.GetList<string>(nameof(unlockedTiles));

		foreach (string savedId in unlockedTiles)
		{
			string[] split = savedId.Split(':');
			if (split.Length != 2)
			{
				Mod.Logger.Warn($"Attempted to load tile \"{savedId}\", which doesn't follow the save format. Skipped.");
				continue;
			}

			string modName = split[0];
			string persistentId = split[1];

			if (modName == _vanillaModName)
			{
				if (!TileID.Search.TryGetId(persistentId, out int id))
				{
					Mod.Logger.Warn($"Attempted to load unrecognized vanilla tile \"{savedId}\". Skipped.");
					continue;
				}

				_manuallyUnlockedTiles.Add(id);
			}
			else
			{
				if (!ModLoader.TryGetMod(modName, out Mod otherMod))
				{
					_unloadedManuallyUnlockedTiles.Add(savedId);
					continue;
				}

				if (!otherMod.TryFind(persistentId, out ModTile modTile))
				{
					Mod.Logger.Warn($"Attempted to load ModTile \"{persistentId}\" from the mod \"{otherMod.DisplayName}\", but it doesn't exist. Skipped.");
					continue;
				}

				_manuallyUnlockedTiles.Add(modTile.Type);
			}
		}
	}
}