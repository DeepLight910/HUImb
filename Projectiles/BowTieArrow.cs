using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace HUImb.Projectiles
{
    public class BowTieArrow : ModProjectile
    {
        public override void SetDefaults()
        {
            Projectile.damage = 4;
            Projectile.penetrate = -1;
            Projectile.timeLeft = 600;
            Projectile.width = 16;
            Projectile.height = 32;
            Projectile.arrow = true;
            Projectile.light = 0.5f;
            Projectile.friendly = true;
            Projectile.hostile = false;
            Projectile.tileCollide = true;
            Projectile.ignoreWater = false;
            Projectile.aiStyle = 0;
        }

        public override void AI()
        {
            Projectile.velocity = new Vector2(Projectile.velocity.X, Projectile.velocity.Y+0.05f);
            Projectile.rotation=MathHelper.ToRadians(90)+Projectile.velocity.ToRotation();
            Dust.NewDust(Projectile.Center, 1, 1, DustID.Water, Projectile.velocity.X * 0.35f, Projectile.velocity.Y * 0.35f, 0, default, 1f);
        }
    }
}