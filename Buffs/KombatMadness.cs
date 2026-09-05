using Terraria;
using Terraria.ModLoader;

namespace HUImb.Buffs
{
	public class KombatMadness : ModBuff
	{
		public override void Update(Player player, ref int buffIndex)
		{
			player.GetDamage(DamageClass.Melee) += 0.1f;
        }
	}
}