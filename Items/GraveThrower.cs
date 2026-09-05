using HUImb.Projectiles;
using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace HUImb.Items
{
    public class GraveThrower : ModItem
    {
        // The Display Name and Tooltip of this item can be edited in the Localization/en-US_Mods.HUImb.hjson file.

        public override void SetDefaults()
        {
            Item.damage = 3000;
            Item.DamageType = DamageClass.Ranged;
            Item.noMelee = true;
            Item.width = 48;
            Item.height = 15;
            Item.useTime = 65;
            Item.useAnimation = 65;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.knockBack = 14;
            Item.value = 2300000;
            Item.rare = ItemRarityID.Lime;
            SoundStyle bazookashoots = new SoundStyle($"{nameof(HUImb)}/Sounds/bazookashoot")
            {
                Volume = 0.75f,
                PitchVariance = 0.5f,
            };
            Item.UseSound = bazookashoots;
            Item.autoReuse = true;
            Item.shootSpeed = 25f;
            Item.shoot = ProjectileID.PurificationPowder;
        }

        public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback)
        {
            float wt = Main.rand.Next(1, 6);
            if (wt == 1)
            {
                type = ModContent.ProjectileType<TrueTombstone>();
            }
            if (wt == 2)
            {
                type = ModContent.ProjectileType<TrueObelisk>();
                Item.damage = 3750;
            }
            if (wt == 3)
            {
                type = ModContent.ProjectileType<TrueGravestone>();
                Item.damage = 2850;
            }
            if (wt == 4)
            {
                type = ModContent.ProjectileType<TrueGraveMarker>();
                Item.damage = 2500;
            }
            if (wt == 5)
            {
                type = ModContent.ProjectileType<TrueCrossGraveMarker>();
                Item.damage = 2500;
            }
            if (wt == 6)
            {
                type = ModContent.ProjectileType<TrueHeadstone>();
                Item.damage = 3250;
            }
        }

        public override void OnHitNPC(Player player, NPC target, NPC.HitInfo hit, int damageDone)
        {
            if (Type == ModContent.ProjectileType<TrueGravestone>())
            {
                target.AddBuff(BuffID.Poisoned, 360);
            }
            if (Type == ModContent.ProjectileType<TrueGraveMarker>())
            {
                target.AddBuff(BuffID.CursedInferno, 360);
            }
            if (Type == ModContent.ProjectileType<TrueHeadstone>())
            {
                target.AddBuff(BuffID.BrokenArmor, 360);
            }
        }
    }
}