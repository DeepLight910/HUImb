using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace HUImb.Items.accessories
{
    public class SaitamaCloak : ModItem
    {
        public override void SetDefaults()
        {
            Item.accessory = true;
            Item.value = 50000;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.GetCritChance(DamageClass.Melee) += 25f;
            player.GetDamage(DamageClass.Melee) += 0.2f;
            player.autoReuseAllWeapons = true;
        }
    }
}