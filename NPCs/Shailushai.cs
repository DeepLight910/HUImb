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

namespace HUImb.NPCs
{
    [AutoloadHead]
    public class Shailushai : ModNPC
    {
        public override void SetDefaults()
        {
            NPC.townNPC = true;
            NPC.width = 24; 
            NPC.height = 40;
            NPC.friendly = true;
            NPC.aiStyle = 7;
            NPC.lifeMax = Main.rand.Next(5678, 7857);
            NPC.defense = Main.rand.Next(56, 79);
            NPC.knockBackResist = 0.78f;
            SoundStyle Narezka = new SoundStyle($"{nameof(HUImb)}/Sounds/Narezka")
            {
                Volume = 1.25f,
                PitchVariance = 0.5f,
            };
            NPC.HitSound = Narezka;
            NPC.DeathSound = SoundID.NPCDeath1;
            Main.npcFrameCount[NPC.type] = 25;
            NPCID.Sets.ExtraFramesCount[NPC.type] = 0;
            NPCID.Sets.AttackFrameCount[NPC.type] = 1;
            NPCID.Sets.DangerDetectRange[NPC.type] = 650;
            NPCID.Sets.AttackType[NPC.type] = 0;
            NPCID.Sets.AttackTime[NPC.type] = 25;
            NPCID.Sets.AttackAverageChance[NPC.type] = 10;
            AnimationType = 22;
            NPC.Happiness
                .SetBiomeAffection<UndergroundBiome>(AffectionLevel.Hate)
                .SetBiomeAffection<DesertBiome>(AffectionLevel.Dislike)
                .SetBiomeAffection<ForestBiome>(AffectionLevel.Like)
                .SetBiomeAffection<MushroomBiome>(AffectionLevel.Love)
                .SetNPCAffection(NPCID.Truffle, AffectionLevel.Love)
                .SetNPCAffection(NPCID.PartyGirl, AffectionLevel.Like)
                .SetNPCAffection(NPCID.WitchDoctor, AffectionLevel.Dislike)
                .SetNPCAffection(NPCID.Nurse, AffectionLevel.Hate);
        }

        public override bool CanTownNPCSpawn(int numTownNPCs)
        {
            for (int i = 0; i < 255; i++)
            {
                Player player = Main.player[i];
                foreach(Item item in player.inventory)
                {
                    if(item.type == ItemID.GlowingMushroom)
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
                Language.GetTextValue("Mods.HUImb.NPCs.Shailushai.Names.Name0"),
                Language.GetTextValue("Mods.HUImb.NPCs.Shailushai.Names.Name1"),
                Language.GetTextValue("Mods.HUImb.NPCs.Shailushai.Names.Name2"),
                Language.GetTextValue("Mods.HUImb.NPCs.Shailushai.Names.Name3"),
                Language.GetTextValue("Mods.HUImb.NPCs.Shailushai.Names.Name4"),
                Language.GetTextValue("Mods.HUImb.NPCs.Shailushai.Names.Name5"),
                Language.GetTextValue("Mods.HUImb.NPCs.Shailushai.Names.Name6"),
                Language.GetTextValue("Mods.HUImb.NPCs.Shailushai.Names.Name7"),
                Language.GetTextValue("Mods.HUImb.NPCs.Shailushai.Names.Name8"),
                Language.GetTextValue("Mods.HUImb.NPCs.Shailushai.Names.Name9"),
                Language.GetTextValue("Mods.HUImb.NPCs.Shailushai.Names.Name10"),
                Language.GetTextValue("Mods.HUImb.NPCs.Shailushai.Names.Name11"),
                Language.GetTextValue("Mods.HUImb.NPCs.Shailushai.Names.Name12"),
                Language.GetTextValue("Mods.HUImb.NPCs.Shailushai.Names.Name13"),
                Language.GetTextValue("Mods.HUImb.NPCs.Shailushai.Names.Name14"),
                Language.GetTextValue("Mods.HUImb.NPCs.Shailushai.Names.Name15"),
                Language.GetTextValue("Mods.HUImb.NPCs.Shailushai.Names.Name16"),
                Language.GetTextValue("Mods.HUImb.NPCs.Shailushai.Names.Name17"),
                Language.GetTextValue("Mods.HUImb.NPCs.Shailushai.Names.Name18"),
                Language.GetTextValue("Mods.HUImb.NPCs.Shailushai.Names.Name19"),
            };
        }
        public override void SetChatButtons(ref string button, ref string button2)
        {
            if (Main.LocalPlayer.HasItem(ModContent.ItemType<QuestItemMef>())) { button = Language.GetTextValue("Mods.HUImb.NPCs.Shailushai.Buttons.QuestButton"); }
            else
            {
                button = Language.GetTextValue("LegacyInterface.28");
            }
            button2 = Language.GetTextValue("Mods.HUImb.NPCs.Shailushai.Buttons.Button2");
        }
        public override void OnChatButtonClicked(bool firstButton, ref string shopName)
        {
            if (firstButton)
            {
                if (Main.LocalPlayer.HasItem(ModContent.ItemType<QuestItemMef>()))
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
                random.Add(Language.GetTextValue("Mods.HUImb.NPCs.Shailushai.Anekdots.Anekdot0"));
                random.Add(Language.GetTextValue("Mods.HUImb.NPCs.Shailushai.Anekdots.Anekdot1"));
                random.Add(Language.GetTextValue("Mods.HUImb.NPCs.Shailushai.Anekdots.Anekdot2"));
                random.Add(Language.GetTextValue("Mods.HUImb.NPCs.Shailushai.Anekdots.Anekdot3"));
                random.Add(Language.GetTextValue("Mods.HUImb.NPCs.Shailushai.Anekdots.Anekdot4"));
                random.Add(Language.GetTextValue("Mods.HUImb.NPCs.Shailushai.Anekdots.Anekdot5"));
                random.Add(Language.GetTextValue("Mods.HUImb.NPCs.Shailushai.Anekdots.Anekdot6"));
                random.Add(Language.GetTextValue("Mods.HUImb.NPCs.Shailushai.Anekdots.Anekdot7"));
                random.Add(Language.GetTextValue("Mods.HUImb.NPCs.Shailushai.Anekdots.Anekdot8"));
                random.Add(Language.GetTextValue("Mods.HUImb.NPCs.Shailushai.Anekdots.Anekdot9"));
                random.Add(Language.GetTextValue("Mods.HUImb.NPCs.Shailushai.Anekdots.Anekdot10"));
                random.Add(Language.GetTextValue("Mods.HUImb.NPCs.Shailushai.Anekdots.Anekdot11"));
                random.Add(Language.GetTextValue("Mods.HUImb.NPCs.Shailushai.Anekdots.Anekdot12"));
                random.Add(Language.GetTextValue("Mods.HUImb.NPCs.Shailushai.Anekdots.Anekdot13"));
                Main.npcChatText = random;
            }
        }
        public override void AddShops()
        {
            var shop = new NPCShop(Type, "Shop");
			shop.Add(new Item(ItemID.PoopBlock) {shopCustomPrice = 56000000});
            shop.Add(new Item(ItemID.GlowingMushroom) { shopCustomPrice = 4});
            shop.Add(new Item(ItemID.Mushroom) { shopCustomPrice = 1});
            shop.Add(new Item(ItemID.Gel) { shopCustomPrice = 2 });
            shop.Add(new Item(ItemID.Daybloom) { shopCustomPrice = 50});
            shop.Add(new Item(ItemID.Moonglow) { shopCustomPrice = 50});
            shop.Add(new Item(ItemID.Blinkroot) { shopCustomPrice = 50 });
            shop.Add(new Item(ItemID.Deathweed) { shopCustomPrice = 50 });
            shop.Add(new Item(ItemID.Waterleaf) { shopCustomPrice = 50 });
            shop.Add(new Item(ItemID.Fireblossom) { shopCustomPrice = 50 });
            shop.Add(new Item(ItemID.Shiverthorn) { shopCustomPrice = 50 });
            shop.Add(new Item(ItemID.Apple) { shopCustomPrice = 12 });
            shop.Add(new Item(ItemID.BloodOrange) { shopCustomPrice = 12 });
            shop.Add(new Item(ItemID.Banana) { shopCustomPrice = 12 });
            shop.Add(new Item(ItemID.Peach) { shopCustomPrice = 12 });
            shop.Add(new Item(ItemID.SharkFin) { shopCustomPrice = 150 });
			shop.Add(new Item(ItemID.JojaCola) { shopCustomPrice = 150 });
            shop.Add(new Item(ItemID.MilkCarton) { shopCustomPrice = 500 });
            shop.Add(new Item(ItemID.SpicyPepper) { shopCustomPrice = 12 });
			shop.Add(new Item(ItemID.Pomegranate) { shopCustomPrice = 12 });
			shop.Add(new Item(ItemID.MonsterLasagna) { shopCustomPrice = 56000 });
            if (ModLoader.TryGetMod("CalamityMod", out Mod Calamity))
            {
                if (Calamity.TryFind<ModItem>("BloodOrb", out ModItem orb)) { shop.Add(new Item(orb.Type){ shopCustomPrice = 2500}, condition: Condition.Hardmode); }
            }
            shop.Add(new Item(ItemID.HeartStatue) { shopCustomPrice = Item.buyPrice(gold: 15) }, condition: Condition.DownedGolem);
            shop.Add(new Item(ItemID.StarStatue) { shopCustomPrice = Item.buyPrice(gold:15) }, condition: Condition.DownedGolem);
            shop.Add(new Item(ItemID.PixieDust) { shopCustomPrice = 7 }, condition: Condition.DownedQueenSlime);
            shop.Add(new Item(ItemID.LifeFruit) { shopCustomPrice = 750 }, condition: Condition.DownedPlantera);
			shop.Add(new Item(ItemID.MasterBait){shopCustomPrice = 5000});
			shop.Add(new Item(ItemID.JourneymanBait){shopCustomPrice = 2500});
			shop.Add(new Item(ItemID.ApprenticeBait){shopCustomPrice = 1000});
			shop.Add(new Item(ItemID.DirtiestBlock){shopCustomPrice = 78000000});
            shop.Register();
        }
        public override void TownNPCAttackStrength(ref int damage, ref float knockback)
        {
            damage = 200;
            knockback = 4f;
        }
        public override void TownNPCAttackCooldown(ref int cooldown, ref int randExtraCooldown)
        {
            cooldown = 15;
            randExtraCooldown = 15;
        }
        public override void TownNPCAttackProj(ref int projType, ref int attackDelay)
        {
            projType = ProjectileID.Mushroom;
            attackDelay = 10;
        }
        public override void TownNPCAttackProjSpeed(ref float multiplier, ref float gravityCorrection, ref float randomOffset)
        {
            multiplier = 75f;
            gravityCorrection = 0f;
            randomOffset = 1f;
        }
        public override void SetBestiary(BestiaryDatabase database, BestiaryEntry bestiaryEntry)
        {
            bestiaryEntry.Info.AddRange(new IBestiaryInfoElement[]
                {
                    BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.SurfaceMushroom,
                    new FlavorTextBestiaryInfoElement("Mods.HUImb.NPCs.Shailushai.Bestiary")
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
            chat.Add(Language.GetTextValue("Mods.HUImb.NPCs.Shailushai.Dialogue.dialogd"));
            chat.Add(Language.GetTextValue("Mods.HUImb.NPCs.Shailushai.Dialogue.dialog0"));
            chat.Add(Language.GetTextValue("Mods.HUImb.NPCs.Shailushai.Dialogue.dialog1"));
            chat.Add(Language.GetTextValue("Mods.HUImb.NPCs.Shailushai.Dialogue.dialog2"));
            chat.Add(Language.GetTextValue("Mods.HUImb.NPCs.Shailushai.Dialogue.dialog3"));
            chat.Add(Language.GetTextValue("Mods.HUImb.NPCs.Shailushai.Dialogue.dialog4"));
            chat.Add(Language.GetTextValue("Mods.HUImb.NPCs.Shailushai.Dialogue.dialog5"));
            chat.Add(Language.GetTextValue("Mods.HUImb.NPCs.Shailushai.Dialogue.dialog6"));
            chat.Add(Language.GetTextValue("Mods.HUImb.NPCs.Shailushai.Dialogue.dialog7"));
            chat.Add(Language.GetTextValue("Mods.HUImb.NPCs.Shailushai.Dialogue.dialog8"));
            return chat;
        }
        public override bool CanGoToStatue(bool toKingStatue)
        {
            return true;    
        }
        public override void HitEffect(NPC.HitInfo hit)
        {
            if(Main.netMode != NetmodeID.Server && NPC.life <=0) 
            {
                Gore.NewGore(NPC.GetSource_Death(), NPC.position, NPC.velocity, Main.rand.Next(61, 64), 1.5f);
            }
        }
    }
}