using System.Runtime.InteropServices;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using System.Linq;
using System;

namespace HUImb.Items.Potions.Ultimate
{

    public class UltimateInfinityPotion : ModItem
    {
        public int dur = 60*60*16;
        public int i = 0;
        public string texture;

        public int[] CombatBuffs = [BuffID.Ironskin, BuffID.Titan, BuffID.ObsidianSkin, BuffID.SugarRush,BuffID.Swiftness, BuffID.Wrath, BuffID.Rage, BuffID.Lifeforce, BuffID.Endurance, BuffID.Heartreach, BuffID.Thorns, BuffID.NightOwl, BuffID.Regeneration];
        public int[] PeacefulBuffs = [BuffID.Invisibility, BuffID.Dangersense, BuffID.ObsidianSkin, BuffID.SugarRush, BuffID.Swiftness, BuffID.NightOwl, BuffID.Shine, BuffID.Calm];
        public int[] AppliedBuffs = [];


        public override void SetDefaults()
        {
            Item.width = 16;
            Item.height = 32;
            Item.useStyle = ItemUseStyleID.DrinkLiquid;
            Item.useTime = 15;
            Item.useAnimation = 15;
            Item.useTurn = true;
            Item.UseSound = SoundID.Item3;
            Item.maxStack = 1;
            Item.consumable = false;
            Item.rare = ItemRarityID.Purple;
            Item.buffType = BuffID.Ironskin;
            Item.value = 0;
            Item.potion = false;
        }

        public override bool AltFunctionUse(Player player)
        {
            return true;
        }

        public override bool CanUseItem(Player player)
        {
            if (player.altFunctionUse == 2)
            {
                if (i > 7)
                {
                    i = 0;
                }
                else
                {
                    i++;
                }
                
                Main.NewText(Language.GetTextValue($"Mods.HUImb.Items.UltimateInfinityPotion.Tl{i}"));
                return false;
            }
            else
            {
                return true;
            };
        }


        public override bool? UseItem(Player player)
        {
            ClearAllAppliedBufs(player);

            switch (i)
            {
                case 0:
                    ApplyBuffs(player, dur, CombatBuffs,[BuffID.Tipsy, BuffID.Inferno]);
                    break;
                case 1:
                    ApplyBuffs(player, dur, CombatBuffs, [BuffID.Archery, BuffID.AmmoReservation]);
                    break;
                case 2:
                    ApplyBuffs(player, dur, CombatBuffs, [BuffID.ManaRegeneration, BuffID.MagicPower]);
                    break;
                case 3:
                    ApplyBuffs(player, dur, CombatBuffs, [BuffID.Summoning]);
                    break;
                case 4:
                    ApplyBuffs(player, dur, PeacefulBuffs, [BuffID.Sonar, BuffID.Crate]);
                    break; 
                case 5:
                    ApplyBuffs(player, dur, PeacefulBuffs, [BuffID.Builder]);
                    break;
                case 6:
                    ApplyBuffs(player, dur, PeacefulBuffs, [BuffID.Spelunker, BuffID.Mining]);
                    break;
                case 7:
                    ApplyBuffs(player, dur, PeacefulBuffs, [BuffID.BiomeSight]);
                    break;
            }


            return true;
        }

        public void ApplyBuffs(Player ply, int duration, int[] Buffs, [Optional] int[] AdditionalBuffs)
        {

            List<int> allBuffs = new List<int>(Buffs); // Создаём список из базовых баффов

            if (AdditionalBuffs != null)
            {
                allBuffs.AddRange(AdditionalBuffs); // Добавляем дополнительные баффы в список
            }

            // Накладываем все баффы из списка
            foreach (int buff in allBuffs)
            {
                ply.AddBuff(buff, duration);
            }

            // Сохраняем применённые баффы как массив
            AppliedBuffs = allBuffs.ToArray();
        }

        public void ClearAllAppliedBufs(Player ply, [Optional] int[] buffs)
        {
            List<int> allBuffsToClear = new List<int>();

            // Собираем все баффы из разных источников
            allBuffsToClear.AddRange(CombatBuffs);
            allBuffsToClear.AddRange(PeacefulBuffs);

            if (AppliedBuffs != null)
            {
                allBuffsToClear.AddRange(AppliedBuffs);
            }

            if (buffs != null)
            {
                allBuffsToClear.AddRange(buffs);
            }

            // Удаляем все собранные баффы
            foreach (int buff in allBuffsToClear.Distinct()) // Используем Distinct() для избежания дубликатов
            {
                ply.ClearBuff(buff);
            }

            AppliedBuffs = Array.Empty<int>(); // Сбрасываем AppliedBuffs
        }

    }
}