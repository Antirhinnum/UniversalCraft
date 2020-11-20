using System.Collections.Generic;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace UniversalCraft.Tiles
{
	public class UniversalCrafterGlobalTile : GlobalTile
	{
		public override int[] AdjTiles(int type)
		{
			if (type == ModContent.TileType<UniversalCrafterTile>())
			{
				List<int> adjTile = new List<int>();

				Main.LocalPlayer.adjWater = true;
				Main.LocalPlayer.adjLava = true;
				Main.LocalPlayer.adjHoney = true;

				if (NPC.downedSlimeKing)
				{
					adjTile.Add(TileID.Solidifier);
				}
				if (NPC.downedGoblins)
				{
					adjTile.Add(TileID.TinkerersWorkbench);
				}
				if (NPC.downedBoss3)
				{
					adjTile.Add(TileID.BoneWelder);
					adjTile.Add(TileID.AlchemyTable);
					Main.LocalPlayer.alchemyTable = true;
				}
				if (NPC.downedQueenBee)
				{
					adjTile.Add(TileID.ImbuingStation);
				}
				if (Main.hardMode)
				{
					adjTile.Add(TileID.MeatGrinder);
					adjTile.Add(TileID.MythrilAnvil);
					adjTile.Add(TileID.CrystalBall);
					adjTile.Add(TileID.AdamantiteForge);
				}
				if (NPC.downedMechBossAny)
				{
					adjTile.Add(TileID.SteampunkBoiler);
					adjTile.Add(TileID.FleshCloningVat);
					adjTile.Add(TileID.Blendomatic);
				}
				if (NPC.downedPlantBoss)
				{
					adjTile.Add(TileID.Autohammer);
					adjTile.Add(TileID.LihzahrdFurnace);
				}
				if (NPC.downedAncientCultist)
				{
					adjTile.Add(TileID.LunarCraftingStation);
				}

				HandleModdedStations(ref adjTile);
				HandleChestStations(ref adjTile);

				return adjTile.ToArray();
			}

			return base.AdjTiles(type);
		}

		private void HandleModdedStations(ref List<int> adjTile)
		{
			foreach (StationInfo info in UniversalCraft.moddedStations)
			{
				if (info.condition.Invoke())
				{
					adjTile.Add(info.type);
				}
			}
		}

		private void HandleChestStations(ref List<int> adjTile)
		{
			int universalTileEntityType = ModContent.TileEntityType<UniversalCrafterTileEntity>();

			foreach (TileEntity current in TileEntity.ByID.Values)
			{
				if (current.type != universalTileEntityType)
				{
					continue;
				}

				UniversalCrafterTileEntity station = current as UniversalCrafterTileEntity;
				if (station.ChestIndex != -1)
				{
					foreach (Item item in Main.chest[station.ChestIndex].item)
					{
						if (item?.createTile > -1)
						{
							adjTile.Add(item.createTile);
						}
					}
				}
			}
		}
	}
}