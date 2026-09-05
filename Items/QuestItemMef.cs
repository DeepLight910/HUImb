using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace HUImb.Items
{
    public class QuestItemMef : ModItem
    {
        // The Display Name and Tooltip of this item can be edited in the Localization/en-US_Mods.HUImb.hjson file.

        public override void SetDefaults()
        {
            Item.value = Item.buyPrice(0, 15, 25 , 12);
            Item.rare = ItemRarityID.Quest;
        }
    }
}