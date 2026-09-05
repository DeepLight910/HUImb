using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System;

namespace HUImb.Projectiles
{
    public class DistantStrongBullet : ModProjectile
    {
        public override void SetDefaults()
        {
            Projectile.DamageType = DamageClass.Ranged;
            Projectile.width = 28;
            Projectile.height = 20;
            Projectile.knockBack = 1f;
            Projectile.aiStyle = 0;
            Projectile.friendly = true;
            Projectile.hostile = false;
            Projectile.ignoreWater = true;
            Projectile.penetrate = -1;
            Projectile.light = 1f;
            Projectile.timeLeft = 3600;
            Projectile.tileCollide = true;
        }
        public override void AI()
        {
            Projectile.rotation = (float)Math.Atan2((double)Projectile.velocity.Y, (double)Projectile.velocity.X);
            Dust.NewDust(Projectile.Center, 1, 1, DustID.PurpleTorch, Projectile.velocity.X * 0.75f, Projectile.velocity.Y * 0.75f, 0, default, 1f);
        }
        public override void ModifyHitNPC(NPC target, ref NPC.HitModifiers modifiers)
        {
            Projectile.Resize(250, 250);
            for (int i = 0; i < 15; i++)
            {
                Dust.NewDust(Projectile.Center, 0, 0, DustID.Smoke, Main.rand.NextFloat(-7.5f, 7.5f), Main.rand.NextFloat(-5f, 5f), 0, default, 1.6f);
                Dust.NewDust(Projectile.Center, 0, 0, DustID.Smoke, Main.rand.NextFloat(-7.5f, 7.5f), Main.rand.NextFloat(-5f, 5f), 0, default, 1.6f);
                Dust.NewDust(Projectile.Center, 0, 0, DustID.Smoke, Main.rand.NextFloat(-7.5f, 7.5f), Main.rand.NextFloat(-5f, 5f), 0, default, 1.6f);
                Dust.NewDust(Projectile.Center, 0, 0, DustID.Smoke, Main.rand.NextFloat(-7.5f, 7.5f), Main.rand.NextFloat(-5f, 5f), 0, default, 1.6f);
                Dust.NewDust(Projectile.Center, 0, 0, DustID.Torch, Main.rand.NextFloat(-7.5f, 7.5f), Main.rand.NextFloat(-5f, 5f), 0, default, 1.6f);
            }
            Projectile.Kill();
        }
    }
}