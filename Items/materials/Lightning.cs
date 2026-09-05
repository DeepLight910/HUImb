using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace HUImb.Items.materials
{
    public class Lightning : ModItem
    {
        public override void SetDefaults()
        {
            Item.material = true;
            Item.width = 14;
            Item.height = 16;
            Item.CommonMaxStack = 9999;
            Item.maxStack = 9999;
            Item.value = Item.buyPrice(0, 0, 0, 5);
            Item.rare = ItemRarityID.Yellow;
        }
    }
}