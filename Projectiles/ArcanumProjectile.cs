using Terraria;
using Terraria.ModLoader;
using System;
using Terraria.ID;
using Microsoft.Xna.Framework;

namespace HUImb.Projectiles
{
    public class ArcanumProjectile : ModProjectile
    {
        public override void SetDefaults()
        {
            Projectile.DamageType = DamageClass.Melee;
            Projectile.width = 57;
            Projectile.height = 18;
            Projectile.aiStyle = 0;
            Projectile.friendly = true;
            Projectile.hostile = false;
            Projectile.ignoreWater = true;
            Projectile.penetrate = 5;
            Projectile.light = 1.5f;
            Projectile.tileCollide = true;
        }
        public override void AI()
        {
            Projectile.ai[0]++;
            Projectile.rotation = (float)Math.Atan2((double)Projectile.velocity.Y, (double)Projectile.velocity.X);
            float maxDetectRadius = 200f; // The maximum radius at which a projectile can detect a target
            float projSpeed = 9.5f; // The speed at which the projectile moves towards the target
            
            Dust.NewDust(Projectile.Center, 1, 1, DustID.PurpleTorch, Projectile.velocity.X * 0.35f, Projectile.velocity.Y * 0.35f, 0, default, 1f);
            // Trying to find NPC closest to the projectile
            NPC closestNPC = FindClosestNPC(maxDetectRadius);
            if (closestNPC == null)
                return;
            Projectile.velocity *= 0.98f;
            int velchange = (int)Projectile.ai[0] % 20;
            // If found, change the velocity of the projectile and turn it in the direction of the target
            // Use the SafeNormalize extension method to avoid NaNs returned by Vector2.Normalize when the vector is zero
            if (velchange == 0)
            {
                Projectile.velocity = (closestNPC.Center - Projectile.Center).SafeNormalize(Vector2.Zero) * projSpeed;
                Projectile.rotation = Projectile.velocity.ToRotation();
            }
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

        public override void Kill(int timeLeft)
        {
            for (int i = 0; i < 10; i++)
            {
                Dust.NewDust(Projectile.Center, 1, 1, DustID.PurpleTorch, Projectile.velocity.X * 0.35f, Projectile.velocity.Y * 0.35f, 0, default, 1f);
            }
        }
    }
}