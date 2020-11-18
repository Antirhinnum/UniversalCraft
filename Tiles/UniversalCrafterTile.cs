using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.Map;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace UniversalCraft.Tiles
{
	public class UniversalCrafterTile : ModTile
	{
		public static List<int> adjTile = new List<int>();

		public override void SetDefaults()
		{
			Main.tileSolidTop[Type] = false;
			Main.tileFrameImportant[Type] = true;
			Main.tileNoAttach[Type] = true;
			Main.tileTable[Type] = false;
			Main.tileLavaDeath[Type] = false;
			TileObjectData.newTile.CopyFrom(TileObjectData.Style5x4);
			TileObjectData.newTile.Height = 3;
			TileObjectData.newTile.Width = 5;
			TileObjectData.newTile.Origin = new Point16(2, 2);
			TileObjectData.newTile.CoordinateHeights = new int[] { 16, 18, 18 };
			TileObjectData.addTile(Type);
			ModTranslation name = CreateMapEntryName();
			name.SetDefault("Universal Crafter");
			AddMapEntry(new Color(0, 191, 225), name);
			dustType = mod.DustType("Sparkle");
			disableSmartCursor = true;

			#region AdjTile

			adjTile.Add(TileID.Anvils);
			adjTile.Add(TileID.Bookcases);
			adjTile.Add(TileID.Bottles);
			adjTile.Add(TileID.Chairs);
			adjTile.Add(TileID.CookingPots);
			adjTile.Add(TileID.DemonAltar);
			adjTile.Add(TileID.DyeVat);
			adjTile.Add(TileID.Furnaces);
			adjTile.Add(TileID.GlassKiln);
			adjTile.Add(TileID.HeavyWorkBench);
			adjTile.Add(TileID.Hellforge);
			adjTile.Add(TileID.HoneyDispenser);
			adjTile.Add(TileID.IceMachine);
			adjTile.Add(TileID.Kegs);
			adjTile.Add(TileID.LivingLoom);
			adjTile.Add(TileID.Loom);
			adjTile.Add(TileID.Sawmill);
			adjTile.Add(TileID.SkyMill);
			adjTile.Add(TileID.Tables);
			adjTile.Add(TileID.Tables2);
			adjTile.Add(TileID.WorkBenches);

			#region Modded Pre-Boss

			if (ModLoader.GetMod("Bismuth") != null)
			{
				adjTile.Add(ModLoader.GetMod("Bismuth").TileType("PapuansBookcase"));
			}

			if (ModLoader.GetMod("CalamityMod") != null)
			{
				adjTile.Add(ModLoader.GetMod("CalamityMod").TileType("EutrophicCrafting"));
			}
			if (ModLoader.GetMod("CheezeMod") != null)
			{
				adjTile.Add(ModLoader.GetMod("CheezeMod").TileType("MegaCorpVendor"));
			}

			if (ModLoader.GetMod("CookieModBeta") != null)
			{
				adjTile.Add(ModLoader.GetMod("CookieModBeta").TileType("CookieBench"));
			}

			if (ModLoader.GetMod("CookieModBeta2") != null)
			{
				adjTile.Add(ModLoader.GetMod("CookieModBeta2").TileType("CookieBench"));
			}

			if (ModLoader.GetMod("CosmeticVariety") != null)
			{
				adjTile.Add(ModLoader.GetMod("CosmeticVariety").TileType("Apiary"));
				adjTile.Add(ModLoader.GetMod("CosmeticVariety").TileType("CanningStation"));
				adjTile.Add(ModLoader.GetMod("CosmeticVariety").TileType("ChillMachine"));
				adjTile.Add(ModLoader.GetMod("CosmeticVariety").TileType("Easel"));
				adjTile.Add(ModLoader.GetMod("CosmeticVariety").TileType("Oven"));
				adjTile.Add(ModLoader.GetMod("CosmeticVariety").TileType("SculptingStation"));
			}
			if (ModLoader.GetMod("Crystilium") != null)
			{
				adjTile.Add(ModLoader.GetMod("Crystilium").TileType("CrystalWoodWorkbench"));
				adjTile.Add(ModLoader.GetMod("Crystilium").TileType("Fountain"));
			}
			if (ModLoader.GetMod("Exodus") != null)
			{
				adjTile.Add(ModLoader.GetMod("Exodus").TileType("BlastFurnaceTile"));
				adjTile.Add(ModLoader.GetMod("Exodus").TileType("SlimeWorkstation"));
			}
			if (ModLoader.GetMod("FlareStone") != null)
			{
				adjTile.Add(ModLoader.GetMod("FlareStone").TileType("Accelerator"));
			}

			if (ModLoader.GetMod("Laugicality") != null)
			{
				adjTile.Add(ModLoader.GetMod("Laugicality").TileType("AlchemicalInfuser"));
				adjTile.Add(ModLoader.GetMod("Laugicality").TileType("LaugicalWorkbench"));
				adjTile.Add(TileID.OpenDoor);
				adjTile.Add(TileID.ClosedDoor);
			}
			if (ModLoader.GetMod("MagicStorage") != null)
			{
				adjTile.Add(ModLoader.GetMod("MagicStorage").TileType("CraftingAccess"));
			}

			if (ModLoader.GetMod("MoAddon") != null)
			{
				adjTile.Add(ModLoader.GetMod("MoAddon").TileType("SnowWBTile"));
			}

			if (ModLoader.GetMod("OreConversion") != null)
			{
				adjTile.Add(ModLoader.GetMod("OreConversion").TileType("OreConvertTable"));
			}

			if (ModLoader.GetMod("RawExpansion") != null)
			{
				adjTile.Add(ModLoader.GetMod("RawExpansion").TileType("FleshCrafter"));
				adjTile.Add(ModLoader.GetMod("RawExpansion").TileType("UpgraderStation"));
			}
			if (ModLoader.GetMod("SimpleAutoChests") != null)
			{
				adjTile.Add(ModLoader.GetMod("SimpleAutoChests").TileType("JungleGatherer"));
				adjTile.Add(ModLoader.GetMod("SimpleAutoChests").TileType("TreeGatherer"));
				adjTile.Add(ModLoader.GetMod("SimpleAutoChests").TileType("SkyGatherer"));
				adjTile.Add(ModLoader.GetMod("SimpleAutoChests").TileType("HellGatherer"));
				adjTile.Add(ModLoader.GetMod("SimpleAutoChests").TileType("FishGatherer"));
			}
			if (ModLoader.GetMod("SpiritMod") != null)
			{
				adjTile.Add(ModLoader.GetMod("SpiritMod").TileType("CreationAltarTile"));
			}

			if (ModLoader.GetMod("StarWarsMod") != null)
			{
				adjTile.Add(ModLoader.GetMod("StarWarsMod").TileType("GeologicalCompressor"));
			}

			if (ModLoader.GetMod("thespatiummod") != null)
			{
				adjTile.Add(ModLoader.GetMod("thespatiummod").TileType("GoldenBinder"));
			}

			if (ModLoader.GetMod("ThoriumMod") != null)
			{
				adjTile.Add(ModLoader.GetMod("ThoriumMod").TileType("ThoriumAnvil"));
			}

			if (ModLoader.GetMod("Tremor") != null)
			{
				adjTile.Add(ModLoader.GetMod("Tremor").TileType("AltarofEnchantmentsTile"));
				adjTile.Add(ModLoader.GetMod("Tremor").TileType("BlastFurnace"));
				adjTile.Add(ModLoader.GetMod("Tremor").TileType("FleshWorkstationTile"));
				adjTile.Add(ModLoader.GetMod("Tremor").TileType("MagicWorkbenchTile"));
				adjTile.Add(ModLoader.GetMod("Tremor").TileType("MineralTransmutator"));
			}
			if (ModLoader.GetMod("VampKnives") != null)
			{
				adjTile.Add(ModLoader.GetMod("VampKnives").TileType("KnifeBench"));
			}

			if (ModLoader.GetMod("Exodus") != null || ModLoader.GetMod("GRealm") != null || ModLoader.GetMod("RawExpasion") != null || ModLoader.GetMod("CrittersRevamped") != null || ModLoader.GetMod("CloudRecipe") != null || ModLoader.GetMod("EvilBlockSwap") != null || ModLoader.GetMod("ExperienceAndClasses") != null || ModLoader.GetMod("ExperienceAndClassesRu") != null || ModLoader.GetMod("Hunger") != null)
			{
				adjTile.Add(TileID.Campfire);
			}

			if (ModLoader.GetMod("AE") != null)
			{
				adjTile.Add(TileID.Extractinator);
			}

			if (ModLoader.GetMod("AnomiconMod") != null)
			{
				adjTile.Add(ModLoader.GetMod("AnomiconMod").TileType("DPrinter"));
			}

			if (ModLoader.GetMod("AFKPETS") != null)
			{
				adjTile.Add(TileID.Beds);
			}

			if (ModLoader.GetMod("Aloha") != null)
			{
				adjTile.Add(TileID.Larva);
				adjTile.Add(TileID.Cactus);
			}
			if (ModLoader.GetMod("AGSmod") != null)
			{
				adjTile.Add(TileID.Pigronata);
			}

			if (ModLoader.GetMod("JoostMod") != null)
			{
				adjTile.Add(ModLoader.GetMod("JoostMod").TileType("ShrineOfLegends"));
			}

			if (ModLoader.GetMod("BetterBoneWelder") != null)
			{
				adjTile.Add(ModLoader.GetMod("BetterBoneWelder").TileType("DaemonForge"));
			}

			if (ModLoader.GetMod("BeastPack") != null)
			{
				adjTile.Add(ModLoader.GetMod("BeastPack").TileType("AdvancedWorkStation"));
				adjTile.Add(ModLoader.GetMod("BeastPack").TileType("WorkStation"));
				adjTile.Add(ModLoader.GetMod("BeastPack").TileType("SkyForge"));
			}
			if (ModLoader.GetMod("BuildPlanner") != null)
			{
				adjTile.Add(ModLoader.GetMod("BuildPlanner").TileType("Scaffold"));
			}

			if (ModLoader.GetMod("bloodScythes") != null)
			{
				adjTile.Add(TileID.Bowls);
			}

			if (ModLoader.GetMod("BuilderPlus") != null)
			{
				adjTile.Add(TileID.WaterDrip);
			}

			if (ModLoader.GetMod("DylansMod") != null)
			{
				adjTile.Add(ModLoader.GetMod("DylansMod").TileType("EnchantmentTable"));
			}

			if (ModLoader.GetMod("DestinyItemsMod") != null)
			{
				adjTile.Add(ModLoader.GetMod("DestinyItemsMod").TileType("GuardiansForge"));
			}

			if (ModLoader.GetMod("DirtMod") != null)
			{
				adjTile.Add(ModLoader.GetMod("DirtMod").TileType("DirtFurnace"));
			}

			if (ModLoader.GetMod("TerrariaDark") != null)
			{
				adjTile.Add(ModLoader.GetMod("TerrariaDark").TileType("DarkAltar"));
			}

			if (ModLoader.GetMod("DoggysMod") != null)
			{
				adjTile.Add(ModLoader.GetMod("DoggysMod").TileType("SuspiciousGlass"));
			}

			if (ModLoader.GetMod("DankBuysMod") != null)
			{
				adjTile.Add(TileID.MonarchButterflyJar);
				adjTile.Add(TileID.FossilOre);
			}
			if (ModLoader.GetMod("Dalekanium") != null || ModLoader.GetMod("HellstoneShotmod") != null)
			{
				adjTile.Add(TileID.Sinks);
			}

			if (ModLoader.GetMod("ExtendedCrops") != null)
			{
				adjTile.Add(TileID.PiggyBank);
				Mod extendedCrops = ModLoader.GetMod("ExtendedCrops");
				adjTile.Add(extendedCrops.TileType("SeedProcessor"));
				adjTile.Add(extendedCrops.TileType("ACopperSeedProcessor"));
				adjTile.Add(extendedCrops.TileType("ATinSeedProcessor"));
				adjTile.Add(extendedCrops.TileType("BIronSeedProcessor"));
				adjTile.Add(extendedCrops.TileType("BLeadSeedProcessor"));
				adjTile.Add(extendedCrops.TileType("CSilverSeedProcessor"));
				adjTile.Add(extendedCrops.TileType("CTungstenSeedProcessor"));
				adjTile.Add(extendedCrops.TileType("DGoldSeedProcessor"));
				adjTile.Add(extendedCrops.TileType("DPlatinumSeedProcessor"));
				adjTile.Add(extendedCrops.TileType("EMeteoriteSeedProcessor"));
				adjTile.Add(extendedCrops.TileType("FDemoniteSeedProcessor"));
				adjTile.Add(extendedCrops.TileType("FCrimtaneSeedProcessor"));
				adjTile.Add(extendedCrops.TileType("GObsidianSeedProcessor"));
				adjTile.Add(extendedCrops.TileType("HHellstoneSeedProcessor"));
			}
			if (ModLoader.GetMod("Eclipysian") != null || ModLoader.GetMod("ExampleMod") != null || ModLoader.GetMod("Test__Test") != null)
			{
				adjTile.Add(TileID.FireflyinaBottle);
			}

			if (ModLoader.GetMod("EasyFishing") != null || ModLoader.GetMod("FrecMod") != null)
			{
				adjTile.Add(TileID.Sunflower);
			}

			if (ModLoader.GetMod("FabusMod") != null)
			{
				adjTile.Add(TileID.Books);
			}

			if (ModLoader.GetMod("FantasiesAdvance") != null)
			{
				adjTile.Add(ModLoader.GetMod("FantasiesAdvance").TileType("DwarvenForge"));
				adjTile.Add(ModLoader.GetMod("FantasiesAdvance").TileType("DwarvenAnvil"));
			}
			if (ModLoader.GetMod("Fernium") != null)
			{
				adjTile.Add(ModLoader.GetMod("Fernium").TileType("LivingWorkbench"));
			}

			if (ModLoader.GetMod("Gemology") != null)
			{
				adjTile.Add(ModLoader.GetMod("Gemology").TileType("gemRefineryPlaced"));
			}

			if (ModLoader.GetMod("HappyDaysMod") != null)
			{
				adjTile.Add(ModLoader.GetMod("HappyDaysMod").TileType("WeaponStation"));
				adjTile.Add(ModLoader.GetMod("HappyDaysMod").TileType("WoodenExtractor"));
				adjTile.Add(ModLoader.GetMod("HappyDaysMod").TileType("ChemistryTable"));
				adjTile.Add(ModLoader.GetMod("HappyDaysMod").TileType("CreatorsTable"));
				adjTile.Add(ModLoader.GetMod("HappyDaysMod").TileType("BoozeKit"));
				adjTile.Add(ModLoader.GetMod("HappyDaysMod").TileType("Apothecary"));
			}
			if (ModLoader.GetMod("Illaz") != null)
			{
				adjTile.Add(ModLoader.GetMod("Illaz").TileType("IllazWorkbench"));
			}

			if (ModLoader.GetMod("Inkursion") != null)
			{
				adjTile.Add(ModLoader.GetMod("Inkursion").TileType("InkyWorkbench"));
			}

			if (ModLoader.GetMod("HellstoneShotmod") != null)
			{
				adjTile.Add(TileID.Tombstones);
				adjTile.Add(TileID.Cobweb);
			}
			if (ModLoader.GetMod("Insanity") != null)
			{
				adjTile.Add(TileID.Candles);
			}

			if (ModLoader.GetMod("CyversMod") != null)
			{
				adjTile.Add(TileID.Trees);
			}

			if (ModLoader.GetMod("SkyblockMod") != null)
			{
				adjTile.Add(ModLoader.GetMod("SkyblockMod").TileType("Compactor"));
			}

			#endregion Modded Pre-Boss

			adjTiles = adjTile.ToArray();

			#endregion AdjTile
		}

		public static int count = 0; //For the right-click tile lists

		public static List<string> TileList = new List<string>(); //Empty list for tile names
		public static List<int> ToConvert = new List<int>(); //Temp. list for all adjTile ints
															 //public static int[] UCTAdj = new int[256]; //Temp. int[] for UCTile.AdjTiles

		public static List<string> AllTiles = new List<string>();
		public static List<string> VanillaStrings = new List<string>(); //List for vanilla tiles
		public static List<string> SymbEModStrings = new List<string>(); //List for mods whose names starts with letters a-e + number and symbols
		public static List<string> FLModStrings = new List<string>(); // f-l
		public static List<string> MSModStrings = new List<string>(); // m-s
		public static List<string> TZModStrings = new List<string>(); // t-z
		public static List<string> Unknown = new List<string>(); //else

		public override void RightClick(int i, int j)
		{
			#region New Right-Click List

			ToConvert = adjTile.Union(mod.GetGlobalTile("UCTile").AdjTiles(mod.TileType("UniversalCrafter"))).ToList(); //Turns the two arrays into a list
			VanillaStrings.Clear(); SymbEModStrings.Clear(); FLModStrings.Clear(); MSModStrings.Clear(); TZModStrings.Clear(); Unknown.Clear(); AllTiles.Clear(); //Clear all the tile lists
			foreach (int tile in ToConvert) //For every integer in ToConvert...
			{
				Mod modName = null; //Set modName to null
				string modNameS = ""; //Set modNameString to null
				string tileName = Lang.GetMapObjectName(MapHelper.TileToLookup(tile, 0)); //Set tileName to look up each tile's name
				char firstL; //Make an enmpty character to be used for alpha. sorting
				if (tileName == "")
				{
					if (tile < TileID.Count)
					{
						tileName = "Tile " + tile; //Invalid name
					}
					else
					{
						tileName = TileLoader.GetTile(tile).Name; //Valid name
					}
				}
				if (TileLoader.GetTile(tile) != null) //If the tile is a modded tile...
				{
					modName = TileLoader.GetTile(tile).mod; //Get the tile's mod's name
				}
				if (modName != null) //If the tile has a mod name...
				{
					modNameS = String.Format(" [c/ffaf00:({0})]", modName.DisplayName.ToString()); //Make a string that formats the name into this: " (modname)" (in blue)
				}
				string TileName2 = tileName + modNameS; //Add name to List. For Vanilla tiles, it will only display the name, as modNameS will be equal to null
				if (modName != null) //If the tile has a mod name...
				{
					firstL = modName.DisplayName.ToString()[0]; //Set firstL to the first character of the mod's name
					bool SymbE = Regex.IsMatch(firstL.ToString(), "[a-e]", RegexOptions.IgnoreCase); //Set to true if firstL is any letter between A and E
					bool FL = Regex.IsMatch(firstL.ToString(), "[f-l]", RegexOptions.IgnoreCase); //Set to true if firstL is any letter between F and L
					bool MS = Regex.IsMatch(firstL.ToString(), "[m-s]", RegexOptions.IgnoreCase); //Set to true if firstL is any letter between M and S
					bool TZ = Regex.IsMatch(firstL.ToString(), "[t-z]", RegexOptions.IgnoreCase); //Set to true if firstL is any letter between T and Z

					if (SymbE || Char.IsSymbol(firstL) || Char.IsNumber(firstL)) //If name begins with A-E, a symbol, or a number...
					{
						SymbEModStrings.Add(TileName2);
					}
					else if (FL) //If name begins with F-L
					{
						FLModStrings.Add(TileName2);
					}
					else if (MS) //If name begins with M-S
					{
						MSModStrings.Add(TileName2);
					}
					else if (TZ) //If name begins with T-Z
					{
						TZModStrings.Add(TileName2);
					}
					else //If name somehow doesn't begin with any of the above...
					{
						Unknown.Add(TileName2);
					}
				}
				else
				{
					VanillaStrings.Add(TileName2); //If the tile has no mod name, just add it to the vanilla list
				}
			} //Adds tile names
			VanillaStrings.Remove("Table"); //Removes extra name added by Tables2
			VanillaStrings.Add("Water"); //Add Water name
			VanillaStrings.Add("Lava"); //Add Lava name
			VanillaStrings.Add("Honey"); //Add Honey name

			AllTiles = VanillaStrings.Union(SymbEModStrings).Union(FLModStrings).Union(MSModStrings).Union(TZModStrings).Union(Unknown).ToList(); //Make a list with all tile name strings in it

			VanillaStrings.Sort(); SymbEModStrings.Sort(); FLModStrings.Sort(); MSModStrings.Sort(); TZModStrings.Sort(); Unknown.Sort(); AllTiles.Sort(); //Alphabetize the lists

			string Vanilla = string.Join(", ", VanillaStrings.ToArray()); //Make one string for all Vanilla tile names (count = 0)
			string SymbEMod = string.Join(", ", SymbEModStrings.ToArray()); //Make one string for all A-E, Symbol, and Number tile names (count = 1)
			string FLMod = string.Join(", ", FLModStrings.ToArray()); //Make one string for all F-L tile names (count = 2)
			string MSMod = string.Join(", ", MSModStrings.ToArray()); //Make one string for all M-S tile names (count = 3)
			string TZMod = string.Join(", ", TZModStrings.ToArray()); //Make one string for all T-Z tile names (count = 4)
			string UnknownMod = string.Join(", ", Unknown.ToArray()); //Make one string for all unknown charater tile names (count = 5)
			string All = string.Join(", ", AllTiles.ToArray()); //Make one string for all tile names (count = 6)

			if (count > 6) //If count somehow equals 7...
			{
				count = 0; //Set it to 0; Count has no values for anything above 6
			}

			switch (count) //When right clicked, the tile withh preform the action associated to the current count value's case
			{
				case 0:
					Main.NewTextMultiline("Currently active Vanilla tiles: " + Vanilla + "."); //Make a string stating all active vanilla tiles
					if (SymbEMod.Any())
					{
						Main.NewText("Right-click again to see A - E tiles.");
						count += 1;
					} //If SymbE has anything in it, increase count to SmybE's case and display a string
					else if (FLMod.Any())
					{
						Main.NewText("Right-click again to see F - L tiles.");
						count += 2;
					}
					else if (MSMod.Any())
					{
						Main.NewText("Right-click again to see M - S tiles.");
						count += 3;
					}
					else if (TZMod.Any())
					{
						Main.NewText("Right-click again to see T - Z tiles.");
						count += 4;
					}
					else if (UnknownMod.Any())
					{
						Main.NewText("Right-click again to see unknown tiles.");
						count += 5;
					}
					else
					{
						break;
					} //If no mod list has any values, set count to All's case and display a message
					break; //Exit case
				case 1:
					Main.NewTextMultiline("Currently active tiles, mods A - E: " + SymbEMod + ".");
					if (FLMod.Any())
					{
						Main.NewText("Right-click again to see F - L tiles.");
						count += 1;
					}
					else if (MSMod.Any())
					{
						Main.NewText("Right-click again to see M - S tiles.");
						count += 2;
					}
					else if (TZMod.Any())
					{
						Main.NewText("Right-click again to see T - Z tiles.");
						count += 3;
					}
					else if (UnknownMod.Any())
					{
						Main.NewText("Right-click again to see unknown tiles.");
						count += 4;
					}
					else
					{
						Main.NewText("Right-click again to see all tiles.");
						count += 5;
					}
					break;

				case 2:
					Main.NewTextMultiline("Currently active tiles, mods F - L: " + FLMod + ".");
					if (MSMod.Any())
					{
						Main.NewText("Right-click again to see M - S tiles.");
						count += 1;
					}
					else if (TZMod.Any())
					{
						Main.NewText("Right-click again to see T - Z tiles.");
						count += 2;
					}
					else if (UnknownMod.Any())
					{
						Main.NewText("Right-click again to see unknown tiles.");
						count += 3;
					}
					else
					{
						Main.NewText("Right-click again to see all tiles.");
						count += 4;
					}
					break;

				case 3:
					Main.NewTextMultiline("Currently active tiles, mods M - S: " + MSMod + ".");
					if (TZMod.Any())
					{
						Main.NewText("Right-click again to see T - Z tiles.");
						count += 1;
					}
					else if (UnknownMod.Any())
					{
						Main.NewText("Right-click again to see unknown tiles.");
						count += 2;
					}
					else
					{
						Main.NewText("Right-click again to see all tiles.");
						count += 3;
					}
					break;

				case 4:
					Main.NewTextMultiline("Currently active tiles, mods T - Z: " + TZMod + ".");
					if (UnknownMod.Any())
					{
						Main.NewText("Right-click again to see unknown tiles.");
						count += 1;
					}
					else
					{
						Main.NewText("Right-click again to see all tiles.");
						count += 2;
					}
					break;

				case 5:
					Main.NewTextMultiline("Currently active tiles, unknown mods: " + UnknownMod + ".");
					Main.NewText("Right-click again to see all tiles.");
					count++;
					break;

				case 6:
					Main.NewTextMultiline("Currently active tiles: " + All + ".");
					Main.NewText("Right-click again to see Vanilla tiles.");
					count = 0;
					break;
			}

			#endregion New Right-Click List
		}

		/// <summary>
		/// Splits strings if needed and displays them to chat.
		/// </summary>
		/// <param name="text">String to be displayed and maybe split</param>
		private void NewTextLongSplitter(string text)
		{
			if (text.Length > 1000)
			{
				string[] textArray = text.Split(new char[] { ',' }, 2);
			}
			else
			{
			}
		}

		public override void NumDust(int i, int j, bool fail, ref int num)
		{
			num = fail ? 1 : 3;
		}

		public override void KillMultiTile(int i, int j, int frameX, int frameY)
		{
			Item.NewItem(i * 16, j * 16, 32, 16, mod.ItemType("UniversalCrafter"));
		}

		public override void PostDraw(int i, int j, SpriteBatch spriteBatch)
		{
			Tile tile = Main.tile[i, j];
			Vector2 zero = new Vector2(Main.offScreenRange, Main.offScreenRange);
			if (Main.drawToScreen) { zero = Vector2.Zero; }
			int height = tile.frameY == 36 ? 18 : 16;
			Main.spriteBatch.Draw(mod.GetTexture("Tiles/UniversalCrafter_Glowmask"), new Vector2(i * 16 - (int)Main.screenPosition.X, j * 16 - (int)Main.screenPosition.Y) + zero, new Rectangle(tile.frameX, tile.frameY, 16, height), Color.White, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0f);
		}

		public override void NearbyEffects(int i, int j, bool closer)
		{
			Player player = Main.player[Main.myPlayer];
			if (closer && NPC.downedBoss3)
			{
				player.alchemyTable = true;
			}
		}
	}
}