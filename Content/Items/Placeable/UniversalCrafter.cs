using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using UniversalCraft.Content.Tiles;

namespace UniversalCraft.Content.Items.Placeable
{
	public class UniversalCrafter : ModItem
	{
		public override void SetDefaults()
		{
			item.width = 32;
			item.height = 32;

			item.maxStack = 999;
			item.useAnimation = 15;
			item.useTime = 10;

			item.consumable = true;
			item.useTurn = true;
			item.autoReuse = true;

			item.useStyle = ItemUseStyleID.SwingThrow;
			item.rare = ItemRarityID.Blue;
			item.value = Item.sellPrice(0, 0, 50, 0);
			item.createTile = ModContent.TileType<UniversalCrafterTile>();
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.Granite, 40);
			recipe.AddIngredient(ItemID.MeteoriteBar, 10);
			recipe.AddIngredient(ItemID.FallenStar, 10);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}