using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using UniversalCraft.Tiles;

namespace UniversalCraft
{
	public class UniversalCrafterGlobalItem : GlobalItem
	{
		public override bool UseItem(Item item, Player player)
		{
			if (ItemID.Sets.ExtractinatorMode[player.inventory[player.selectedItem].type] >= 0 && Main.tile[Player.tileTargetX, Player.tileTargetY].active() && Main.tile[Player.tileTargetX, Player.tileTargetY].type == ModContent.TileType<UniversalCrafterTile>() && player.whoAmI == Main.myPlayer)
			{
				if (player.position.X / 16f - Player.tileRangeX - player.inventory[player.selectedItem].tileBoost - player.blockRange <= Player.tileTargetX && (player.position.X + player.width) / 16f + Player.tileRangeX + player.inventory[player.selectedItem].tileBoost - 1f + player.blockRange >= Player.tileTargetX && player.position.Y / 16f - Player.tileRangeY - player.inventory[player.selectedItem].tileBoost - player.blockRange <= Player.tileTargetY && (player.position.Y + player.height) / 16f + Player.tileRangeY + player.inventory[player.selectedItem].tileBoost - 2f + player.blockRange >= Player.tileTargetY && player.itemTime == 0 && player.itemAnimation > 0 && player.controlUseItem)
				{
					player.itemTime = (int)(player.inventory[player.selectedItem].useTime / PlayerHooks.TotalUseTimeMultiplier(player, player.inventory[player.selectedItem]));
					Main.PlaySound(SoundID.Grab, -1, -1, 1, 1f, 0f);
					int extractType = ItemID.Sets.ExtractinatorMode[player.inventory[player.selectedItem].type];
					ExtractinatorUse(extractType);
				}
				else
				{
					return false;
				}
			}
			return false;
		}

		private static void ExtractinatorUse(int extractType)
		{
			int num = 5000;
			int num2 = 25;
			int num3 = 50;
			int num4 = -1;
			if (extractType == 3347)
			{
				num /= 3;
				num2 *= 2;
				num3 /= 2;
				num4 = 10;
			}
			int num5 = 1;
			int num6 = 0;
			if (num4 != -1 && Main.rand.Next(num4) == 0)
			{
				num6 = 3380;
				if (Main.rand.Next(5) == 0)
				{
					num5 += Main.rand.Next(2);
				}
				if (Main.rand.Next(10) == 0)
				{
					num5 += Main.rand.Next(3);
				}
				if (Main.rand.Next(15) == 0)
				{
					num5 += Main.rand.Next(4);
				}
			}
			else if (Main.rand.Next(2) == 0)
			{
				if (Main.rand.Next(12000) == 0)
				{
					num6 = 74;
					if (Main.rand.Next(14) == 0)
					{
						num5 += Main.rand.Next(0, 2);
					}
					if (Main.rand.Next(14) == 0)
					{
						num5 += Main.rand.Next(0, 2);
					}
					if (Main.rand.Next(14) == 0)
					{
						num5 += Main.rand.Next(0, 2);
					}
				}
				else if (Main.rand.Next(800) == 0)
				{
					num6 = 73;
					if (Main.rand.Next(6) == 0)
					{
						num5 += Main.rand.Next(1, 21);
					}
					if (Main.rand.Next(6) == 0)
					{
						num5 += Main.rand.Next(1, 21);
					}
					if (Main.rand.Next(6) == 0)
					{
						num5 += Main.rand.Next(1, 21);
					}
					if (Main.rand.Next(6) == 0)
					{
						num5 += Main.rand.Next(1, 21);
					}
					if (Main.rand.Next(6) == 0)
					{
						num5 += Main.rand.Next(1, 20);
					}
				}
				else if (Main.rand.Next(60) == 0)
				{
					num6 = 72;
					if (Main.rand.Next(4) == 0)
					{
						num5 += Main.rand.Next(5, 26);
					}
					if (Main.rand.Next(4) == 0)
					{
						num5 += Main.rand.Next(5, 26);
					}
					if (Main.rand.Next(4) == 0)
					{
						num5 += Main.rand.Next(5, 26);
					}
					if (Main.rand.Next(4) == 0)
					{
						num5 += Main.rand.Next(5, 25);
					}
				}
				else
				{
					num6 = 71;
					if (Main.rand.Next(3) == 0)
					{
						num5 += Main.rand.Next(10, 26);
					}
					if (Main.rand.Next(3) == 0)
					{
						num5 += Main.rand.Next(10, 26);
					}
					if (Main.rand.Next(3) == 0)
					{
						num5 += Main.rand.Next(10, 26);
					}
					if (Main.rand.Next(3) == 0)
					{
						num5 += Main.rand.Next(10, 25);
					}
				}
			}
			else if (num != -1 && Main.rand.Next(num) == 0)
			{
				num6 = 1242;
			}
			else if (num2 != -1 && Main.rand.Next(num2) == 0)
			{
				num6 = Main.rand.Next(6);
				switch (num6)
				{
					case 0:
						num6 = 181;
						break;

					case 1:
						num6 = 180;
						break;

					case 2:
						num6 = 177;
						break;

					case 3:
						num6 = 179;
						break;

					case 4:
						num6 = 178;
						break;

					default:
						num6 = 182;
						break;
				}
				if (Main.rand.Next(20) == 0)
				{
					num5 += Main.rand.Next(0, 2);
				}
				if (Main.rand.Next(30) == 0)
				{
					num5 += Main.rand.Next(0, 3);
				}
				if (Main.rand.Next(40) == 0)
				{
					num5 += Main.rand.Next(0, 4);
				}
				if (Main.rand.Next(50) == 0)
				{
					num5 += Main.rand.Next(0, 5);
				}
				if (Main.rand.Next(60) == 0)
				{
					num5 += Main.rand.Next(0, 6);
				}
			}
			else if (num3 != -1 && Main.rand.Next(num3) == 0)
			{
				num6 = 999;
				if (Main.rand.Next(20) == 0)
				{
					num5 += Main.rand.Next(0, 2);
				}
				if (Main.rand.Next(30) == 0)
				{
					num5 += Main.rand.Next(0, 3);
				}
				if (Main.rand.Next(40) == 0)
				{
					num5 += Main.rand.Next(0, 4);
				}
				if (Main.rand.Next(50) == 0)
				{
					num5 += Main.rand.Next(0, 5);
				}
				if (Main.rand.Next(60) == 0)
				{
					num5 += Main.rand.Next(0, 6);
				}
			}
			else if (Main.rand.Next(3) == 0)
			{
				if (Main.rand.Next(5000) == 0)
				{
					num6 = 74;
					if (Main.rand.Next(10) == 0)
					{
						num5 += Main.rand.Next(0, 3);
					}
					if (Main.rand.Next(10) == 0)
					{
						num5 += Main.rand.Next(0, 3);
					}
					if (Main.rand.Next(10) == 0)
					{
						num5 += Main.rand.Next(0, 3);
					}
					if (Main.rand.Next(10) == 0)
					{
						num5 += Main.rand.Next(0, 3);
					}
					if (Main.rand.Next(10) == 0)
					{
						num5 += Main.rand.Next(0, 3);
					}
				}
				else if (Main.rand.Next(400) == 0)
				{
					num6 = 73;
					if (Main.rand.Next(5) == 0)
					{
						num5 += Main.rand.Next(1, 21);
					}
					if (Main.rand.Next(5) == 0)
					{
						num5 += Main.rand.Next(1, 21);
					}
					if (Main.rand.Next(5) == 0)
					{
						num5 += Main.rand.Next(1, 21);
					}
					if (Main.rand.Next(5) == 0)
					{
						num5 += Main.rand.Next(1, 21);
					}
					if (Main.rand.Next(5) == 0)
					{
						num5 += Main.rand.Next(1, 20);
					}
				}
				else if (Main.rand.Next(30) == 0)
				{
					num6 = 72;
					if (Main.rand.Next(3) == 0)
					{
						num5 += Main.rand.Next(5, 26);
					}
					if (Main.rand.Next(3) == 0)
					{
						num5 += Main.rand.Next(5, 26);
					}
					if (Main.rand.Next(3) == 0)
					{
						num5 += Main.rand.Next(5, 26);
					}
					if (Main.rand.Next(3) == 0)
					{
						num5 += Main.rand.Next(5, 25);
					}
				}
				else
				{
					num6 = 71;
					if (Main.rand.Next(2) == 0)
					{
						num5 += Main.rand.Next(10, 26);
					}
					if (Main.rand.Next(2) == 0)
					{
						num5 += Main.rand.Next(10, 26);
					}
					if (Main.rand.Next(2) == 0)
					{
						num5 += Main.rand.Next(10, 26);
					}
					if (Main.rand.Next(2) == 0)
					{
						num5 += Main.rand.Next(10, 25);
					}
				}
			}
			else
			{
				num6 = Main.rand.Next(8);
				switch (num6)
				{
					case 0:
						num6 = 12;
						break;

					case 1:
						num6 = 11;
						break;

					case 2:
						num6 = 14;
						break;

					case 3:
						num6 = 13;
						break;

					case 4:
						num6 = 699;
						break;

					case 5:
						num6 = 700;
						break;

					case 6:
						num6 = 701;
						break;

					default:
						num6 = 702;
						break;
				}
				if (Main.rand.Next(20) == 0)
				{
					num5 += Main.rand.Next(0, 2);
				}
				if (Main.rand.Next(30) == 0)
				{
					num5 += Main.rand.Next(0, 3);
				}
				if (Main.rand.Next(40) == 0)
				{
					num5 += Main.rand.Next(0, 4);
				}
				if (Main.rand.Next(50) == 0)
				{
					num5 += Main.rand.Next(0, 5);
				}
				if (Main.rand.Next(60) == 0)
				{
					num5 += Main.rand.Next(0, 6);
				}
			}
			ItemLoader.ExtractinatorUse(ref num6, ref num5, extractType);
			if (num6 > 0)
			{
				Vector2 vector = Main.ReverseGravitySupport(Main.MouseScreen, 0f) + Main.screenPosition;
				int number = Item.NewItem((int)vector.X, (int)vector.Y, 1, 1, num6, num5, false, -1, false, false);
				if (Main.netMode == NetmodeID.MultiplayerClient)
				{
					NetMessage.SendData(MessageID.SyncItem, -1, -1, null, number, 1f, 0f, 0f, 0, 0, 0);
				}
			}
		}
	}
}