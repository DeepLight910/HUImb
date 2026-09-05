using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria.Audio;

namespace HUImb.Projectiles
{
    public class PyroSpikeProj : ModProjectile
    {
        public override void SetDefaults()
        {
            Projectile.DamageType = DamageClass.Melee;
            Projectile.width = 52;
            Projectile.height = 52;
            Projectile.knockBack = 1f;
            Projectile.aiStyle = 0;
            Projectile.friendly = true;
            Projectile.hostile = false;
            Projectile.ignoreWater = true;
            Projectile.penetrate = -1;
            Projectile.light = 2f;
            Projectile.timeLeft = 3600;
            Projectile.tileCollide = true;
        }

        public override void AI()
        {
            Projectile.rotation += 0.4f;
            Projectile.ai[0]++;
            if (Projectile.ai[1] == 0)
            {
                Projectile.velocity = new Vector2(Projectile.velocity.X, Projectile.velocity.Y + 0.04f);
            }
            else
            {
                Projectile.velocity = new Vector2(Projectile.velocity.X * 0.94f, Projectile.velocity.Y + 0.01f);
                Vector2 speed = new Vector2(0.4f, 0.4f);
                Vector2 _speed = new Vector2(-0.4f, 0.4f);
                if (Projectile.ai[0] % 3 == 0)
                {
                    Projectile.NewProjectile(Projectile.GetSource_FromAI(), Projectile.Center, speed, ModContent.ProjectileType<PyroTrail>(), 80, 2f, Projectile.owner);
                    Projectile.NewProjectile(Projectile.GetSource_FromAI(), Projectile.Center, _speed, ModContent.ProjectileType<PyroTrail>(), 80, 2f, Projectile.owner);
                }

            }
            if (Projectile.ai[0] % 15 == 0)
            {
                Dust.NewDust(Projectile.Center, 1, 1, DustID.Torch, Projectile.velocity.X * 0.2f, Projectile.velocity.Y * 0.2f);
                Dust.NewDust(Projectile.Center, 1, 1, DustID.RedTorch, Projectile.velocity.X * 0.2f, Projectile.velocity.Y * 0.2f);
                Projectile.ai[0] = 0;
            }

        }

        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {
            Projectile.ai[1] = 1;
            target.AddBuff(BuffID.Burning, 60 * 3);
        }

        public override void OnKill(int timeLeft)
        {
            SoundEngine.PlaySound(SoundID.Dig, Projectile.position);
            for (int i = 0; i < 10; i++)
            {
                if (i % 2 == 0)
                {
                    Dust.NewDust(Projectile.position, 1, 1, DustID.Smoke, Main.rand.NextFloat(-5f, 5f), Main.rand.NextFloat(-5f, 5f), Scale: 2.5f);
                }
                Dust.NewDust(Projectile.position, 1, 1, DustID.Torch, Main.rand.NextFloat(-5f, 5f), Main.rand.NextFloat(-5f, 5f));
                Dust.NewDust(Projectile.position, 1, 1, DustID.RedTorch, Main.rand.NextFloat(-5f, 5f), Main.rand.NextFloat(-5f, 5f));
            }
        }

        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            if ((Projectile.ai[1] == 0 && !(oldVelocity.Y <= 1f && oldVelocity.Y >=-1f)) || Projectile.timeLeft >= 60*58)
            {
                Projectile.velocity = new Vector2(oldVelocity.X, oldVelocity.Y*(-0.75f));
                return false;
            }
            else
            {
                Projectile.Kill();
                return true;
            }
        }
    }
}