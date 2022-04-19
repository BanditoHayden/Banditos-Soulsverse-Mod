   
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;
using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using SoulsMod.Buffs;
namespace SoulsMod.Items.Accessories
{


    public class cheatacc : ModItem
    {

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Cheat Accessory");
            Tooltip.SetDefault("Weapon art cooldown immunity");
        }
        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {

            foreach (TooltipLine line2 in tooltips)
            {
                if (line2.mod == "Terraria" && line2.Name == "ItemName")
                {
                    line2.overrideColor = new Color(Main.DiscoR = 124, Main.DiscoG = 252, Main.DiscoB = 0);
                }
            }
        }
        public override void SetDefaults()
        {
            Item.accessory = true;
            Item.value = Item.sellPrice(0, 40, 0, 0);
            Item.rare = 4;
        }


        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.buffImmune[ModContent.BuffType<WeaponArtCooldown>()] = true;
            player.statLifeMax2 += 1000;
        }

    }
}