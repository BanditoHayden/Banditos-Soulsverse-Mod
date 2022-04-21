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

namespace SoulsMod.Items.Weapons.Melee.Greatswords
{
  
    public class StarscourgeGreatsword : ModItem
    {
        int currentAttack = 1;
      
           
        public override void SetStaticDefaults()
        {

            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
            Tooltip.SetDefault("Every [c/FFD700:third] attack, spawn a star at your mouse position");
        }
        public override void SetDefaults()
        {
            // Common Properties
            Item.rare = ItemRarityID.Pink;
           
            Item.width = 60;
            Item.height = 60;
            Item.scale = 1.3f;
            Item.noUseGraphic = true;
            // Use Properties
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.useAnimation = 30;
            Item.useTime = 30;
            Item.UseSound = SoundID.Item1;
            Item.autoReuse = false;
            // Weapon Properties
            Item.damage = 32;
            Item.knockBack = 6.6f;
            Item.crit = 10;
            Item.DamageType = DamageClass.Melee;
            // Projectile Properties
            Item.shoot = ModContent.ProjectileType<StarscourgeGreatswordHeld>();
            Item.shootSpeed = 12f;
           
        }
        public override bool AltFunctionUse(Player player)
        {
            return true;
        }
        int shoot;
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            Vector2 target = Main.screenPosition + new Vector2(Main.mouseX, Main.mouseY);
            float ceilingLimit = target.Y;
            if (ceilingLimit > player.Center.Y - 200f)
            {
                ceilingLimit = player.Center.Y - 200f;
            }
            shoot++;

            if (shoot == 3)
            {
                shoot = 0;
                for (int i = 0; i < 1; i++)
                {
                    position = player.Center - new Vector2(Main.rand.NextFloat(401) * player.direction, 600f);
                    position.Y -= 100 * i;
                    Vector2 heading = target - position;

                    if (heading.Y < 0f)
                    {
                        heading.Y *= -1f;
                    }

                    if (heading.Y < 20f)
                    {
                        heading.Y = 20f;
                    }

                    heading.Normalize();
                    heading *= velocity.Length();
                    heading.Y += Main.rand.Next(-40, 41) * 0.02f;
                    Projectile.NewProjectile(source, position, heading, 503, damage * 2, knockback, player.whoAmI, 0f, ceilingLimit);
                }

            }

            int dir = currentAttack;
            currentAttack = -currentAttack;
            Projectile.NewProjectile(source, position, velocity, type, damage, knockback, player.whoAmI, 1, dir);

            return false;
        }
        












        public override void AddRecipes()
        {
            CreateRecipe()
           .AddIngredient(ItemID.MeteoriteBar, 25)
            .AddIngredient(ItemID.FallenStar, 10)
            .AddTile(TileID.Anvils)
            .Register();
        }

    }
}
