using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;

namespace HUImb.Projectiles
{
    public class Ring : ModProjectile 
    {
        public override void SetDefaults()
        {
            Projectile.width = 24;
            Projectile.height = 24;

            Projectile.friendly = true;
            Projectile.light = 0.8f;
            Projectile.DamageType = DamageClass.Magic;
            Projectile.timeLeft = 10800;
        }

        public override void AI()
        {
            Projectile.rotation += MathHelper.PiOver4;

            Vector2 dustPosition = Projectile.Center + new Vector2(Main.rand.Next(-4, 5), Main.rand.Next(-4, 5));
            Dust dust = Dust.NewDustPerfect(dustPosition, DustID.BloodWater, null, 100, Color.OrangeRed, 0.8f);
            dust.velocity *= 0.3f;
            dust.noGravity = true;

            // In Multi Player (MP) This code only runs on the client of the projectile's owner, this is because it relies on mouse position, which isn't the same across all clients.
            if (Main.myPlayer == Projectile.owner && Projectile.ai[0] == 0f)
            {

                Player player = Main.player[Projectile.owner];
                // If the player channels the weapon, do something. This check only works if item.channel is true for the weapon.
                if (player.channel)
                {
                    float maxDistance = 18f; // This also sets the maximun speed the projectile can reach while following the cursor.
                    Vector2 vectorToCursor = Main.MouseWorld - Projectile.Center;
                    float distanceToCursor = vectorToCursor.Length();

                    // Here we can see that the speed of the projectile depends on the distance to the cursor.
                    if (distanceToCursor > maxDistance)
                    {
                        distanceToCursor = maxDistance / distanceToCursor;
                        vectorToCursor *= distanceToCursor;
                    }

                    int velocityXBy1000 = (int)(vectorToCursor.X * 50000f);
                    int oldVelocityXBy1000 = (int)(Projectile.velocity.X * 50000f);
                    int velocityYBy1000 = (int)(vectorToCursor.Y * 50000f);
                    int oldVelocityYBy1000 = (int)(Projectile.velocity.Y * 50000f);

                    // This code checks if the precious velocity of the projectile is different enough from its new velocity, and if it is, syncs it with the server and the other clients in MP.
                    // We previously multiplied the speed by 1000, then casted it to int, this is to reduce its precision and prevent the speed from being synced too much.
                    if (velocityXBy1000 != oldVelocityXBy1000 || velocityYBy1000 != oldVelocityYBy1000)
                    {
                        Projectile.netUpdate = true;
                    }

                    Projectile.velocity = vectorToCursor;

                }
                // If the player stops channeling, do something else.
                else if (Projectile.ai[0] == 0f)
                {

                    // This code block is very similar to the previous one, but only runs once after the player stops channeling their weapon.
                    Projectile.netUpdate = true;

                    float maxDistance = 14f; // This also sets the maximun speed the projectile can reach after it stops following the cursor.
                    Vector2 vectorToCursor = Main.MouseWorld - Projectile.Center;
                    float distanceToCursor = vectorToCursor.Length();

                    //If the projectile was at the cursor's position, set it to move in the oposite direction from the player.
                    if (distanceToCursor == 0f)
                    {
                        vectorToCursor = Projectile.Center - player.Center;
                        distanceToCursor = vectorToCursor.Length();
                    }

                    distanceToCursor = maxDistance / distanceToCursor;
                    vectorToCursor *= distanceToCursor;

                    Projectile.velocity = vectorToCursor;

                    if (Projectile.velocity == Vector2.Zero)
                    {
                        Projectile.Kill();
                    }

                    Projectile.ai[0] = 1f;
                }
            }
        }

        public override void OnKill(int timeLeft)
        {
            // If the projectile dies without hitting an enemy, crate a small explosion that hits all enemies in the area.
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
                Dust dust = Dust.NewDustDirect(Projectile.position - Projectile.velocity, Projectile.width, Projectile.height, DustID.BloodWater, 0, 0, 100, Color.OrangeRed, 0.8f);
                dust.noGravity = true;
                dust.velocity *= 2f;
                dust = Dust.NewDustDirect(Projectile.position - Projectile.velocity, Projectile.width, Projectile.height, DustID.BloodWater, 0f, 0f, 100, Color.Red, 0.5f);
            }
        }
    }
}