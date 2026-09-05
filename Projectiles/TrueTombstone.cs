using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace HUImb.Projectiles
{
    public class TrueTombstone : ModProjectile
    {
        public override void SetDefaults()
        {
            Projectile.CloneDefaults(ProjectileID.Tombstone);
            Projectile.damage = 1;
            Projectile.penetrate = -1;
            Projectile.timeLeft = 300;
            Projectile.width = 32;
            Projectile.height = 32;
            Projectile.friendly = true;
            Projectile.hostile = false;
            AIType = ProjectileID.Tombstone;
        }
    }
}