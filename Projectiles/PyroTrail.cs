using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace HUImb.Projectiles
{
    public class PyroTrail : ModProjectile
    {
        public override void SetDefaults()
        {
            Projectile.DamageType = DamageClass.Melee;
            Projectile.width = 28;
            Projectile.height = 20;
            Projectile.knockBack = 1f;
            Projectile.aiStyle = 0;
            Projectile.friendly = true;
            Projectile.hostile = false;
            Projectile.ignoreWater = true;
            Projectile.penetrate = -1;
            Projectile.light = 1f;
            Projectile.timeLeft = 300;
            Projectile.tileCollide = false;
        }
        public override void AI()
        {
            Projectile.ai[0]++;
            Projectile.rotation +=0.4f;
            if (Projectile.ai[0] % 15 == 0)
            {
                Dust.NewDust(Projectile.Center, 1, 1, DustID.OrangeTorch, Projectile.velocity.X * 0.75f, Projectile.velocity.Y * 0.75f, 0, default, 1f);
            }
        }
        public override void ModifyHitNPC(NPC target, ref NPC.HitModifiers modifiers)
        {
            target.AddBuff(BuffID.Burning, 60 * 3);
        }

        public override void OnKill(int timeLeft)
        {
            for (int i = 0; i < 5; i++)
            {
                Dust.NewDust(Projectile.Center, 1, 1, DustID.OrangeTorch, Main.rand.NextFloat(-5, 5f), Main.rand.NextFloat(-5, 5f));
            }
        }
    }
}