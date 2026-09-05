using Terraria;
using Terraria.ModLoader;

namespace HUImb.Buffs
{
    public class ReviveCooldown : ModBuff
    {
        public override void SetStaticDefaults()
        {
            Main.debuff[Type] = true;
        }
        public override void Update(Player player, ref int buffIndex)
        {
        }

        public override bool RightClick(int buffIndex)
        {
            return false;
        }
    }
}