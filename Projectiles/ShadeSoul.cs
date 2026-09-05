using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using System;

namespace HUImb.Projectiles
{
    public class ShadeSoul : ModProjectile
    {
        public override void SetDefaults()
        {
            Projectile.DamageType = DamageClass.Melee;
            Projectile.width = 111;
            Projectile.height = 31;
            Projectile.knockBack = 1f;
            Projectile.aiStyle = 0;
            Projectile.friendly = true;
            Projectile.hostile = false;
            Projectile.ignoreWater = true;
            Projectile.penetrate = -1;
            Projectile.light = 1f;
            Projectile.timeLeft = 1000;
            Projectile.tileCollide = true;
            Projectile.damage = 90;
        }
        public override void AI()
        {
            Projectile.rotation = (float)Math.Atan2((double)Projectile.velocity.Y, (double)Projectile.velocity.X);
        }
    }
}