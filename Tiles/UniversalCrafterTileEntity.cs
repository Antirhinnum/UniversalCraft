using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace UniversalCraft.Tiles
{
	public class UniversalCrafterTileEntity : ModTileEntity
	{
		public int ChestIndex => Chest.FindChestByGuessing(Position.X, Position.Y);

		public override bool ValidTile(int i, int j)
		{
			Tile tile = Main.tile[i, j];
			return tile.active() && tile.type == ModContent.TileType<UniversalCrafterTile>();
		}

		public override int Hook_AfterPlacement(int i, int j, int type, int style, int direction)
		{
			if (Main.netMode == NetmodeID.MultiplayerClient)
			{
				NetMessage.SendTileSquare(Main.myPlayer, i, j - 1, 5);
				NetMessage.SendData(MessageID.TileEntityPlacement, -1, -1, null, i - 2, j - 2, Type);
				return -1;
			}
			return Place(i - 2, j - 2);
		}
	}
}