using Terraria;
using Terraria.ModLoader;

namespace HUImb.Buffs
{
    public class ArcanumBuff2 : ModBuff
    {
        public override void Update(Player player, ref int buffIndex)
        {
            player.GetDamage(DamageClass.Melee) += 0.2f;
            player.GetDamage(DamageClass.Magic) += 0.2f;
            player.GetCritChance(DamageClass.Generic) += 20;
        }
    }
}