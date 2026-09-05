using HUImb.Buffs;
using HUImb.Tiles;
using HUImb.Items.accessories;
using HUImb.Items.Placeable;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.GameInput;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;
using static Terraria.ModLoader.ModContent;

namespace HUImb
{
    
    public class HPlayer : ModPlayer
    {
        public void Nullify(Player ply)
        {
            for (int i = 0; i < ply.buffType.Length; i++)
            {
                if(Main.debuff[ply.buffType[i]] && (ply.buffTime[i] !=0 ))
                {
                    ply.ClearBuff(i);
                }
            }
        }
        public bool hasSurvivalTest;
        public int cool;

        public override void ResetEffects()
        {
            hasSurvivalTest = false;
            cool = 0;
        }

        public override void SyncPlayer(int toWho, int fromWho, bool newPlayer)
        {
            ModPacket packet = Mod.GetPacket();
            packet.Write((byte)Player.whoAmI);
            packet.Send(toWho, fromWho);
        }

        public override void PostUpdate()
        {
            int num = 0;
            hasSurvivalTest = false;
            foreach (Item item in Player.armor)
            {
                num++;
                if (item.type == ModContent.ItemType<SurvivalTest>() && !(num == 13 || num == 14 || num == 15 || num == 16 || num == 17 || num == 18 || num == 19))
                {
                    hasSurvivalTest = true;
                    break;
                }
            }
            if (hasSurvivalTest) 
            { 
                Player.statLife = Player.statLifeMax2;
            }

            if (Player.sitting.isSitting)
            {
                int tileX = (int)(Player.Bottom.X / 16);
                int tileY = (int)(Player.Bottom.Y / 16);

                // Проверка центрального тайла под сиденьем
                Tile tile = Main.tile[tileX, tileY];
                if (tile.HasTile && tile.TileType == ModContent.TileType<ZenithToiletTile>())
                {
                    Player.noItems = true; // Блокирует использование предметов
                }
            }
            else { Player.noItems = false; }
        }

        public override bool FreeDodge(Player.HurtInfo info)
        {
            if (!Player.sitting.isSitting)
            { return false; }
            else
            {
                int tileX = (int)(Player.Bottom.X);
                int tileY = (int)(Player.Bottom.Y);

                // Проверка центрального тайла под сиденьем
                Tile tile = Main.tile[tileX, tileY];
                if (tile.HasTile && tile.TileType == ModContent.TileType<ZenithToiletTile>())
                {
                    return true;
                }
                else { return false; }
            }
        }

        public override bool CanUseItem(Item item)
        {
            if (!Player.sitting.isSitting)
            { return true; }
            else
            {
                int tileX = (int)(Player.Bottom.X);
                int tileY = (int)(Player.Bottom.Y);

                // Проверка центрального тайла под сиденьем
                Tile tile = Main.tile[tileX, tileY];
                if (tile.HasTile && tile.TileType == ModContent.TileType<ZenithToiletTile>())
                {
                    return false;
                }
                else { return true; }
            }
        }

        public override bool PreKill(double damage, int hitDirection, bool pvp, ref bool playSound, ref bool genDust, ref PlayerDeathReason damageSource)
        {
           
            int num = 0;
            hasSurvivalTest = false;
            foreach (Item item in Player.armor)
            {
                num++;
                if(item.type == ModContent.ItemType<SurvivalTest>() && !(num == 13 || num == 14 || num == 15 || num == 16 || num == 17 || num == 18 || num == 19))
                {
                    hasSurvivalTest = true; 
                    break;
                }
            }
            if (!hasSurvivalTest || Player.HasBuff<ReviveCooldown>()) return true;
            
            Player.statLife += 300;
            if (Player.statLife > Player.statLifeMax2)
            {
                Player.statLife = Player.statLifeMax2;
            }
            SoundEngine.PlaySound(SoundID.Item165, Player.Center);
            Nullify(Player);
            for (int i = 0; i < 20; i++)
            {
                Dust.NewDust(Player.Center, 0, 0, DustID.GoldCoin, Main.rand.NextFloat(-5f, 5f), Main.rand.NextFloat(-2.5f, 2.5f), 0, default, 1.6f);
                Dust.NewDust(Player.Center, 0, 0, DustID.Ice_Purple, Main.rand.NextFloat(-5f, 5f), Main.rand.NextFloat(-2.5f, 2.5f), 0, default, 1.6f);
                Dust.NewDust(Player.Center, 0, 0, DustID.IceTorch, Main.rand.NextFloat(-5f, 5f), Main.rand.NextFloat(-2.5f, 2.5f), 0, default, 1.6f);
                Dust.NewDust(Player.Center, 0, 0, DustID.Ice_Pink, Main.rand.NextFloat(-5f, 5f), Main.rand.NextFloat(-2.5f, 2.5f), 0, default, 1.6f);
                Dust.NewDust(Player.Center, 0, 0, DustID.Water_Crimson, Main.rand.NextFloat(-5f, 5f), Main.rand.NextFloat(-2.5f, 2.5f), 0, default, 1.6f);
                Dust.NewDust(Player.Center, 0, 0, DustID.Smoke, Main.rand.NextFloat(-5f, 5f), Main.rand.NextFloat(-2.5f, 2.5f), 0, Color.Red, 1.6f);
                Dust.NewDust(Player.Center, 0, 0, DustID.Ice_Purple, Main.rand.NextFloat(-5f, 5f), Main.rand.NextFloat(-2.5f, 2.5f), 0, Color.PaleVioletRed, 1.6f);
                Dust.NewDust(Player.Center, 0, 0, DustID.IceTorch, Main.rand.NextFloat(-5f, 5f), Main.rand.NextFloat(-2.5f, 2.5f), 0, Color.Violet, 1.6f);
                Dust.NewDust(Player.Center, 0, 0, DustID.Ice_Pink, Main.rand.NextFloat(-5f, 5f), Main.rand.NextFloat(-2.5f, 2.5f), 0, Color.BlueViolet, 1.6f);
                Dust.NewDust(Player.Center, 0, 0, DustID.Water_Crimson, Main.rand.NextFloat(-5f, 5f), Main.rand.NextFloat(-2.5f, 2.5f), 0, Color.Crimson, 1.6f);
            }
            for (int j = 0; j < 25; j++)
            {
                Dust.NewDustPerfect(Player.Center, DustID.PortalBolt, Vector2.One.RotatedBy(MathHelper.ToRadians(360 / 20 * j * 2)) * (j < 33 ? 2 : j > 66 ? 6 : 4));
            }
            Player.AddBuff(ModContent.BuffType<ReviveCooldown>(), (int)(3600*1.5));
            playSound = genDust = false;
            
            return false;           
        }
    }
}
