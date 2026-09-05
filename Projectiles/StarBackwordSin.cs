using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace HUImb.Projectiles
{
    public class StarBackwordSin : ModProjectile
    {
        private Vector2 _originalDirection;
        private float _originalSpeed;
        private float dmgBoost;

        public override void SetDefaults()
        {
            Projectile.width = 16;
            Projectile.height = 16;
            Projectile.hostile = false;
            Projectile.friendly = true;
            Projectile.penetrate = 1;
            Projectile.tileCollide = false;
            Projectile.ignoreWater = true;
            Projectile.aiStyle = 0;
            Projectile.light = 1f;
            Projectile.timeLeft = 3600;
        }

        public override void AI()
        {
            if (Projectile.ai[0] % 5f == 0)
            {
                dmgBoost = Projectile.damage * 1.01f;
                Projectile.damage = (int)dmgBoost;
            }

            
            if (Projectile.localAI[0] == 0f)
            {
                _originalSpeed = Projectile.velocity.Length();
                _originalDirection = Projectile.velocity.SafeNormalize(Vector2.UnitX);
                Projectile.localAI[0] = 1f;
            }

            
            Projectile.ai[0] += 1f;

            
            float amplitude = 10f;
            float frequency = 0.05f;

            
            float wave = (float)MathHelper.TwoPi * frequency * Projectile.ai[0];
            float displacement = (float)System.Math.Cos(wave) * amplitude;

            
            Vector2 perpendicular = new Vector2(-_originalDirection.Y, _originalDirection.X);

            
            Projectile.velocity = _originalDirection * _originalSpeed + perpendicular * displacement;

            
            Projectile.rotation = Projectile.velocity.ToRotation() + MathHelper.PiOver2;
            if (Projectile.ai[0] % 20f == 0)
            {
                Dust.NewDust(Projectile.position, 1, 1, DustID.Smoke, Main.rand.NextFloat(-5f, 6f), Main.rand.NextFloat(-5f, 6f), 0, Color.Purple, 1);
            }
        }

        public override void OnKill(int timeLeft)
        {
            for (int i = 0; i <= 5; i++)
            {
                Dust.NewDust(Projectile.position, 1, 1, DustID.Smoke, Main.rand.NextFloat(-3f, 4f), Main.rand.NextFloat(-3f, 4f), 0, Color.Purple, 1);
                Dust.NewDust(Projectile.position, 1, 1, DustID.Smoke, Main.rand.NextFloat(-3f, 4f), Main.rand.NextFloat(-3f, 4f), 0, Color.DeepPink, 1);
                Dust.NewDust(Projectile.position, 1, 1, DustID.Smoke, Main.rand.NextFloat(-3f, 4f), Main.rand.NextFloat(-3f, 4f), 0, Color.DarkViolet, 1);
            }

        }
    }
}