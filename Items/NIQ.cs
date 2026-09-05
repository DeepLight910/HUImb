using HUImb.Projectiles;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace HUImb.Items
{
	public class NIQ : ModItem
	{
        // The Display Name and Tooltip of this item can be edited in the Localization/en-US_Mods.HUImb.hjson file.

		public override void SetDefaults()
		{
			Item.damage = 100;
			Item.DamageType = DamageClass.Melee;
			Item.noMelee = false;
			Item.width = 40;
			Item.height = 40;
			Item.useTime = 20;
			Item.useAnimation = 20;
			Item.useStyle = ItemUseStyleID.Swing;
			Item.knockBack = 6;
			Item.value = 10000;
			Item.rare = ItemRarityID.Green;
			Item.UseSound = SoundID.Item1;
			Item.autoReuse = true;
			Item.shoot = ModContent.ProjectileType<ArcanumProjectile>();
			Item.shootSpeed = 10f;
		}
	}
}