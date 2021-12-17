using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using UniversalCraft.DataStructures;
using UniversalCraft.Enums;

namespace UniversalCraft
{
	public class UniversalCraft : Mod
	{
		private const string UNKNOWN_MESSAGE_KEY = "Mods.UniversalCraft.Misc.UnknownMessage";
		private const string CALL_ERROR_KEY = "Mods.UniversalCraft.Misc.CallError";
		public static UniversalCraft Instance => ModContent.GetInstance<UniversalCraft>();
		public static List<StationInfo> StationInfos { get; set; }

		public UniversalCraft()
		{
		}

		public override void Load()
		{
			StationInfos = new List<StationInfo>()
			{
				new StationInfo(TileID.WorkBenches,				() => true),
				new StationInfo(TileID.Furnaces,				() => true),
				new StationInfo(TileID.Anvils,					() => true),
				new StationInfo(TileID.Bookcases,				() => true),
				new StationInfo(TileID.Bottles,					() => true),
				new StationInfo(TileID.Chairs,					() => true),
				new StationInfo(TileID.Tables,					() => true),
				new StationInfo(TileID.Tables2,					() => true),
				new StationInfo(TileID.CookingPots,				() => true),
				new StationInfo(TileID.Containers,				() => true),
				new StationInfo(TileID.Containers2,				() => true),
				new StationInfo(TileID.DyeVat,					() => true),
				new StationInfo(TileID.GlassKiln,				() => true),
				new StationInfo(TileID.HeavyWorkBench,			() => true),
				new StationInfo(TileID.IceMachine,				() => true),
				new StationInfo(TileID.Kegs,					() => true),
				new StationInfo(TileID.LivingLoom,				() => true),
				new StationInfo(TileID.Loom,					() => true),
				new StationInfo(TileID.Sawmill,					() => true),
				new StationInfo(TileID.SkyMill,					() => true),
				new StationInfo(TileID.Solidifier,				() => NPC.downedSlimeKing),
				new StationInfo(TileID.DemonAltar,				() => NPC.downedBoss1),
				new StationInfo(TileID.Hellforge,				() => NPC.downedBoss2),
				new StationInfo(TileID.BoneWelder,				() => NPC.downedBoss3),
				new StationInfo(TileID.AlchemyTable,			() => NPC.downedBoss3),
				new StationInfo(TileID.TinkerersWorkbench,		() => NPC.downedGoblins),
				new StationInfo(TileID.ImbuingStation,			() => NPC.downedQueenBee),
				new StationInfo(TileID.HoneyDispenser,			() => NPC.downedQueenBee),
				new StationInfo(TileID.MeatGrinder,				() => Main.hardMode),
				new StationInfo(TileID.MythrilAnvil,			() => Main.hardMode),
				new StationInfo(TileID.AdamantiteForge,			() => Main.hardMode),
				new StationInfo(TileID.CrystalBall,				() => Main.hardMode),
				new StationInfo(TileID.SteampunkBoiler,			() => NPC.downedMechBossAny),
				new StationInfo(TileID.FleshCloningVat,			() => NPC.downedMechBossAny),
				new StationInfo(TileID.Blendomatic,				() => NPC.downedMechBossAny),
				new StationInfo(TileID.Autohammer,				() => NPC.downedPlantBoss),
				new StationInfo(TileID.LihzahrdFurnace,			() => NPC.downedPlantBoss),
				new StationInfo(TileID.LunarCraftingStation,	() => NPC.downedAncientCultist)
			};
		}

		public override void Unload()
		{
			StationInfos.Clear();
			StationInfos = null;
		}

		public override object Call(params object[] args)
		{
			try
			{
				CallType callType = (CallType)Convert.ToByte(args[0]);
				switch (callType)
				{
					case CallType.AddStation:
						if (args.Length > 2)
						{
							AddStation(Convert.ToUInt16(args[1]), (Func<bool>)args[2]);
							break;
						}
						AddStation(Convert.ToUInt16(args[1]));
						break;

					default:
						Instance.Logger.Warn(Language.GetTextValue(UNKNOWN_MESSAGE_KEY, args[0]));
						break;
				}

				return base.Call(args);
			}
			catch (Exception e)
			{
				Logger.Error(Language.GetTextValue(CALL_ERROR_KEY) + e.StackTrace + e.Message);
				return null;
			}
		}

		private void AddStation(ushort type, Func<bool> condition = null)
		{
			StationInfos.Add(new StationInfo(type, condition));
		}
	}
}