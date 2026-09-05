using Terraria;
using Terraria.ModLoader;

namespace HUImb.Buffs
{
    public class Cigarette3 : ModBuff
    {
        public override void Update(Player player, ref int buffIndex)
        {
            float db = 0.3f * player.statLifeMax2;
            player.statLifeMax2 -= (int)db;
            player.maxMinions += 2;
        }
    }
}