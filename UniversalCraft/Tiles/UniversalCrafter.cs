using Terraria.DataStructures;
using System.Linq;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.ObjectData;
using System;

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

            if (ModLoader.GetLoadedMods().Contains("VampKnives"))
            {
                Mod knives = ModLoader.GetMod("VampKnives");
                adjTile.Add(knives.TileType("KnifeBench"));
            }

            adjTiles = adjTile.ToArray();
            #endregion
        }

        public override void RightClick(int i, int j)
        {
            #region Right-Click List
            List<string> rightClick = new List<string>();

            rightClick.Add("Workbench"); //WorkBenches
            rightClick.Add("Furnace"); //Furnaces
            rightClick.Add("Anvil"); //Anvils
            rightClick.Add("Bottle"); //Bottles
            rightClick.Add("Sawmill"); //Sawmill
            rightClick.Add("Loom"); //Loom
            rightClick.Add("Chair"); //Chairs
            rightClick.Add("Table"); //Tables & Tables2
            rightClick.Add("Cooking Pot"); //CookingPots
            rightClick.Add("Dye Vat"); //DyeVat
            rightClick.Add("Bookcase"); //Bookcases
            rightClick.Add("Keg"); //Kegs
            rightClick.Add("Heavy Work Bench"); //HeavyWorkBench
            rightClick.Add("Glass Kiln"); //GlassKiln
            rightClick.Add("Ice Machine"); //IceMachine
            rightClick.Add("Living Loom"); //LivingLoom
            rightClick.Add("Sky Mill"); //SkyMill
            rightClick.Add("Sink"); //Sinks
            rightClick.Add("Campfire"); //Campfire
            rightClick.Add("block of Living Wood"); //Living Wood
            rightClick.Add("block of Cactus"); //Cactus
            rightClick.Add("Firefly in a Bottle"); //Firefly in a Bottle
            rightClick.Add("Book"); //Book
            rightClick.Add("Water Fountain"); //Water Fountain
            rightClick.Add("Water");

            if (ModLoader.GetLoadedMods().Contains("CosmeticVariety"))
            {
                rightClick.Add("Sculpting Stand");
                rightClick.Add("Canning Station");
                rightClick.Add("Chill Machine");
                rightClick.Add("Apiray");
                rightClick.Add("Oven");
                rightClick.Add("Easel");
            }

            if (ModLoader.GetLoadedMods().Contains("Tremor"))
            {
                rightClick.Add("Magic Workbench");
                rightClick.Add("Altar of Enchantments");
                rightClick.Add("Mineral Transmutator");
                rightClick.Add("Flesh Workstation");
                rightClick.Add("Blast Furnace");
            }

            if (ModLoader.GetLoadedMods().Contains("ThoriumMod"))
            {
                rightClick.Add("Thorium Anvil");
            }

            if (ModLoader.GetLoadedMods().Contains("Antiaris"))
            {
                rightClick.Add("Compressor");
            }

            if (ModLoader.GetLoadedMods().Contains("CrystilliumMod"))
            {
                rightClick.Add("Crystal Fountain");
                rightClick.Add("Crystal Wood Workbench");
            }

            if (ModLoader.GetLoadedMods().Contains("Laugicality"))
            {
                rightClick.Add("Alchemical Infuser");
                rightClick.Add("Laugical Workbench");
            }

            if (ModLoader.GetLoadedMods().Contains("SpiritMod"))
            {
                rightClick.Add("Altar of Creation");
            }

            if (ModLoader.GetLoadedMods().Contains("ElementsAwoken"))
            {
                if (ModLoader.GetLoadedMods().Contains("JoostMod"))
                {
                    rightClick.Add("Elements Awoken Elemental Forge");
                }
                else
                {
                    rightClick.Add("Elemental Forge");
                }
            }

            if (ModLoader.GetLoadedMods().Contains("RawExpansion"))
            {
                rightClick.Add("Upgrader Station");
            }

            if (ModLoader.GetLoadedMods().Contains("CheezeMod"))
            {
                rightClick.Add("MegaCorp Vendor");
            }

            if (ModLoader.GetLoadedMods().Contains("MoAddon"))
            {
                rightClick.Add("Snow Workbench");
            }

            if (ModLoader.GetLoadedMods().Contains("thespatiummod"))
            {
                rightClick.Add("Golden Binder");
            }

            if (ModLoader.GetLoadedMods().Contains("OreConversion"))
            {
                rightClick.Add("Ore Conversion Table");
            }

            if (ModLoader.GetLoadedMods().Contains("Exodus"))
            {
                rightClick.Add("Slime Workstation");
            }

            if (ModLoader.GetLoadedMods().Contains("CookieModBeta2"))
            {
                rightClick.Add("Cookie Workbench");
            }

            if (ModLoader.GetLoadedMods().Contains("FlareStone"))
            {
                rightClick.Add("Accelerator");
            }

            if (ModLoader.GetLoadedMods().Contains("Bismuth"))
            {
                rightClick.Add("Papuan's Bookcase");
            }

            if (ModLoader.GetLoadedMods().Contains("BuildPlanner"))
            {
                rightClick.Add("Scaffolding");
            }

            if (ModLoader.GetLoadedMods().Contains("MagicStorage"))
            {
                rightClick.Add("part of Magic Storage System");
            }

            if (ModLoader.GetLoadedMods().Contains("StarWarsMod"))
            {
                rightClick.Add("Geological Compressor");
            }

            if (ModLoader.GetLoadedMods().Contains("VampKnives"))
            {
                Mod knives = ModLoader.GetMod("VampKnives");
                rightClick.Add("Knife Worktable");
            }


            if (NPC.downedSlimeKing)
            {
                rightClick.Add("Solidifier"); //Solidifier
            }
            if (NPC.downedBoss1)
            {
                rightClick.Add("Demon Altar"); //Demon Altar
                if (ModLoader.GetLoadedMods().Contains("ThoriumMod"))
                {
                    Mod thorium = ModLoader.GetMod("ThoriumMod");
                    rightClick.Add("Arcane Armor Fabricator"); //Arcane Armor Fabricator
                }
            }
            if (NPC.downedGoblins)
            {
                rightClick.Add("Tinkerer's Workshop"); //Tinkerer's Workshop
            }
            if (NPC.downedBoss2)
            {
                if (ModLoader.GetLoadedMods().Contains("AlchemistNPC"))
                {
                    Mod alchemistNPC = ModLoader.GetMod("AlchemistNPC");
                    rightClick.Add("Wing of the World");
                }
            }
            if (NPC.downedBoss3)
            {
                rightClick.Add("Hellforge"); //Hellforge
                rightClick.Add("Bone Welder"); //Bone Welder
                if (ModLoader.GetLoadedMods().Contains("Tremor"))
                {
                    rightClick.Add("Alchemy Station"); //Alchemy Station
                }
                else
                {
                    rightClick.Add("Vanilla Alchemy Station"); //Alchemy Station
                }
                rightClick.Add("Bewitching Table"); //Bewitching Table
                rightClick.Add("Lava");
                if (ModLoader.GetLoadedMods().Contains("BetterBoneWelder"))
                {
                    Mod bone = ModLoader.GetMod("BetterBoneWelder");
                    rightClick.Add("Daemon Forge");
                }
                if (ModLoader.GetLoadedMods().Contains("Osmium"))
                {
                    Mod os = ModLoader.GetMod("Osmium");
                    rightClick.Add("Bar Press");
                }
                if (ModLoader.GetLoadedMods().Contains("Project__C"))
                {
                    Mod projC = ModLoader.GetMod("Project__C");
                    rightClick.Add("Energy Condenser");
                }
                if (ModLoader.GetLoadedMods().Contains("CosmeticVariety"))
                {
                    Mod FFF = ModLoader.GetMod("CosmeticVariety");
                    rightClick.Add("Beverage Brewer");
                }
                if (ModLoader.GetLoadedMods().Contains("Laugicality"))
                {
                    Mod logic = ModLoader.GetMod("Laugicality");
                    rightClick.Add("Crystalline Infuser");
                }
                if (ModLoader.GetLoadedMods().Contains("Tremor"))
                {
                    rightClick.Add("Necromaniac Workbench");
                    rightClick.Add("Devil Forge");
                }
            }
            if (NPC.downedQueenBee)
            {
                rightClick.Add("Imbuing Station"); //Imbuing Station
                rightClick.Add("Honey Dispenser"); //Honey Dispenser
                rightClick.Add("Honey");
            }
            if (Main.hardMode)
            {
                rightClick.Add("Mythril Anvil"); //Mythril Anvil
                rightClick.Add("Adamantite Forge"); //Adamantite Forge
                rightClick.Add("Crystal Ball"); //Crystal Ball
                rightClick.Add("Meat Grinder"); //Meat Grinder
                rightClick.Add("Autohammer"); //Autohammer
                if (ModLoader.GetLoadedMods().Contains("CosmeticVariety"))
                {
                    Mod FFF = ModLoader.GetMod("CosmeticVariety");
                    rightClick.Add("Shadow Extraltar");
                }
                if (ModLoader.GetLoadedMods().Contains("JoostMod"))
                {
                    Mod joost = ModLoader.GetMod("JoostMod");
                    if (ModLoader.GetLoadedMods().Contains("ElementsAwoken"))
                    {
                        rightClick.Add("Joost Elemental Forge");
                    }
                    else
                    {
                        rightClick.Add("Elemental Forge");
                    }
                }
                if (ModLoader.GetLoadedMods().Contains("thespatiummod"))
                {
                    Mod bind = ModLoader.GetMod("thespatiummod");
                    rightClick.Add("Colbalt Binder");
                }
                if (ModLoader.GetLoadedMods().Contains("Laugicality"))
                {
                    Mod logic = ModLoader.GetMod("Laugicality");
                    rightClick.Add("Mineral Enchanter");
                }
                if (ModLoader.GetLoadedMods().Contains("SpiritMod"))
                {
                    Mod spirit = ModLoader.GetMod("SpiritMod");
                    rightClick.Add("Essense Distorter");
                }
                if (ModLoader.GetLoadedMods().Contains("Tremor"))
                {
                    rightClick.Add("Recycler of Matter");
                }
            }
            if (NPC.downedMechBossAny)
            {
                rightClick.Add("Blend-O-Matic"); //Blend-O-Matic
                rightClick.Add("Flesh Cloning Vat"); //Flesh Cloning Vat
                rightClick.Add("Steampunk Boiler"); //Steampunk Boiler
                if (ModLoader.GetLoadedMods().Contains("Bluemagic"))
                {
                    rightClick.Add("Clentamistation");
                }
            }
            if (NPC.downedMechBoss1 && NPC.downedMechBoss2 && NPC.downedMechBoss3)
            {
                if (ModLoader.GetLoadedMods().Contains("ThoriumMod"))
                {
                    Mod thorium = ModLoader.GetMod("ThoriumMod");
                    rightClick.Add("Soul Forge"); //Soul Forge
                }
                if (ModLoader.GetLoadedMods().Contains("CopperPlusMod"))
                {
                    Mod copper = ModLoader.GetMod("CopperPlusMod");
                    rightClick.Add("Mechanical Forge");
                    rightClick.Add("Vigolythic Anvil");
                }
                if (ModLoader.GetLoadedMods().Contains("thespatiummod"))
                {
                    Mod bind = ModLoader.GetMod("thespatiummod");
                    rightClick.Add("Soulful Binder");
                }
                if (ModLoader.GetLoadedMods().Contains("Undermod"))
                {
                    Mod under = ModLoader.GetMod("Undermod");
                    rightClick.Add("Determination Extraction Machine");
                }
            }
            if (NPC.downedPlantBoss)
            {
                if (ModLoader.GetLoadedMods().Contains("Laugicality"))
                {
                    Mod logic = ModLoader.GetMod("Laugicality");
                    rightClick.Add("Ancient Enchanter");
                }
                if (ModLoader.GetLoadedMods().Contains("Tremor"))
                {
                    rightClick.Add("Alchemator");
                }
            }
            if (NPC.downedGolemBoss)
            {
                rightClick.Add("Lihzahrd Furnace"); //Lihzahrd Furnace
                rightClick.Add("Lihzahrd Altar"); //Lihzahrd Altar

                if (ModLoader.GetLoadedMods().Contains("GRealm") && ModLoader.GetLoadedMods().Contains("BaseMod"))
                {
                    Mod gRealm = ModLoader.GetMod("GRealm");
                    rightClick.Add("Arcane Welding Station");
                }
            }
            if (NPC.downedAncientCultist)
            {
                rightClick.Add("Ancient Manipulator"); //Ancient Manipulator

                if (ModLoader.GetLoadedMods().Contains("Fargowiltas"))
                {
                    Mod fargo = ModLoader.GetMod("Fargowiltas");
                    rightClick.Add("Crucible of the Cosmos");
                }
                if (ModLoader.GetLoadedMods().Contains("AlchemistNPC"))
                {
                    Mod alchemistNPC = ModLoader.GetMod("AlchemistNPC");
                    rightClick.Add("Materia Transmutator");
                }
            }
            if (NPC.downedMoonlord)
            {
                if (ModLoader.GetLoadedMods().Contains("CosmeticVariety"))
                {
                    Mod FFF = ModLoader.GetMod("CosmeticVariety");
                    rightClick.Add("Aegis Contraption");
                }
                if (ModLoader.GetLoadedMods().Contains("TheDeconstructor"))
                {
                    Mod uncraft = ModLoader.GetMod("TheDeconstructor");
                    rightClick.Add("Lunar Deconstuctor");
                }
                if (ModLoader.GetLoadedMods().Contains("thespatiummod"))
                {
                    Mod bind = ModLoader.GetMod("thespatiummod");
                    rightClick.Add("Celestial Binder");
                }
                if (ModLoader.GetLoadedMods().Contains("Tremor"))
                {
                    rightClick.Add("Tremor Alchemy Station");
                    rightClick.Add("Starvil");
                }
            }
            if (NPC.downedSlimeKing || NPC.downedBoss1 || NPC.downedBoss2 || NPC.downedBoss3 || NPC.downedQueenBee || Main.hardMode || NPC.downedMechBossAny || NPC.downedPlantBoss || NPC.downedGolemBoss || NPC.downedFishron || NPC.downedAncientCultist || NPC.downedMoonlord)
            {
                if (ModLoader.GetLoadedMods().Contains("Mysticality"))
                {
                    Mod mystic = ModLoader.GetMod("Mysticality");
                    rightClick.Add("Omnibench");
                }
            }

            if (sacredTools != null)
            {
                if (Abadabadingdong || Abadabadingdong2)
                {
                    rightClick.Add("Oblivion Forge"); //Oblivion Forge
                }

                if (MagicWaifuNuba)
                {
                    rightClick.Add("Lunatic Infuser"); //Lunatic Infuser
                }

                if (SnakesAreSuperiorBitch)
                {
                    rightClick.Add("Flarium Anvil"); //Flarium Anvil
                    rightClick.Add("Flarium Workbench"); //Flarium Workbench
                    rightClick.Add("Flarium Forge"); //Flarium Forge
                }

                if (Deadfreeze)
                {
                    rightClick.Add("Cernium Anvil"); //Cernium Anvil
                    rightClick.Add("Cernium Forge"); //Cernium Forge
                }

                if (TotallyNotDanYami)
                {
                    rightClick.Add("Asthraltite Workbench"); //Asthraltite Workbench
                }
            }

            if (calamity != null)
            {
                if (Doggo)
                {
                    rightClick.Add("Draedon's Forge"); //Draedon's Forge
                }
            }

            if (bluemagic != null)
            {
                if (Abomination && NPC.downedMoonlord)
                {
                    rightClick.Add("Purium Forge"); //Purium Forge
                    rightClick.Add("Purium Anvil"); //Purium Anvil
                }
            }

            if (pumpking != null)
            {
                if (TerraLord)
                {
                    rightClick.Add("Terra Forge"); //Terra Forge
                }
            }
            #endregion

            var lastNdx = rightClick.Count - 1;
            var sentence = "Current active tiles: " + String.Join(", ",
                rightClick.Select((s, ndx) =>
                {
                    var ls = s.ToLower();
                    string ret = "";
                    if ("aeiou".Contains(ls[0]))
                        ret = "an " + s;
                    else if (ls.Contains("\'"))
                        ret = s;
                    else ret = "a " + s;
                    if (ndx == lastNdx)
                        ret = "and " + ret;
                    return ret;
                }).ToArray());
            // This bit of code makes it so I don't have to personally add 'a' or 'an' in front of each word. It's inaccuarte, unfortunately.

            Main.NewText(sentence);
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