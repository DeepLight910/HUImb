using HUImb.Projectiles;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace HUImb.Items.weapons
{
    public class Stargazer : ModItem
    {

        private SoundStyle Shootsound = new SoundStyle($"{nameof(HUImb)}/Sounds/Shit11") {Volume = 1f};

        public override void SetDefaults()
        {
            Item.damage = 80;
            Item.DamageType = DamageClass.Magic;
            Item.noMelee = true;
            Item.width = 78;
            Item.height = 32;
            Item.useTime = 10;
            Item.useAnimation = 10;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.knockBack = 6;
            Item.value = Item.buyPrice(gold: 78, silver: 56);
            Item.rare = ItemRarityID.Cyan;
            Item.UseSound = Shootsound;
            Item.mana = 15;
            Item.shootSpeed = 10f;
            Item.shoot = ModContent.ProjectileType<StarSin>();
            Item.autoReuse = true;
        }

        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            Projectile.NewProjectile(source, position, velocity, ModContent.ProjectileType<StarBackwordSin>(), damage, knockback);

            return true;
        }
    }
}