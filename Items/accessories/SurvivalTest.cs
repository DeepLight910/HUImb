using Terraria;
using Terraria.ModLoader;

namespace HUImb.Items.accessories
{
    
    public class SurvivalTest : ModItem
    {
        public float defboost = 0f;
        public override void SetDefaults()
        {
            Item.accessory = true;
            Item.value = 50000;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {

            if (NPC.downedMoonlord)
            {
                player.statLifeMax2 = 150;
                defboost = player.statDefense * 3f;
            }
            else
            {
                defboost = player.statDefense * 3f;
                player.statLifeMax2 = 75;
            } 
            player.statDefense += (int)defboost;
            player.GetDamage(DamageClass.Generic) += 2.5f;
            player.lifeRegen += 40000;
        }
    }
}