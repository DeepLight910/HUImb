using HUImb.Items.materials;
using HUImb.Projectiles;
using HUImb.Projectiles.Magic.SunsContempt;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace HUImb.Items.weapons.Magic
{
    public class SunsContempt : ModItem
    {

        

        public override void SetDefaults()
        {
            Item.damage = 25;
            Item.DamageType = DamageClass.Magic;
            Item.noMelee = true;
            Item.width = 26;
            Item.height = 26;
            Item.useTime = 105;
            Item.useAnimation = 105;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.knockBack = 0;
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
            Vector2 poss = new Vector2(Main.MouseWorld.X, Main.MouseWorld.Y-2400f);
            Projectile.NewProjectile(source, poss, new Vector2(0f, 15f), ModContent.ProjectileType<SunsContemptProjFirst>(), damage*4, knockback);

            return true;
        }

        public override void HoldItem(Player player)
        {
            List<Vector2> poss = new List<Vector2>(){
                new Vector2(player.position.X+5f, player.position.Y-22f), new Vector2(player.position.X+7f, player.position.Y-22f), new Vector2(player.position.X+9f, player.position.Y-22f)
            };
            foreach (Vector2 pos in poss)
            {
                Dust.NewDust(pos, 1, 1, DustID.YellowStarDust);
            }
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