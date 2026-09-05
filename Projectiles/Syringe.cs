using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using System;

namespace HUImb.Projectiles
{
    
    public class Syringe : ModProjectile
    {
        public bool healed;
        public override void SetDefaults()
        {
            Projectile.DamageType = DamageClass.Ranged;
            Projectile.width = 16;
            Projectile.height = 8;
            Projectile.knockBack = 1f;
            Projectile.aiStyle = 0;
            Projectile.friendly = true;
            Projectile.hostile = false;
            Projectile.ignoreWater = true;
            Projectile.penetrate = 1;
            Projectile.tileCollide = true;
        }
        public override void AI()
        {
            Projectile.ai[0]++;
            if (Projectile.ai[0] % 5 == 0)
            {
                Dust.NewDust(Projectile.position, 1, 1, DustID.Smoke, (float)Projectile.velocity.X * 0.2f, (float)Projectile.velocity.Y * 0.2f, 0, default, 1);
                Dust.NewDust(Projectile.position, 1, 1, DustID.Smoke, (float)Projectile.velocity.X * 0.2f, (float)Projectile.velocity.Y * 0.5f, 0, default, 1);
                Dust.NewDust(Projectile.position, 1, 1, DustID.Smoke, (float)Projectile.velocity.X * 0.2f, (float)Projectile.velocity.Y * -0.2f, 0, default, 1);
                Dust.NewDust(Projectile.position, 1, 1, DustID.Smoke, (float)Projectile.velocity.X * 0.2f, (float)Projectile.velocity.Y * -0.5f, 0, default, 1);
            }
            Projectile.rotation = (float)Math.Atan2((double)Projectile.velocity.Y, (double)Projectile.velocity.X);
        }

        public override void ModifyHitNPC(NPC target, ref NPC.HitModifiers modifiers)
        {
            healed = false;
            if (Main.rand.NextBool(10))
            {
                float heal = target.lifeMax * 0.03f;
                target.life += (int)heal;
                healed = true;
            }
            if (!healed)
            {
                target.AddBuff(BuffID.Poisoned, 300);
            }
        }

        public override void OnKill(int timeLeft)
        {
            for (int i = 0; i < 10; i++)
            {
                Dust.NewDust(Projectile.position, 1, 1, DustID.Smoke, Main.rand.NextFloat(-5f, 6f), Main.rand.NextFloat(-5f, 6f), 0, default, 1);
                Dust.NewDust(Projectile.position, 1, 1, DustID.LifeCrystal, Main.rand.NextFloat(-5f, 6f), Main.rand.NextFloat(-5f, 6f), 0, default, 1);
                Dust.NewDust(Projectile.position, 1, 1, DustID.RedTorch, Main.rand.NextFloat(-5f, 6f), Main.rand.NextFloat(-5f, 6f), 0, default, 1);
            }
        }
    }
}