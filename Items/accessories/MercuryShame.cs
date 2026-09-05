using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using HUImb.Items.materials;

namespace HUImb.Items.accessories
{
    public class MercuryShame : ModItem 
    {
        public override void SetDefaults()
        {
            Item.accessory = true;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.manaCost -= 0.1f;
            player.statManaMax2 += 100;
            player.GetCritChance(DamageClass.Magic) += 0.15f;
            player.GetDamage(DamageClass.Magic) += 0.15f;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.SorcererEmblem)
                .AddIngredient(ModContent.ItemType<ZodiacHeart>())
                .AddIngredient(ItemID.FallenStar, 50)
                .AddIngredient(ItemID.ManaCrystal, 20)
                .AddIngredient(ItemID.MoonStone)
                .AddTile(TileID.TinkerersWorkbench)
                .Register();
        }
    }
}
