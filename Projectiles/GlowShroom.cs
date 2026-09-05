using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using System;
using Terraria.Audio;

namespace HUImb.Projectiles
{
    public class GlowShroom : ModProjectile
    {
        public override void SetDefaults()
        {
            Projectile.DamageType = DamageClass.Magic;
            Projectile.width = 33;
            Projectile.height = 9;
            Projectile.knockBack = 1f;
            Projectile.aiStyle = 0;
            Projectile.friendly = true;
            Projectile.hostile = false;
            Projectile.ignoreWater = true;
            Projectile.penetrate = 1;
            Projectile.light = 1.5f;
            Projectile.timeLeft = 1000;
            Projectile.tileCollide = true;
            Projectile.damage = 19;
        }
        public override void AI()
        {

            Projectile.rotation += (0.35f * (float)Projectile.direction);
            float maxDetectRadius = 250f; // The maximum radius at which a projectile can detect a target
            float projSpeed = 15f; // The speed at which the projectile moves towards the target

            // Trying to find NPC closest to the projectile
            NPC closestNPC = FindClosestNPC(maxDetectRadius);
            if (closestNPC == null)
                return;

            // If found, change the velocity of the projectile and turn it in the direction of the target
            // Use the SafeNormalize extension method to avoid NaNs returned by Vector2.Normalize when the vector is zero
            Projectile.velocity = (closestNPC.Center - Projectile.Center).SafeNormalize(Vector2.Zero) * projSpeed;
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