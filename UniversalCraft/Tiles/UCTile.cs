using System.Collections.Generic;
using System.Linq;
using Terraria;
using Terraria.ModLoader;

namespace UniversalCraft.Tiles
{
    public class UCTile : GlobalTile
    {
        Mod sacredTools = ModLoader.GetMod("SacredTools");
        Mod calamity = ModLoader.GetMod("CalamityMod");
        Mod bluemagic = ModLoader.GetMod("Bluemagic");
        Mod pumpking = ModLoader.GetMod("Pumpking");
        Mod tremor = ModLoader.GetMod("Tremor");

        public override int[] AdjTiles(int type)
        {
            if (type == mod.TileType("UniversalCrafter"))
            {
                Main.LocalPlayer.adjWater = true;

                if (NPC.downedBoss3)
                {
                    Main.LocalPlayer.adjLava = true;
                }

                if (NPC.downedQueenBee)
                {
                    Main.LocalPlayer.adjHoney = true;
                }
            }

            List<int> adjTile = new List<int>();

            if (type == mod.TileType("UniversalCrafter"))
            {
                if (NPC.downedSlimeKing)
                {
                    adjTile.Add(220); //Solidifier
                }
                if (NPC.downedBoss1)
                {
                    adjTile.Add(26); //Demon Altar
                    if (ModLoader.GetLoadedMods().Contains("ThoriumMod"))
                    {
                        Mod thorium = ModLoader.GetMod("ThoriumMod");
                        adjTile.Add(thorium.TileType("ArcaneArmorFabricator")); //Arcane Armor Fabricator
                    }
                }
                if (NPC.downedGoblins)
                {
                    adjTile.Add(114); //Tinkerer's Workshop
                }
                if (NPC.downedBoss2)
                {
                    if (ModLoader.GetLoadedMods().Contains("AlchemistNPC"))
                    {
                        Mod alchemistNPC = ModLoader.GetMod("AlchemistNPC");
                        adjTile.Add(alchemistNPC.TileType("WingoftheWorld"));
                    }
                }
                if (NPC.downedBoss3)
                {
                    adjTile.Add(77); //Hellforge
                    adjTile.Add(300); //Bone Welder
                    adjTile.Add(355); //Alchemy Station
                    adjTile.Add(354); //Bewitching Table
                    if (ModLoader.GetLoadedMods().Contains("BetterBoneWelder"))
                    {
                        Mod bone = ModLoader.GetMod("BetterBoneWelder");
                        adjTile.Add(bone.TileType("DaemonForge"));
                    }
                    if (ModLoader.GetLoadedMods().Contains("Osmium"))
                    {
                        Mod os = ModLoader.GetMod("Osmium");
                        adjTile.Add(os.TileType("BarPressTile"));
                    }
                    if (ModLoader.GetLoadedMods().Contains("Project__C"))
                    {
                        Mod projC = ModLoader.GetMod("Project__C");
                        adjTile.Add(projC.TileType("EnergyCondenser"));
                    }
                    if (ModLoader.GetLoadedMods().Contains("CosmeticVariety"))
                    {
                        Mod FFF = ModLoader.GetMod("CosmeticVariety");
                        adjTile.Add(FFF.TileType("BeverageBrewer"));
                    }
                    if (ModLoader.GetLoadedMods().Contains("Laugicality"))
                    {
                        Mod logic = ModLoader.GetMod("Laugicality");
                        adjTile.Add(logic.TileType("CrystalineInfuser"));
                    }
                    if (ModLoader.GetLoadedMods().Contains("Tremor"))
                    {
                        adjTile.Add(tremor.TileType("NecromaniacWorkbenchTile"));
                        adjTile.Add(tremor.TileType("DevilForge"));
                    }
                }
                if (NPC.downedQueenBee)
                {
                    adjTile.Add(243); //Imbuing Station
                    adjTile.Add(308); //Honey Dispenser
                }
                if (Main.hardMode)
                {
                    adjTile.Add(133); //Mythril Anvil
                    adjTile.Add(134); //Adamantite Forge
                    adjTile.Add(125); //Crystal Ball
                    adjTile.Add(218); //Meat Grinder
                    adjTile.Add(247); //Autohammer
                    if (ModLoader.GetLoadedMods().Contains("CosmeticVariety"))
                    {
                        Mod FFF = ModLoader.GetMod("CosmeticVariety");
                        adjTile.Add(FFF.TileType("ShadowExtraltar"));
                    }
                    if (ModLoader.GetLoadedMods().Contains("JoostMod"))
                    {
                        Mod joost = ModLoader.GetMod("JoostMod");
                        adjTile.Add(joost.TileType("ElementalForge"));
                    }
                    if (ModLoader.GetLoadedMods().Contains("thespatiummod"))
                    {
                        Mod bind = ModLoader.GetMod("thespatiummod");
                        adjTile.Add(bind.TileType("CobaltBinder"));
                    }
                    if (ModLoader.GetLoadedMods().Contains("Laugicality"))
                    {
                        Mod logic = ModLoader.GetMod("Laugicality");
                        adjTile.Add(logic.TileType("MineralEnchanter"));
                    }
                    if (ModLoader.GetLoadedMods().Contains("SpiritMod"))
                    {
                        Mod spirit = ModLoader.GetMod("SpiritMod");
                        adjTile.Add(spirit.TileType("EssenceDistorter"));
                    }
                    if (ModLoader.GetLoadedMods().Contains("Tremor"))
                    {
                        adjTile.Add(tremor.TileType("RecyclerofMatterTile"));
                    }
                }
                if (NPC.downedMechBossAny)
                {
                    adjTile.Add(217); //Blend-O-Matic
                    adjTile.Add(301); //Flesh Cloning Vat
                    adjTile.Add(307); //Steampunk Boiler
                    if (ModLoader.GetLoadedMods().Contains("Bluemagic"))
                    {
                        adjTile.Add(bluemagic.TileType("Clentamistation"));
                    }
                }
                if (NPC.downedMechBoss1 && NPC.downedMechBoss2 && NPC.downedMechBoss3)
                {
                    if (ModLoader.GetLoadedMods().Contains("ThoriumMod"))
                    {
                        Mod thorium = ModLoader.GetMod("ThoriumMod");
                        adjTile.Add(thorium.TileType("SoulForge")); //Soul Forge
                    }
                    if (ModLoader.GetLoadedMods().Contains("CopperPlusMod"))
                    {
                        Mod copper = ModLoader.GetMod("CopperPlusMod");
                        adjTile.Add(copper.TileType("OddForge"));
                        adjTile.Add(copper.TileType("VigolythicAnvil"));
                    }
                    if (ModLoader.GetLoadedMods().Contains("thespatiummod"))
                    {
                        Mod bind = ModLoader.GetMod("thespatiummod");
                        adjTile.Add(bind.TileType("SoulfulBinder"));
                    }
                    if (ModLoader.GetLoadedMods().Contains("Undermod"))
                    {
                        Mod under = ModLoader.GetMod("Undermod");
                        adjTile.Add(under.TileType("DTEM"));
                    }
                }
                if (NPC.downedPlantBoss)
                {
                    if (ModLoader.GetLoadedMods().Contains("Laugicality"))
                    {
                        Mod logic = ModLoader.GetMod("Laugicality");
                        adjTile.Add(logic.TileType("AncientEnchanter"));
                    }
                    if (ModLoader.GetLoadedMods().Contains("Tremor"))
                    {
                        adjTile.Add(tremor.TileType("AlchematorTile"));
                    }
                }
                if (NPC.downedGolemBoss)
                {
                    adjTile.Add(303); //Lihzahrd Furnace
                    adjTile.Add(237); //Lihzahrd Altar

                    if (ModLoader.GetLoadedMods().Contains("GRealm") && ModLoader.GetLoadedMods().Contains("BaseMod"))
                    {
                        Mod gRealm = ModLoader.GetMod("GRealm");
                        adjTile.Add(gRealm.TileType("ArcaneWeldingStation"));
                    }
                }
                if (NPC.downedAncientCultist)
                {
                    adjTile.Add(412); //Ancient Manipulator

                    if (ModLoader.GetLoadedMods().Contains("Fargowiltas"))
                    {
                        Mod fargo = ModLoader.GetMod("Fargowiltas");
                        adjTile.Add(fargo.TileType("CrucibleCosmosSheet"));
                    }
                    if (ModLoader.GetLoadedMods().Contains("AlchemistNPC"))
                    {
                        Mod alchemistNPC = ModLoader.GetMod("AlchemistNPC");
                        adjTile.Add(alchemistNPC.TileType("MateriaTransmutator"));
                    }
                }
                if (NPC.downedMoonlord)
                {
                    if (ModLoader.GetLoadedMods().Contains("CosmeticVariety"))
                    {
                        Mod FFF = ModLoader.GetMod("CosmeticVariety");
                        adjTile.Add(FFF.TileType("AegisContraption"));
                    }
                    if (ModLoader.GetLoadedMods().Contains("TheDeconstructor"))
                    {
                        Mod uncraft = ModLoader.GetMod("TheDeconstructor");
                        adjTile.Add(uncraft.TileType("Deconstructor"));
                    }
                    if (ModLoader.GetLoadedMods().Contains("thespatiummod"))
                    {
                        Mod bind = ModLoader.GetMod("thespatiummod");
                        adjTile.Add(bind.TileType("CelestialBinder"));
                    }
                    if (ModLoader.GetLoadedMods().Contains("Tremor"))
                    {
                        adjTile.Add(tremor.TileType("AlchemyStationTile"));
                        adjTile.Add(tremor.TileType("Starvil"));
                    }
                }
                if (NPC.downedSlimeKing || NPC.downedBoss1 || NPC.downedBoss2 || NPC.downedBoss3 || NPC.downedQueenBee || Main.hardMode || NPC.downedMechBossAny || NPC.downedPlantBoss || NPC.downedGolemBoss || NPC.downedFishron || NPC.downedAncientCultist || NPC.downedMoonlord)
                {
                    if (ModLoader.GetLoadedMods().Contains("Mysticality"))
                    {
                        Mod mystic = ModLoader.GetMod("Mysticality");
                        adjTile.Add(mystic.TileType("OmniBench"));
                    }
                }

                if (sacredTools != null)
                {
                    if (Abadabadingdong || Abadabadingdong2)
                    {
                        adjTile.Add(sacredTools.TileType("OblivionForge")); //Oblivion Forge
                    }

                    if (MagicWaifuNuba)
                    {
                        adjTile.Add(sacredTools.TileType("LunarAltar")); //Lunatic Infuser
                    }

                    if (SnakesAreSuperiorBitch)
                    {
                        adjTile.Add(sacredTools.TileType("FlameAnvil")); //Flarium Anvil
                        adjTile.Add(sacredTools.TileType("FlameWorkbench")); //Flarium Workbench
                        adjTile.Add(sacredTools.TileType("FlameForge")); //Flarium Forge
                    }

                    if (Deadfreeze)
                    {
                        adjTile.Add(sacredTools.TileType("FrostAnvil")); //Cernium Anvil
                        adjTile.Add(sacredTools.TileType("FrostForge")); //Cernium Forge
                    }

                    if (TotallyNotDanYami)
                    {
                        adjTile.Add(sacredTools.TileType("AsthralWorkbench")); //Asthraltite Workbench
                    }
                }

                if (calamity != null)
                {
                    if (Doggo)
                    {
                        adjTile.Add(calamity.TileType("DraedonsForge")); //Draedon's Forge
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
                        adjTile.Add(pumpking.TileType("TerraForge"));
                    }
                }

                //if (tremor != null)
                //{
                //    if (Tiki)
                //    {
                //        adjTile.Add(tremor.TileType("GreatAnvilTile"));
                //    }
                //}
            }

            return adjTile.ToArray();
        }

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
        //public bool Tiki
        //{
        //    get { return Tremor.TremorWorld.downedTikiTotem; }
        //}
    }
}