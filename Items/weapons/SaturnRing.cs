using HUImb.Projectiles;
using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;

namespace HUImb.Items.weapons
{
    public class SaturnRing : ModItem
    {
        // The Display Name and Tooltip of this item can be edited in the Localization/en-US_Mods.HUImb.hjson file.
        public override void SetDefaults()
        {
            Item.damage = 900;
            Item.DamageType = DamageClass.Magic;
            Item.noMelee = true;
            Item.width = 66;
            Item.height = 66;
            Item.useTime = 15;
            Item.useAnimation = 15;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.knockBack = 10;
            Item.channel = true;
            Item.value = Item.sellPrice(gold:75);
            Item.rare = ItemRarityID.Orange;
            Item.mana = 10;
            SoundStyle Loom = new SoundStyle($"{nameof(HUImb)}/Sounds/Ring")
            {
                Volume = 1f,
                PitchVariance = 0.5f,
            };
            Item.UseSound = Loom;
            Item.autoReuse = false;
            Item.shoot = ModContent.ProjectileType<Ring>();
            Item.shootSpeed = 10f;
        }

        public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback)
        {
            double CurrenTime = Main.time;
            double MaxTime = Main.dayTime ? Main.dayLength : Main.nightLength;
            int direction = Main.dayTime ? 1 : -1;
            float timemult = (float)Math.Sin(CurrenTime / MaxTime * Math.PI);

            timemult = 1 + timemult * direction * 0.5f;
            float boost = damage * timemult;

            damage = (int)boost;
        }

    }
}