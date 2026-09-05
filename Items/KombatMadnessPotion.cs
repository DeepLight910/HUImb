using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace HUImb.Items
{
	public class KombatMadnessPotion : ModItem
	{
		public override void SetDefaults()
		{
			Item.width = 14;
			Item.height = 48;
			Item.useStyle = ItemUseStyleID.DrinkLiquid;
			Item.useTime = 15;
			Item.useAnimation = 15;
			Item.useTurn = true;
			Item.UseSound = SoundID.Item3;
			Item.maxStack = 1;
			Item.consumable = true;
			Item.rare = ItemRarityID.Cyan;
			Item.value = 5300;
			Item.potion = false;
			Item.buffType = ModContent.BuffType<Buffs.KombatMadness>();
			Item.buffTime = 27000;
		}
	}
}
