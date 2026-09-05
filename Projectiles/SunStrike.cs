using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using System;

namespace HUImb.Projectiles
{
    public class SunStrike : ModProjectile
    {
        public override void SetDefaults()
        {
            Projectile.DamageType = DamageClass.Ranged;
            Projectile.width = 90;
            Projectile.height = 17;
            Projectile.knockBack = 1f;
            Projectile.aiStyle = 0;
            Projectile.friendly = true;
            Projectile.hostile = false;
            Projectile.ignoreWater = true;
            Projectile.penetrate = 3;
            Projectile.light = 1f;
            Projectile.timeLeft = 1000;
            Projectile.tileCollide = true;
        }
        public override void AI()
        {
            Projectile.ai[0]++;
            if (Projectile.ai[0] < 30) 
            {
                Projectile.velocity *= 1.03f;
            }
            else
            {
                Projectile.velocity *= 1.06f;
                if (Projectile.ai[0] >= 180)
                {
                    Projectile.Kill();
                }
            }
            Projectile.rotation = (float)Math.Atan2((double)Projectile.velocity.Y, (double)Projectile.velocity.X);

            Dust dust = Dust.NewDustDirect(Projectile.Left, Projectile.width, Projectile.height, DustID.RedTorch, 0, 0, 100, Color.DarkRed, 0.8f);
            Dust dust1 = Dust.NewDustDirect(Projectile.Center, Projectile.width, Projectile.height, DustID.Firework_Yellow,  0, 0, 100, Color.White, 0.8f);
            Dust dust2 = Dust.NewDustDirect(Projectile.Right, Projectile.width, Projectile.height, DustID.FireworkFountain_Yellow, 0, 0, 100, Color.Purple, 0.8f);

            dust.noGravity = true;
            dust.velocity *= 0.3f;

            dust1.noGravity = true;
            dust1.velocity *= 0.3f;

            dust2.noGravity = true;
            dust2.velocity *= 0.3f;
        }
    }
}