//using Terraria;
//using Terraria.ID;
//using Terraria.ModLoader;
//using UniversalCraft.Content.Tiles;

//namespace UniversalCraft
//{
//	public class UniversalCrafterGlobalItem : GlobalItem
//	{
//		public override bool UseItem(Item item, Player player)
//		{
//			if (ItemID.Sets.ExtractinatorMode[player.inventory[player.selectedItem].type] >= 0 && Main.tile[Player.tileTargetX, Player.tileTargetY].active() && Main.tile[Player.tileTargetX, Player.tileTargetY].type == ModContent.TileType<UniversalCrafterTileOLD>() && player.whoAmI == Main.myPlayer)
//			{
//				if (player.position.X / 16f - Player.tileRangeX - player.inventory[player.selectedItem].tileBoost - player.blockRange <= Player.tileTargetX && (player.position.X + player.width) / 16f + Player.tileRangeX + player.inventory[player.selectedItem].tileBoost - 1f + player.blockRange >= Player.tileTargetX && player.position.Y / 16f - Player.tileRangeY - player.inventory[player.selectedItem].tileBoost - player.blockRange <= Player.tileTargetY && (player.position.Y + player.height) / 16f + Player.tileRangeY + player.inventory[player.selectedItem].tileBoost - 2f + player.blockRange >= Player.tileTargetY && player.itemTime == 0 && player.itemAnimation > 0 && player.controlUseItem)
//				{
//					player.itemTime = (int)(player.inventory[player.selectedItem].useTime / PlayerHooks.TotalUseTimeMultiplier(player, player.inventory[player.selectedItem]));
//					Main.PlaySound(SoundID.Grab, -1, -1, 1, 1f, 0f);
//					int extractType = ItemID.Sets.ExtractinatorMode[player.inventory[player.selectedItem].type];
//					typeof(Player).GetMethod("ExtractinatorUse", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Static).Invoke(player, new object[] { extractType });
//				}
//				else
//				{
//					return false;
//				}
//			}
//			return false;
//		}
//	}
//}