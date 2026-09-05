using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using System;
using Terraria.Audio;

namespace HUImb.Projectiles
{
    public class ZodiacSickleProj : ModProjectile
    {
        public float rot = 1f;
        public override void SetDefaults()
        {
            Projectile.DamageType = DamageClass.Magic;
            Projectile.width = 36;
            Projectile.height = 36;
            Projectile.knockBack = 1f;
            Projectile.aiStyle = 0;
            Projectile.friendly = true;
            Projectile.hostile = false;
            Projectile.ignoreWater = true;
            Projectile.penetrate = 1;
            Projectile.light = 1f;
            Projectile.timeLeft = 1000;
            Projectile.tileCollide = true;
        }
        public override void AI()
        {
            Projectile.ai[0]++;

            float maxDetectRadius = 450f; // The maximum radius at which a projectile can detect a target
            float projSpeed = 10f; // The speed at which the projectile moves towards the target

            Dust dust = Dust.NewDustDirect(Projectile.Top, Projectile.width, Projectile.height, DustID.PurpleCrystalShard, 0, 0, 100, Color.Purple, 0.8f);
            Dust dust1 = Dust.NewDustDirect(Projectile.Center, Projectile.width, Projectile.height, DustID.Shadowflame, 0, 0, 100, Color.Purple, 0.8f);
            Dust dust2 = Dust.NewDustDirect(Projectile.Bottom, Projectile.width, Projectile.height, DustID.VenomStaff, 0, 0, 100, Color.Purple, 0.8f);

            dust.noGravity = true;
            dust.velocity *= 0.3f;

            dust1.noGravity = true;
            dust1.velocity *= 0.3f;

            dust2.noGravity = true;
            dust2.velocity *= 0.3f;

            // Trying to find NPC closest to the projectile
            NPC closestNPC = FindClosestNPC(maxDetectRadius);
            if (closestNPC == null)
            {
                if (Projectile.ai[0] < 60)
                {
                    Projectile.velocity *= 0.98f;
                    rot *= 0.98f;
                }
                else
                {
                    Projectile.velocity *= 0.96f;
                    rot *= 0.96f;
                    if (Projectile.ai[0] >= 120)
                    {
                        Projectile.Kill();
                    }
                }



                Projectile.rotation += rot;


                return;
            }
            if (rot < 0.5f)
            {
                rot *= 1.03f;
            }
            Projectile.rotation += rot;
            // If found, change the velocity of the projectile and turn it in the direction of the target
            // Use the SafeNormalize extension method to avoid NaNs returned by Vector2.Normalize when the vector is zero
            Projectile.velocity = (closestNPC.Center - Projectile.Center).SafeNormalize(Vector2.Zero) * projSpeed;

            
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

        public override void OnKill(int timeLeft)
        {

            if (Projectile.penetrate == 1)
            {
                // Makes the projectile hit all enemies as it circunvents the penetrate limit.
                Projectile.maxPenetrate = -1;
                Projectile.penetrate = -1;

                int explosionArea = 60;
                Vector2 oldSize = Projectile.Size;
                // Resize the projectile hitbox to be bigger.
                Projectile.position = Projectile.Center;
                Projectile.Size += new Vector2(explosionArea);
                Projectile.Center = Projectile.position;

                Projectile.tileCollide = false;
                Projectile.velocity *= 0.01f;
                // Damage enemies inside the hitbox area
                Projectile.Damage();
                Projectile.scale = 0.01f;

                //Resize the hitbox to its original size
                Projectile.position = Projectile.Center;
                Projectile.Size = new Vector2(10);
                Projectile.Center = Projectile.position;
            }

            SoundEngine.PlaySound(SoundID.Item10, Projectile.position);
            for (int i = 0; i < 10; i++)
            {
                Dust dust = Dust.NewDustDirect(Projectile.position - Projectile.velocity, Projectile.width, Projectile.height, DustID.MartianHit, 0, 0, 100, Color.Purple, 0.8f);
                dust.noGravity = true;
                dust.velocity *= 2f;
                dust = Dust.NewDustDirect(Projectile.position - Projectile.velocity, Projectile.width, Projectile.height, DustID.Grubby, 0f, 0f, 100, Color.Pink, 0.5f);
            }
        }

    }
}