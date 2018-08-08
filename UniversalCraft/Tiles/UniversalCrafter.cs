using Terraria.DataStructures;
using System.Linq;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.ObjectData;
using Microsoft.Xna.Framework.Graphics;
using Terraria.ID;
using Terraria.Map;
using System;
using System.Text.RegularExpressions;

namespace UniversalCraft.Tiles
{
    public class UniversalCrafter : ModTile
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
            if (ModLoader.GetLoadedMods().Contains("Bismuth"))
                adjTile.Add(ModLoader.GetMod("Bismuth").TileType("PapuansBookcase"));
            if (ModLoader.GetLoadedMods().Contains("CheezeMod"))
                adjTile.Add(ModLoader.GetMod("CheezeMod").TileType("MegaCorpVendor"));
            if (ModLoader.GetLoadedMods().Contains("CookieModBeta"))
                adjTile.Add(ModLoader.GetMod("CookieModBeta").TileType("CookieBench"));
            if (ModLoader.GetLoadedMods().Contains("CookieModBeta2"))
                adjTile.Add(ModLoader.GetMod("CookieModBeta2").TileType("CookieBench"));
            if (ModLoader.GetLoadedMods().Contains("CosmeticVariety"))
            {
                adjTile.Add(ModLoader.GetMod("CosmeticVariety").TileType("Apiary"));
                adjTile.Add(ModLoader.GetMod("CosmeticVariety").TileType("CanningStation"));
                adjTile.Add(ModLoader.GetMod("CosmeticVariety").TileType("ChillMachine"));
                adjTile.Add(ModLoader.GetMod("CosmeticVariety").TileType("Easel"));
                adjTile.Add(ModLoader.GetMod("CosmeticVariety").TileType("Oven"));
                adjTile.Add(ModLoader.GetMod("CosmeticVariety").TileType("SculptingStation"));
            }
            if (ModLoader.GetLoadedMods().Contains("Crystilium"))
            {
                adjTile.Add(ModLoader.GetMod("Crystilium").TileType("CrystalWoodWorkbench"));
                adjTile.Add(ModLoader.GetMod("Crystilium").TileType("Fountain"));
            }
            if (ModLoader.GetLoadedMods().Contains("Exodus"))
            {
                adjTile.Add(ModLoader.GetMod("Exodus").TileType("BlastFurnaceTile"));
                adjTile.Add(ModLoader.GetMod("Exodus").TileType("SlimeWorkstation"));
            }
            if (ModLoader.GetLoadedMods().Contains("FlareStone"))
                adjTile.Add(ModLoader.GetMod("FlareStone").TileType("Accelerator"));
            if (ModLoader.GetLoadedMods().Contains("Laugicality"))
            {
                adjTile.Add(ModLoader.GetMod("Laugicality").TileType("AlchemicalInfuser"));
                adjTile.Add(ModLoader.GetMod("Laugicality").TileType("LaugicalWorkbench"));
                adjTile.Add(TileID.OpenDoor);
                adjTile.Add(TileID.ClosedDoor);
            }
            if (ModLoader.GetLoadedMods().Contains("MagicStorage"))
                adjTile.Add(ModLoader.GetMod("MagicStorage").TileType("CraftingAccess"));
            if (ModLoader.GetLoadedMods().Contains("MoAddon"))
                adjTile.Add(ModLoader.GetMod("MoAddon").TileType("SnowWBTile"));
            if (ModLoader.GetLoadedMods().Contains("OreConversion"))
                adjTile.Add(ModLoader.GetMod("OreConversion").TileType("OreConvertTable"));
            if (ModLoader.GetLoadedMods().Contains("RawExpansion"))
            {
                adjTile.Add(ModLoader.GetMod("RawExpansion").TileType("FleshCrafter"));
                adjTile.Add(ModLoader.GetMod("RawExpansion").TileType("UpgraderStation"));
            }
            if (ModLoader.GetLoadedMods().Contains("SpiritMod"))
                adjTile.Add(ModLoader.GetMod("SpiritMod").TileType("CreationAltarTile"));
            if (ModLoader.GetLoadedMods().Contains("StarWarsMod"))
                adjTile.Add(ModLoader.GetMod("StarWarsMod").TileType("GeologicalCompressor"));
            if (ModLoader.GetLoadedMods().Contains("thespatiummod"))
                adjTile.Add(ModLoader.GetMod("thespatiummod").TileType("GoldenBinder"));
            if (ModLoader.GetLoadedMods().Contains("ThoriumMod"))
                adjTile.Add(ModLoader.GetMod("ThoriumMod").TileType("ThoriumAnvil"));
            if (ModLoader.GetLoadedMods().Contains("Tremor"))
            {
                adjTile.Add(ModLoader.GetMod("Tremor").TileType("AltarofEnchantmentsTile"));
                adjTile.Add(ModLoader.GetMod("Tremor").TileType("BlastFurnace"));
                adjTile.Add(ModLoader.GetMod("Tremor").TileType("FleshWorkstationTile"));
                adjTile.Add(ModLoader.GetMod("Tremor").TileType("MagicWorkbenchTile"));
                adjTile.Add(ModLoader.GetMod("Tremor").TileType("MineralTransmutator"));
            }
            if (ModLoader.GetLoadedMods().Contains("VampKnives"))
                adjTile.Add(ModLoader.GetMod("VampKnives").TileType("KnifeBench"));
            if (ModLoader.GetLoadedMods().Contains("Exodus") || ModLoader.GetLoadedMods().Contains("GRealm") || ModLoader.GetLoadedMods().Contains("RawExpasion") || ModLoader.GetLoadedMods().Contains("CrittersRevamped") || ModLoader.GetLoadedMods().Contains("CloudRecipe") || ModLoader.GetLoadedMods().Contains("EvilBlockSwap") || ModLoader.GetLoadedMods().Contains("ExperienceAndClasses") || ModLoader.GetLoadedMods().Contains("ExperienceAndClassesRu") || ModLoader.GetLoadedMods().Contains("Hunger"))
                adjTile.Add(TileID.Campfire);
            if (ModLoader.GetLoadedMods().Contains("AE"))
                adjTile.Add(TileID.Extractinator);
            if (ModLoader.GetLoadedMods().Contains("AnomiconMod"))
                adjTile.Add(ModLoader.GetMod("AnomiconMod").TileType("DPrinter"));
            if (ModLoader.GetLoadedMods().Contains("AFKPETS"))
                adjTile.Add(TileID.Beds);
            if (ModLoader.GetLoadedMods().Contains("Aloha"))
            {
                adjTile.Add(TileID.Larva);
                adjTile.Add(TileID.Cactus);
            }
            if (ModLoader.GetLoadedMods().Contains("AGSmod"))
                adjTile.Add(TileID.Pigronata);
            if (ModLoader.GetLoadedMods().Contains("JoostMod"))
                adjTile.Add(ModLoader.GetMod("JoostMod").TileType("ShrineOfLegends"));
            if (ModLoader.GetLoadedMods().Contains("BetterBoneWelder"))
                adjTile.Add(ModLoader.GetMod("BetterBoneWelder").TileType("DaemonForge"));
            if (ModLoader.GetLoadedMods().Contains("BeastPack"))
            {
                adjTile.Add(ModLoader.GetMod("BeastPack").TileType("AdvancedWorkStation"));
                adjTile.Add(ModLoader.GetMod("BeastPack").TileType("WorkStation"));
                adjTile.Add(ModLoader.GetMod("BeastPack").TileType("SkyForge"));
            }
            if (ModLoader.GetLoadedMods().Contains("BuildPlanner"))
                adjTile.Add(ModLoader.GetMod("BuildPlanner").TileType("Scaffold"));
            if (ModLoader.GetLoadedMods().Contains("bloodScythes"))
                adjTile.Add(TileID.Bowls);
            if (ModLoader.GetLoadedMods().Contains("BuilderPlus"))
                adjTile.Add(TileID.WaterDrip);
            if (ModLoader.GetLoadedMods().Contains("DylansMod"))
                adjTile.Add(ModLoader.GetMod("DylansMod").TileType("EnchantmentTable"));
            if (ModLoader.GetLoadedMods().Contains("DestinyItemsMod"))
                adjTile.Add(ModLoader.GetMod("DestinyItemsMod").TileType("GuardiansForge"));
            if (ModLoader.GetLoadedMods().Contains("DirtMod"))
                adjTile.Add(ModLoader.GetMod("DirtMod").TileType("DirtFurnace"));
            if (ModLoader.GetLoadedMods().Contains("TerrariaDark"))
                adjTile.Add(ModLoader.GetMod("TerrariaDark").TileType("DarkAltar"));
            if (ModLoader.GetLoadedMods().Contains("DoggysMod"))
                adjTile.Add(ModLoader.GetMod("DoggysMod").TileType("SuspiciousGlass"));
            if (ModLoader.GetLoadedMods().Contains("DankBuysMod"))
            {
                adjTile.Add(TileID.MonarchButterflyJar);
                adjTile.Add(TileID.FossilOre);
            }
            if (ModLoader.GetLoadedMods().Contains("Dalekanium") || ModLoader.GetLoadedMods().Contains("HellstoneShotmod"))
                adjTile.Add(TileID.Sinks);
            if (ModLoader.GetLoadedMods().Contains("ExtendedCrops"))
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
            if (ModLoader.GetLoadedMods().Contains("Eclipysian") || ModLoader.GetLoadedMods().Contains("ExampleMod") || ModLoader.GetLoadedMods().Contains("Test__Test"))
                adjTile.Add(TileID.FireflyinaBottle);
            if (ModLoader.GetLoadedMods().Contains("EasyFishing") || ModLoader.GetLoadedMods().Contains("FrecMod"))
                adjTile.Add(TileID.Sunflower);
            if (ModLoader.GetLoadedMods().Contains("FabusMod"))
                adjTile.Add(TileID.Books);
            if (ModLoader.GetLoadedMods().Contains("FantasiesAdvance"))
            {
                adjTile.Add(ModLoader.GetMod("FantasiesAdvance").TileType("DwarvenForge"));
                adjTile.Add(ModLoader.GetMod("FantasiesAdvance").TileType("DwarvenAnvil"));
            }
            if (ModLoader.GetLoadedMods().Contains("Fernium"))
                adjTile.Add(ModLoader.GetMod("Fernium").TileType("LivingWorkbench"));
            if (ModLoader.GetLoadedMods().Contains("Gemology"))
                adjTile.Add(ModLoader.GetMod("Gemology").TileType("gemRefineryPlaced"));
            if (ModLoader.GetLoadedMods().Contains("HappyDaysMod"))
            {
                adjTile.Add(ModLoader.GetMod("HappyDaysMod").TileType("WeaponStation"));
                adjTile.Add(ModLoader.GetMod("HappyDaysMod").TileType("WoodenExtractor"));
                adjTile.Add(ModLoader.GetMod("HappyDaysMod").TileType("ChemistryTable"));
                adjTile.Add(ModLoader.GetMod("HappyDaysMod").TileType("CreatorsTable"));
                adjTile.Add(ModLoader.GetMod("HappyDaysMod").TileType("BoozeKit"));
                adjTile.Add(ModLoader.GetMod("HappyDaysMod").TileType("Apothecary"));
            }
            if (ModLoader.GetLoadedMods().Contains("Illaz"))
                adjTile.Add(ModLoader.GetMod("Illaz").TileType("IllazWorkbench"));
            if (ModLoader.GetLoadedMods().Contains("Inkursion"))
                adjTile.Add(ModLoader.GetMod("Inkursion").TileType("InkyWorkbench"));
            if (ModLoader.GetLoadedMods().Contains("HellstoneShotmod"))
            {
                adjTile.Add(TileID.Tombstones);
                adjTile.Add(TileID.Cobweb);
            }
            if (ModLoader.GetLoadedMods().Contains("Insanity"))
                adjTile.Add(TileID.Candles);
            if (ModLoader.GetLoadedMods().Contains("CyversMod"))
                adjTile.Add(TileID.Trees);
            #endregion
            adjTiles = adjTile.ToArray();
            #endregion
        }

        public static List<string> TileList = new List<string>(); //Empty list for tile names
        public static List<int> ToConvert = new List<int>(); //Temp. list for all adjTile ints
        public static int[] UCTAdj = new int[256]; //Temp. int[] for UCTile.AdjTiles

        int count = 0;

        public static List<string> VanillaStrings = new List<string>(); //List for vanilla tiles
        public static List<string> SymbEModStrings = new List<string>(); //List for mods whose names starts with letters a-e + number and symbols
        public static List<string> FLModStrings = new List<string>(); // f-l
        public static List<string> MSModStrings = new List<string>(); // m-s
        public static List<string> TZModStrings = new List<string>(); // t-z
        public static List<string> Unknown = new List<string>(); //else
        public static List<string> AllTiles = new List<string>();

        public override void RightClick(int i, int j)
        {
            #region New Right-Click List
            //if (Main.tile[i, j].frameX == 36 && Main.tile[i, j].frameY == 0) //Blue orb on top of tile
            //{
            UCTAdj = mod.GetGlobalTile("UCTile").AdjTiles(mod.TileType("UniversalCrafter")); //Get AdjTiles from UCTile
            ToConvert = adjTile.Union(UCTAdj).ToList(); //Turns the two arrays into a list
            VanillaStrings.Clear(); SymbEModStrings.Clear(); FLModStrings.Clear(); MSModStrings.Clear(); TZModStrings.Clear(); Unknown.Clear(); AllTiles.Clear();
            foreach (int tile in ToConvert) //For every integer in ToConvert...
            {
                Mod modName = null; //Set modName to null
                string modNameS = ""; //Set modNameString to null
                string tileName = Lang.GetMapObjectName(MapHelper.TileToLookup(tile, 0)); //Set tileName to look up each tile's name
                char firstL;
                if (tileName == "")
                {
                    if (tile < TileID.Count)
                        tileName = "Tile " + tile; //Invalid name
                    else
                        tileName = TileLoader.GetTile(tile).Name; //Valid name
                }
                if (TileLoader.GetTile(tile) != null) //If the tile is a modded tile...
                {
                    modName = TileLoader.GetTile(tile).mod;
                }
                if (modName != null)
                {
                    modNameS = String.Format(" [c/ffaf00:({0})]", modName.DisplayName.ToString());
                }
                string TileName2 = tileName + modNameS; //Add name to List. For Vanilla tiles, it will only display the name, as modNameS will be equal to null
                if (modName != null)
                {
                    firstL = modName.DisplayName.ToString()[0];
                    bool SymbE = Regex.IsMatch(firstL.ToString(), "[a-e]", RegexOptions.IgnoreCase);
                    bool FL = Regex.IsMatch(firstL.ToString(), "[f-l]", RegexOptions.IgnoreCase);
                    bool MS = Regex.IsMatch(firstL.ToString(), "[m-s]", RegexOptions.IgnoreCase);
                    bool TZ = Regex.IsMatch(firstL.ToString(), "[t-z]", RegexOptions.IgnoreCase);

                    if (SymbE || Char.IsSymbol(firstL) || Char.IsNumber(firstL))
                        SymbEModStrings.Add(TileName2);
                    else if (FL)
                        FLModStrings.Add(TileName2);
                    else if (MS)
                        MSModStrings.Add(TileName2);
                    else if (TZ)
                        TZModStrings.Add(TileName2);
                    else
                        Unknown.Add(TileName2);
                }
                else
                    VanillaStrings.Add(TileName2);

            } //Adds tile names
            VanillaStrings.Remove("Table"); //Removes extra name added by Tables and Tables2
            VanillaStrings.Add("Water"); //Add Water name
            VanillaStrings.Add("Lava"); //Add Lava name
            VanillaStrings.Add("Honey"); //Add Honey name

            AllTiles = VanillaStrings.Union(SymbEModStrings).Union(FLModStrings).Union(MSModStrings).Union(TZModStrings).Union(Unknown).ToList();

            VanillaStrings.Sort(); //Alphabetize the list
            SymbEModStrings.Sort();
            FLModStrings.Sort();
            MSModStrings.Sort();
            TZModStrings.Sort();
            Unknown.Sort();
            AllTiles.Sort();

            //string TileListString = string.Join(", ", TileList.ToArray()); //Seperate everything with commas

            string Vanilla = string.Join(", ", VanillaStrings.ToArray()); //0
            string SymbEMod = string.Join(", ", SymbEModStrings.ToArray()); //1
            string FLMod = string.Join(", ", FLModStrings.ToArray()); //2
            string MSMod = string.Join(", ", MSModStrings.ToArray()); //3
            string TZMod = string.Join(", ", TZModStrings.ToArray()); //4
            string UnknownMod = string.Join(", ", Unknown.ToArray()); //5
            string All = string.Join(", ", AllTiles.ToArray()); //6

            if (count > 6)
                count = 0;

            switch (count)
            {
                case 0:
                    Main.NewTextMultiline("Currently active Vanilla tiles: " + Vanilla + ".");
                    if (SymbEMod.Any())
                    {
                        Main.NewText("Right-click again to see A - E tiles.");
                        count += 1;
                    }
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
                    }
                    break;
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
            //}
            #endregion
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
    }

    public class UCTile : GlobalTile
    {
        #region Mods
        Mod afkPets = ModLoader.GetMod("AFKPETS");
        Mod alchemistNPC = ModLoader.GetMod("AlchemistNPC");
        Mod aventadorsMod = ModLoader.GetMod("AventadorsMod");
        Mod azurium = ModLoader.GetMod("Azurium");
        Mod bananium = ModLoader.GetMod("Bananium");
        Mod betterPaint = ModLoader.GetMod("BetterPaint");
        Mod bismuth = ModLoader.GetMod("Bismuth");
        Mod bluemagic = ModLoader.GetMod("Bluemagic");
        Mod boi = ModLoader.GetMod("Boi");
        Mod calamityMod = ModLoader.GetMod("CalamityMod");
        Mod chadsFurni = ModLoader.GetMod("chadsfurni");
        Mod copperPlusMod = ModLoader.GetMod("CopperPlusMod");
        Mod cosmeticVariety = ModLoader.GetMod("CosmeticVariety");
        Mod disarray = ModLoader.GetMod("Disarray");
        Mod draxyMod = ModLoader.GetMod("DraxyMOD");
        Mod exodus = ModLoader.GetMod("Exodus");
        Mod extendedCrops = ModLoader.GetMod("ExtendedCrops");
        Mod fargowiltas = ModLoader.GetMod("Fargowiltas");
        Mod fishing3 = ModLoader.GetMod("Fishing3");
        Mod forbiddenCryonics = ModLoader.GetMod("ForbiddenCryonics");
        Mod gadgetBox = ModLoader.GetMod("GadgetBox");
        Mod ghoul = ModLoader.GetMod("Ghoul");
        Mod gRealm = ModLoader.GetMod("GRealm");
        Mod hmPlus = ModLoader.GetMod("HMPlus");
        Mod joostMod = ModLoader.GetMod("JoostMod");
        Mod laugicality = ModLoader.GetMod("Laugicality");
        Mod mysticality = ModLoader.GetMod("Mysticality");
        Mod osmium = ModLoader.GetMod("Osmium");
        Mod project__C = ModLoader.GetMod("Project__C");
        Mod pumpking = ModLoader.GetMod("Pumpking");
        Mod sacredTools = ModLoader.GetMod("SacredTools");
        Mod serrariaModTwo = ModLoader.GetMod("SerrariaModTwo");
        Mod spiritMod = ModLoader.GetMod("SpiritMod");
        Mod terrariaDark = ModLoader.GetMod("TerrariaDark");
        Mod theDeconstructor = ModLoader.GetMod("TheDeconstructor");
        Mod theSpatiumMod = ModLoader.GetMod("thespatiummod");
        Mod thoriumMod = ModLoader.GetMod("ThoriumMod");
        Mod tremor = ModLoader.GetMod("Tremor");
        #endregion

        public override int[] AdjTiles(int type)
        {
            List<int> adjTile = new List<int>();

            if (type == mod.TileType("UniversalCrafter"))
            {
                Main.LocalPlayer.adjWater = true;
                Main.LocalPlayer.adjLava = true;
                Main.LocalPlayer.adjHoney = true;
                if (NPC.downedSlimeKing)
                {
                    adjTile.Add(TileID.Solidifier);
                    if (azurium != null)
                        adjTile.Add(azurium.TileType("SlimeStationTile"));
                }
                if (NPC.downedBoss1)
                {
                    if (thoriumMod != null)
                        adjTile.Add(thoriumMod.TileType("ArcaneArmorFabricator"));
                }
                if (NPC.downedGoblins)
                {
                    adjTile.Add(TileID.TinkerersWorkbench);
                    if (serrariaModTwo != null)
                    {
                        adjTile.Add(serrariaModTwo.TileType("UncraftingTable"));
                        adjTile.Add(serrariaModTwo.TileType("UnUnCraftingTable"));
                    }
                }
                if (NPC.downedBoss2)
                {
                    if (alchemistNPC != null)
                        adjTile.Add(alchemistNPC.TileType("WingoftheWorld"));
                    if (tremor != null)
                        adjTile.Add(tremor.TileType("DevilForge"));
                }
                if (NPC.downedBoss3)
                {
                    adjTile.Add(TileID.BoneWelder);
                    adjTile.Add(TileID.AlchemyTable);
                    Player player = new Player { alchemyTable = true };
                    if (chadsFurni != null)
                    {
                        adjTile.Add(chadsFurni.TileType("printer3"));
                        adjTile.Add(chadsFurni.TileType("wallomatic"));
                        adjTile.Add(chadsFurni.TileType("printer"));
                    }
                    if (cosmeticVariety != null)
                        adjTile.Add(cosmeticVariety.TileType("BeverageBrewer"));
                    if (laugicality != null)
                    {
                        adjTile.Add(laugicality.TileType("CrystalineInfuser"));
                        adjTile.Add(laugicality.TileType("TransmutationTable"));
                    }
                    if (osmium != null)
                        adjTile.Add(osmium.TileType("BarPressTile"));
                    if (tremor != null)
                        adjTile.Add(tremor.TileType("NecromaniacWorkbenchTile"));
                    if (afkPets != null)
                        adjTile.Add(afkPets.TileType("Computer"));
                }
                if (NPC.downedBoss1 || NPC.downedBoss2 || NPC.downedBoss3)
                {
                    if (chadsFurni != null)
                        adjTile.Add(chadsFurni.TileType("CultivationBox"));
                }
                if (NPC.downedQueenBee)
                {
                    adjTile.Add(TileID.ImbuingStation);
                    if (ModLoader.GetLoadedMods().Contains("corofevil"))
                        adjTile.Add(TileID.WaterFountain);
                }
                if (Main.hardMode)
                {
                    adjTile.Add(TileID.MeatGrinder);
                    adjTile.Add(TileID.MythrilAnvil);
                    adjTile.Add(TileID.CrystalBall);
                    adjTile.Add(TileID.AdamantiteForge);
                    if (bismuth != null)
                    {
                        adjTile.Add(bismuth.TileType("RuneTable"));
                        adjTile.Add(bismuth.TileType("OrcishBookcase"));
                    }
                    if (cosmeticVariety != null)
                        adjTile.Add(cosmeticVariety.TileType("ShadowExtraltar"));
                    if (joostMod != null)
                        adjTile.Add(joostMod.TileType("ElementalForge"));
                    if (laugicality != null)
                        adjTile.Add(laugicality.TileType("MineralEnchanter"));
                    if (spiritMod != null)
                        adjTile.Add(spiritMod.TileType("EssenceDistorter"));
                    if (theSpatiumMod != null)
                        adjTile.Add(theSpatiumMod.TileType("CobaltBinder"));
                    if (tremor != null)
                        adjTile.Add(tremor.TileType("RecyclerofMatterTile"));
                    if (chadsFurni != null)
                        adjTile.Add(chadsFurni.TileType("RimpelstiltskinsLoom"));
                    if (hmPlus != null)
                        adjTile.Add(TileID.LivingFire);
                    if (boi != null)
                        adjTile.Add(TileID.RainbowBrick);
                    if (draxyMod != null)
                        adjTile.Add(draxyMod.TileType("PreBoss__altar"));
                    if (terrariaDark != null)
                        adjTile.Add(terrariaDark.TileType("DaedricForge"));
                    if (extendedCrops != null)
                    {
                        adjTile.Add(extendedCrops.TileType("ICobaltSeedProcessor"));
                        adjTile.Add(extendedCrops.TileType("IPalladiumSeedProcessor"));
                        adjTile.Add(extendedCrops.TileType("JMythrilSeedProcessor"));
                        adjTile.Add(extendedCrops.TileType("JOrichalcumSeedProcessor"));
                        adjTile.Add(extendedCrops.TileType("KAdamantiteSeedProcessor"));
                        adjTile.Add(extendedCrops.TileType("KTitaniumSeedProcessor"));
                    }
                    if (forbiddenCryonics != null)
                        adjTile.Add(forbiddenCryonics.TileType("SoulWeaverTile"));
                }
                if (NPC.downedPirates)
                {

                }
                if (NPC.downedMechBossAny)
                {
                    adjTile.Add(TileID.SteampunkBoiler);
                    adjTile.Add(TileID.FleshCloningVat);
                    adjTile.Add(TileID.Blendomatic);
                    if (osmium != null)
                        adjTile.Add(osmium.TileType("HallowedAnvilTile"));
                    if (bluemagic != null)
                        adjTile.Add(bluemagic.TileType("Clentamistation"));
                    if (betterPaint != null)
                        adjTile.Add(betterPaint.TileType("PaintMixer"));
                    if (extendedCrops != null)
                        adjTile.Add(extendedCrops.TileType("LHallowedSeedProcessor"));
                }
                if (NPC.downedMechBoss1 && NPC.downedMechBoss2 && NPC.downedMechBoss3)
                {
                    if (copperPlusMod != null)
                    {
                        adjTile.Add(copperPlusMod.TileType("VigolythicAnvil"));
                        adjTile.Add(copperPlusMod.TileType("OddForge"));
                    }
                    if (theSpatiumMod != null)
                        adjTile.Add(theSpatiumMod.TileType("SoulfulBinder"));
                    if (thoriumMod != null)
                        adjTile.Add(thoriumMod.TileType("SoulForge"));
                    if (bananium != null)
                        adjTile.Add(bananium.TileType("BananaAnvil"));
                    if (extendedCrops != null)
                        adjTile.Add(extendedCrops.TileType("MChlorophyteSeedProcessor"));
                }
                if (NPC.downedPlantBoss)
                {
                    adjTile.Add(TileID.Autohammer);
                    adjTile.Add(TileID.LihzahrdFurnace);
                    if (exodus != null)
                        adjTile.Add(exodus.TileType("SecretMilitaryWorkshopTile"));
                    if (laugicality != null)
                        adjTile.Add(laugicality.TileType("AncientEnchanter"));
                    if (pumpking != null || afkPets != null || ghoul != null)
                        adjTile.Add(TileID.LihzahrdAltar);
                    if (tremor != null)
                        adjTile.Add(tremor.TileType("AlchematorTile"));
                    if (gadgetBox != null)
                        adjTile.Add(gadgetBox.TileType("LihzahrdWorkshopTile"));
                    if (aventadorsMod != null)
                        adjTile.Add(aventadorsMod.TileType("NeonChargerTile"));
                    if (extendedCrops != null)
                    {
                        adjTile.Add(extendedCrops.TileType("NSpectreSeedProcessor"));
                        adjTile.Add(extendedCrops.TileType("OShroomiteSeedProcessor"));
                    }
                }
                if (NPC.downedHalloweenTree)
                {

                }
                if (NPC.downedHalloweenKing)
                {

                }
                if (NPC.downedChristmasTree)
                {

                }
                if (NPC.downedChristmasSantank)
                {

                }
                if (NPC.downedChristmasIceQueen)
                {

                }
                if (NPC.downedGolemBoss)
                {
                    if (gRealm != null)
                        adjTile.Add(gRealm.TileType("ArcaneWeldingStation"));
                }
                if (NPC.downedFishron)
                {

                }
                if (NPC.downedMartians)
                {
                    if (fishing3 != null)
                        adjTile.Add(fishing3.TileType("AnalyzerTile"));
                }
                if (NPC.downedAncientCultist)
                {
                    adjTile.Add(TileID.LunarCraftingStation);
                    if (alchemistNPC != null)
                        adjTile.Add(alchemistNPC.TileType("MateriaTransmutator"));
                    if (fargowiltas != null)
                        adjTile.Add(fargowiltas.TileType("CrucibleCosmosSheet"));
                    if (project__C != null)
                        adjTile.Add(project__C.TileType("EnergyCondenser"));
                }
                if (NPC.downedTowerSolar)
                {

                }
                if (NPC.downedTowerVortex)
                {

                }
                if (NPC.downedTowerNebula)
                {

                }
                if (NPC.downedTowerStardust)
                {

                }
                if (NPC.downedMoonlord)
                {
                    if (cosmeticVariety != null)
                        adjTile.Add(cosmeticVariety.TileType("AegisContraption"));
                    if (theDeconstructor != null)
                        adjTile.Add(theDeconstructor.TileType("Deconstructor"));
                    if (theSpatiumMod != null)
                        adjTile.Add(theSpatiumMod.TileType("CelestialBinder"));
                    if (tremor != null)
                    {
                        adjTile.Add(tremor.TileType("Starvil"));
                        adjTile.Add(tremor.TileType("AlchemyStationTile"));
                    }
                    if (disarray != null)
                        adjTile.Add(disarray.TileType("ProfaneAnvilTile"));
                    if (extendedCrops != null)
                        adjTile.Add(extendedCrops.TileType("PLuminiteSeedProcessor"));
                }
                if (NPC.downedSlimeKing || NPC.downedBoss1 || NPC.downedBoss2 || NPC.downedBoss3 || NPC.downedQueenBee || Main.hardMode || NPC.downedMechBossAny || NPC.downedPlantBoss || NPC.downedGolemBoss || NPC.downedFishron || NPC.downedAncientCultist || NPC.downedMoonlord)
                {
                    if (mysticality != null)
                        adjTile.Add(mysticality.TileType("OmniBench"));
                }
                if (sacredTools != null)
                {
                    if (Abaddon1 || Abaddon2)
                        adjTile.Add(sacredTools.TileType("OblivionForge"));
                    if (Lunarians)
                        adjTile.Add(sacredTools.TileType("LunarAltar"));
                    if (Araghur)
                    {
                        adjTile.Add(sacredTools.TileType("FlameAnvil"));
                        adjTile.Add(sacredTools.TileType("FlameWorkbench"));
                        adjTile.Add(sacredTools.TileType("FlameForge"));
                    }
                    if (Cerena)
                    {
                        adjTile.Add(sacredTools.TileType("FrostAnvil"));
                        adjTile.Add(sacredTools.TileType("FrostForge"));
                    }
                    if (Erazor)
                        adjTile.Add(sacredTools.TileType("AsthralWorkbench"));
                }
                if (calamityMod != null)
                {
                    if (DoG)
                        adjTile.Add(calamityMod.TileType("DraedonsForge"));
                }
                if (bluemagic != null)
                {
                    if (Abomination && NPC.downedMoonlord)
                    {
                        adjTile.Add(bluemagic.TileType("PuriumForge"));
                        adjTile.Add(bluemagic.TileType("PuriumAnvil"));
                    }
                }
                if (pumpking != null)
                {
                    if (TerraLord)
                        adjTile.Add(pumpking.TileType("TerraForge"));
                }
                if (tremor != null)
                {
                    if (TikiTotem)
                        adjTile.Add(tremor.TileType("GreatAnvilTile"));
                    if (Trinity)
                        adjTile.Add(tremor.TileType("DivineForgeTile"));
                }
                if (copperPlusMod != null)
                {
                    if (NPC.downedMoonlord && SuperiorBeing)
                        adjTile.Add(copperPlusMod.TileType("AtomObliterator"));
                }
            }
            return adjTile.ToArray();
        }

        #region Bools
        public bool Abaddon1
        {
            get { return SacredTools.ModdedWorld.downedAbaddon; }
        }
        public bool Abaddon2
        {
            get { return SacredTools.ModdedWorld.OblivionSpawns; }
        }
        public bool Lunarians
        {
            get { return SacredTools.ModdedWorld.downedLunarians; }
        }
        public bool Araghur
        {
            get { return SacredTools.ModdedWorld.FlariumSpawns; }
        }
        public bool Cerena
        {
            get { return SacredTools.ModdedWorld.CerniumSpawns; }
        }
        public bool Erazor
        {
            get { return SacredTools.ModdedWorld.downedChallenger; }
        }
        public bool DoG
        {
            get { return CalamityMod.CalamityWorld.downedDoG; }
        }
        public bool Abomination
        {
            get { return Bluemagic.BluemagicWorld.downedAbomination; }
        }
        public bool TerraLord
        {
            get { return Pumpking.PumpkingWorld.downedTerraLord; }
        }
        public bool TikiTotem
        {
            get { return Tremor.TremorWorld.downedBoss[Tremor.TremorWorld.Boss.TikiTotem]; }
        }
        public bool Trinity
        {
            get { return Tremor.TremorWorld.downedBoss[Tremor.TremorWorld.Boss.Trinity]; }
        }
        public bool SuperiorBeing
        {
            get { return CopperPlusMod.CopperWorld.downedBeing; }
        }
        #endregion
    }
}