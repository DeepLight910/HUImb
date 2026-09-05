using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using HUImb.Items.materials;

namespace HUImb.Items.accessories
{
    public class LastHope : ModItem
    {
        public override void SetDefaults()
        {
            Item.accessory = true;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.manaCost -= 0.5f;
            player.statManaMax2 += 200;
            player.statDefense /= 2;
            player.moveSpeed *= 2;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ModContent.ItemType<MercuryShame>())
                .AddIngredient(ModContent.ItemType<ZodiacStar>(), 15)
                .AddIngredient(ModContent.ItemType<ZodiacHeart>())
                .AddIngredient(ItemID.LunarBar, 10)
                .AddTile(TileID.TinkerersWorkbench)
                .Register();
        }
    }
}