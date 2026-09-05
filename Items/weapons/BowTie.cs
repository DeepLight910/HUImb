using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using HUImb.Projectiles;

namespace HUImb.Items.weapons
{
    public class BowTie : ModItem
    {
        // The Display Name and Tooltip of this item can be edited in the Localization/en-US_Mods.HUImb.hjson file.

        public override void SetDefaults()
        {
            Item.damage = 15;
            Item.DamageType = DamageClass.Ranged;
            Item.noMelee = true;
            Item.width = 17;
            Item.height = 32;
            Item.useTime = 15;
            Item.useAnimation = 15;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.knockBack = 1;
            Item.value = 15000;
            Item.rare = ItemRarityID.LightPurple;
            Item.UseSound = SoundID.Item5;
            Item.autoReuse = true;
            Item.shootSpeed = 10f;
            Item.shoot = ModContent.ProjectileType<BowTieArrow>();
        }
    }
}