using Terraria.ModLoader;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria;
using Terraria.ID;
using SoulsMod.Items.Weapons.Melee.Reapers;
using Terraria.GameContent.ItemDropRules;
using SoulsMod.Items.Weapons.Melee.Greatswords;
using SoulsMod.Items.Weapons.Melee.Spears;

namespace SoulsMod
{
    public class SoulsNpc : GlobalNPC
    {
        public override void SetupShop(int type, Chest shop, ref int nextSlot)
        {
           if (Main.hardMode)
            {
                if (type == NPCID.Merchant)
                {
                    shop.item[nextSlot].SetDefaults(ModContent.ItemType<CrescentSickle>());
                    nextSlot++;
                }
            }
            if (NPC.downedBoss3) // Skele
            {
                if (type == NPCID.ArmsDealer)
                {
                    shop.item[nextSlot].SetDefaults(ModContent.ItemType<RifleSpear>());
                    nextSlot++;
                }
            } 
        }
        public override void ModifyNPCLoot(NPC npc, NPCLoot npcLoot)
        {
            if (npc.type == NPCID.MeteorHead)
            {
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<StarscourgeGreatsword>(), 75));
            }
        }









    }
}
