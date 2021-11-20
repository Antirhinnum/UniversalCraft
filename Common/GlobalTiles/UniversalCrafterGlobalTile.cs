using System.Collections.Generic;
using System.Linq;
using Terraria;
using Terraria.ModLoader;
using UniversalCraft.Content.Tiles;
using UniversalCraft.DataStructures;

namespace UniversalCraft.Common.GlobalTiles
{
	public class UniversalCrafterGlobalTile : GlobalTile
	{
		public override int[] AdjTiles(int type)
		{
			if (type == ModContent.TileType<UniversalCrafterTile>())
			{
				HashSet<int> tiles = new HashSet<int>();

				foreach (StationInfo info in UniversalCraft.StationInfos)
				{
					if (info.condition is null || info.condition.Invoke())
					{
						tiles.Add(info.type);
					}
				}

				HandleChestStations(tiles);

				return tiles.ToArray();
			}

			return base.AdjTiles(type);
		}

		private void HandleChestStations(HashSet<int> tiles)
		{
			if (Main.chest is null)
			{
				return;
			}

			foreach (Chest chest in Main.chest)
			{
				if (chest is null)
				{
					continue;
				}

				if (chest.bankChest)
				{
					continue;
				}

				Tile tile = Main.tile[chest.x, chest.y];

				if (tile is null)
				{
					continue;
				}

				if (tile.type != ModContent.TileType<UniversalCrafterTile>())
				{
					continue;
				}

				IEnumerable<Item> items = chest.item.Where((item) => item != null && item.createTile > -1);
				foreach (Item item in items)
				{
					tiles.Add(item.createTile);
				}
			}
		}
	}
}