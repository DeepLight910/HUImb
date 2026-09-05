using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace HUImb.Projectiles
{
    public class Nugget : ModProjectile
    {

        public float boost=0f;

        public override void SetDefaults()
        {
            Projectile.DamageType = DamageClass.Melee;
            Projectile.width = 16;
            Projectile.height = 22;
            Projectile.knockBack = 1f;
            Projectile.aiStyle = 0;
            Projectile.friendly = true;
            Projectile.hostile = false;
            Projectile.ignoreWater = true;
            Projectile.penetrate = 1;
            Projectile.light = 0.5f;
            Projectile.timeLeft = 3600;
            Projectile.tileCollide = true;
        }

        public override void AI()
        {
            Projectile.ai[0]++;
            if (Projectile.ai[0] % 10 == 0)
            {
                Dust.NewDust(Projectile.position, 1, 1, DustID.Smoke, Projectile.velocity.X, Projectile.velocity.Y, 1, Colors.RarityAmber, 1);
            }
            Projectile.rotation += 0.75f;
            Player player = Main.player[Projectile.owner];;
            if (Projectile.ai[0] < 60)
            {
                Projectile.velocity *= 0.95f;
            }
            else if (Projectile.ai[0] == 60) 
            {
                Projectile.velocity *= -1f;
            }
            else if (Projectile.ai[0]>60) 
            {
                Projectile.velocity *= 1.05f;
                if (boost == 0f) { boost = Projectile.damage; }
                boost *= 1.01875f;
                Projectile.damage = (int)boost;
            }
            else if (Projectile.ai[0] >= 180)
            {
                Projectile.Kill();
            }
        }

        public override void OnKill(int timeLeft)
        {
            for (int i = 0; i < 10; i++)
            {
                float speedX = (float)Math.Pow(-1, i)*0.2f;
                Dust.NewDust(Projectile.position, 1, 1, DustID.Smoke, speedX, 0.2f, 1, Colors.RarityAmber, 1);
            }
        }
    }
}