using Terraria;
using Terraria.ModLoader;

namespace HUImb.Buffs
{
    public class Cigarette1 : ModBuff
    {
        public override void Update(Player player, ref int buffIndex)
        {
            float db = 0.1f*player.statLifeMax2;
            player.statLifeMax2 -= (int)db;
            player.maxMinions += 1;
        }
    }
}