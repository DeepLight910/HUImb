using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using HUImb.Projectiles;

namespace HUImb.Items.weapons
{
    public class SyringeGun : ModItem
    {
        // The Display Name and Tooltip of this item can be edited in the Localization/en-US_Mods.HUImb.hjson file.

        public override void SetDefaults()
        {
            Item.damage = 15;
            Item.DamageType = DamageClass.Ranged;
            Item.noMelee = true;
            Item.width = 46;
            Item.height = 27;
            Item.useTime = 7;
            Item.useAnimation = 7;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.knockBack = 1;
            Item.value = 150000;
            Item.rare = ItemRarityID.White;
            Item.UseSound = SoundID.Item7;
            Item.autoReuse = true;
            Item.shootSpeed = 35f;
            Item.shoot = ModContent.ProjectileType<Syringe>();
        }


    }
}