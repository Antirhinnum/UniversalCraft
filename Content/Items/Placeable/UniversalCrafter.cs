using Terraria;
using Terraria.Enums;
using Terraria.ID;
using Terraria.ModLoader;
using UniversalCraft.Content.Tiles;

namespace UniversalCraft.Content.Items.Placeable;

public sealed class UniversalCrafter : ModItem
{
	public override void SetDefaults()
	{
		Item.DefaultToPlaceableTile(ModContent.TileType<UniversalCrafterTile>());
		Item.SetShopValues(ItemRarityColor.Blue1, Item.sellPrice(silver: 50));
	}

	public override void AddRecipes()
	{
		CreateRecipe()
			.AddIngredient(ItemID.Granite, 40)
			.AddIngredient(ItemID.MeteoriteBar, 10)
			.AddIngredient(ItemID.FallenStar, 10)
			.AddTile(TileID.Anvils)
			.Register();
	}
}