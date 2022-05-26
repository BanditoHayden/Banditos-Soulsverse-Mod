using Terraria.ModLoader;
using Terraria.Audio;
using Terraria.DataStructures;
using SoulsMod.Buffs.MoonlightBlessing;
using Terraria;

namespace SoulsMod
{
    public class SoulsPlayer : ModPlayer
    {
        
        public override void ModifyWeaponDamage(Item item, ref StatModifier damage)
        {
            if (Player.HasBuff(ModContent.BuffType<MoonlightBlessing>()))
            {
                damage += 0.5f;
            }
        }
        public override void Kill(double damage, int hitDirection, bool pvp, PlayerDeathReason damageSource)
        {
            if (ModContent.GetInstance<Config>().SoundToggle)
            {
                SoundEngine.PlaySound(SoundLoader.GetLegacySoundSlot(Mod, "Sounds/Custom/DeathSound"));
            }
        }
    }
}
