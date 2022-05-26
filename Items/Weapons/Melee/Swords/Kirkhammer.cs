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
using SoulsMod.Projectiles.Swords;

namespace SoulsMod.Items.Weapons.Melee.Swords
{
    public class Kirkhammer : ModItem
    {
        int currentAttack = 1;
        public override void SetStaticDefaults()
        {

            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
            Tooltip.SetDefault("Right click to use special\n[c/FFD700:Hammer Mode]");
        }
        public override void SetDefaults()
        {
            // Common Properties
            Item.rare = ItemRarityID.Pink;
            Item.width = 30;
            Item.height = 30;
            Item.scale = 1.0f;
            // Use Properties
            Item.useStyle = ItemUseStyleID.Swing;
            Item.noUseGraphic = false;
            Item.UseSound = SoundID.Item1;
            Item.autoReuse = false;
            // Weapon Properties
            Item.damage = 80;
            Item.knockBack = 6.6f;
            Item.DamageType = DamageClass.Melee;
            // Projectile Properties
           
        }
        public override bool AltFunctionUse(Player player)
        {
            return true;
        }
        int shoot;
        public override bool CanUseItem(Player player)
        {
            if (player.altFunctionUse == 2)
            {
                Item.shoot = ProjectileID.None;
                Item.noUseGraphic = false;
                Item.useTime = 60;
                Item.useAnimation = 60;
                Item.useStyle = ItemUseStyleID.Swing;

            }
            else
            {
                Item.shootSpeed = 3.4f;
                Item.shoot = ModContent.ProjectileType<KirkhammerProjectile>();
                Item.noUseGraphic = true;
                Item.useTime = 40;
                Item.useAnimation = 40;
                Item.useStyle = ItemUseStyleID.Shoot;
            }
            return base.CanUseItem(player);
        }
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            int dir = currentAttack;
            currentAttack = -currentAttack;
            Projectile.NewProjectile(source, position, velocity, type, damage / 3, knockback, player.whoAmI, 1, dir);
            return false;
        }











    }
}
