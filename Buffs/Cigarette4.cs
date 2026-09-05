using Terraria;
using Terraria.ModLoader;

namespace HUImb.Buffs
{
    public class Cigarette4 : ModBuff
    {
        public override void Update(Player player, ref int buffIndex)
        {
            float db = 0.4f * player.statLifeMax2;
            player.statLifeMax2 -= (int)db;
            player.maxMinions += 2;
        }
    }
}