using System.Collections.Generic;
using System.Linq;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace UniversalCraft.Tiles
{
    public class UCTile : GlobalTile
    {
        #region Mods
        Mod alchemistNPC = ModLoader.GetMod("AlchemistNPC"); //AlchemistNPC
        Mod bismuth = ModLoader.GetMod("Bismuth"); //Bismuth Mod
        Mod bluemagic = ModLoader.GetMod("Bluemagic"); //Elemental Unleash
        Mod calamityMod = ModLoader.GetMod("CalamityMod"); //Calamity Mod
        Mod chadsFurni = ModLoader.GetMod("chadsfurni"); //Chad's Furniture Mod
        Mod copperPlusMod = ModLoader.GetMod("CopperPlusMod"); //Copper Plus
        Mod cosmeticVariety = ModLoader.GetMod("CosmeticVariety"); //Furniture, Food, and Fun
        Mod exodus = ModLoader.GetMod("Exodus"); //Exodus Mod
        Mod fargowiltas = ModLoader.GetMod("Fargowiltas"); //Fargo's Mutant Mod: Summons and Souls
        Mod gRealm = ModLoader.GetMod("GRealm"); //GRealm
        Mod joostMod = ModLoader.GetMod("JoostMod"); //Joostmod
        Mod laugicality = ModLoader.GetMod("Laugicality"); //The Enigma Mod
        Mod mysticality = ModLoader.GetMod("Mysticality"); //Mysticality
        Mod osmium = ModLoader.GetMod("Osmium"); //Osmium Mod
        Mod project__C = ModLoader.GetMod("Project__C"); //ProjectC (EE2 / ProjectE)
        Mod pumpking = ModLoader.GetMod("Pumpking"); //Pumpking's Mod
        Mod sacredTools = ModLoader.GetMod("SacredTools"); //SacredTools
        Mod spiritMod = ModLoader.GetMod("SpiritMod"); //Spirit Mod
        Mod theDeconstructor = ModLoader.GetMod("TheDeconstructor"); //The Lunar Deconstructor
        Mod theSpatiumMod = ModLoader.GetMod("thespatiummod"); //Item Binders
        Mod thoriumMod = ModLoader.GetMod("ThoriumMod"); //Thorium Mod
        Mod tremor = ModLoader.GetMod("Tremor"); //Tremor Mod Remastered
        #endregion

        public override int[] AdjTiles(int type)
        {
            List<int> adjTile = new List<int>();

            if (type == mod.TileType("UniversalCrafter"))
            {
                Main.LocalPlayer.adjWater = true; //Water
                Main.LocalPlayer.adjLava = true; //Lava
                Main.LocalPlayer.adjHoney = true; //Honey

                if (NPC.downedSlimeKing)
                {
                    adjTile.Add(TileID.Solidifier); //Soldifier
                }
                if (NPC.downedBoss1)
                {
                    if (ModLoader.GetLoadedMods().Contains("ThoriumMod"))
                    {
                        adjTile.Add(thoriumMod.TileType("ArcaneArmorFabricator")); //Arcane Armor Fabricator
                    }
                }
                if (NPC.downedGoblins)
                {
                    adjTile.Add(TileID.TinkerersWorkbench); //Tinkerer's Workshop
                }
                if (NPC.downedBoss2)
                {
                    if (ModLoader.GetLoadedMods().Contains("AlchemistNPC"))
                    {
                        adjTile.Add(alchemistNPC.TileType("WingoftheWorld")); //Wing of the World
                    }
                    if (ModLoader.GetLoadedMods().Contains("Tremor"))
                    {
                        adjTile.Add(tremor.TileType("DevilForge")); //Devil Forge
                    }
                }
                if (NPC.downedBoss3)
                {
                    adjTile.Add(TileID.BoneWelder); //Bone Welder
                    adjTile.Add(TileID.AlchemyTable); //Alchemy Table
                    if (ModLoader.GetLoadedMods().Contains("chadsfurni"))
                    {
                        adjTile.Add(chadsFurni.TileType("printer3")); //3D Printer
                        adjTile.Add(chadsFurni.TileType("wallomatic")); //Wall-O-Matic
                        adjTile.Add(chadsFurni.TileType("printer")); //Printer
                    }
                    if (ModLoader.GetLoadedMods().Contains("CosmeticVariety"))
                    {
                        adjTile.Add(cosmeticVariety.TileType("BeverageBrewer")); //Beverage Brewer
                    }
                    if (ModLoader.GetLoadedMods().Contains("Laugicality"))
                    {
                        adjTile.Add(laugicality.TileType("CrystalineInfuser")); //Crystaline Infuser
                    }
                    if (ModLoader.GetLoadedMods().Contains("Osmium"))
                    {
                        adjTile.Add(osmium.TileType("BarPressTile")); //Bar Press
                    }
                    if (ModLoader.GetLoadedMods().Contains("Tremor"))
                    {
                        adjTile.Add(tremor.TileType("NecromaniacWorkbenchTile")); //Necromaniac Workbench
                    }
                }
                if (NPC.downedQueenBee)
                {
                    adjTile.Add(TileID.ImbuingStation); //Imbuing Station
                }
                if (Main.hardMode)
                {
                    adjTile.Add(TileID.MeatGrinder); //Meat Grinder
                    adjTile.Add(TileID.MythrilAnvil); //Mythril Anvil
                    adjTile.Add(TileID.CrystalBall); //Crystal Ball
                    adjTile.Add(TileID.AdamantiteForge); //Adamantite Forge
                    adjTile.Add(TileID.Autohammer); //Autohammer
                    if (ModLoader.GetLoadedMods().Contains("Bismuth"))
                    {
                        adjTile.Add(bismuth.TileType("RuneTable")); //Rune Table
                        adjTile.Add(bismuth.TileType("OrcishBookcase")); //Orcish Bookcase
                    }
                    if (ModLoader.GetLoadedMods().Contains("CosmeticVariety"))
                    {
                        adjTile.Add(cosmeticVariety.TileType("ShadowExtraltar")); //Shadow Extraltar
                    }
                    if (ModLoader.GetLoadedMods().Contains("JoostMod"))
                    {
                        adjTile.Add(joostMod.TileType("ElementalForge")); //Elemental Forge
                    }
                    if (ModLoader.GetLoadedMods().Contains("Laugicality"))
                    {
                        adjTile.Add(laugicality.TileType("MineralEnchanter")); //Mineral Enchanter
                    }
                    if (ModLoader.GetLoadedMods().Contains("SpiritMod"))
                    {
                        adjTile.Add(spiritMod.TileType("EssenceDistorter")); //Essence Distorter
                    }
                    if (ModLoader.GetLoadedMods().Contains("thespatiummod"))
                    {
                        adjTile.Add(theSpatiumMod.TileType("CobaltBinder")); //Cobalt Binder
                    }
                    if (ModLoader.GetLoadedMods().Contains("Tremor"))
                    {
                        adjTile.Add(tremor.TileType("RecyclerofMatterTile")); //Recycler of Matter
                    }
                }
                if (NPC.downedPirates)
                {

                }
                if (NPC.downedMechBossAny)
                {
                    adjTile.Add(TileID.SteampunkBoiler); //Steampunk Boiler
                    adjTile.Add(TileID.FleshCloningVat); //Flesh Cloning Vat
                    adjTile.Add(TileID.Blendomatic); //Blend-o-Matic
                    if (ModLoader.GetLoadedMods().Contains("Osmium"))
                    {
                        adjTile.Add(osmium.TileType("HallowedAnvilTile")); //Hallowed Anvil
                    }
                }
                if (NPC.downedMechBoss1 && NPC.downedMechBoss2 && NPC.downedMechBoss3)
                {
                    if (ModLoader.GetLoadedMods().Contains("CopperPlusMod"))
                    {
                        adjTile.Add(copperPlusMod.TileType("VigolythicAnvil")); //Vigolythic Anvil
                        adjTile.Add(copperPlusMod.TileType("OddForge")); //Mechanical Forge
                    }
                    if (ModLoader.GetLoadedMods().Contains("thespatiummod"))
                    {
                        adjTile.Add(theSpatiumMod.TileType("SoulfulBinder")); //Soulful Binder
                    }
                    if (ModLoader.GetLoadedMods().Contains("ThoriumMod"))
                    {
                        adjTile.Add(thoriumMod.TileType("SoulForge")); //Soul Forge
                    }
                }
                if (NPC.downedPlantBoss)
                {
                    adjTile.Add(TileID.LihzahrdFurnace); //Lihzahrd Furnace
                    if (ModLoader.GetLoadedMods().Contains("Exodus"))
                    {
                        adjTile.Add(exodus.TileType("SecretMilitaryWorkshopTile")); //Secret Military Workshop
                    }
                    if (ModLoader.GetLoadedMods().Contains("Laugicality"))
                    {
                        adjTile.Add(laugicality.TileType("AncientEnchanter")); //Ancient Enchanter
                    }
                    if (ModLoader.GetLoadedMods().Contains("Pumpking"))
                    {
                        adjTile.Add(TileID.LihzahrdAltar); //Lihzahrd Altar
                    }
                    if (ModLoader.GetLoadedMods().Contains("Tremor"))
                    {
                        adjTile.Add(tremor.TileType("AlchematorTile")); //Alchemator
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
                        adjTile.Add(gRealm.TileType("ArcaneWeldingStation")); //Arcane Welding Station
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
                    adjTile.Add(TileID.LunarCraftingStation); //Ancient Manipulator
                    if (ModLoader.GetLoadedMods().Contains("AlchemistNPC"))
                    {
                        adjTile.Add(alchemistNPC.TileType("MateriaTransmutator")); //Materia Transmutator
                    }
                    if (ModLoader.GetLoadedMods().Contains("Fargowiltas"))
                    {
                        adjTile.Add(fargowiltas.TileType("CrucibleCosmosSheet")); //Crucible of the Cosmos
                    }
                    if (ModLoader.GetLoadedMods().Contains("Project__C"))
                    {
                        adjTile.Add(project__C.TileType("EnergyCondenser")); //Energy Condenser
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
                        adjTile.Add(cosmeticVariety.TileType("AegisContraption")); //Aegis Contraption
                    }
                    if (ModLoader.GetLoadedMods().Contains("TheDeconstructor"))
                    {
                        adjTile.Add(theDeconstructor.TileType("Deconstructor")); //Lunar Deconstructor
                    }
                    if (ModLoader.GetLoadedMods().Contains("thespatiummod"))
                    {
                        adjTile.Add(theSpatiumMod.TileType("CelestialBinder")); //Celestial Binder
                    }
                    if (ModLoader.GetLoadedMods().Contains("Tremor"))
                    {
                        adjTile.Add(tremor.TileType("Starvil")); //Starvil
                        adjTile.Add(tremor.TileType("AlchemyStationTile")); //Alchemy Station
                    }
                }
                if (NPC.downedSlimeKing || NPC.downedBoss1 || NPC.downedBoss2 || NPC.downedBoss3 || NPC.downedQueenBee || Main.hardMode || NPC.downedMechBossAny || NPC.downedPlantBoss || NPC.downedGolemBoss || NPC.downedFishron || NPC.downedAncientCultist || NPC.downedMoonlord)
                {
                    if (ModLoader.GetLoadedMods().Contains("Mysticality"))
                    {
                        adjTile.Add(mysticality.TileType("OmniBench")); //Omni Bench
                    }
                }
                if (sacredTools != null)
                {
                    if (Abaddon1 || Abaddon2)
                    {
                        adjTile.Add(sacredTools.TileType("OblivionForge")); //Oblivion Forge
                    }
                    if (Lunarians)
                    {
                        adjTile.Add(sacredTools.TileType("LunarAltar")); //Lunatic Infuser
                    }
                    if (Araghur)
                    {
                        adjTile.Add(sacredTools.TileType("FlameAnvil")); //Flarium Anvil
                        adjTile.Add(sacredTools.TileType("FlameWorkbench")); //Flarium Workbench
                        adjTile.Add(sacredTools.TileType("FlameForge")); //Flarium Forge
                    }
                    if (Cerena)
                    {
                        adjTile.Add(sacredTools.TileType("FrostAnvil")); //Cernium Anvil
                        adjTile.Add(sacredTools.TileType("FrostForge")); //Cernium Forge
                    }
                    if (Erazor)
                    {
                        adjTile.Add(sacredTools.TileType("AsthralWorkbench")); //Asthraltite Workbench
                    }
                }
                if (calamityMod != null)
                {
                    if (DoG)
                    {
                        adjTile.Add(calamityMod.TileType("DraedonsForge")); //Draedon's Forge
                    }
                }
                if (bluemagic != null)
                {
                    if (Abomination && NPC.downedMoonlord)
                    {
                        adjTile.Add(bluemagic.TileType("PuriumForge")); //Purium Forge
                        adjTile.Add(bluemagic.TileType("PuriumAnvil")); //Purium Anvil
                    }
                }
                if (pumpking != null)
                {
                    if (TerraLord)
                    {
                        adjTile.Add(pumpking.TileType("TerraForge")); //Terra Forge
                    }
                }
                if (tremor != null)
                {
                    if (TikiTotem)
                    {
                        adjTile.Add(tremor.TileType("GreatAnvilTile")); //Great Anvil
                    }
                    if (Trinity)
                    {
                        adjTile.Add(tremor.TileType("DivineForgeTile")); //Divine Forge
                    }
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
        #endregion
    }
}