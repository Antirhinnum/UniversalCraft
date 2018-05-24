using Terraria.ModLoader;
using UniversalCraft.Tiles;

namespace UniversalCraft
{
    public class UniversalCrafter : Mod
    {
        public UniversalCrafter()
        {
            Properties = new ModProperties()
            {
                Autoload = true,
            };
        }

        /*public static bool SacredToolsLoaded = ModLoader.GetMod("SacredTools") != null;



        public static Mod Thorium;
        public static Mod SacredTools;
        public static Mod Calamity;
        public static Mod Tremor;

        public override void Load()
        {
            Thorium = ModLoader.GetMod("ThoriumMod");
            SacredTools = ModLoader.GetMod("SacredTools");
            Calamity = ModLoader.GetMod("CalamityMod");
            Tremor = ModLoader.GetMod("Tremor");

            AddGlobalTile("UCTile", new UCTile());
        }

        public override void Unload()
        {
            Thorium = null;
            SacredTools = null;
            Calamity = null;
            Tremor = null;
        }*/
    }
}