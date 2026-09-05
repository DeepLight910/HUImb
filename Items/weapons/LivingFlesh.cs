using HUImb.Projectiles;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace HUImb.Items.weapons
{
    public class LivingFlesh : ModItem
    {

        public override void SetDefaults()
        {
            Item.damage = 90;
            Item.DamageType = DamageClass.Magic;
            Item.noMelee = true;
            Item.width = 62;
            Item.height = 24;
            Item.useTime = 40;
            Item.useAnimation = 40;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.knockBack = 6;
            Item.value = 500000;
            Item.rare = ItemRarityID.Purple;
            Item.UseSound = SoundID.NPCHit13;
            Item.mana = 25;
            Item.shootSpeed = 3f;
            Item.shoot = ModContent.ProjectileType<EyeOfAle>();
            Item.autoReuse = true;
        }
    }
}