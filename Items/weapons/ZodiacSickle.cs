using HUImb.Projectiles;
using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace HUImb.Items.weapons
{
    public class ZodiacSickle : ModItem
    {

        public override void SetDefaults()
        {
            Item.damage = 90;
            Item.DamageType = DamageClass.Melee;
            Item.noMelee = false;
            Item.width = 64;
            Item.height = 64;
            Item.useTime = 20;
            Item.useAnimation = 20;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.knockBack = 6;
            Item.value = 10000;
            Item.rare = ItemRarityID.Master;
            Item.UseSound = SoundID.Item1;
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
                Item.shoot = ModContent.ProjectileType<ZodiacSickleProj>();
                Item.DamageType = DamageClass.Melee;
                Item.mana = 75;
                Item.damage = 90;
                Item.useTime = 80;
                Item.useAnimation = 20;
                Item.shootSpeed = 30f;

            }
            else
            {
                Item.DamageType = DamageClass.Melee;
                Item.mana = 0;
                Item.shoot = ModContent.ProjectileType<Zaglushka>();
                Item.damage = 90;
                Item.useTime = 20;
                Item.useAnimation = 20;
            }
            return true;
        }

        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            double bonus = Math.Round((double)player.statManaMax2/50);
            float numberProjectiles = 6 + (float)bonus;
            float rotation = MathHelper.ToRadians(180);

            position += Vector2.Normalize(velocity) * 25f;

            for (int i = 0; i < numberProjectiles; i++)
            {
                Vector2 perturbedSpeed = velocity.RotatedBy(MathHelper.Lerp(-rotation, rotation, i / (numberProjectiles - 1))) * .2f; // Watch out for dividing by 0 if there is only 1 projectile.
                Projectile.NewProjectile(source, position, perturbedSpeed, type, damage, knockback, player.whoAmI);
            }

            return false;
        }
    }
}