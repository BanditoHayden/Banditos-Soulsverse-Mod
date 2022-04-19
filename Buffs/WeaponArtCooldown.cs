using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System.Threading.Tasks;

namespace SoulsMod.Buffs
{
    public class WeaponArtCooldown : ModBuff
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Weapon Art Cooldown");
            Description.SetDefault("Prevents the player from using a weapon art");
            Main.buffNoTimeDisplay[Type] = false;
            Main.debuff[Type] = true;
        }

    }
}
