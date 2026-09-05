using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ModLoader;

namespace HUImb.Projectiles.Magic.SunsContempt
{
    public class SunsContemptProjFirst : ModProjectile
    {
        private int n = 0;

        public Vector2 poss = Vector2.Zero;
        private Vector2 fiveteenF = new Vector2(0f, 15f);
        private Vector2 cen = new Vector2(2f, 0f);

        public int shouldBeSlowed = 0;
        public override void SetDefaults()
        {
            Projectile.penetrate = -1;
            Projectile.timeLeft = 600;
            Projectile.width = 5;
            Projectile.height = 10;
            Projectile.light = 1f;
            Projectile.friendly = true;
            Projectile.hostile = false;
            Projectile.tileCollide = false;
            Projectile.ignoreWater = true;
            Projectile.aiStyle = 0;
        }

        public override void AI()
        {
            if (Projectile.velocity != fiveteenF*4 && shouldBeSlowed == 0) { Projectile.velocity = fiveteenF*4; }
            if(Projectile.timeLeft >= 600 - 120 || (n < ((1920+400)/15)) ) { Projectile.tileCollide = false; } else {  Projectile.tileCollide = true; }

            if (Projectile.localAI[0] == 0)
            {
                poss = Projectile.position+cen;

                Projectile.localAI[0]++;
            }

            float h = (float)Math.Abs((Projectile.position + cen).Length() - poss.Length());

            if (h > 15f)
            {
                poss += fiveteenF;
                SpawnProj();
            }
        }

        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            if (poss.Length() > Projectile.position.Length() + cen.Length())
            {
                Projectile.Kill();
                return false;
            }
            if (poss.Length() > 3000f) {
                shouldBeSlowed = 1;
                Projectile.velocity = fiveteenF;
            }
            return false;
        }

        private void SpawnProj()
        {
            if (Projectile.owner == Main.myPlayer)
            {
                n++;
                Projectile.NewProjectile(Projectile.GetSource_FromAI(), poss, Vector2.Zero, ModContent.ProjectileType<SunsContemptProjLaser>(), Projectile.damage/4, 0f, Projectile.owner);
            }
        }
    }
}