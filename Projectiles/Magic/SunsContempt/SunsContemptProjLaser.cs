using Terraria;
using Terraria.ModLoader;

namespace HUImb.Projectiles.Magic.SunsContempt
{
    public class SunsContemptProjLaser : ModProjectile
    {
        public override void SetDefaults()
        {
            Projectile.penetrate = -1;
            Projectile.timeLeft = 60*5;
            Projectile.width = 30;
            Projectile.height = 15;
            Projectile.light = 0.6f;
            Projectile.friendly = true;
            Projectile.hostile = false;
            Projectile.tileCollide = false;
            Projectile.ignoreWater = true;
            Projectile.aiStyle = 0;
        }
    }
}