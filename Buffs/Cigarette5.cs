using Terraria;
using Terraria.ModLoader;

namespace HUImb.Buffs
{
    public class Cigarette5 : ModBuff
    {
        public override void Update(Player player, ref int buffIndex)
        {
            float db = 0.5f * player.statLifeMax2;
            player.statLifeMax2 -= (int)db;
            player.maxMinions += 3;
        }
    }
}