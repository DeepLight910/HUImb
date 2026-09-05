using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace HUImb.Items.materials
{
    public class Dollar : ModItem
    {
        // The Display Name and Tooltip of this item can be edited in the Localization/en-US_Mods.HUImb.hjson file.

        public override void SetDefaults()
        {
            Item.material = true;
            Item.CommonMaxStack = 9999;
            Item.maxStack = 9999;
            Item.value = Item.buyPrice(0, 0, 0, 99);
            Item.rare = ItemRarityID.White;
        }
    }
}