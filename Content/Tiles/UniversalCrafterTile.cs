using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.DataStructures;
using Terraria.Enums;
using Terraria.ID;
using Terraria.Localization;
using Terraria.Map;
using Terraria.ModLoader;
using Terraria.ObjectData;
using UniversalCraft.Common.GlobalTiles;
using UniversalCraft.Content.Items.Placeable;

namespace UniversalCraft.Content.Tiles
{
	public class UniversalCrafterTile : ModTile
	{
		public override bool Autoload(ref string name, ref string texture)
		{
			On.Terraria.WorldGen.PlaceChestDirect += WorldGen_PlaceChestDirect;
			return base.Autoload(ref name, ref texture);
		}

		public override void SetDefaults()
		{
			Main.tileSpelunker[Type] = true;
			Main.tileContainer[Type] = true;
			Main.tileShine2[Type] = true;
			Main.tileShine[Type] = 1200;
			Main.tileFrameImportant[Type] = true;
			Main.tileNoAttach[Type] = true;
			Main.tileValue[Type] = 10;
			TileID.Sets.HasOutlines[Type] = true;

			TileObjectData.newTile.CopyFrom(TileObjectData.Style5x4);
			TileObjectData.newTile.Height = 3;
			TileObjectData.newTile.Origin = new Point16(2, 2);
			TileObjectData.newTile.CoordinateHeights = new int[] { 16, 16, 16 };
			TileObjectData.newTile.HookCheck = new PlacementHook(new Func<int, int, int, int, int, int>(Chest.FindEmptyChest), -1, 0, true);
			TileObjectData.newTile.HookPostPlaceMyPlayer = new PlacementHook(new Func<int, int, int, int, int, int>(Chest.AfterPlacement_Hook), -1, 0, false);
			TileObjectData.newTile.AnchorInvalidTiles = new[] { (int)TileID.MagicalIceBlock };
			TileObjectData.newTile.LavaDeath = false;
			TileObjectData.newTile.AnchorBottom = new AnchorData(AnchorType.SolidTile | AnchorType.SolidWithTop | AnchorType.SolidSide, TileObjectData.newTile.Width, 0);
			TileObjectData.addTile(Type);

			ModTranslation name = CreateMapEntryName();
			AddMapEntry(new Color(0, 191, 225), name);

			disableSmartCursor = true;
			chest = name.GetTranslation(Language.ActiveCulture);
			chestDrop = ModContent.ItemType<UniversalCrafter>();
		}

		public override bool HasSmartInteract()
		{
			return true;
		}

		public string MapChestName(string name, int i, int j)
		{
			Tile tile = Main.tile[i, j];
			int left = i - (tile.frameX / 18);
			int top = j - (tile.frameY / 18);

			int chest = Chest.FindChest(left, top);
			if (chest < 0)
			{
				return Language.GetTextValue("LegacyChestType.0");
			}
			else if (Main.chest[chest].name == "")
			{
				return name;
			}
			else
			{
				return name + ": " + Main.chest[chest].name;
			}
		}

		public override bool NewRightClick(int i, int j)
		{
			Player player = Main.LocalPlayer;
			Main.mouseRightRelease = false;
			Tile tile = Main.tile[i, j];
			int left = i - (tile.frameX / 18);
			int top = j - (tile.frameY / 18);

			if (left + 2 == i && top == j) // Clicked orb, list tile names
			{
				int[] tiles = ModContent.GetInstance<UniversalCrafterGlobalTile>().AdjTiles(Type);
				List<string> names = new List<string>();
				foreach (int id in tiles)
				{
					string name = Lang.GetMapObjectName(MapHelper.TileToLookup(id, 0));
					if (name == string.Empty)
					{
						if (id >= TileID.Count)
						{
							name = TileLoader.GetTile(id).Name;
						}
						else
						{
							name = $"Tile {id}";
						}
					}
					names.Add(name);
				}

				names.Sort();

				Main.NewTextMultiline($"Active Tiles: {string.Join(", ", names)}");
				Main.NewText("\n");

				return true;
			}

			// Didn't click orb, open chest.
			if (player.sign >= 0)
			{
				Main.PlaySound(SoundID.MenuClose);
				player.sign = -1;
				Main.editSign = false;
				Main.npcChatText = "";
			}
			if (Main.editChest)
			{
				Main.PlaySound(SoundID.MenuTick);
				Main.editChest = false;
				Main.npcChatText = "";
			}
			if (player.editedChestName)
			{
				NetMessage.SendData(MessageID.SyncPlayerChest, -1, -1, NetworkText.FromLiteral(Main.chest[player.chest].name), player.chest, 1f, 0f, 0f, 0, 0, 0);
				player.editedChestName = false;
			}

			if (Main.netMode == NetmodeID.MultiplayerClient)
			{
				if (left == player.chestX && top == player.chestY && player.chest >= 0)
				{
					player.chest = -1;
					Recipe.FindRecipes();
					Main.PlaySound(SoundID.MenuClose);
				}
				else
				{
					NetMessage.SendData(MessageID.RequestChestOpen, -1, -1, null, left, (float)top, 0f, 0f, 0, 0, 0);
					Main.stackSplit = 600;
				}
			}
			else
			{
				int chest = Chest.FindChest(left, top);
				if (chest >= 0)
				{
					Main.stackSplit = 600;
					if (chest == player.chest)
					{
						player.chest = -1;
						Main.PlaySound(SoundID.MenuClose);
					}
					else
					{
						player.chest = chest;
						Main.playerInventory = true;
						Main.recBigList = false;
						player.chestX = left;
						player.chestY = top;
						Main.PlaySound(player.chest < 0 ? SoundID.MenuOpen : SoundID.MenuTick);
					}
					Recipe.FindRecipes();
				}
			}
			return true;
		}

		public override void KillMultiTile(int i, int j, int frameX, int frameY)
		{
			Item.NewItem(i * 16, j * 16, 32, 16, chestDrop);
			Chest.DestroyChest(i, j);
		}

		public override bool PreDraw(int i, int j, SpriteBatch spriteBatch)
		{
			Tile tile = Main.tile[i, j];
			Vector2 zero = new Vector2(Main.offScreenRange);
			if (Main.drawToScreen) { zero = Vector2.Zero; }

			Texture2D texture = Main.tileTexture[Type];
			Vector2 drawPosition = new Vector2((i * 16) - (int)Main.screenPosition.X, (j * 16) - (int)Main.screenPosition.Y + 2) + zero;
			Rectangle? frame = new Rectangle(tile.frameX, tile.frameY, 16, 16);
			spriteBatch.Draw(texture, drawPosition, frame, Lighting.GetColor(i, j));
			return false;
		}

		public override void PostDraw(int i, int j, SpriteBatch spriteBatch)
		{
			// Glowmask
			Tile tile = Main.tile[i, j];
			Vector2 zero = new Vector2(Main.offScreenRange);
			if (Main.drawToScreen) { zero = Vector2.Zero; }
			int height = tile.frameY == 36 ? 16 : 16;

			Texture2D glowmaskTexture = ModContent.GetTexture("UniversalCraft/Content/Tiles/UniversalCrafterTile_Glowmask");
			Vector2 drawPosition = new Vector2((i * 16) - (int)Main.screenPosition.X, (j * 16) - (int)Main.screenPosition.Y + 2) + zero;
			Rectangle? frame = new Rectangle(tile.frameX, tile.frameY, 16, height);
			spriteBatch.Draw(glowmaskTexture, drawPosition, frame, Color.White);

			// Highlight
			Point point = new Point(i, j);
			if (Collision.InTileBounds(i, j, Main.TileInteractionLX, Main.TileInteractionLY, Main.TileInteractionHX, Main.TileInteractionHY) && Main.SmartInteractTileCoords.Contains(point))
			{
				Texture2D highlightTexture = ModContent.GetTexture("UniversalCraft/Content/Tiles/UniversalCrafterTile_Highlight");
				Color drawColor = Color.Transparent;
				Color lightColor = Lighting.GetColor(i, j);
				int brightness = (lightColor.R + lightColor.G + lightColor.B) / 3;
				bool selected = Main.SmartInteractTileCoordsSelected.Contains(point);
				if (brightness > 10)
				{
					drawColor = selected ? new Color(brightness, brightness, brightness / 3, brightness) : new Color(brightness / 2, brightness / 2, brightness / 2, brightness);
				}
				spriteBatch.Draw(highlightTexture, drawPosition, frame, drawColor);
			}
		}

		public override bool CanKillTile(int i, int j, ref bool blockDamaged)
		{
			Tile tile = Framing.GetTileSafely(i, j);
			i -= tile.frameX / 16;
			j -= tile.frameY / 16;
			if (Chest.FindChest(i, j) != -1)
			{
				return Chest.CanDestroyChest(i, j);
			}

			return base.CanKillTile(i, j, ref blockDamaged);
		}

		// Fucking hell.
		// Manually syncs the placement of a new Universal Crafter because Terraria thinks its 2x2 and frames it weirdly.
		private void WorldGen_PlaceChestDirect(On.Terraria.WorldGen.orig_PlaceChestDirect orig, int x, int y, ushort type, int style, int id)
		{
			if (type != Type)
			{
				orig(x, y, type, style, id);
				return;
			}

			Chest.CreateChest(x, y - 2, id);
			for (int i = -2; i < 3; i++)
			{
				for (int j = -2; j < 1; j++)
				{
					Tile tile = Framing.GetTileSafely(x + i, y + j); // Null-checks and sets the tile to a new one.
					tile.active(active: true);
					tile.frameX = (short)(18 * (i + 2));
					tile.frameY = (short)(18 * (j + 2));
					tile.type = type;
					tile.halfBrick(halfBrick: false);
				}
			}
		}

		public override void NearbyEffects(int i, int j, bool closer)
		{
			Player player = Main.LocalPlayer;
			if (closer)
			{
				player.adjWater = true;
				player.adjLava = true;
				player.adjHoney = true;

				if (NPC.downedBoss3)
				{
					player.alchemyTable = true;
				}
			}
		}
	}
}