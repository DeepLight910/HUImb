using Terraria;
using Terraria.ModLoader;

namespace HUImb.Buffs
{
    public class Cigarette2 : ModBuff
    {
        public override void Update(Player player, ref int buffIndex)
        {
            float db = 0.2f * player.statLifeMax2;
            player.statLifeMax2 -= (int)db;
            player.maxMinions += 1;
        }
    }
}