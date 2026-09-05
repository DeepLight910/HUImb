using HUImb.Projectiles;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace HUImb.Items
{
    public class MoonWand : ModItem
    {
        // The Display Name and Tooltip of this item can be edited in the Localization/en-US_Mods.HUImb.hjson file.
        public override void SetDefaults()
        {
            Item.damage = 300;
            Item.DamageType = DamageClass.Magic;
            Item.noMelee = true;
            Item.width = 66;
            Item.height = 66;
            Item.useTime = 11;
            Item.useAnimation = 11;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.knockBack = 1;
            Item.value = 3000000;
            Item.rare = ItemRarityID.Pink;
            Item.mana = 7;
            Item.UseSound = SoundID.Item43;
            Item.autoReuse = true;
            Item.shoot = ModContent.ProjectileType<MoonLaser>();
            Item.shootSpeed = 60f;
        }
        public override void OnHitNPC(Player player, NPC target, NPC.HitInfo hit, int damageDone)
        {
            target.AddBuff(BuffID.Ichor, 1800);
            target.AddBuff(BuffID.ShadowFlame, 1800);
        }
    }
}