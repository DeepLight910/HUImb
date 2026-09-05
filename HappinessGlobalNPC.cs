using Terraria;
using Terraria.GameContent.Personalities;
using Terraria.ID;
using Terraria.ModLoader;
using HUImb.NPCs;

namespace HUImb
{
    public class HappinessGlobalNPC : GlobalNPC
    {
        public override void SetStaticDefaults()
        {

            int Shailushai = ModContent.NPCType<Shailushai>(); // Get our Town NPC's type.
            int StarCount = ModContent.NPCType<StarCount>();

            var truffleHappiness = NPCHappiness.Get(NPCID.Truffle); // Get the Guide's happiness.
            var PartyGirlHappiness = NPCHappiness.Get(NPCID.PartyGirl); // Get the Goblin Tinkerer's happiness.
            var WitchDoctorHappiness = NPCHappiness.Get(NPCID.WitchDoctor);
            var NurseHappiness = NPCHappiness.Get(NPCID.Nurse);
            var WizardHappiness = NPCHappiness.Get(NPCID.Wizard);
            var TaxCollectorHappiness = NPCHappiness.Get(NPCID.TaxCollector);
            var CyborgHappiness = NPCHappiness.Get(NPCID.Cyborg);

            truffleHappiness.SetNPCAffection(Shailushai, AffectionLevel.Love); // Make the Guide like our Town NPC.
            PartyGirlHappiness.SetNPCAffection(Shailushai, AffectionLevel.Like); // Make the Goblin Tinkerer dislike our Town NPC.
            WitchDoctorHappiness.SetNPCAffection(Shailushai, AffectionLevel.Dislike);
            NurseHappiness.SetNPCAffection(Shailushai, AffectionLevel.Hate);
            WizardHappiness.SetNPCAffection(StarCount, AffectionLevel.Love);
            PartyGirlHappiness.SetNPCAffection(StarCount, AffectionLevel.Dislike);
            CyborgHappiness.SetNPCAffection(StarCount, AffectionLevel.Hate);
            TaxCollectorHappiness.SetNPCAffection(StarCount, AffectionLevel.Like);
            WitchDoctorHappiness.SetNPCAffection(StarCount, AffectionLevel.Like);

        }
    }
}