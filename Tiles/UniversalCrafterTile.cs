using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ObjectData;
using UniversalCraft.Items;

namespace UniversalCraft.Tiles
{
	public class UniversalCrafterTile : ModTile
	{
		public override void SetDefaults()
		{
			Main.tileSolidTop[Type] = false;
			Main.tileFrameImportant[Type] = true;
			Main.tileNoAttach[Type] = true;
			Main.tileTable[Type] = false;
			Main.tileLavaDeath[Type] = false;
			Main.tileContainer[Type] = true;

			//TileID.Sets.BasicChest[Type] = true;
			TileID.Sets.HasOutlines[Type] = true;

			TileObjectData.newTile.CopyFrom(TileObjectData.Style5x4);
			TileObjectData.newTile.Height = 3;
			TileObjectData.newTile.Origin = new Point16(2, 2);
			TileObjectData.newTile.CoordinateHeights = new int[] { 16, 16, 16 };
			TileObjectData.newTile.HookCheck = new PlacementHook(new Func<int, int, int, int, int, int>(Chest.FindEmptyChest), -1, 0, true);
			TileObjectData.newTile.HookPostPlaceMyPlayer = new PlacementHook(new Func<int, int, int, int, int, int>(Chest.AfterPlacement_Hook), -1, 0, false);
			//TileObjectData.newTile.HookPostPlaceEveryone = new PlacementHook(ModContent.GetInstance<UniversalCrafterTileEntity>().Hook_AfterPlacement, -1, 0, true);
			TileObjectData.newTile.AnchorInvalidTiles = new[] { (int)TileID.MagicalIceBlock };
			TileObjectData.addTile(Type);

			AddMapEntry(new Color(0, 191, 225), CreateMapEntryName());

			disableSmartCursor = true;
			adjTiles = new int[]
			{
				TileID.Anvils,
				TileID.Bookcases,
				TileID.Bottles,
				TileID.Chairs,
				TileID.CookingPots,
				TileID.Containers,
				TileID.Containers2,
				TileID.DemonAltar,
				TileID.DyeVat,
				TileID.Furnaces,
				TileID.GlassKiln,
				TileID.HeavyWorkBench,
				TileID.Hellforge,
				TileID.HoneyDispenser,
				TileID.IceMachine,
				TileID.Kegs,
				TileID.LivingLoom,
				TileID.Loom,
				TileID.Sawmill,
				TileID.SkyMill,
				TileID.Tables,
				TileID.Tables2,
				TileID.WorkBenches
			};

			chest = Language.GetTextValue("Mods.UniversalCrafter.MapObject.UniversalCrafterTile");
			chestDrop = ModContent.ItemType<UniversalCrafterItem>();
		}

		public override bool HasSmartInteract()
		{
			return true;
		}

		public string MapChestName(string name, int i, int j)
		{
			int left = i;
			int top = j;
			Tile tile = Main.tile[i, j];
			if (tile.frameX % 36 != 0)
			{
				left--;
			}
			if (tile.frameY != 0)
			{
				top--;
			}
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

		//public static int count = 0; //For the right-click tile lists

		//public static List<string> TileList = new List<string>(); //Empty list for tile names
		//public static List<int> ToConvert = new List<int>(); //Temp. list for all adjTile ints
		//													 //public static int[] UCTAdj = new int[256]; //Temp. int[] for UCTile.AdjTiles

		//public static List<string> AllTiles = new List<string>();
		//public static List<string> VanillaStrings = new List<string>(); //List for vanilla tiles
		//public static List<string> SymbEModStrings = new List<string>(); //List for mods whose names starts with letters a-e + number and symbols
		//public static List<string> FLModStrings = new List<string>(); // f-l
		//public static List<string> MSModStrings = new List<string>(); // m-s
		//public static List<string> TZModStrings = new List<string>(); // t-z
		//public static List<string> Unknown = new List<string>(); //else

		//public override void RightClick(int i, int j)
		//{
		//	#region New Right-Click List

		//	ToConvert = adjTiles.Union(mod.GetGlobalTile("UCTile").AdjTiles(mod.TileType("UniversalCrafter"))).ToList(); //Turns the two arrays into a list
		//	VanillaStrings.Clear(); SymbEModStrings.Clear(); FLModStrings.Clear(); MSModStrings.Clear(); TZModStrings.Clear(); Unknown.Clear(); AllTiles.Clear(); //Clear all the tile lists
		//	foreach (int tile in ToConvert) //For every integer in ToConvert...
		//	{
		//		Mod modName = null; //Set modName to null
		//		string modNameS = ""; //Set modNameString to null
		//		string tileName = Lang.GetMapObjectName(MapHelper.TileToLookup(tile, 0)); //Set tileName to look up each tile's name
		//		char firstL; //Make an enmpty character to be used for alpha. sorting
		//		if (tileName == "")
		//		{
		//			if (tile < TileID.Count)
		//			{
		//				tileName = "Tile " + tile; //Invalid name
		//			}
		//			else
		//			{
		//				tileName = TileLoader.GetTile(tile).Name; //Valid name
		//			}
		//		}
		//		if (TileLoader.GetTile(tile) != null) //If the tile is a modded tile...
		//		{
		//			modName = TileLoader.GetTile(tile).mod; //Get the tile's mod's name
		//		}
		//		if (modName != null) //If the tile has a mod name...
		//		{
		//			modNameS = String.Format(" [c/ffaf00:({0})]", modName.DisplayName.ToString()); //Make a string that formats the name into this: " (modname)" (in blue)
		//		}
		//		string TileName2 = tileName + modNameS; //Add name to List. For Vanilla tiles, it will only display the name, as modNameS will be equal to null
		//		if (modName != null) //If the tile has a mod name...
		//		{
		//			firstL = modName.DisplayName.ToString()[0]; //Set firstL to the first character of the mod's name
		//			bool SymbE = Regex.IsMatch(firstL.ToString(), "[a-e]", RegexOptions.IgnoreCase); //Set to true if firstL is any letter between A and E
		//			bool FL = Regex.IsMatch(firstL.ToString(), "[f-l]", RegexOptions.IgnoreCase); //Set to true if firstL is any letter between F and L
		//			bool MS = Regex.IsMatch(firstL.ToString(), "[m-s]", RegexOptions.IgnoreCase); //Set to true if firstL is any letter between M and S
		//			bool TZ = Regex.IsMatch(firstL.ToString(), "[t-z]", RegexOptions.IgnoreCase); //Set to true if firstL is any letter between T and Z

		//			if (SymbE || Char.IsSymbol(firstL) || Char.IsNumber(firstL)) //If name begins with A-E, a symbol, or a number...
		//			{
		//				SymbEModStrings.Add(TileName2);
		//			}
		//			else if (FL) //If name begins with F-L
		//			{
		//				FLModStrings.Add(TileName2);
		//			}
		//			else if (MS) //If name begins with M-S
		//			{
		//				MSModStrings.Add(TileName2);
		//			}
		//			else if (TZ) //If name begins with T-Z
		//			{
		//				TZModStrings.Add(TileName2);
		//			}
		//			else //If name somehow doesn't begin with any of the above...
		//			{
		//				Unknown.Add(TileName2);
		//			}
		//		}
		//		else
		//		{
		//			VanillaStrings.Add(TileName2); //If the tile has no mod name, just add it to the vanilla list
		//		}
		//	} //Adds tile names
		//	VanillaStrings.Remove("Table"); //Removes extra name added by Tables2
		//	VanillaStrings.Add("Water"); //Add Water name
		//	VanillaStrings.Add("Lava"); //Add Lava name
		//	VanillaStrings.Add("Honey"); //Add Honey name

		//	AllTiles = VanillaStrings.Union(SymbEModStrings).Union(FLModStrings).Union(MSModStrings).Union(TZModStrings).Union(Unknown).ToList(); //Make a list with all tile name strings in it

		//	VanillaStrings.Sort(); SymbEModStrings.Sort(); FLModStrings.Sort(); MSModStrings.Sort(); TZModStrings.Sort(); Unknown.Sort(); AllTiles.Sort(); //Alphabetize the lists

		//	string Vanilla = string.Join(", ", VanillaStrings.ToArray()); //Make one string for all Vanilla tile names (count = 0)
		//	string SymbEMod = string.Join(", ", SymbEModStrings.ToArray()); //Make one string for all A-E, Symbol, and Number tile names (count = 1)
		//	string FLMod = string.Join(", ", FLModStrings.ToArray()); //Make one string for all F-L tile names (count = 2)
		//	string MSMod = string.Join(", ", MSModStrings.ToArray()); //Make one string for all M-S tile names (count = 3)
		//	string TZMod = string.Join(", ", TZModStrings.ToArray()); //Make one string for all T-Z tile names (count = 4)
		//	string UnknownMod = string.Join(", ", Unknown.ToArray()); //Make one string for all unknown charater tile names (count = 5)
		//	string All = string.Join(", ", AllTiles.ToArray()); //Make one string for all tile names (count = 6)

		//	if (count > 6) //If count somehow equals 7...
		//	{
		//		count = 0; //Set it to 0; Count has no values for anything above 6
		//	}

		//	switch (count) //When right clicked, the tile withh preform the action associated to the current count value's case
		//	{
		//		case 0:
		//			Main.NewTextMultiline("Currently active Vanilla tiles: " + Vanilla + "."); //Make a string stating all active vanilla tiles
		//			if (SymbEMod.Any())
		//			{
		//				Main.NewText("Right-click again to see A - E tiles.");
		//				count += 1;
		//			} //If SymbE has anything in it, increase count to SmybE's case and display a string
		//			else if (FLMod.Any())
		//			{
		//				Main.NewText("Right-click again to see F - L tiles.");
		//				count += 2;
		//			}
		//			else if (MSMod.Any())
		//			{
		//				Main.NewText("Right-click again to see M - S tiles.");
		//				count += 3;
		//			}
		//			else if (TZMod.Any())
		//			{
		//				Main.NewText("Right-click again to see T - Z tiles.");
		//				count += 4;
		//			}
		//			else if (UnknownMod.Any())
		//			{
		//				Main.NewText("Right-click again to see unknown tiles.");
		//				count += 5;
		//			}
		//			else
		//			{
		//				break;
		//			} //If no mod list has any values, set count to All's case and display a message
		//			break; //Exit case
		//		case 1:
		//			Main.NewTextMultiline("Currently active tiles, mods A - E: " + SymbEMod + ".");
		//			if (FLMod.Any())
		//			{
		//				Main.NewText("Right-click again to see F - L tiles.");
		//				count += 1;
		//			}
		//			else if (MSMod.Any())
		//			{
		//				Main.NewText("Right-click again to see M - S tiles.");
		//				count += 2;
		//			}
		//			else if (TZMod.Any())
		//			{
		//				Main.NewText("Right-click again to see T - Z tiles.");
		//				count += 3;
		//			}
		//			else if (UnknownMod.Any())
		//			{
		//				Main.NewText("Right-click again to see unknown tiles.");
		//				count += 4;
		//			}
		//			else
		//			{
		//				Main.NewText("Right-click again to see all tiles.");
		//				count += 5;
		//			}
		//			break;

		//		case 2:
		//			Main.NewTextMultiline("Currently active tiles, mods F - L: " + FLMod + ".");
		//			if (MSMod.Any())
		//			{
		//				Main.NewText("Right-click again to see M - S tiles.");
		//				count += 1;
		//			}
		//			else if (TZMod.Any())
		//			{
		//				Main.NewText("Right-click again to see T - Z tiles.");
		//				count += 2;
		//			}
		//			else if (UnknownMod.Any())
		//			{
		//				Main.NewText("Right-click again to see unknown tiles.");
		//				count += 3;
		//			}
		//			else
		//			{
		//				Main.NewText("Right-click again to see all tiles.");
		//				count += 4;
		//			}
		//			break;

		//		case 3:
		//			Main.NewTextMultiline("Currently active tiles, mods M - S: " + MSMod + ".");
		//			if (TZMod.Any())
		//			{
		//				Main.NewText("Right-click again to see T - Z tiles.");
		//				count += 1;
		//			}
		//			else if (UnknownMod.Any())
		//			{
		//				Main.NewText("Right-click again to see unknown tiles.");
		//				count += 2;
		//			}
		//			else
		//			{
		//				Main.NewText("Right-click again to see all tiles.");
		//				count += 3;
		//			}
		//			break;

		//		case 4:
		//			Main.NewTextMultiline("Currently active tiles, mods T - Z: " + TZMod + ".");
		//			if (UnknownMod.Any())
		//			{
		//				Main.NewText("Right-click again to see unknown tiles.");
		//				count += 1;
		//			}
		//			else
		//			{
		//				Main.NewText("Right-click again to see all tiles.");
		//				count += 2;
		//			}
		//			break;

		//		case 5:
		//			Main.NewTextMultiline("Currently active tiles, unknown mods: " + UnknownMod + ".");
		//			Main.NewText("Right-click again to see all tiles.");
		//			count++;
		//			break;

		//		case 6:
		//			Main.NewTextMultiline("Currently active tiles: " + All + ".");
		//			Main.NewText("Right-click again to see Vanilla tiles.");
		//			count = 0;
		//			break;
		//	}

		//	#endregion New Right-Click List
		//}

		// https://github.com/tModLoader/tModLoader/blob/master/ExampleMod/Tiles/ExampleChest.cs

		private readonly Point OrbSegment = new Point(2, 0);

		public override bool NewRightClick(int i, int j)
		{
			Tile tile = Framing.GetTileSafely(i, j);
			Point segment = new Point(tile.frameX / 18, tile.frameY / 18);

			if (segment == OrbSegment) // Open chest
			{
				Player player = Main.LocalPlayer;
				Main.mouseRightRelease = false;
				int left = i - 2;
				int top = j;

				if (player.sign >= 0)
				{
					Main.PlaySound(SoundID.MenuClose);
					player.sign = -1;
					Main.editSign = false;
					Main.npcChatText = string.Empty;
				}

				if (Main.editChest)
				{
					Main.PlaySound(SoundID.MenuTick);
					Main.editChest = false;
					Main.npcChatText = string.Empty;
				}

				if (player.editedChestName)
				{
					NetMessage.SendData(MessageID.SyncPlayerChest, -1, -1, NetworkText.FromLiteral(Main.chest[player.chest].name), player.chest, 1f);
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
						NetMessage.SendData(MessageID.RequestChestOpen, -1, -1, null, left, top);
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
			}
			else // List
			{
				//Chest.
				int chest = Chest.FindChestByGuessing(i, j);

				Main.NewText($"Clicked: {i}, {j}");
				//Main.NewText($"Chest: {Main.chest[chest].x}, {Main.chest[chest].y}");
				//Main.NewText("Capital H");
			}

			return true;
		}

		public override void NumDust(int i, int j, bool fail, ref int num)
		{
			num = fail ? 1 : 3;
		}

		public override void KillMultiTile(int i, int j, int frameX, int frameY)
		{
			Item.NewItem(i * 16, j * 16, 32, 16, chestDrop);
			Chest.DestroyChest(i, j);
			ModContent.GetInstance<UniversalCrafterTileEntity>().Kill(i, j);
		}

		public override bool PreDraw(int i, int j, SpriteBatch spriteBatch)
		{
			Tile tile = Main.tile[i, j];
			Vector2 zero = new Vector2(Main.offScreenRange);
			if (Main.drawToScreen) { zero = Vector2.Zero; }
			int height = tile.frameY == 36 ? 16 : 16;

			Texture2D texture = Main.tileTexture[Type];
			Vector2 drawPosition = new Vector2((i * 16) - (int)Main.screenPosition.X, (j * 16) - (int)Main.screenPosition.Y + 2) + zero;
			Rectangle? frame = new Rectangle(tile.frameX, tile.frameY, 16, height);
			spriteBatch.Draw(texture, drawPosition, frame, Color.White);
			return false;
		}

		public override void PostDraw(int i, int j, SpriteBatch spriteBatch)
		{
			Tile tile = Main.tile[i, j];
			Vector2 zero = new Vector2(Main.offScreenRange);
			if (Main.drawToScreen) { zero = Vector2.Zero; }
			int height = tile.frameY == 36 ? 16 : 16;

			Texture2D glowmaskTexture = ModContent.GetTexture("UniversalCraft/Tiles/UniversalCrafterTile_Glowmask");
			Vector2 drawPosition = new Vector2((i * 16) - (int)Main.screenPosition.X, (j * 16) - (int)Main.screenPosition.Y + 2) + zero;
			Rectangle? frame = new Rectangle(tile.frameX, tile.frameY, 16, height);
			spriteBatch.Draw(glowmaskTexture, drawPosition, frame, Color.White);
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

		public override void PlaceInWorld(int i, int j, Item item)
		{
			//Chest.AfterPlacement_Hook(i - 2, j - 1, Type);
			ModContent.GetInstance<UniversalCrafterTileEntity>().Hook_AfterPlacement(i, j, Type, 0, 0);

			//if (Main.netMode == NetmodeID.MultiplayerClient)
			//{
			//	//NetMessage.SendData(MessageID.TileSquare)
			//}
		}

		//public override void NearbyEffects(int i, int j, bool closer)
		//{
		//	Player player = Main.player[Main.myPlayer];
		//	if (closer)
		//	{
		//		player.adjWater = true;
		//		player.adjLava = true;
		//		player.adjHoney = true;
		//	}
		//	if (closer && NPC.downedBoss3)
		//	{
		//		player.alchemyTable = true;
		//	}
		//}
	}
}