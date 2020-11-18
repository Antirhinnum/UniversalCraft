using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace UniversalCraft.Tiles
{
	public class UCTile : GlobalTile
	{
		#region Mods

		private Mod afkPets = ModLoader.GetMod("AFKPETS");
		private Mod alchemistNPC = ModLoader.GetMod("AlchemistNPC");
		private Mod aventadorsMod = ModLoader.GetMod("AventadorsMod");
		private Mod azurium = ModLoader.GetMod("Azurium");
		private Mod bananium = ModLoader.GetMod("Bananium");
		private Mod betterPaint = ModLoader.GetMod("BetterPaint");
		private Mod bismuth = ModLoader.GetMod("Bismuth");
		private Mod bluemagic = ModLoader.GetMod("Bluemagic");
		private Mod boi = ModLoader.GetMod("Boi");
		private Mod calamityMod = ModLoader.GetMod("CalamityMod");
		private Mod chadsFurni = ModLoader.GetMod("chadsfurni");
		private Mod copperPlusMod = ModLoader.GetMod("CopperPlusMod");
		private Mod cosmeticVariety = ModLoader.GetMod("CosmeticVariety");
		private Mod disarray = ModLoader.GetMod("Disarray");
		private Mod draxyMod = ModLoader.GetMod("DraxyMOD");
		private Mod exodus = ModLoader.GetMod("Exodus");
		private Mod extendedCrops = ModLoader.GetMod("ExtendedCrops");
		private Mod fargo = ModLoader.GetMod("Fargowiltas");
		private Mod fargoSouls = ModLoader.GetMod("FargowiltasSouls");
		private Mod fishing3 = ModLoader.GetMod("Fishing3");
		private Mod forbiddenCryonics = ModLoader.GetMod("ForbiddenCryonics");
		private Mod gadgetBox = ModLoader.GetMod("GadgetBox");
		private Mod ghoul = ModLoader.GetMod("Ghoul");
		private Mod gRealm = ModLoader.GetMod("GRealm");
		private Mod hmPlus = ModLoader.GetMod("HMPlus");
		private Mod joostMod = ModLoader.GetMod("JoostMod");
		private Mod laugicality = ModLoader.GetMod("Laugicality");
		private Mod mysticality = ModLoader.GetMod("Mysticality");
		private Mod osmium = ModLoader.GetMod("Osmium");
		private Mod project__C = ModLoader.GetMod("Project__C");
		private Mod pumpking = ModLoader.GetMod("Pumpking");
		private Mod qolRecipes = ModLoader.GetMod("QualityOfLifeRecipes");
		private Mod sacredTools = ModLoader.GetMod("SacredTools");
		private Mod serrariaModTwo = ModLoader.GetMod("SerrariaModTwo");
		private Mod simpleAutoChests = ModLoader.GetMod("SimpleAutoChests");
		private Mod spiritMod = ModLoader.GetMod("SpiritMod");
		private Mod terrariaDark = ModLoader.GetMod("TerrariaDark");
		private Mod theDeconstructor = ModLoader.GetMod("TheDeconstructor");
		private Mod theSpatiumMod = ModLoader.GetMod("thespatiummod");
		private Mod thoriumMod = ModLoader.GetMod("ThoriumMod");
		private Mod touhouMod = ModLoader.GetMod("TouhouMod");
		private Mod tremor = ModLoader.GetMod("Tremor");

		#endregion Mods

		public override int[] AdjTiles(int type)
		{
			List<int> adjTile = new List<int>();
			if (type == mod.TileType("UniversalCrafter"))
			{
				Player player = Main.player[Main.myPlayer];
				player.adjWater = true;
				player.adjLava = true;
				player.adjHoney = true;
				if (NPC.downedSlimeKing)
				{
					adjTile.Add(TileID.Solidifier);
					if (azurium != null)
					{
						adjTile.Add(azurium.TileType("SlimeStationTile"));
					}
				}
				if (NPC.downedBoss1)
				{
					if (thoriumMod != null)
					{
						adjTile.Add(thoriumMod.TileType("ArcaneArmorFabricator"));
					}

					if (touhouMod != null)
					{
						adjTile.Add(touhouMod.TileType("DanmakuTable"));
					}
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
					{
						adjTile.Add(alchemistNPC.TileType("WingoftheWorld"));
					}

					if (tremor != null)
					{
						adjTile.Add(tremor.TileType("DevilForge"));
					}

					if (simpleAutoChests != null)
					{
						adjTile.Add(simpleAutoChests.TileType("OreGatherer"));
						adjTile.Add(simpleAutoChests.TileType("CrimsonGatherer"));
						adjTile.Add(simpleAutoChests.TileType("CorruptionGatherer"));
						adjTile.Add(simpleAutoChests.TileType("BlockGatherer"));
					}
				}
				if (NPC.downedBoss3)
				{
					adjTile.Add(TileID.BoneWelder);
					adjTile.Add(TileID.AlchemyTable);
					if (chadsFurni != null)
					{
						adjTile.Add(chadsFurni.TileType("printer3"));
						adjTile.Add(chadsFurni.TileType("wallomatic"));
						adjTile.Add(chadsFurni.TileType("printer"));
					}
					if (cosmeticVariety != null)
					{
						adjTile.Add(cosmeticVariety.TileType("BeverageBrewer"));
					}

					if (laugicality != null)
					{
						adjTile.Add(laugicality.TileType("CrystalineInfuser"));
						adjTile.Add(laugicality.TileType("TransmutationTable"));
					}
					if (osmium != null)
					{
						adjTile.Add(osmium.TileType("BarPressTile"));
					}

					if (tremor != null)
					{
						adjTile.Add(tremor.TileType("NecromaniacWorkbenchTile"));
					}

					if (afkPets != null)
					{
						adjTile.Add(afkPets.TileType("Computer"));
					}

					if (simpleAutoChests != null)
					{
						adjTile.Add(simpleAutoChests.TileType("LiquidGatherer"));
						adjTile.Add(simpleAutoChests.TileType("DungeonbGatherer"));
					}
					if (qolRecipes != null)
					{
						adjTile.Add(qolRecipes.TileType("AlterationStation"));
					}
				}
				if (NPC.downedBoss1 || NPC.downedBoss2 || NPC.downedBoss3)
				{
					if (chadsFurni != null)
					{
						adjTile.Add(chadsFurni.TileType("CultivationBox"));
					}
				}
				if (NPC.downedQueenBee)
				{
					adjTile.Add(TileID.ImbuingStation);
					if (ModLoader.GetMod("corofevil") != null)
					{
						adjTile.Add(TileID.WaterFountain);
					}
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
					{
						adjTile.Add(cosmeticVariety.TileType("ShadowExtraltar"));
					}

					if (joostMod != null)
					{
						adjTile.Add(joostMod.TileType("ElementalForge"));
					}

					if (laugicality != null)
					{
						adjTile.Add(laugicality.TileType("MineralEnchanter"));
					}

					if (spiritMod != null)
					{
						adjTile.Add(spiritMod.TileType("EssenceDistorter"));
					}

					if (theSpatiumMod != null)
					{
						adjTile.Add(theSpatiumMod.TileType("CobaltBinder"));
					}

					if (tremor != null)
					{
						adjTile.Add(tremor.TileType("RecyclerofMatterTile"));
					}

					if (chadsFurni != null)
					{
						adjTile.Add(chadsFurni.TileType("RimpelstiltskinsLoom"));
					}

					if (hmPlus != null)
					{
						adjTile.Add(TileID.LivingFire);
					}

					if (boi != null)
					{
						adjTile.Add(TileID.RainbowBrick);
					}

					if (draxyMod != null)
					{
						adjTile.Add(draxyMod.TileType("PreBoss__altar"));
					}

					if (terrariaDark != null)
					{
						adjTile.Add(terrariaDark.TileType("DaedricForge"));
					}

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
					{
						adjTile.Add(forbiddenCryonics.TileType("SoulWeaverTile"));
					}

					if (calamityMod != null)
					{
						adjTile.Add(calamityMod.TileType("VoidCondenser"));
					}

					if (simpleAutoChests != null)
					{
						adjTile.Add(simpleAutoChests.TileType("HallowGatherer"));
					}
				}
				if (NPC.downedPirates)
				{
					if (fargoSouls != null)
					{
						adjTile.Add(fargoSouls.TileType("GoldenDippingVatSheet"));
					}
				}
				if (NPC.downedMechBossAny)
				{
					adjTile.Add(TileID.SteampunkBoiler);
					adjTile.Add(TileID.FleshCloningVat);
					adjTile.Add(TileID.Blendomatic);
					if (osmium != null)
					{
						adjTile.Add(osmium.TileType("HallowedAnvilTile"));
					}

					if (bluemagic != null)
					{
						adjTile.Add(bluemagic.TileType("Clentamistation"));
					}

					if (betterPaint != null)
					{
						adjTile.Add(betterPaint.TileType("PaintMixer"));
					}

					if (extendedCrops != null)
					{
						adjTile.Add(extendedCrops.TileType("LHallowedSeedProcessor"));
					}
				}
				if (NPC.downedMechBoss1 && NPC.downedMechBoss2 && NPC.downedMechBoss3)
				{
					if (copperPlusMod != null)
					{
						adjTile.Add(copperPlusMod.TileType("VigolythicAnvil"));
						adjTile.Add(copperPlusMod.TileType("OddForge"));
					}
					if (theSpatiumMod != null)
					{
						adjTile.Add(theSpatiumMod.TileType("SoulfulBinder"));
					}

					if (thoriumMod != null)
					{
						adjTile.Add(thoriumMod.TileType("SoulForge"));
					}

					if (bananium != null)
					{
						adjTile.Add(bananium.TileType("BananaAnvil"));
					}

					if (extendedCrops != null)
					{
						adjTile.Add(extendedCrops.TileType("MChlorophyteSeedProcessor"));
					}

					if (calamityMod != null)
					{
						adjTile.Add(calamityMod.TileType("AshenAltar"));
						adjTile.Add(calamityMod.TileType("AncientAltar"));
					}
				}
				if (NPC.downedPlantBoss)
				{
					adjTile.Add(TileID.Autohammer);
					adjTile.Add(TileID.LihzahrdFurnace);
					if (exodus != null)
					{
						adjTile.Add(exodus.TileType("SecretMilitaryWorkshopTile"));
					}

					if (laugicality != null)
					{
						adjTile.Add(laugicality.TileType("AncientEnchanter"));
					}

					if (pumpking != null || afkPets != null || ghoul != null)
					{
						adjTile.Add(TileID.LihzahrdAltar);
					}

					if (tremor != null)
					{
						adjTile.Add(tremor.TileType("AlchematorTile"));
					}

					if (gadgetBox != null)
					{
						adjTile.Add(gadgetBox.TileType("LihzahrdWorkshopTile"));
					}

					if (aventadorsMod != null)
					{
						adjTile.Add(aventadorsMod.TileType("NeonChargerTile"));
					}

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
					{
						adjTile.Add(gRealm.TileType("ArcaneWeldingStation"));
					}

					if (calamityMod != null)
					{
						adjTile.Add(calamityMod.TileType("PlagueInfuser"));
					}
				}
				if (NPC.downedFishron)
				{
				}
				if (NPC.downedMartians)
				{
					if (fishing3 != null)
					{
						adjTile.Add(fishing3.TileType("AnalyzerTile"));
					}
				}
				if (NPC.downedAncientCultist)
				{
					adjTile.Add(TileID.LunarCraftingStation);
					if (alchemistNPC != null)
					{
						adjTile.Add(alchemistNPC.TileType("MateriaTransmutator"));
					}

					if (project__C != null)
					{
						adjTile.Add(project__C.TileType("EnergyCondenser"));
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
					if (cosmeticVariety != null)
					{
						adjTile.Add(cosmeticVariety.TileType("AegisContraption"));
					}

					if (theDeconstructor != null)
					{
						adjTile.Add(theDeconstructor.TileType("Deconstructor"));
					}

					if (theSpatiumMod != null)
					{
						adjTile.Add(theSpatiumMod.TileType("CelestialBinder"));
					}

					if (tremor != null)
					{
						adjTile.Add(tremor.TileType("Starvil"));
						adjTile.Add(tremor.TileType("AlchemyStationTile"));
					}
					if (disarray != null)
					{
						adjTile.Add(disarray.TileType("ProfaneAnvilTile"));
					}

					if (extendedCrops != null)
					{
						adjTile.Add(extendedCrops.TileType("PLuminiteSeedProcessor"));
					}

					if (calamityMod != null)
					{
						adjTile.Add(calamityMod.TileType("ProfanedBasin"));
					}

					if (fargo != null)
					{
						adjTile.Add(fargo.TileType("CrucibleCosmosSheet"));
					}
				}
				if (NPC.downedSlimeKing || NPC.downedBoss1 || NPC.downedBoss2 || NPC.downedBoss3 || NPC.downedQueenBee || Main.hardMode || NPC.downedMechBossAny || NPC.downedPlantBoss || NPC.downedGolemBoss || NPC.downedFishron || NPC.downedAncientCultist || NPC.downedMoonlord)
				{
					if (mysticality != null)
					{
						adjTile.Add(mysticality.TileType("OmniBench"));
					}
				}
				if (sacredTools != null)
				{
					if (Abaddon1 || Abaddon2)
					{
						adjTile.Add(sacredTools.TileType("OblivionForge"));
					}

					if (Lunarians)
					{
						adjTile.Add(sacredTools.TileType("LunarAltar"));
					}

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
					{
						adjTile.Add(sacredTools.TileType("AsthralWorkbench"));
					}
				}
				if (calamityMod != null)
				{
					if (SlimeGod)
					{
						adjTile.Add(calamityMod.TileType("StaticRefiner"));
					}

					if (DoG)
					{
						adjTile.Add(calamityMod.TileType("DraedonsForge"));
					}

					if (Yharon1)
					{
						adjTile.Add(calamityMod.TileType("SilvaBasin"));
					}
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
					{
						adjTile.Add(pumpking.TileType("TerraForge"));
					}
				}
				//if (tremor != null)
				//{
				//	if (TikiTotem)
				//	{
				//		adjTile.Add(tremor.TileType("GreatAnvilTile"));
				//	}

				//	if (Trinity)
				//	{
				//		adjTile.Add(tremor.TileType("DivineForgeTile"));
				//	}
				//}
				if (copperPlusMod != null)
				{
					if (NPC.downedMoonlord && SuperiorBeing)
					{
						adjTile.Add(copperPlusMod.TileType("AtomObliterator"));
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
			get { return CalamityMod.World.CalamityWorld.downedDoG; }
		}

		public bool SlimeGod
		{
			get { return CalamityMod.World.CalamityWorld.downedSlimeGod; }
		}

		public bool Yharon1
		{
			get { return CalamityMod.World.CalamityWorld.buffedEclipse; }
		}

		public bool Abomination
		{
			get { return Bluemagic.BluemagicWorld.downedAbomination; }
		}

		public bool TerraLord
		{
			get { return Pumpking.PumpkingWorld.downedTerraLord; }
		}

		//public bool TikiTotem
		//{
		//	get { return Tremor.TremorWorld.downedBoss[Tremor.TremorWorld.Boss.TikiTotem]; }
		//}
		//public bool Trinity
		//{
		//	get { return Tremor.TremorWorld.downedBoss[Tremor.TremorWorld.Boss.Trinity]; }
		//}
		public bool SuperiorBeing
		{
			get { return CopperPlusMod.CopperWorld.downedBeing; }
		}

		#endregion Bools
	}
}