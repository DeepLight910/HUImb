using HUImb.Projectiles;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace HUImb.Items
{
    public class OldNail : ModItem
    {

        public override void SetDefaults()
        {
            Item.damage = 35;
            Item.DamageType = DamageClass.Melee;
            Item.noMelee = false;
            Item.width = 40;
            Item.height = 40;
            Item.useTime = 20;
            Item.useAnimation = 20;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.knockBack = 6;
            Item.value = 20000;
            Item.rare = ItemRarityID.Green;
            Item.UseSound = SoundID.Item1;
            Item.autoReuse = true;
        }
        public override bool AltFunctionUse(Player player)
        {
            return true;
        }
        public override bool CanUseItem(Player player)
        {
            if (player.altFunctionUse == 2)
            {
                Item.damage = 70;
                Item.useTime = 40;
                Item.shootSpeed = 30f;
                Item.shoot = ModContent.ProjectileType<VengefulSpirit>();
            }
            else 
            {
                Item.shoot = ModContent.ProjectileType<Zaglushka>();
                Item.damage = 35;
                Item.useTime = 20;
            }
            return true;
        }
    }
}