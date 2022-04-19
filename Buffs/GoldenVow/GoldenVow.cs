using Terraria;
using Terraria.ModLoader;

namespace SoulsMod.Buffs.GoldenVow
{
    public class GoldenVow : ModBuff
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Golden Vow");
            Description.SetDefault("Grants +10 defense\n+20% Damage");
        }

        public override void Update(Player player, ref int buffIndex)
        {
            player.statDefense += 10;
            player.GetDamage(DamageClass.Generic) += 0.2f;

        }
    }
}