using Terraria.DataStructures;
using System.Linq;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace UniversalCraft.Tiles
{
    public class UniversalCrafter : ModTile
    {
        Mod sacredTools = ModLoader.GetMod("SacredTools");
        Mod calamity = ModLoader.GetMod("CalamityMod");
        Mod bluemagic = ModLoader.GetMod("Bluemagic");
        Mod pumpking = ModLoader.GetMod("Pumpking");
        Mod tremor = ModLoader.GetMod("Tremor");

        public override void SetDefaults()
        {
            Main.tileSolidTop[Type] = false;
            Main.tileFrameImportant[Type] = true;
            Main.tileNoAttach[Type] = true;
            Main.tileTable[Type] = false;
            Main.tileLavaDeath[Type] = false;
            TileObjectData.newTile.CopyFrom(TileObjectData.Style2x2);
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

            #region AdjTiles
            List<int> adjTile = new List<int>();

            adjTile.Add(18); //WorkBenches
            adjTile.Add(17); //Furnaces
            adjTile.Add(16); //Anvils
            adjTile.Add(13); //Bottles
            adjTile.Add(106); //Sawmill
            adjTile.Add(86); //Loom
            adjTile.Add(15); //Chairs
            adjTile.Add(14); //Tables
            adjTile.Add(469); //Tables2
            adjTile.Add(96); //CookingPots
            adjTile.Add(228); //DyeVat
            adjTile.Add(101); //Bookcases
            adjTile.Add(94); //Kegs
            adjTile.Add(283); //HeavyWorkBench
            adjTile.Add(302); //GlassKiln
            adjTile.Add(306); //IceMachine
            adjTile.Add(304); //LivingLoom
            adjTile.Add(305); //SkyMill
            adjTile.Add(172); //Sinks
            adjTile.Add(215); //Campfire
            adjTile.Add(191); //Living Wood
            adjTile.Add(80); //Cactus
            adjTile.Add(270); //Firefly in a Bottle
            adjTile.Add(50); //Book
            adjTile.Add(207); //Water Fountain

            if (ModLoader.GetLoadedMods().Contains("CosmeticVariety"))
            {
                Mod FFF = ModLoader.GetMod("CosmeticVariety");
                adjTile.Add(FFF.TileType("SculptingStand"));
                adjTile.Add(FFF.TileType("CanningStation"));
                adjTile.Add(FFF.TileType("ChillMachine"));
                adjTile.Add(FFF.TileType("Apiary"));
                adjTile.Add(FFF.TileType("Oven"));
                adjTile.Add(FFF.TileType("Easel"));
            }

            if (ModLoader.GetLoadedMods().Contains("Tremor"))
            {
                Mod tremor = ModLoader.GetMod("Tremor");
                adjTile.Add(tremor.TileType("MagicWorkbenchTile"));
                adjTile.Add(tremor.TileType("AltarofEnchantmentsTile"));
                adjTile.Add(tremor.TileType("MineralTransmutator"));
                adjTile.Add(tremor.TileType("FleshWorkstationTile"));
                adjTile.Add(tremor.TileType("BlastFurnace"));
            }

            if (ModLoader.GetLoadedMods().Contains("ThoriumMod"))
            {
                Mod thorium = ModLoader.GetMod("ThoriumMod");
                adjTile.Add(thorium.TileType("ThoriumAnvil"));
            }

            if (ModLoader.GetLoadedMods().Contains("Antiaris"))
            {
                Mod ant = ModLoader.GetMod("Antiaris");
                adjTile.Add(ant.TileType("Compressor"));
            }

            if (ModLoader.GetLoadedMods().Contains("CrystilliumMod"))
            {
                Mod crystal = ModLoader.GetMod("CrystilliumMod");
                adjTile.Add(crystal.TileType("Fountain"));
                adjTile.Add(crystal.TileType("CrystalWoodWorkbench"));
            }

            if (ModLoader.GetLoadedMods().Contains("Laugicality"))
            {
                Mod logic = ModLoader.GetMod("Laugicality");
                adjTile.Add(logic.TileType("AlchemicalInfuser"));
                adjTile.Add(logic.TileType("LaugicalWorkbench"));
            }

            if (ModLoader.GetLoadedMods().Contains("SpiritMod"))
            {
                Mod spirit = ModLoader.GetMod("SpiritMod");
                adjTile.Add(spirit.TileType("CreationAltarTile"));
            }

            if (ModLoader.GetLoadedMods().Contains("ElementsAwoken"))
            {
                Mod elem = ModLoader.GetMod("ElementsAwoken");
                adjTile.Add(elem.TileType("ElementalForge"));
            }

            if (ModLoader.GetLoadedMods().Contains("RawExpansion"))
            {
                Mod raw = ModLoader.GetMod("RawExpansion");
                adjTile.Add(raw.TileType("UpgraderStation"));
            }

            if (ModLoader.GetLoadedMods().Contains("CheezeMod"))
            {
                Mod cheeze = ModLoader.GetMod("CheezeMod");
                adjTile.Add(cheeze.TileType("MegaCorpVendor"));
            }

            if (ModLoader.GetLoadedMods().Contains("MoAddon"))
            {
                Mod mo = ModLoader.GetMod("MoAddon");
                adjTile.Add(mo.TileType("SnowWBTile"));
            }

            if (ModLoader.GetLoadedMods().Contains("thespatiummod"))
            {
                Mod bind = ModLoader.GetMod("thespatiummod");
                adjTile.Add(bind.TileType("GoldenBinder"));
            }

            if (ModLoader.GetLoadedMods().Contains("OreConversion"))
            {
                Mod ore = ModLoader.GetMod("OreConversion");
                adjTile.Add(ore.TileType("OreConvertTable"));
            }

            if (ModLoader.GetLoadedMods().Contains("Exodus"))
            {
                Mod exodus = ModLoader.GetMod("Exodus");
                adjTile.Add(exodus.TileType("SlimeWorkstation"));
            }

            if (ModLoader.GetLoadedMods().Contains("CookieModBeta2"))
            {
                Mod cookie = ModLoader.GetMod("CookieModBeta2");
                adjTile.Add(cookie.TileType("CookieBench"));
            }

            if (ModLoader.GetLoadedMods().Contains("FlareStone"))
            {
                Mod flare = ModLoader.GetMod("FlareStone");
                adjTile.Add(flare.TileType("AcceleratorTile"));
            }

            if (ModLoader.GetLoadedMods().Contains("Bismuth"))
            {
                Mod bismuth = ModLoader.GetMod("Bismuth");
                adjTile.Add(bismuth.TileType("PapuansBookcase"));
            }

            if (ModLoader.GetLoadedMods().Contains("BuildPlanner"))
            {
                Mod scaffold = ModLoader.GetMod("BuildPlanner");
                adjTile.Add(scaffold.TileType("Scaffold"));
                adjTile.Add(scaffold.TileType("ScaffoldPlatform"));
            }

            if (ModLoader.GetLoadedMods().Contains("MagicStorage"))
            {
                Mod storage = ModLoader.GetMod("MagicStorage");
                adjTile.Add(storage.TileType("CraftingAccess"));
            }

            if (ModLoader.GetLoadedMods().Contains("StarWarsMod"))
            {
                Mod star = ModLoader.GetMod("StarWarsMod");
                adjTile.Add(star.TileType("GeologicalCompressor"));
            }

            adjTiles = adjTile.ToArray();
            #endregion
        }

        public override void RightClick(int i, int j)
        {
            #region Right-Click List
            List<string> rightClick = new List<string>();

            rightClick.Add("A Workbench"); //WorkBenches
            rightClick.Add("a Furnace"); //Furnaces
            rightClick.Add("an Anvil"); //Anvils
            rightClick.Add("a Bottle"); //Bottles
            rightClick.Add("a Sawmill"); //Sawmill
            rightClick.Add("a Loom"); //Loom
            rightClick.Add("a Chair"); //Chairs
            rightClick.Add("a Table"); //Tables & Tables2
            rightClick.Add("a Cooking Pot"); //CookingPots
            rightClick.Add("a Dye Vat"); //DyeVat
            rightClick.Add("a Bookcase"); //Bookcases
            rightClick.Add("a Keg"); //Kegs
            rightClick.Add("a Heavy Work Bench"); //HeavyWorkBench
            rightClick.Add("a Glass Kiln"); //GlassKiln
            rightClick.Add("a Ice Machine"); //IceMachine
            rightClick.Add("a Living Loom"); //LivingLoom
            rightClick.Add("a Sky Mill"); //SkyMill
            rightClick.Add("a Sink"); //Sinks
            rightClick.Add("a Campfire"); //Campfire
            rightClick.Add("a block of Living Wood"); //Living Wood
            rightClick.Add("a block of Cactus"); //Cactus
            rightClick.Add("a Firefly in a Bottle"); //Firefly in a Bottle
            rightClick.Add("a Book"); //Book
            rightClick.Add("a Water Fountain"); //Water Fountain
            rightClick.Add("Water");

            if (ModLoader.GetLoadedMods().Contains("CosmeticVariety"))
            {
                rightClick.Add("a Sculpting Stand");
                rightClick.Add("a Canning Station");
                rightClick.Add("a Chill Machine");
                rightClick.Add("an Apiray");
                rightClick.Add("an Oven");
                rightClick.Add("an Easel");
            }

            if (ModLoader.GetLoadedMods().Contains("Tremor"))
            {
                rightClick.Add("a Magic Workbench");
                rightClick.Add("an Altar of Enchantments");
                rightClick.Add("a Mineral Transmutator");
                rightClick.Add("a Flesh Workstation");
                rightClick.Add("a Blast Furnace");
            }

            if (ModLoader.GetLoadedMods().Contains("ThoriumMod"))
            {
                rightClick.Add("a Thorium Anvil");
            }

            if (ModLoader.GetLoadedMods().Contains("Antiaris"))
            {
                rightClick.Add("a Compressor");
            }

            if (ModLoader.GetLoadedMods().Contains("CrystilliumMod"))
            {
                rightClick.Add("a Crystal Fountain");
                rightClick.Add("a Crystal Wood Workbench");
            }

            if (ModLoader.GetLoadedMods().Contains("Laugicality"))
            {
                rightClick.Add("an Alchemical Infuser");
                rightClick.Add("a Laugical Workbench");
            }

            if (ModLoader.GetLoadedMods().Contains("SpiritMod"))
            {
                rightClick.Add("an Altar of Creation");
            }

            if (ModLoader.GetLoadedMods().Contains("ElementsAwoken"))
            {
                if (ModLoader.GetLoadedMods().Contains("JoostMod"))
                {
                    rightClick.Add("an Elements Awoken Elemental Forge");
                }
                else
                {
                    rightClick.Add("an Elemental Forge");
                }
            }

            if (ModLoader.GetLoadedMods().Contains("RawExpansion"))
            {
                rightClick.Add("an Upgrader Station");
            }

            if (ModLoader.GetLoadedMods().Contains("CheezeMod"))
            {
                rightClick.Add("a MegaCorp Vendor");
            }

            if (ModLoader.GetLoadedMods().Contains("MoAddon"))
            {
                rightClick.Add("a Snow Workbench");
            }

            if (ModLoader.GetLoadedMods().Contains("thespatiummod"))
            {
                rightClick.Add("a Golden Binder");
            }

            if (ModLoader.GetLoadedMods().Contains("OreConversion"))
            {
                rightClick.Add("an Ore Conversion Table");
            }

            if (ModLoader.GetLoadedMods().Contains("Exodus"))
            {
                rightClick.Add("a Slime Workstation");
            }

            if (ModLoader.GetLoadedMods().Contains("CookieModBeta2"))
            {
                rightClick.Add("a Cookie Workbench");
            }

            if (ModLoader.GetLoadedMods().Contains("FlareStone"))
            {
                rightClick.Add("an Accelerator");
            }

            if (ModLoader.GetLoadedMods().Contains("Bismuth"))
            {
                rightClick.Add("Papuan's Bookcase");
            }

            if (ModLoader.GetLoadedMods().Contains("BuildPlanner"))
            {
                ;
                rightClick.Add("Scaffolding");
            }

            if (ModLoader.GetLoadedMods().Contains("MagicStorage"))
            {
                rightClick.Add("part of a Magic Storage System");
            }

            if (ModLoader.GetLoadedMods().Contains("StarWarsMod"))
            {
                rightClick.Add("a Geological Compressor");
            }


            if (NPC.downedSlimeKing == true)
            {
                rightClick.Add("a Solidifier"); //Solidifier
            }
            if (NPC.downedBoss1 == true)
            {
                rightClick.Add("a Demon Altar"); //Demon Altar
                if (ModLoader.GetLoadedMods().Contains("ThoriumMod"))
                {
                    Mod thorium = ModLoader.GetMod("ThoriumMod");
                    rightClick.Add("an Arcane Armor Fabricator"); //Arcane Armor Fabricator
                }
            }
            if (NPC.downedGoblins == true)
            {
                rightClick.Add("a Tinkerer's Workshop"); //Tinkerer's Workshop
            }
            if (NPC.downedBoss3 == true)
            {
                rightClick.Add("a Hellforge"); //Hellforge
                rightClick.Add("a Bone Welder"); //Bone Welder
                if (ModLoader.GetLoadedMods().Contains("Tremor"))
                {
                    rightClick.Add("an Alchemy Station"); //Alchemy Station
                }
                else
                {
                    rightClick.Add("a Vanilla Alchemy Station"); //Alchemy Station
                }
                rightClick.Add("a Bewitching Table"); //Bewitching Table
                rightClick.Add("Lava");
                if (ModLoader.GetLoadedMods().Contains("BetterBoneWelder"))
                {
                    Mod bone = ModLoader.GetMod("BetterBoneWelder");
                    rightClick.Add("a Daemon Forge");
                }
                if (ModLoader.GetLoadedMods().Contains("Osmium"))
                {
                    Mod os = ModLoader.GetMod("Osmium");
                    rightClick.Add("a Bar Press");
                }
                if (ModLoader.GetLoadedMods().Contains("Project__C"))
                {
                    Mod projC = ModLoader.GetMod("Project__C");
                    rightClick.Add("an Energy Condenser");
                }
                if (ModLoader.GetLoadedMods().Contains("CosmeticVariety"))
                {
                    Mod FFF = ModLoader.GetMod("CosmeticVariety");
                    rightClick.Add("a Beverage Brewer");
                }
                if (ModLoader.GetLoadedMods().Contains("AlchemistNPC"))
                {
                    Mod alchemistNPC = ModLoader.GetMod("AlchemistNPC");
                    rightClick.Add("a Wing of the World");
                }
                if (ModLoader.GetLoadedMods().Contains("Laugicality"))
                {
                    Mod logic = ModLoader.GetMod("Laugicality");
                    rightClick.Add("a Crystalline Infuser");
                }
                if (ModLoader.GetLoadedMods().Contains("Tremor"))
                {
                    rightClick.Add("a Necromaniac Workbench");
                    rightClick.Add("a Devil Forge");
                }
            }
            if (NPC.downedQueenBee == true)
            {
                rightClick.Add("an Imbuing Station"); //Imbuing Station
                rightClick.Add("a Honey Dispenser"); //Honey Dispenser
                rightClick.Add("Honey");
            }
            if (Main.hardMode == true)
            {
                rightClick.Add("a Mythril Anvil"); //Mythril Anvil
                rightClick.Add("an Adamantite Forge"); //Adamantite Forge
                rightClick.Add("a Crystal Ball"); //Crystal Ball
                rightClick.Add("a Meat Grinder"); //Meat Grinder
                rightClick.Add("an Autohammer"); //Autohammer
                if (ModLoader.GetLoadedMods().Contains("CosmeticVariety"))
                {
                    Mod FFF = ModLoader.GetMod("CosmeticVariety");
                    rightClick.Add("a Shadow Extraltar");
                }
                if (ModLoader.GetLoadedMods().Contains("JoostMod"))
                {
                    Mod joost = ModLoader.GetMod("JoostMod");
                    if (ModLoader.GetLoadedMods().Contains("ElementsAwoken"))
                    {
                        rightClick.Add("a Joost Elemental Forge");
                    }
                    else
                    {
                        rightClick.Add("an Elemental Forge");
                    }
                }
                if (ModLoader.GetLoadedMods().Contains("thespatiummod"))
                {
                    Mod bind = ModLoader.GetMod("thespatiummod");
                    rightClick.Add("a Colbalt Binder");
                }
                if (ModLoader.GetLoadedMods().Contains("Laugicality"))
                {
                    Mod logic = ModLoader.GetMod("Laugicality");
                    rightClick.Add("a Mineral Enchanter");
                }
                if (ModLoader.GetLoadedMods().Contains("SpiritMod"))
                {
                    Mod spirit = ModLoader.GetMod("SpiritMod");
                    rightClick.Add("an Essense Distorter");
                }
                if (ModLoader.GetLoadedMods().Contains("Tremor"))
                {
                    rightClick.Add("a Recycler of Matter");
                }
            }
            if (NPC.downedMechBossAny)
            {
                rightClick.Add("a Blend-O-Matic"); //Blend-O-Matic
                rightClick.Add("a Flesh Cloning Vat"); //Flesh Cloning Vat
                rightClick.Add("a Steampunk Boiler"); //Steampunk Boiler
                if (ModLoader.GetLoadedMods().Contains("Bluemagic"))
                {
                    rightClick.Add("a Clentamistation");
                }
            }
            if (NPC.downedMechBoss1 && NPC.downedMechBoss2 && NPC.downedMechBoss3)
            {
                if (ModLoader.GetLoadedMods().Contains("ThoriumMod"))
                {
                    Mod thorium = ModLoader.GetMod("ThoriumMod");
                    rightClick.Add("a Soul Forge"); //Soul Forge
                }
                if (ModLoader.GetLoadedMods().Contains("CopperPlusMod"))
                {
                    Mod copper = ModLoader.GetMod("CopperPlusMod");
                    rightClick.Add("a Mechanical Forge");
                    rightClick.Add("a Vigolythic Anvil");
                }
                if (ModLoader.GetLoadedMods().Contains("thespatiummod"))
                {
                    Mod bind = ModLoader.GetMod("thespatiummod");
                    rightClick.Add("a Soulful Binder");
                }
                if (ModLoader.GetLoadedMods().Contains("Undermod"))
                {
                    Mod under = ModLoader.GetMod("Undermod");
                    rightClick.Add("a Determination Extraction Machine");
                }
            }
            if (NPC.downedPlantBoss == true)
            {
                if (ModLoader.GetLoadedMods().Contains("Laugicality"))
                {
                    Mod logic = ModLoader.GetMod("Laugicality");
                    rightClick.Add("an Ancient Enchanter");
                }
                if (ModLoader.GetLoadedMods().Contains("Tremor"))
                {
                    rightClick.Add("an Alchemator");
                }
            }
            if (NPC.downedGolemBoss == true)
            {
                rightClick.Add("a Lihzahrd Furnace"); //Lihzahrd Furnace
                rightClick.Add("a Lihzahrd Altar"); //Lihzahrd Altar

                if (ModLoader.GetLoadedMods().Contains("GRealm") && ModLoader.GetLoadedMods().Contains("BaseMod"))
                {
                    Mod gRealm = ModLoader.GetMod("GRealm");
                    rightClick.Add("an Arcane Welding Station");
                }
            }
            if (NPC.downedAncientCultist == true)
            {
                rightClick.Add("an Ancient Manipulator"); //Ancient Manipulator

                if (ModLoader.GetLoadedMods().Contains("Fargowiltas"))
                {
                    Mod fargo = ModLoader.GetMod("Fargowiltas");
                    rightClick.Add("a Crucible of the Cosmos");
                }
                if (ModLoader.GetLoadedMods().Contains("AlchemistNPC"))
                {
                    Mod alchemistNPC = ModLoader.GetMod("AlchemistNPC");
                    rightClick.Add("a Materia Transmutator");
                }
            }
            if (NPC.downedMoonlord == true)
            {
                if (ModLoader.GetLoadedMods().Contains("CosmeticVariety"))
                {
                    Mod FFF = ModLoader.GetMod("CosmeticVariety");
                    rightClick.Add("an Aegis Contraption");
                }
                if (ModLoader.GetLoadedMods().Contains("TheDeconstructor"))
                {
                    Mod uncraft = ModLoader.GetMod("TheDeconstructor");
                    rightClick.Add("a Lunar Deconstuctor");
                }
                if (ModLoader.GetLoadedMods().Contains("thespatiummod"))
                {
                    Mod bind = ModLoader.GetMod("thespatiummod");
                    rightClick.Add("a Celestial Binder");
                }
                if (ModLoader.GetLoadedMods().Contains("Tremor"))
                {
                    rightClick.Add("a Tremor Alchemy Station");
                    rightClick.Add("a Starvil");
                }
            }
            if (NPC.downedSlimeKing || NPC.downedBoss1 || NPC.downedBoss2 || NPC.downedBoss3 || NPC.downedQueenBee || Main.hardMode || NPC.downedMechBossAny || NPC.downedPlantBoss || NPC.downedGolemBoss || NPC.downedFishron || NPC.downedAncientCultist || NPC.downedMoonlord)
            {
                if (ModLoader.GetLoadedMods().Contains("Mysticality"))
                {
                    Mod mystic = ModLoader.GetMod("Mysticality");
                    rightClick.Add("an Omnibench");
                }
            }

            if (sacredTools != null)
            {
                if (Abadabadingdong == true || Abadabadingdong2 == true)
                {
                    rightClick.Add("an Oblivion Forge"); //Oblivion Forge
                }

                if (MagicWaifuNuba == true)
                {
                    rightClick.Add("a Lunatic Infuser"); //Lunatic Infuser
                }

                if (SnakesAreSuperiorBitch == true)
                {
                    rightClick.Add("a Flarium Anvil"); //Flarium Anvil
                    rightClick.Add("a Flarium Workbench"); //Flarium Workbench
                    rightClick.Add("a Flarium Forge"); //Flarium Forge
                }

                if (Deadfreeze == true)
                {
                    rightClick.Add("a Cernium Anvil"); //Cernium Anvil
                    rightClick.Add("a Cernium Forge"); //Cernium Forge
                }

                if (TotallyNotDanYami == true)
                {
                    rightClick.Add("an Asthraltite Workbench"); //Asthraltite Workbench
                }
            }

            if (calamity != null)
            {
                if (Doggo == true)
                {
                    rightClick.Add("Draedon's Forge"); //Draedon's Forge
                }
            }

            if (bluemagic != null)
            {
                if (Abomination == true && NPC.downedMoonlord)
                {
                    rightClick.Add("a Purium Forge"); //Purium Forge
                    rightClick.Add("a Purium Anvil"); //Purium Anvil
                }
            }

            if (pumpking != null)
            {
                if (TerraLord == true)
                {
                    rightClick.Add("a Terra Forge");
                }
            }
            #endregion

            string tileList = string.Join(", ", rightClick.ToArray());
            Main.NewText("Current active tiles: " + tileList);
        }

        public override void NumDust(int i, int j, bool fail, ref int num)
        {
            num = fail ? 1 : 3;
        }

        public override void KillMultiTile(int i, int j, int frameX, int frameY)
        {
            Item.NewItem(i * 16, j * 16, 32, 16, mod.ItemType("UniversalCrafter"));
        }

        #region Bools
        public bool Abadabadingdong
        {
            get { return SacredTools.ModdedWorld.downedAbaddon; }
        }
        public bool Abadabadingdong2
        {
            get { return SacredTools.ModdedWorld.OblivionSpawns; }
        }
        public bool MagicWaifuNuba
        {
            get { return SacredTools.ModdedWorld.downedLunarians; }
        }
        public bool SnakesAreSuperiorBitch
        {
            get { return SacredTools.ModdedWorld.FlariumSpawns; }
        }
        public bool Deadfreeze
        {
            get { return SacredTools.ModdedWorld.CerniumSpawns; }
        }
        public bool TotallyNotDanYami
        {
            get { return SacredTools.ModdedWorld.downedChallenger; }
        }
        public bool Doggo
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
        #endregion
    }
}