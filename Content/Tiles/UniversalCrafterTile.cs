using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.Enums;
using Terraria.GameContent.ObjectInteractions;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ObjectData;
using TileFunctionLibrary.API;
using UniversalCraft.Common.Systems;
using UniversalCraft.Content.Items.Placeable;

namespace UniversalCraft.Content.Tiles;

public sealed class UniversalCrafterTile : ModTile, IExtractinatorTile
{
	bool IExtractinatorTile.ShouldFunctionAsExtractinator => UnlockedStationsSystem.UnlockedStations.Contains(TileID.Extractinator);

	public override void SetStaticDefaults()
	{
		Main.tileSpelunker[Type] = true;
		Main.tileShine2[Type] = true;
		Main.tileShine[Type] = 1200;
		Main.tileFrameImportant[Type] = true;
		Main.tileNoAttach[Type] = true;
		Main.tileOreFinderPriority[Type] = 10;
		TileID.Sets.CountsAsHoneySource[Type] = true;
		TileID.Sets.CountsAsLavaSource[Type] = true;
		TileID.Sets.CountsAsWaterSource[Type] = true;
		TileID.Sets.DisableSmartCursor[Type] = true;
		TileID.Sets.HasOutlines[Type] = true;

		TileObjectData.newTile.CopyFrom(TileObjectData.Style5x4);
		TileObjectData.newTile.Height = 3;
		TileObjectData.newTile.Origin = new Point16(2, 2);
		TileObjectData.newTile.CoordinateHeights = new int[] { 16, 16, 16 };
		TileObjectData.newTile.LavaDeath = false;
		TileObjectData.newTile.AnchorBottom = new AnchorData(AnchorType.SolidTile | AnchorType.SolidWithTop | AnchorType.SolidSide, TileObjectData.newTile.Width, 0);
		TileObjectData.addTile(Type);

		AddMapEntry(new Color(0, 191, 225), CreateMapEntryName());

		DustType = DustID.Granite;
	}

	public override bool HasSmartInteract(int i, int j, SmartInteractScanSettings settings)
	{
		return true;
	}

	public override void NumDust(int i, int j, bool fail, ref int num)
	{
		num = 1;
	}

	public override void KillMultiTile(int i, int j, int frameX, int frameY)
	{
		Item.NewItem(new EntitySource_TileBreak(i, j), i * 16, j * 16, 32, 32, ModContent.ItemType<UniversalCrafter>());
	}

	public override bool RightClick(int i, int j)
	{
		Player player = Main.LocalPlayer;
		Tile tile = Main.tile[i, j];
		Main.mouseRightRelease = false;
		int left = i - (tile.TileFrameX / 16);
		int top = j - (tile.TileFrameY / 16);

		// Top-center, the orb
		if (i - left == 2 && j - top == 0)
		{
			UnlockedStationsSystem.DisplayStations();
		}
		else if (player.HeldItem.createTile > -1)
		{
			if (player.HeldItem.type != ModContent.ItemType<UniversalCrafter>())
			{
				UnlockedStationsSystem.AddTile(player.HeldItem.createTile);
			}
			else if (!Main.dedServ)
			{
				Main.NewText(Language.GetTextValue("Mods.UniversalCraft.Misc.NoRecursion"));
			}
		}

		return true;
	}

	public override void MouseOver(int i, int j)
	{
		Player player = Main.LocalPlayer;
		player.cursorItemIconID = ModContent.ItemType<UniversalCrafter>();
		player.cursorItemIconText = "";
		player.noThrow = 2;
		player.cursorItemIconEnabled = true;
	}

	public override void MouseOverFar(int i, int j)
	{
		MouseOver(i, j);
		Player player = Main.LocalPlayer;
		if (player.cursorItemIconText == "")
		{
			player.cursorItemIconEnabled = false;
			player.cursorItemIconID = 0;
		}
	}
}