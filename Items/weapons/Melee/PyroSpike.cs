using HUImb.Projectiles;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace HUImb.Items.weapons.Melee
{
    public class PyroSpike : ModItem
    {
        // The Display Name and Tooltip of this item can be edited in the Localization/en-US_Mods.HUImb.hjson file.

        public override void SetDefaults()
        {
            Item.damage = 400;
            Item.DamageType = DamageClass.Throwing;
            Item.noMelee = false;
            Item.width = 52;
            Item.height = 52;
            Item.useTime = 20;
            Item.useAnimation = 20;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.knockBack = 6f;
            Item.value = Item.buyPrice(platinum:1, gold: 25, silver: 78);
            Item.rare = ItemRarityID.Red;
            Item.UseSound = SoundID.Item1;
            Item.autoReuse = true;
            Item.shoot = ModContent.ProjectileType<PyroSpikeProj>();
            Item.shootSpeed = 10f;
            Item.noUseGraphic = true;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.GolemFist)
                .AddIngredient(ItemID.Boulder, 2)
                .AddIngredient(ItemID.Spike, 30)
                .AddIngredient(ItemID.InfernoPotion, 5)
                .AddIngredient(ItemID.WarmthPotion, 5)
                .Register();
        }
    }
}