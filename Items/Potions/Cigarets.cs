using HUImb.Buffs;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace HUImb.Items.Potions
{

    public class Cigarets : ModItem
    {
        public override void SetDefaults()
        {
            Item.width = 21;
            Item.height = 42;
            Item.useStyle = ItemUseStyleID.DrinkLong;
            Item.useTime = 25;
            Item.useAnimation = 25;
            Item.useTurn = true;
            SoundStyle sound = new SoundStyle($"{nameof(HUImb)}/Sounds/Cigarette")
            {
                Volume = 4f,
                PitchVariance = 1f,
            };
            Item.UseSound = sound;
            Item.maxStack = 1;
            Item.consumable = false;
            Item.rare = ItemRarityID.Gray;
            Item.value = 2700;
            Item.potion = false;
        }

        public override bool? UseItem(Player player)
        {
            if (player.HasBuff<Cigarette5>())
            {
                player.statLife = 1;
            }
            else if (player.HasBuff<Cigarette4>())
            {
                player.ClearBuff(ModContent.BuffType<Cigarette4>());
                player.AddBuff(ModContent.BuffType<Cigarette5>(), 27000);
            }
            else if (player.HasBuff<Cigarette3>())
            {
                player.ClearBuff(ModContent.BuffType<Cigarette3>());
                player.AddBuff(ModContent.BuffType<Cigarette4>(), 27000);
            }
            else if (player.HasBuff<Cigarette2>())
            {
                player.ClearBuff(ModContent.BuffType<Cigarette2>());
                player.AddBuff(ModContent.BuffType<Cigarette3>(), 27000);
            }
            else if (player.HasBuff<Cigarette1>())
            {
                player.ClearBuff(ModContent.BuffType<Cigarette1>());
                player.AddBuff(ModContent.BuffType<Cigarette2>(), 27000);
            }
            else
            {
                player.AddBuff(ModContent.BuffType<Cigarette1>(), 27000);
            }
            return true;
        }
    }
}