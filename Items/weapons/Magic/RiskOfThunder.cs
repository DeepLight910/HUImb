using HUImb.Items.materials;
using HUImb.Projectiles;
using HUImb.Projectiles.Magic.SunsContempt;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace HUImb.Items.weapons.Magic
{
    public class RiskOfThunder : ModItem
    {



        public override void SetDefaults()
        {
            Item.damage = 34;
            Item.DamageType = DamageClass.Magic;
            Item.noMelee = true;
            Item.width = 26;
            Item.height = 26;
            Item.useTime = 105;
            Item.useAnimation = 105;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.knockBack = 10f;
            Item.value = Item.buyPrice(gold: 2, silver: 56);
            Item.rare = ItemRarityID.Green;
            Item.UseSound = SoundID.Item8;
            Item.shoot = ModContent.ProjectileType<Zaglushka>();
            Item.shootSpeed = 15f;
            Item.mana = 15;
            Item.autoReuse = false;
            Item.mana = 50;
        }

        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            Vector2 poss = new Vector2(Main.MouseWorld.X, Main.MouseWorld.Y - 2400f);
            Projectile.NewProjectile(source, poss, Vector2.Zero, ModContent.ProjectileType<SunsContemptProjFirst>(), damage * 2, knockback);

            return true;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.Star, 5)
                .AddIngredient(ItemID.Cloud, 40)
                .AddIngredient(ModContent.ItemType<ZodiacStar>())
                .AddIngredient(ItemID.MeteoriteBar, 3)
                .Register();
        }
    }
}