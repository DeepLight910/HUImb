using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace HUImb.Projectiles
{
    public class TrueHeadstone : ModProjectile
    {
        public override void SetDefaults()
        {
            Projectile.CloneDefaults(ProjectileID.Headstone);
            Projectile.damage = 250;
            Projectile.penetrate = -1;
            Projectile.timeLeft = 300;
            Projectile.height = 32;
            Projectile.width = 28;
            Projectile.friendly = true;
            Projectile.hostile = false;
            AIType = ProjectileID.Headstone;
        }
    }
}