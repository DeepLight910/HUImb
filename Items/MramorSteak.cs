using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace HUImb.Items
{
    public class MramorSteak : ModItem
    {
        public override void SetDefaults()
        {
            Item.width = 14;
            Item.height = 48;
            Item.useStyle = ItemUseStyleID.EatFood;
            Item.useTime = 15;
            Item.useAnimation = 15;
            Item.useTurn = true;
            Item.UseSound = SoundID.Item2;
            Item.maxStack = 9999;
            Item.CommonMaxStack = 9999;
            Item.consumable = true;
            Item.rare = ItemRarityID.Yellow;
            Item.value = 2000;
            Item.potion = false;
            Item.buffType = BuffID.WellFed3;
            Item.buffTime = 54000;
        }
    }
}