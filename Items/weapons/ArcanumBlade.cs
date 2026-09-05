using HUImb.Buffs;
using HUImb.Projectiles;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace HUImb.Items.weapons
{
    public class ArcanumBlade : ModItem
    {
        // The Display Name and Tooltip of this item can be edited in the Localization/en-US_Mods.HUImb.hjson file.

        public override void SetDefaults()
        {
            Item.damage = 30;
            Item.DamageType = DamageClass.Melee;
            Item.noMelee = false;
            Item.width = 44;
            Item.height = 44;
            Item.useTime = 20;
            Item.useAnimation = 20;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.knockBack = 6;
            Item.value = 10000;
            Item.rare = ItemRarityID.Green;
            Item.UseSound = SoundID.Item1;
            Item.autoReuse = true;
            Item.shoot = ModContent.ProjectileType<ArcanumProjectile>();
            Item.shootSpeed = 10f;
        }
        public override bool AltFunctionUse(Player player)
        {
            return true;
        }
        public override bool CanUseItem(Player player)
        {
            if (player.altFunctionUse == 2)
            {
                Item.useStyle = ItemUseStyleID.HoldUp;
                if(player.statManaMax2 >= 200)
                {
                    player.AddBuff(ModContent.BuffType<ArcanumBuff3>(), (int)(3600*10));
                }
                if (player.statManaMax2 < 200 && player.statManaMax2 >=100)
                {
                    player.AddBuff(ModContent.BuffType<ArcanumBuff2>(), (int)(3600 * 10));
                }
                if (player.statManaMax2 < 100)
                {
                    player.AddBuff(ModContent.BuffType<ArcanumBuff1>(), (int)(3600 * 10));
                }
            }
            else
            {
                Item.useStyle = ItemUseStyleID.Swing;
            }
            return true;
        }
    }
}