using HUImb.Projectiles;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace HUImb.Items.weapons
{
    public class DistantStrike : ModItem
    {

        public override void SetDefaults()
        {
            Item.damage = 512;
            Item.DamageType = DamageClass.Ranged;
            Item.noMelee = true;
            Item.width = 62;
            Item.height = 24;
            Item.useTime = 30;
            Item.useAnimation = 30;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.knockBack = 6;
            Item.value = 2500000;
            Item.rare = ItemRarityID.Purple;
            Item.UseSound = SoundID.Item11;
            Item.shootSpeed = 40;
            Item.autoReuse = true;
        }
        public override bool AltFunctionUse(Player player)
        {
            return true;
        }
        public override bool CanUseItem(Player player)
        {
            if (player.altFunctionUse == 2)
            {
                Item.shoot = ModContent.ProjectileType<DistantFastBullet>();

            }
            else
            {
                Item.shoot = ModContent.ProjectileType<DistantStrongBullet>();
            }
            return true;
        }
    }
}