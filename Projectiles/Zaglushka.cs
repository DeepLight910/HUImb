using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using System;

namespace HUImb.Projectiles
{
    public class Zaglushka : ModProjectile
    {
        public override void SetDefaults()
        {
            Projectile.DamageType = DamageClass.Magic;
            Projectile.width = 1;
            Projectile.height = 1;
            Projectile.knockBack = 1f;
            Projectile.aiStyle = 0;
            Projectile.friendly = true;
            Projectile.hostile = false;
            Projectile.ignoreWater = true;
            Projectile.penetrate = 3;
            Projectile.light = 0f;
            Projectile.timeLeft = 1;
            Projectile.tileCollide = true;
            Projectile.damage = 0;
        }
        public override void AI()
        {
            Projectile.rotation = (float)Math.Atan2((double)Projectile.velocity.Y, (double)Projectile.velocity.X);
        }
    }
}