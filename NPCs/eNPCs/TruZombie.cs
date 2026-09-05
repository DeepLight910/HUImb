using HUImb.Items;
using HUImb.Items.materials;
using Microsoft.Xna.Framework;
using System;
using System.IO;
using Terraria;
using Terraria.GameContent.Bestiary;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;
using Terraria.ModLoader.Utilities;

namespace HUImb.NPCs.eNPCs 
{
    public class TruZombie : ModNPC 
    {
        
        public int StolenItems = 0;
        public override void SetDefaults() 
        {
            NPC.width = 18;
            NPC.height = 40;
            NPC.damage = 78;
            NPC.defense = 56;
            NPC.lifeMax = 500;
            NPC.HitSound = SoundID.NPCHit1;
            NPC.DeathSound = SoundID.NPCDeath2;
            NPC.value = 1f;
            NPC.knockBackResist = 0.5f;
            NPC.aiStyle = 3; // Fighter AI, important to choose the aiStyle that matches the NPCID that we want to mimic

            Main.npcFrameCount[Type] = Main.npcFrameCount[NPCID.Zombie];

            AIType = NPCID.Zombie; // Use vanilla zombie's type when executing AI code. (This also means it will try to despawn during daytime)
            AnimationType = NPCID.Zombie; // Use vanilla zombie's type when executing animation code. Important to also match Main.npcFrameCount[NPC.type] in SetStaticDefaults.
            Banner = Item.NPCtoBanner(NPCID.Zombie); // Makes this NPC get affected by the normal zombie banner.
            BannerItem = Item.BannerToItem(Banner);
        }
        public override void SetBestiary(BestiaryDatabase database, BestiaryEntry bestiaryEntry)
        {
            bestiaryEntry.Info.AddRange(new IBestiaryInfoElement[]
                {
                    BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Times.NightTime,
                    new FlavorTextBestiaryInfoElement("Mods.HUImb.NPCs.TruZombie.Bestiary")
                }
            );
        }

        public override void AI()
        {
            if (Main.netMode == NetmodeID.MultiplayerClient) {
                return;
            }

            Rectangle Hitbox = NPC.Hitbox;
            foreach (Item item in Main.item) 
            {
                if (item.active && !item.beingGrabbed && (item.type == ItemID.SilverCoin || item.type == ItemID.CopperCoin || item.type == ItemID.GoldCoin || item.type == ItemID.PlatinumCoin) && Hitbox.Intersects(item.Hitbox)) 
                {
                    item.active = false;
                    StolenItems += item.stack;

                    NetMessage.SendData(MessageID.SyncItem, -1, -1, null, item.whoAmI);
                }
            }
        }

        public override void SendExtraAI(BinaryWriter writer)
        {
            writer.Write(StolenItems);
        }

        public override void ReceiveExtraAI(BinaryReader reader)
        {
            StolenItems = reader.ReadInt32();
        }

        public override void OnKill()
        {
            if (Main.netMode == NetmodeID.MultiplayerClient) {  return; }

            if (StolenItems >= 100) {
                StolenItems = 0;
                Item.NewItem(NPC.GetSource_Death(), NPC.Center, ModContent.ItemType<Dollar>(), 1);
            }
        }

        public override bool NeedSaving()
        {
            return StolenItems>=10;
        }

        public override void SaveData(TagCompound tag)
        {
            if (StolenItems > 0)
            {
                // Note that at this point it may have less than 10 stolen items, if another mod or part of our decides to save the NPC
                tag["StolenItems"] = StolenItems;
            }
        }

        public override void LoadData(TagCompound tag)
        {
            StolenItems = tag.GetInt("StolenItems");
        }

        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
            if (!NPC.AnyNPCs(Type) && NPC.downedMechBossAny) 
            {
                return SpawnCondition.OverworldNightMonster.Chance * 0.6f;
            }
            return 0f;
        }
    }
}
