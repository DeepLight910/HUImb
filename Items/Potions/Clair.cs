using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace HUImb.Items.Potions
{
    public class Clair : ModItem
    {
        public override void SetDefaults()
        {
            Item.width = 32;
            Item.height = 46;
            Item.useStyle = ItemUseStyleID.EatFood;
            Item.useTime = 15;
            Item.useAnimation = 15;
            Item.useTurn = true;
            Item.UseSound = SoundID.Item3;
            Item.maxStack = 9999;
            Item.CommonMaxStack = 9999;
            Item.consumable = true;
            Item.rare = ItemRarityID.White;
            Item.value = 750;
            Item.potion = false;
            Item.buffType = BuffID.WellFed2;
            Item.buffTime = 20250;
            Item.material = true;
            Item.consumable = false;
        }
    }
}