using Terraria;
using Terraria.GameContent.Personalities;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using Terraria.ModLoader;
using HUImb.NPCs;
using HUImb.Items.materials;
using System;
using HUImb.Items.weapons;

namespace HUImb
{
    public class DropsGlobalNPC : GlobalNPC
    {

        public override void ModifyNPCLoot(NPC npc, NPCLoot npcLoot)
        {

            if (npc.type == NPCID.Harpy){npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Egg>(), 2, 1, 5));}
            if (npc.type == NPCID.WallofFlesh) {npcLoot.Add(ItemDropRule.BossBag(ModContent.ItemType<LivingFlesh>()));}
            if (npc.type == NPCID.QueenSlimeBoss) {npcLoot.Add(ItemDropRule.BossBag(ModContent.ItemType<Stargazer>()));}
        }

        public override void ModifyGlobalLoot(GlobalLoot globalLoot)
        {
            globalLoot.Add(ItemDropRule.ByCondition(, ModContent.ItemType<Lighting>(), 5, 1, 5));
        }
    }
}