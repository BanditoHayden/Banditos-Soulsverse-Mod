using Terraria.Audio;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;
using SoulsMod.Items;
using SoulsMod.Projectiles.Greatswords;
using SoulsMod.Projectiles;
using Terraria;
using Microsoft.Xna.Framework;
using SoulsMod.Buffs;
using System.Collections.Generic;
using SoulsMod.Projectiles.WeaponArts;

namespace SoulsMod.Items.Weapons.Melee.Reapers
{
   public class CrescentSickle : ModItem
    {
        public override void SetStaticDefaults()
        {

            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
            Tooltip.SetDefault("A sickle with a crescent-shaped blade.\nThis weapon gains extraordinary power at night");
        }
        public override void SetDefaults()
        {
            // Common Properties
            Item.rare = ItemRarityID.Pink;
            Item.value = Item.buyPrice(gold: 50);
            Item.width = 30;
            Item.height = 30;
            Item.scale = 1.3f;
            // Use Properties
            Item.useStyle = ItemUseStyleID.Swing;
            Item.useAnimation = 50;
            Item.useTime = 50;
            Item.UseSound = SoundID.Item1;
            Item.autoReuse = false;
            // Weapon Properties
            Item.damage = 40;
            Item.knockBack = 6.6f;
            Item.crit = 10;
            Item.DamageType = DamageClass.Melee;
            // Projectile Properties
          //  Item.shoot = ModContent.ProjectileType<StarscourgeGreatswordHeld>();
            //Item.shootSpeed = 12f;

        }
        public override void ModifyWeaponDamage(Player player, ref StatModifier damage, ref float flat)
        {
            if (!Main.dayTime)
            {
                damage += 1;
            }
        }



    }
}
