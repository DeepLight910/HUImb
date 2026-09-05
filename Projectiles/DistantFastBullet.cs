using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System;

namespace HUImb.Projectiles
{
    public class DistantFastBullet : ModProjectile
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
            Projectile.penetrate = 1;
            Projectile.light = 1f;
            Projectile.timeLeft = 3600;
            Projectile.tileCollide = true;
        }
        public override void AI()
        {
            Projectile.rotation = (float)Math.Atan2((double)Projectile.velocity.Y, (double)Projectile.velocity.X);
            Dust.NewDust(Projectile.Center, 1, 1, DustID.WhiteTorch, Projectile.velocity.X*0.75f, Projectile.velocity.Y*0.75f, 0, default, 1f);
            Projectile.velocity *= 1.02f;
        }
        public override void ModifyHitNPC(NPC target, ref NPC.HitModifiers modifiers)
        {
            target.AddBuff(BuffID.BrokenArmor, 300);
            target.AddBuff(BuffID.Ichor, 300);
        }
    }
}