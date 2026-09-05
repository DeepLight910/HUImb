using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using System;

namespace HUImb.Projectiles
{
    public class EyeOfAle : ModProjectile
    {

        public float Speed = 3f;
        public int frame = 20;
        public override void SetDefaults()
        {
            Projectile.DamageType = DamageClass.Magic;
            Projectile.width = 32;
            Projectile.height = 24;
            Projectile.knockBack = 1f;
            Projectile.aiStyle = 0;
            Projectile.friendly = true;
            Projectile.hostile = false;
            Projectile.ignoreWater = true;
            Projectile.penetrate = 15;
            Projectile.light = 1f;
            Projectile.timeLeft = 3600;
            Projectile.tileCollide = true;
        }
        public override void AI()
        {
            Projectile.ai[0]++;
            Dust.NewDust(Projectile.Center, 1, 1, DustID.LifeCrystal, Projectile.velocity.X * 0.35f, Projectile.velocity.Y * 0.35f, 0, default, 1f);
            Dust.NewDust(Projectile.Center, 1, 1, 24, Projectile.velocity.X * 0.35f, Projectile.velocity.Y * 0.35f, 0, default, 1f);

            float maxDetectRadius = 400f;

            NPC closestNPC = FindClosestNPC(maxDetectRadius);
            if (closestNPC != null && Projectile.ai[0] % frame == 0)
            {
                Projectile.velocity = (closestNPC.Center - Projectile.Center).SafeNormalize(Vector2.Zero) * Speed;
                if (frame > 5)
                {
                    frame -= 2;
                }
                else
                {
                    frame = 4;
                }
            }
            Projectile.velocity *= 1.015f;
            Speed *= 1.015f;

            Projectile.rotation = Projectile.velocity.ToRotation();
        }

        public NPC FindClosestNPC(float maxDetectDistance)
        {
            NPC closestNPC = null;
            float sqrMaxDetectDistance = maxDetectDistance * maxDetectDistance;
            for (int k = 0; k < Main.maxNPCs; k++)
            {
                NPC target = Main.npc[k];
                if (target.CanBeChasedBy())
                {
                    float sqrDistanceToTarget = Vector2.DistanceSquared(target.Center, Projectile.Center);

                    // Check if it is within the radius
                    if (sqrDistanceToTarget < sqrMaxDetectDistance)
                    {
                        sqrMaxDetectDistance = sqrDistanceToTarget;
                        closestNPC = target;
                    }
                }
            }

            return closestNPC;
        }
    }
}