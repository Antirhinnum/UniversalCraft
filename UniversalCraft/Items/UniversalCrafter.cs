using Terraria.ModLoader;
using Terraria.ID;

namespace UniversalCraft.Items
{
    public class UniversalCrafter : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Universal Crafter");
            Tooltip.SetDefault("'All in one!'\nActs as tons of crafting stations\nMore stations are added as you progress through the game\nRight-click the tile to see what stations you currently have\nCan be used as an Extractinator");
            
            DisplayName.AddTranslation(GameCulture.Chinese, "宇宙工坊");
            Tooltip.AddTranslation(GameCulture.Chinese, "'融为一体!'\n蕴含大量制作环境\n随着游戏发展,会增加更多制作环境\n右键工坊可查看目前拥有的制作环境\n可用作提炼机");
        }

        public override void SetDefaults()
        {
            item.width = 32;
            item.height = 32;
            item.maxStack = 999;
            item.useTurn = true;
            item.autoReuse = true;
            item.useAnimation = 15;
            item.useTime = 10;
            item.useStyle = 1;
            item.consumable = true;
            item.rare = 11;
            item.value = 10;
            item.createTile = mod.TileType("UniversalCrafter");
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Wood, 10);
            recipe.AddIngredient(ItemID.GrayBrick, 20);
            recipe.AddRecipeGroup("IronBar", 10);
            recipe.AddIngredient(ItemID.Torch, 15);
            recipe.AddIngredient(ItemID.LesserHealingPotion, 5);
            recipe.AddIngredient(ItemID.Glass, 20);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
