using HUImb.Items.materials;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace HUImb.Items
{
    public class ManaCrystalizer : ModItem
    {
        public override void SetDefaults()
        {
            Item.width = 14;
            Item.height = 48;
            Item.useStyle = ItemUseStyleID.HoldUp;
            Item.useTime = 15;
            Item.useAnimation = 15;
            Item.useTurn = true;
            Item.UseSound = SoundID.Item2;
            Item.maxStack = 9999;
            Item.consumable = true;
            Item.rare = ItemRarityID.Blue;
            Item.value = 2;
        }

        public override bool? UseItem(Player player)
        {
            player.QuickSpawnItem(player.GetSource_Loot(),ModContent.ItemType<CrystalMana>(), player.statManaMax2);
            player.statMana = 0;
            return true;
        }
    }
}