using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using HUImb.Items.materials;

namespace HUImb.Items.accessories
{
    public class DollarThree : ModItem
    {
        public override void SetDefaults()
        {
            Item.accessory = true;

        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.manaCost -= 0.1f;
            player.statManaMax2 += 60;
            player.GetCritChance(DamageClass.Magic) += 0.1f;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ModContent.ItemType<Dollar>(), 3)
                .AddTile(TileID.PiggyBank)
                .Register();
        }
    }
}