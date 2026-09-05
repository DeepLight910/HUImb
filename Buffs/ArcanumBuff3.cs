using Terraria;
using Terraria.ModLoader;

namespace HUImb.Buffs
{
    public class ArcanumBuff3 : ModBuff
    {
        public override void Update(Player player, ref int buffIndex)
        {
            player.GetDamage(DamageClass.Melee) += 0.3f;
            player.GetDamage(DamageClass.Magic) += 0.3f;
            player.GetCritChance(DamageClass.Generic) += 50;
        }
    }
}