using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.GameContent.Personalities;
using Terraria.Localization;
using Terraria.GameContent.Bestiary;
using Terraria.Chat;
using Terraria.Audio;
using Terraria.Utilities;
using HUImb.Items;
using HUImb.Items.materials;

namespace HUImb.NPCs
{
    [AutoloadHead]
    public class StarCount : ModNPC
    {
        public override void SetDefaults()
        {
            NPC.townNPC = true;
            NPC.width = 24;
            NPC.height = 40;
            NPC.friendly = true;
            NPC.aiStyle = 7;
            NPC.lifeMax = 512;
            NPC.defense = 32;
            NPC.knockBackResist = 2.5f;
            NPC.HitSound = SoundID.NPCHit1;
            NPC.DeathSound = SoundID.NPCDeath1;
            Main.npcFrameCount[NPC.type] = 23;
            NPCID.Sets.ExtraFramesCount[NPC.type] = 0;
            NPCID.Sets.AttackFrameCount[NPC.type] = 1;
            NPCID.Sets.DangerDetectRange[NPC.type] = 650;
            NPCID.Sets.AttackType[NPC.type] = 0;
            NPCID.Sets.AttackTime[NPC.type] = 25;
            NPCID.Sets.AttackAverageChance[NPC.type] = 10;
            AnimationType = NPCID.Wizard;
            NPC.Happiness
                .SetBiomeAffection<UndergroundBiome>(AffectionLevel.Hate)
                .SetBiomeAffection<CrimsonBiome>(AffectionLevel.Dislike)
                .SetBiomeAffection<CorruptionBiome>(AffectionLevel.Dislike)
                .SetBiomeAffection<SnowBiome>(AffectionLevel.Like)
                .SetBiomeAffection<HallowBiome>(AffectionLevel.Love)
                .SetNPCAffection(NPCID.Wizard, AffectionLevel.Love)
                .SetNPCAffection(NPCID.PartyGirl, AffectionLevel.Dislike)
                .SetNPCAffection(NPCID.WitchDoctor, AffectionLevel.Like)
                .SetNPCAffection(NPCID.TaxCollector, AffectionLevel.Like)
                .SetNPCAffection(NPCID.Cyborg, AffectionLevel.Hate);
        }

        public override bool CanTownNPCSpawn(int numTownNPCs)
        {
            for (int i = 0; i < 255; i++)
            {
                Player player = Main.player[i];
                foreach (Item item in player.inventory)
                {
                    if (item.type == ModContent.ItemType<ZodiacStar>())
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        public override List<string> SetNPCNameList()
        {
            return new List<string>
            {
                Language.GetTextValue("Mods.HUImb.NPCs.StarCount.Names.Name0"),
                Language.GetTextValue("Mods.HUImb.NPCs.StarCount.Names.Name1"),
                Language.GetTextValue("Mods.HUImb.NPCs.StarCount.Names.Name2"),
                Language.GetTextValue("Mods.HUImb.NPCs.StarCount.Names.Name3"),
                Language.GetTextValue("Mods.HUImb.NPCs.StarCount.Names.Name4"),
                Language.GetTextValue("Mods.HUImb.NPCs.StarCount.Names.Name5"),
                Language.GetTextValue("Mods.HUImb.NPCs.StarCount.Names.Name6"),
                Language.GetTextValue("Mods.HUImb.NPCs.StarCount.Names.Name7"),
                Language.GetTextValue("Mods.HUImb.NPCs.StarCount.Names.Name8"),
                Language.GetTextValue("Mods.HUImb.NPCs.StarCount.Names.Name9"),
                Language.GetTextValue("Mods.HUImb.NPCs.StarCount.Names.Name10"),
                Language.GetTextValue("Mods.HUImb.NPCs.StarCount.Names.Name11"),
                Language.GetTextValue("Mods.HUImb.NPCs.StarCount.Names.Name12"),
                Language.GetTextValue("Mods.HUImb.NPCs.StarCount.Names.Name13"),
                Language.GetTextValue("Mods.HUImb.NPCs.StarCount.Names.Name14"),
                Language.GetTextValue("Mods.HUImb.NPCs.StarCount.Names.Name15"),
                Language.GetTextValue("Mods.HUImb.NPCs.StarCount.Names.Name16"),
                Language.GetTextValue("Mods.HUImb.NPCs.StarCount.Names.Name17"),
                Language.GetTextValue("Mods.HUImb.NPCs.StarCount.Names.Name18"),
                Language.GetTextValue("Mods.HUImb.NPCs.StarCount.Names.Name19"),
            };
        }
        public override void SetChatButtons(ref string button, ref string button2)
        {
            if (Main.LocalPlayer.HasItem(ModContent.ItemType<NIQ>())) { button = Language.GetTextValue("Mods.HUImb.NPCs.StarCount.Buttons.QuestButton"); }
            else
            {
                button = Language.GetTextValue("LegacyInterface.28");
            }
            button2 = Language.GetTextValue("Mods.HUImb.NPCs.StarCount.Buttons.Button2");
        }
        public override void OnChatButtonClicked(bool firstButton, ref string shopName)
        {
            if (firstButton)
            {
                if (Main.LocalPlayer.HasItem(ModContent.ItemType<NIQ>()))
                {
                    Main.npcChatText = Language.GetTextValue("Mods.HUImb.NPCs.Shailushai.QuestFrases.MenuFrase");
                    int niger = Main.LocalPlayer.FindItem(ModContent.ItemType<QuestItemMef>());
                    var entitySource = NPC.GetSource_GiftOrReward();
                    Main.LocalPlayer.inventory[niger].TurnToAir();
                    Main.LocalPlayer.QuickSpawnItem(entitySource, ModContent.ItemType<SwordShroomBonk>());
                    ChatHelper.BroadcastChatMessage(NetworkText.From(Language.GetTextValue("Mods.HUImb.NPCs.Shailushai.QuestFrases.ChatFrase")), color: Color.Cyan);
                    ChatHelper.BroadcastChatMessage(NetworkText.From(Language.GetTextValue("Mods.HUImb.NPCs.Shailushai.QuestFrases.ChatFrase2")), color: Color.Cyan);
                    ChatHelper.BroadcastChatMessage(NetworkText.From(Language.GetTextValue("Mods.HUImb.NPCs.Shailushai.QuestFrases.ChatFrase3")), color: Color.Cyan);
                }
                else
                {
                    shopName = "Shop";
                }
            }
            if (!firstButton)
            {
                WeightedRandom<string> random = new();
                random.Add(Language.GetTextValue("Mods.HUImb.NPCs.StarCount.Space.Space0"));
                random.Add(Language.GetTextValue("Mods.HUImb.NPCs.StarCount.Space.Space1"));
                random.Add(Language.GetTextValue("Mods.HUImb.NPCs.StarCount.Space.Space2"));
                random.Add(Language.GetTextValue("Mods.HUImb.NPCs.StarCount.Space.Space3"));
                random.Add(Language.GetTextValue("Mods.HUImb.NPCs.StarCount.Space.Space4"));
                random.Add(Language.GetTextValue("Mods.HUImb.NPCs.StarCount.Space.Space5"));
                random.Add(Language.GetTextValue("Mods.HUImb.NPCs.StarCount.Space.Space6"));
                Main.npcChatText = random;
            }
        }
        public override void AddShops()
        {
            var shop = new NPCShop(Type, "Shop");
            shop.Add(new Item(ItemID.Meteorite) { shopCustomPrice = 4 });
            shop.Add(new Item(ItemID.FallenStar) { shopCustomPrice = 1488 });
            shop.Add(new Item(ModContent.ItemType<Vengera>()) { shopCustomPrice = 50000 });
            shop.Add(new Item(ModContent.ItemType<StrangeNote>()) { shopCustomPrice = 1000000 });
            shop.Add(new Item(ModContent.ItemType<ZodiacStar>()) { shopCustomPrice = 75000 }, condition: Condition.DownedCultist);
            shop.Add(new Item(ItemID.Sextant) { shopCustomPrice = 75000 });
            shop.Register();
        }
        public override void TownNPCAttackStrength(ref int damage, ref float knockback)
        {
            damage = 10;
            knockback = 4f;
        }
        public override void TownNPCAttackCooldown(ref int cooldown, ref int randExtraCooldown)
        {
            cooldown = 15;
            randExtraCooldown = 15;
        }
        public override void TownNPCAttackProj(ref int projType, ref int attackDelay)
        {
            projType = ProjectileID.Meteor1;
            attackDelay = 10;
        }
        public override void TownNPCAttackProjSpeed(ref float multiplier, ref float gravityCorrection, ref float randomOffset)
        {
            multiplier = 10f;
            gravityCorrection = 0f;
            randomOffset = 1f;
        }
        public override void SetBestiary(BestiaryDatabase database, BestiaryEntry bestiaryEntry)
        {
            bestiaryEntry.Info.AddRange(new IBestiaryInfoElement[]
                {
                    BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.TheHallow,
                    new FlavorTextBestiaryInfoElement("Mods.HUImb.NPCs.StarCount.Bestiary")
                }
            );
        }
        public override bool UsesPartyHat()
        {
            return false;
        }
        public override string GetChat()
        {
            WeightedRandom<string> chat = new();
            chat.Add(Language.GetTextValue("Mods.HUImb.NPCs.StarCount.Dialogue.dialogd"));
            chat.Add(Language.GetTextValue("Mods.HUImb.NPCs.StarCount.Dialogue.dialog0"));
            chat.Add(Language.GetTextValue("Mods.HUImb.NPCs.StarCount.Dialogue.dialog1"));
            chat.Add(Language.GetTextValue("Mods.HUImb.NPCs.StarCount.Dialogue.dialog2"));
            chat.Add(Language.GetTextValue("Mods.HUImb.NPCs.StarCount.Dialogue.dialog3"));
            chat.Add(Language.GetTextValue("Mods.HUImb.NPCs.StarCount.Dialogue.dialog4"));
            chat.Add(Language.GetTextValue("Mods.HUImb.NPCs.StarCount.Dialogue.dialog5"));
            chat.Add(Language.GetTextValue("Mods.HUImb.NPCs.StarCount.Dialogue.dialog6"));
            chat.Add(Language.GetTextValue("Mods.HUImb.NPCs.StarCount.Dialogue.dialog7"));
            chat.Add(Language.GetTextValue("Mods.HUImb.NPCs.StarCount.Dialogue.dialog8"));
            return chat;
        }
        public override bool CanGoToStatue(bool toKingStatue)
        {
            return toKingStatue;
        }
        public override void HitEffect(NPC.HitInfo hit)
        {
            if (Main.netMode != NetmodeID.Server && NPC.life <= 0)
            {
                Gore.NewGore(NPC.GetSource_Death(), NPC.position, NPC.velocity, Main.rand.Next(61, 64), 1.5f);
            }
        }
    }
}