using Terraria;
using Terraria.ID;
using Terraria.ModLoader;


namespace HUImb.Items
{
    public class BreadMyakish : ModItem
    {
        // The Display Name and Tooltip of this item can be edited in the Localization/en-US_Mods.HUImb.hjson file.

        public override void SetDefaults()
        {
            Item.material = false;
            Item.CommonMaxStack = 9999;
            Item.maxStack = 9999;
            Item.consumable = true;
            Item.value = Item.buyPrice(0, 0, 0, 6);
            Item.bait = 25;
            Item.rare = ItemRarityID.White;
        }

        public override void AddRecipes()
        {
            CreateRecipe(20)
                .AddIngredient(ItemID.Hay, 5)
                .AddTile(TileID.Furnaces)
                .Register();
        }
    }
}