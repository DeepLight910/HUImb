using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace HUImb.Items.materials
{
    public class Cellulose : ModItem
    {
        public override void SetDefaults()
        {
            Item.material = true;
            Item.CommonMaxStack = 9999;
            Item.maxStack = 9999;
            Item.value = Item.buyPrice(0, 0, 0, 5);
            Item.rare = ItemRarityID.White;
        }
    }
}