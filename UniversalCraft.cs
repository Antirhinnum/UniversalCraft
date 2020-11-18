using Terraria.ID;
using Terraria.ModLoader;

namespace UniversalCraft
{
    public class UniversalCraft : Mod
    {
        public UniversalCraft()
        {
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(this);
            recipe.AddIngredient(ItemID.EmptyBucket, 1);
            recipe.needWater = true;
            recipe.SetResult(ItemID.WaterBucket, 1);
            recipe.AddRecipe();

            recipe = new ModRecipe(this);
            recipe.AddIngredient(ItemID.EmptyBucket, 1);
            recipe.needLava = true;
            recipe.SetResult(ItemID.LavaBucket, 1);
            recipe.AddRecipe();

            recipe = new ModRecipe(this);
            recipe.AddIngredient(ItemID.EmptyBucket, 1);
            recipe.needHoney = true;
            recipe.SetResult(ItemID.HoneyBucket, 1);
            recipe.AddRecipe();
        }
    }
}