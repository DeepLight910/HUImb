using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using System;

namespace HUImb.Projectiles
{
    public class MoonLaser : ModProjectile
    {
        public override void SetDefaults()
        {
            Projectile.DamageType = DamageClass.Magic;
            Projectile.width = 33; 
            Projectile.height = 9;
            Projectile.knockBack = 1f;
            Projectile.aiStyle = 0;
            Projectile.friendly = true;
            Projectile.hostile = false;
            Projectile.ignoreWater = true;
            Projectile.penetrate = 3;
            Projectile.light = 0.5f;
            Projectile.timeLeft = 1000;
            Projectile.tileCollide = true;
            Projectile.damage = 37;
        }
        public override void AI()
        {
            Projectile.rotation = (float)Math.Atan2((double)Projectile.velocity.Y, (double)Projectile.velocity.X);
        }
    }
}