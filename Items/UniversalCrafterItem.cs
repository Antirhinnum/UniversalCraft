using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace UniversalCraft.Items
{
	public class UniversalCrafterItem : ModItem
	{
		public override void SetDefaults()
		{
			item.Size = new Vector2(32);

			item.maxStack = 999;
			item.useAnimation = 15;
			item.useTime = 10;

			item.consumable = true;
			item.useTurn = true;
			item.autoReuse = true;

			item.useStyle = ItemUseStyleID.SwingThrow;
			item.rare = ItemRarityID.Green;
			item.value = Item.sellPrice(0, 0, 50, 0);
			item.createTile = ModContent.TileType<Tiles.UniversalCrafterTile>();
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.Wood, 10);
			recipe.AddIngredient(ItemID.GrayBrick, 20);
			recipe.AddRecipeGroup(RecipeGroupID.IronBar, 10);
			recipe.AddIngredient(ItemID.Torch, 15);
			recipe.AddIngredient(ItemID.LesserHealingPotion, 5);
			recipe.AddIngredient(ItemID.Glass, 20);
			recipe.AddTile(TileID.WorkBenches);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}