using Terraria.DataStructures;
using System.Linq;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.ObjectData;
using Microsoft.Xna.Framework.Graphics;
using Terraria.ID;

namespace UniversalCraft.Tiles
{
    public class UniversalCrafter : ModTile
    {
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
            List<int> adjTile = new List<int>();

            adjTile.Add(TileID.Anvils); //Anvil
            adjTile.Add(TileID.Bookcases); //Bookcase
            adjTile.Add(TileID.Bottles); //Bottle
            adjTile.Add(TileID.Chairs); //Chair
            adjTile.Add(TileID.CookingPots); //Cooking Pot
            adjTile.Add(TileID.DemonAltar); //Demon Altar
            adjTile.Add(TileID.DyeVat); //Dye Vat
            adjTile.Add(TileID.Furnaces); //Furnace
            adjTile.Add(TileID.GlassKiln); //Glass Kiln
            adjTile.Add(TileID.HeavyWorkBench); //Heavy Work Bench
            adjTile.Add(TileID.Hellforge); //Hellforge
            adjTile.Add(TileID.HoneyDispenser); //Honey Dispenser
            adjTile.Add(TileID.IceMachine); //Ice Machine
            adjTile.Add(TileID.Kegs); //Keg
            adjTile.Add(TileID.LivingLoom); //Living Loom
            adjTile.Add(TileID.Loom); //Loom
            adjTile.Add(TileID.Sawmill); //Sawmill
            adjTile.Add(TileID.SkyMill); //Sky Mill
            adjTile.Add(TileID.Tables); //Tables
            adjTile.Add(TileID.Tables2); //Tables
            adjTile.Add(TileID.WorkBenches); //Workbench
            if (ModLoader.GetLoadedMods().Contains("Bismuth")) //Bismuth Mod
            {
                Mod bismuth = ModLoader.GetMod("Bismuth");
                adjTile.Add(bismuth.TileType("PapuansBookcase")); //Papuan's Bookcase
            }
            if (ModLoader.GetLoadedMods().Contains("CheezeMod")) //Cheeze's Content Pack
            {
                Mod cheezeMod = ModLoader.GetMod("CheezeMod");
                adjTile.Add(cheezeMod.TileType("MegaCorpVendor")); //MegaCorp Vendor
            }
            if (ModLoader.GetLoadedMods().Contains("CookieModBeta")) //Cookie Mod Beta
            {
                Mod cookieModBeta = ModLoader.GetMod("CookieModBeta");
                adjTile.Add(cookieModBeta.TileType("CookieBench")); //Cookie Bench Item
            }
            if (ModLoader.GetLoadedMods().Contains("CookieModBeta2")) //Cookie Mod Beta
            {
                Mod cookieModBeta = ModLoader.GetMod("CookieModBeta2");
                adjTile.Add(cookieModBeta.TileType("CookieBench")); //Cookie Bench Item
            }
            if (ModLoader.GetLoadedMods().Contains("CosmeticVariety")) //Furniture, Food, and Fun
            {
                Mod cosmeticVariety = ModLoader.GetMod("CosmeticVariety");
                adjTile.Add(cosmeticVariety.TileType("Apiary")); //Apiary
                adjTile.Add(cosmeticVariety.TileType("CanningStation")); //Canning Station
                adjTile.Add(cosmeticVariety.TileType("ChillMachine")); //Chill Machine
                adjTile.Add(cosmeticVariety.TileType("Easel")); //Easel 
                adjTile.Add(cosmeticVariety.TileType("Oven")); //Oven
                adjTile.Add(cosmeticVariety.TileType("SculptingStation")); //Sculpting Station
            }
            if (ModLoader.GetLoadedMods().Contains("Crystilium")) //Crystilium
            {
                Mod crystilium = ModLoader.GetMod("Crystilium");
                adjTile.Add(crystilium.TileType("CrystalWoodWorkbench")); //Crystal Wood Workbench
                adjTile.Add(crystilium.TileType("Fountain")); //Crystal Fountain
            }
            if (ModLoader.GetLoadedMods().Contains("Exodus")) //Exodus Mod
            {
                Mod exodus = ModLoader.GetMod("Exodus");
                adjTile.Add(exodus.TileType("BlastFurnaceTile")); //Alloy Forge
                adjTile.Add(exodus.TileType("SlimeWorkstation")); //Slime Workstation
            }
            if (ModLoader.GetLoadedMods().Contains("FlareStone")) //FlareStone
            {
                Mod flareStone = ModLoader.GetMod("FlareStone");
                adjTile.Add(flareStone.TileType("Accelerator")); //Accelerator
            }
            if (ModLoader.GetLoadedMods().Contains("Laugicality")) //The Enigma Mod
            {
                Mod laugicality = ModLoader.GetMod("Laugicality");
                adjTile.Add(laugicality.TileType("AlchemicalInfuser")); //Alchemical Infuser
                adjTile.Add(TileID.ClosedDoor); //Door
                adjTile.Add(laugicality.TileType("LaugicalWorkbench")); //Laugical Workbench
                adjTile.Add(TileID.OpenDoor); //Door
            }
            if (ModLoader.GetLoadedMods().Contains("MagicStorage")) //Magic Storage
            {
                Mod magicStorage = ModLoader.GetMod("MagicStorage");
                adjTile.Add(magicStorage.TileType("CraftingAccess")); //Storage Crafting Interface
            }
            if (ModLoader.GetLoadedMods().Contains("MoAddon")) //Mohammed's Addon
            {
                Mod moAddon = ModLoader.GetMod("MoAddon");
                adjTile.Add(moAddon.TileType("SnowWBTile")); //Snow Workbench
            }
            if (ModLoader.GetLoadedMods().Contains("OreConversion")) //OreConversion
            {
                Mod oreConversion = ModLoader.GetMod("OreConversion");
                adjTile.Add(oreConversion.TileType("OreConvertTable")); //Ore Conversion Table
            }
            if (ModLoader.GetLoadedMods().Contains("RawExpansion")) //Raw Expansion
            {
                Mod rawExpansion = ModLoader.GetMod("RawExpansion");
                adjTile.Add(rawExpansion.TileType("FleshCrafter")); //Flesh Shaper
                adjTile.Add(rawExpansion.TileType("UpgraderStation")); //Upgrade Station
            }
            if (ModLoader.GetLoadedMods().Contains("SpiritMod")) //Spirit Mod
            {
                Mod spiritMod = ModLoader.GetMod("SpiritMod");
                adjTile.Add(spiritMod.TileType("CreationAltarTile")); //Altar of Creation
            }
            if (ModLoader.GetLoadedMods().Contains("StarWarsMod")) //Star Wars Mod
            {
                Mod starWarsMod = ModLoader.GetMod("StarWarsMod");
                adjTile.Add(starWarsMod.TileType("GeologicalCompressor")); //Geological Compressor
            }
            if (ModLoader.GetLoadedMods().Contains("thespatiummod")) //Item Binders
            {
                Mod theSpatiumMod = ModLoader.GetMod("thespatiummod");
                adjTile.Add(theSpatiumMod.TileType("GoldenBinder")); //Golden Binder
            }
            if (ModLoader.GetLoadedMods().Contains("ThoriumMod")) //Thorium Mod
            {
                Mod thoriumMod = ModLoader.GetMod("ThoriumMod");
                adjTile.Add(thoriumMod.TileType("ThoriumAnvil")); //Thorium Anvil
            }
            if (ModLoader.GetLoadedMods().Contains("Tremor")) //Tremor Mod Remastered
            {
                Mod tremor = ModLoader.GetMod("Tremor");
                adjTile.Add(tremor.TileType("AltarofEnchantmentsTile")); //Altar of Enchantments
                adjTile.Add(tremor.TileType("BlastFurnace")); //Blast Furnace
                adjTile.Add(tremor.TileType("FleshWorkstationTile")); //Flesh Workstation
                adjTile.Add(tremor.TileType("MagicWorkbenchTile")); //Magic Workbench
                adjTile.Add(tremor.TileType("MineralTransmutator")); //Mineral Transmutator
            }
            if (ModLoader.GetLoadedMods().Contains("VampKnives")) //Vampire Knives Expanded
            {
                Mod vampKnives = ModLoader.GetMod("VampKnives");
                adjTile.Add(vampKnives.TileType("KnifeBench")); //Knife Worktable
            }
            if (ModLoader.GetLoadedMods().Contains("Exodus") || ModLoader.GetLoadedMods().Contains("GRealm") || ModLoader.GetLoadedMods().Contains("RawExpasion"))
            {
                adjTile.Add(TileID.Campfire); //Campfire
            }
            adjTiles = adjTile.ToArray();
            #endregion
        }

        int cycle = 0;

        public override void RightClick(int i, int j)
        {
            #region Right-Click Tile Lists
            //if (Main.tile[i, j].frameX == 36 && Main.tile[i, j].frameY == 0)
            //{
                List<string> Vanilla = new List<string>();
                List<string> VanillaDecor = new List<string>();
                List<string> BigMods = new List<string>();
                List<string> MediumMods = new List<string>();
                List<string> SmallMods = new List<string>();
                List<string> AllTiles = new List<string>();

                #region Tile Names
                #region Pre-Boss
                Vanilla.Add("Anvil"); //Anvil
                Vanilla.Add("Bookcase"); //Bookcase
                Vanilla.Add("Bottle"); //Bottle
                Vanilla.Add("Chair"); //Chair
                Vanilla.Add("Cooking Pot"); //Cooking Pot
                Vanilla.Add("Demon Altar"); //Demon Altar
                Vanilla.Add("Dye Vat"); //Dye Vat
                Vanilla.Add("Furnace"); //Furnace
                VanillaDecor.Add("Glass Kiln"); //Glass Kiln
                VanillaDecor.Add("Heavy Work Bench"); //Heavy Work Bench
                Vanilla.Add("Hellforge"); //Hellforge
                VanillaDecor.Add("Honey Dispenser"); //Honey Dispenser
                VanillaDecor.Add("Ice Machine"); //Ice Machine
                Vanilla.Add("Keg"); //Keg
                VanillaDecor.Add("Living Loom"); //Living Loom
                Vanilla.Add("Loom"); //Loom
                Vanilla.Add("Sawmill"); //Sawmill
                VanillaDecor.Add("Sky Mill"); //Sky Mill
                Vanilla.Add("Table"); //Tables
                Vanilla.Add("Workbench"); //Workbench
                if (ModLoader.GetLoadedMods().Contains("Bismuth")) //Bismuth Mod
                {
                    MediumMods.Add("Papuan's Bookcase"); //Papuan's Bookcase
                }
                if (ModLoader.GetLoadedMods().Contains("CheezeMod")) //Cheeze's Content Pack
                {
                    MediumMods.Add("MegaCorp Vendor"); //MegaCorp Vendor
                }
                if (ModLoader.GetLoadedMods().Contains("CookieModBeta")) //Cookie Mod Beta
                {
                    SmallMods.Add("Cookie Bench"); //Cookie Bench Item
                }
                if (ModLoader.GetLoadedMods().Contains("CookieModBeta2")) //Cookie Mod Beta
                {
                    SmallMods.Add("Cookie Bench"); //Cookie Bench Item
                }
                if (ModLoader.GetLoadedMods().Contains("CosmeticVariety")) //Furniture, Food, and Fun
                {
                    BigMods.Add("Apiary"); //Apiary
                    BigMods.Add("Canning Station"); //Canning Station
                    BigMods.Add("Chill Machine"); //Chill Machine
                    BigMods.Add("Easel"); //Easel
                    BigMods.Add("Oven"); //Oven
                    BigMods.Add("Scuplting Station"); //Sculpting Station
                }
                if (ModLoader.GetLoadedMods().Contains("Crystilium")) //Crystilium
                {
                    MediumMods.Add("Crystal Wood Workbench"); //Crystal Wood Workbench
                    MediumMods.Add("Crystal Fountain"); //Crystal Fountain
                }
                if (ModLoader.GetLoadedMods().Contains("Exodus")) //Exodus Mod
                {
                    MediumMods.Add("Alloy Forge"); //Alloy Forge
                    MediumMods.Add("Slime Workstation"); //Slime Workstation
                }
                if (ModLoader.GetLoadedMods().Contains("FlareStone")) //FlareStone
                {
                    SmallMods.Add("Accelerator"); //Accelerator
                }
                if (ModLoader.GetLoadedMods().Contains("Laugicality")) //The Enigma Mod
                {
                    BigMods.Add("Alchemical Infuser"); //Alchemical Infuser
                    Vanilla.Add("Door"); //Door
                    BigMods.Add("Laugical Workbench"); //Laugical Workbench
                }
                if (ModLoader.GetLoadedMods().Contains("MagicStorage")) //Magic Storage
                {
                    MediumMods.Add("Storage Crafting Interface"); //Storage Crafting Interface
                }
                if (ModLoader.GetLoadedMods().Contains("MoAddon")) //Mohammed's Addon
                {
                    SmallMods.Add("Snow Workbench"); //Snow Workbench
                }
                if (ModLoader.GetLoadedMods().Contains("OreConversion")) //OreConversion
                {
                    SmallMods.Add("Ore Conversion Table"); //Ore Conversion Table
                }
                if (ModLoader.GetLoadedMods().Contains("RawExpansion")) //Raw Expansion
                {
                    SmallMods.Add("Flesh Shaper"); //Flesh Shaper
                    SmallMods.Add("Upgrade Station"); //Upgrade Station
                }
                if (ModLoader.GetLoadedMods().Contains("SpiritMod")) //Spirit Mod
                {
                    BigMods.Add("Altar of Creation"); //Altar of Creation
                }
                if (ModLoader.GetLoadedMods().Contains("StarWarsMod")) //Star Wars Mod
                {
                    SmallMods.Add("Geological Compressor"); //Geological Compressor
                }
                if (ModLoader.GetLoadedMods().Contains("thespatiummod")) //Item Binders
                {
                    SmallMods.Add("Golden Binder"); //Golden Binder
                }
                if (ModLoader.GetLoadedMods().Contains("ThoriumMod")) //Thorium Mod
                {
                    BigMods.Add("Thorium Anvil"); //Thorium Anvil
                }
                if (ModLoader.GetLoadedMods().Contains("Tremor")) //Tremor Mod Remastered
                {
                    BigMods.Add("Altar of Enchantments"); //Altar of Enchantments
                    BigMods.Add("Blast Furnace"); //Blast Furnace
                    BigMods.Add("Flesh Workstation"); //Flesh Workstation
                    BigMods.Add("Magic Workbench"); //Magic Workbench
                    BigMods.Add("Mineral Transmutator"); //Mineral Transmutator
                }
                if (ModLoader.GetLoadedMods().Contains("VampKnives")) //Vampire Knives Expanded
                {
                    SmallMods.Add("Knife Worktable"); //Knife Worktable
                }
                if (ModLoader.GetLoadedMods().Contains("Exodus") || ModLoader.GetLoadedMods().Contains("GRealm") || ModLoader.GetLoadedMods().Contains("RawExpasion"))
                {
                    Vanilla.Add("Campfire"); //Campfire
                }
                Vanilla.Add("Water"); //Water
                Vanilla.Add("Lava"); //Lava
                Vanilla.Add("Honey"); //Honey
                #endregion
                if (NPC.downedSlimeKing)
                {
                    VanillaDecor.Add("Soldifier"); //Soldifier
                }
                if (NPC.downedBoss1)
                {
                    if (ModLoader.GetLoadedMods().Contains("ThoriumMod"))
                    {
                        BigMods.Add("Arcane Armor Fabricator"); //Arcane Armor Fabricator
                    }
                }
                if (NPC.downedGoblins)
                {
                    Vanilla.Add("Tinkerer's Workshop"); //Tinkerer's Workshop
                    if (ModLoader.GetLoadedMods().Contains("SerreriaModTwo"))
                    {
                        MediumMods.Add("Uncrafting Station");
                        MediumMods.Add("Un-UncraftingStation");
                    }
                }
                if (NPC.downedBoss2)
                {
                    if (ModLoader.GetLoadedMods().Contains("AlchemistNPC"))
                    {
                        MediumMods.Add("Wing of the World"); //Wing of the World
                    }
                    if (ModLoader.GetLoadedMods().Contains("Tremor"))
                    {
                        BigMods.Add("Devil Forge"); //Devil Forge
                    }
                }
                if (NPC.downedBoss3)
                {
                    VanillaDecor.Add("Bone Welder"); //Bone Welder
                    Vanilla.Add("Alchemy Table"); //Alchemy Table
                    if (ModLoader.GetLoadedMods().Contains("chadsfurni"))
                    {
                        MediumMods.Add("3D Printer"); //3D Printer
                        MediumMods.Add("Wall-O-Matic"); //Wall-O-Matic
                        MediumMods.Add("Printer"); //Printer
                    }
                    if (ModLoader.GetLoadedMods().Contains("CosmeticVariety"))
                    {
                        BigMods.Add("Beverage Brewer"); //Beverage Brewer
                    }
                    if (ModLoader.GetLoadedMods().Contains("Laugicality"))
                    {
                        BigMods.Add("Crystaline Infuser"); //Crystaline Infuser
                    }
                    if (ModLoader.GetLoadedMods().Contains("Osmium"))
                    {
                        MediumMods.Add("Bar Press"); //Bar Press
                    }
                    if (ModLoader.GetLoadedMods().Contains("Tremor"))
                    {
                        BigMods.Add("Necromaniac Workbench"); //Necromaniac Workbench
                    }
                }
                if (NPC.downedQueenBee)
                {
                    Vanilla.Add("Imbuing Station"); //Imbuing Station
                }
                if (Main.hardMode)
                {
                    VanillaDecor.Add("Meat Grinder"); //Meat Grinder
                    Vanilla.Add("Mythril Anvil"); //Mythril Anvil
                    Vanilla.Add("Crystal Ball"); //Crystal Ball
                    Vanilla.Add("Adamantite Forge"); //Adamantite Forge
                    Vanilla.Add("Autohammer"); //Autohammer
                    if (ModLoader.GetLoadedMods().Contains("Bismuth"))
                    {
                        MediumMods.Add("Rune Table"); //Rune Table
                        MediumMods.Add("Orcish Bookcase"); //Orcish Bookcase
                    }
                    if (ModLoader.GetLoadedMods().Contains("CosmeticVariety"))
                    {
                        BigMods.Add("Shadow Extraltar"); //Shadow Extraltar
                    }
                    if (ModLoader.GetLoadedMods().Contains("JoostMod"))
                    {
                        BigMods.Add("Elemental Forge"); //Elemental Forge
                    }
                    if (ModLoader.GetLoadedMods().Contains("Laugicality"))
                    {
                        BigMods.Add("Mineral Enchanter"); //Mineral Enchanter
                    }
                    if (ModLoader.GetLoadedMods().Contains("SpiritMod"))
                    {
                        BigMods.Add("Essence Distorter"); //Essence Distorter
                    }
                    if (ModLoader.GetLoadedMods().Contains("thespatiummod"))
                    {
                        SmallMods.Add("Cobalt Binder"); //Cobalt Binder
                    }
                    if (ModLoader.GetLoadedMods().Contains("Tremor"))
                    {
                        BigMods.Add("Recycler of Matter"); //Recycler of Matter
                    }
                }
                if (NPC.downedPirates)
                {

                }
                if (NPC.downedMechBossAny)
                {
                    VanillaDecor.Add("Steampunk Boiler"); //Steampunk Boiler
                    VanillaDecor.Add("Flesh Cloning Vat"); //Flesh Cloning Vat
                    Vanilla.Add("Blend-o-matic"); //Blend-o-Matic
                    if (ModLoader.GetLoadedMods().Contains("Osmium"))
                    {
                        MediumMods.Add("Hallowed Anvil"); //Hallowed Anvil
                    }
                }
                if (NPC.downedMechBoss1 && NPC.downedMechBoss2 && NPC.downedMechBoss3)
                {
                    if (ModLoader.GetLoadedMods().Contains("CopperPlusMod"))
                    {
                        MediumMods.Add("Vigolythic Anvil"); //Vigolythic Anvil
                        MediumMods.Add("Mechanical Forge"); //Mechanical Forge
                    }
                    if (ModLoader.GetLoadedMods().Contains("thespatiummod"))
                    {
                        SmallMods.Add("Soulful Binder"); //Soulful Binder
                    }
                    if (ModLoader.GetLoadedMods().Contains("ThoriumMod"))
                    {
                        BigMods.Add("Soul Forge"); //Soul Forge
                    }
                }
                if (NPC.downedPlantBoss)
                {
                    VanillaDecor.Add("Lihzahrd Furnace"); //Lihzahrd Furnace
                    if (ModLoader.GetLoadedMods().Contains("Exodus"))
                    {
                        MediumMods.Add("Secret Military Workshop"); //Secret Military Workshop
                    }
                    if (ModLoader.GetLoadedMods().Contains("Laugicality"))
                    {
                        BigMods.Add("Ancient Enchanter"); //Ancient Enchanter
                    }
                    if (ModLoader.GetLoadedMods().Contains("Pumpking"))
                    {
                        Vanilla.Add("Lihzahrd Altar"); //Lihzahrd Altar
                    }
                    if (ModLoader.GetLoadedMods().Contains("Tremor"))
                    {
                        BigMods.Add("Alchemator"); //Alchemator
                    }
                    if (ModLoader.GetLoadedMods().Contains("GadgetBox"))
                    {
                        SmallMods.Add("Lihzahrd Workshop");
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
                    if (ModLoader.GetLoadedMods().Contains("GRealm"))
                    {
                        BigMods.Add("Arcane Welding Station"); //Arcane Welding Station
                    }
                }
                if (NPC.downedFishron)
                {

                }
                if (NPC.downedMartians)
                {

                }
                if (NPC.downedAncientCultist)
                {
                    Vanilla.Add("Ancient Manipulator"); //Ancient Manipulator
                    if (ModLoader.GetLoadedMods().Contains("AlchemistNPC"))
                    {
                        MediumMods.Add("Materia Transmutator"); //Materia Transmutator
                    }
                    if (ModLoader.GetLoadedMods().Contains("Fargowiltas"))
                    {
                        MediumMods.Add("Crucible of the Cosmos"); //Crucible of the Cosmos
                    }
                    if (ModLoader.GetLoadedMods().Contains("Project__C"))
                    {
                        SmallMods.Add("Energy Condenser"); //Energy Condenser
                    }
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
                    if (ModLoader.GetLoadedMods().Contains("CosmeticVariety"))
                    {
                        BigMods.Add("Aegis Contraption"); //Aegis Contraption
                    }
                    if (ModLoader.GetLoadedMods().Contains("TheDeconstructor"))
                    {
                        SmallMods.Add("Lunar Deconstructor"); //Lunar Deconstructor
                    }
                    if (ModLoader.GetLoadedMods().Contains("thespatiummod"))
                    {
                        SmallMods.Add("Celestial Binder"); //Celestial Binder
                    }
                    if (ModLoader.GetLoadedMods().Contains("Tremor"))
                    {
                        BigMods.Add("Starvil"); //Starvil
                        BigMods.Add("Alchemy Station"); //Alchemy Station
                    }
                }
                if (NPC.downedSlimeKing || NPC.downedBoss1 || NPC.downedBoss2 || NPC.downedBoss3 || NPC.downedQueenBee || Main.hardMode || NPC.downedMechBossAny || NPC.downedPlantBoss || NPC.downedGolemBoss || NPC.downedFishron || NPC.downedAncientCultist || NPC.downedMoonlord)
                {
                    if (ModLoader.GetLoadedMods().Contains("Mysticality"))
                    {
                        MediumMods.Add("Omni Bench"); //Omni Bench
                    }
                }
                if (ModLoader.GetLoadedMods().Contains("SacredTools"))
                {
                    if (Abaddon1 || Abaddon2)
                    {
                        BigMods.Add("Oblivion Forge"); //Oblivion Forge
                    }
                    if (Lunarians)
                    {
                        BigMods.Add("Lunatic Infuser"); //Lunatic Infuser
                    }
                    if (Araghur)
                    {
                        BigMods.Add("Flarium Anvil"); //Flarium Anvil
                        BigMods.Add("Flarium Workbench"); //Flarium Workbench
                        BigMods.Add("Flarium Forge"); //Flarium Forge
                    }
                    if (Cerena)
                    {
                        BigMods.Add("Cernium Anvil"); //Cernium Anvil
                        BigMods.Add("Cernium Forge"); //Cernium Forge
                    }
                    if (Erazor)
                    {
                        BigMods.Add("Asthraltite Workbench"); //Asthraltite Workbench
                    }
                }
                if (ModLoader.GetLoadedMods().Contains("CalamityMod"))
                {
                    if (DoG)
                    {
                        BigMods.Add("Draedon's Forge"); //Draedon's Forge
                    }
                }
                if (ModLoader.GetLoadedMods().Contains("Bluemagic"))
                {
                    if (Abomination && NPC.downedMoonlord)
                    {
                        BigMods.Add("Purium Forge"); //Purium Forge
                        BigMods.Add("Purium Anvil"); //Purium Anvil
                    }
                }
                if (ModLoader.GetLoadedMods().Contains("Pumpking"))
                {
                    if (TerraLord)
                    {
                        MediumMods.Add("Terra Forge"); //Terra Forge
                    }
                }
                if (ModLoader.GetLoadedMods().Contains("Tremor"))
                {
                    if (TikiTotem)
                    {
                        BigMods.Add("Great Anvil"); //Great Anvil
                    }
                    if (Trinity)
                    {
                        BigMods.Add("Divine Forge"); //Divine Forge
                    }
                }
                #endregion

                AllTiles = Vanilla.Union(VanillaDecor).Union(BigMods).Union(MediumMods).Union(SmallMods).ToList();

                Vanilla.Sort();
                VanillaDecor.Sort();
                BigMods.Sort();
                MediumMods.Sort();
                SmallMods.Sort();
                AllTiles.Sort();

                string VanillaString = string.Join(", ", Vanilla.ToArray());
                string VanillaDecorString = string.Join(", ", VanillaDecor.ToArray());
                string BigModsString = string.Join(", ", BigMods.ToArray());
                string MediumModsString = string.Join(", ", MediumMods.ToArray());
                string SmallModsString = string.Join(", ", SmallMods.ToArray());
                string AllTilesString = string.Join(", ", AllTiles.ToArray());

                if (cycle > 5)
                    cycle = 0;

                switch (cycle)
                {
                    case 0:
                        Main.NewText("Currently active Vanilla Tiles: " + VanillaString + ".");
                        Main.NewText("Right-click again to see Vanilla Decor Tiles.");
                        cycle++;
                        break;
                    case 1:
                        Main.NewText("Currently active Vanilla Decor Tiles: " + VanillaDecorString + ".");
                        if (BigMods.Any())
                        {
                            Main.NewText("Right-click again to see Big Mod Tiles.");
                            cycle++;
                        }
                        else if (MediumMods.Any())
                        {
                            Main.NewText("Right-click to see Medium Mod Tiles.");
                            cycle += 2;
                        }
                        else if (SmallMods.Any())
                        {
                            Main.NewText("Right-click again to see Small Mod Tiles.");
                            cycle += 3;
                        }
                        else
                        {
                            Main.NewText("Right-click again to see All Tiles.");
                            cycle += 4;
                        }
                        break;
                    case 2:
                        Main.NewText("Currently active Big Mod Tiles: " + BigModsString + ".");
                        if (MediumMods.Any())
                        {
                            Main.NewText("Right-click to see Medium Mod Tiles.");
                            cycle++;
                        }
                        else if (SmallMods.Any())
                        {
                            Main.NewText("Right-click again to see Small Mod Tiles.");
                            cycle += 2;
                        }
                        else
                        {
                            Main.NewText("Right-click again to see All Tiles.");
                            cycle += 3;
                        }
                        break;
                    case 3:
                        Main.NewText("Currently active Medium Mod Tiles: " + MediumModsString + ".");
                        if (SmallMods.Any())
                        {
                            Main.NewText("Right-click again to see Small Mod Tiles.");
                            cycle++;
                        }
                        else
                        {
                            Main.NewText("Right-click again to see All Tiles.");
                            cycle += 2;
                        }
                        break;
                    case 4:
                        Main.NewText("Currently active Small Mod Tiles: " + SmallModsString + ".");
                        Main.NewText("Right-click again to see All Tiles.");
                        cycle++;
                        break;
                    case 5:
                        Main.NewText("Currently active tiles: " + AllTilesString + ".");
                        Main.NewText("Right-click again to see Vanilla Tiles.");
                        cycle = 0;
                        break;
                    default:
                        return;
                }
            //}
            #endregion
            #region Test

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
            if (Main.drawToScreen)
            {
                zero = Vector2.Zero;
            }
            int height = tile.frameY == 36 ? 18 : 16;
            Main.spriteBatch.Draw(mod.GetTexture("Tiles/UniversalCrafter_Glowmask"), new Vector2(i * 16 - (int)Main.screenPosition.X, j * 16 - (int)Main.screenPosition.Y) + zero, new Rectangle(tile.frameX, tile.frameY, 16, height), Color.White, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0f);
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
        #endregion
    }
}