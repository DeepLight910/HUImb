using HUImb.Tiles;
using System;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;


namespace HUImb.Items.Placeable
{
    internal class ZenithToilet : ModItem
    {
        public override void SetDefaults()
        {
            Item.DefaultToPlaceableTile(ModContent.TileType<ZenithToiletTile>());
            Item.value = Item.buyPrice(platinum: 44, gold: 78);
            Item.maxStack = 99;
            Item.width = 16;
            Item.height = 24;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.Toilet)
                .AddIngredient(ItemID.TerraToilet)
                .AddIngredient(ItemID.ToiletHoney)
                .AddIngredient(ItemID.ToiletMartian)
                .AddIngredient(ItemID.ToiletLivingWood)
                .AddIngredient(ItemID.NebulaToilet)
                .AddIngredient(ItemID.GoldenToilet)
                .AddTile(TileID.MythrilAnvil)
                .Register();
        }

    }
}
