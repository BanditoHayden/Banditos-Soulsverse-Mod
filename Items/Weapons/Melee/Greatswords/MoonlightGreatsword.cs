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
using SoulsMod.Buffs.MoonlightBlessing;

namespace SoulsMod.Items.Weapons.Melee.Greatswords
{
    public class MoonlightGreatsword : ModItem
    {
        int currentAttack = 1;
        int fired;


        public override void SetStaticDefaults()
        {

            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
            Tooltip.SetDefault("");
        }
        public override void SetDefaults()
        {
            // Common Properties
            Item.rare = ItemRarityID.Master;

            Item.width = 60;
            Item.height = 60;
            Item.scale = 1.3f;
            Item.noUseGraphic = true;
            // Use Properties
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.useAnimation = 40;
            Item.useTime = 30;
            Item.UseSound = SoundID.Item1;
            Item.autoReuse = false;
            // Weapon Properties
            Item.damage = 200;
            Item.knockBack = 8.6f;
            Item.DamageType = DamageClass.Melee;
            Item.crit = 14;
            // Projectile Properties
            Item.shoot = ModContent.ProjectileType<MoonlightGreatswordHeld>();
            Item.shootSpeed = 4f;
            
        }


         public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            fired++;
            int dir = currentAttack;
            currentAttack = -currentAttack;
            Projectile.NewProjectile(source, position, velocity, type, damage, knockback, player.whoAmI, 1, dir);
            Projectile.NewProjectile(source, position, velocity, ModContent.ProjectileType<MoonlightSlash>(), damage, knockback, player.whoAmI);
            if(fired == 10)
            {
                fired = 0;
                player.AddBuff(ModContent.BuffType<MoonlightBlessing>(), 360);
            }
            return false;
        }
        

    }
}
