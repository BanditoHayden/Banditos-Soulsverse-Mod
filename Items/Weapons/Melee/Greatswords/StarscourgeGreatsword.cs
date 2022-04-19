using SoulsMod.Buffs;
using SoulsMod.Buffs.GoldenVow;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.Audio;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;
using SoulsMod.Items;
using SoulsMod.Projectiles.Greatswords;

namespace SoulsMod.Items.Weapons.Melee.Greatswords
{
    public class StarscourgeGreatsword : ModItem
    {
        public override void SetStaticDefaults()
        {

            Tooltip.SetDefault("Hold UP to use weapon art\n[c/FFD700:Starcaller Cry]\nRight click to use special\n[c/FFD700:Sword Slash]");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }
        public override void SetDefaults()
        {
            // Common Properties
            Item.rare = ItemRarityID.Pink;
            Item.value = Item.sellPrice(silver: 10);
            Item.width = 60;
            Item.height = 60;
            Item.scale = 1.3f;
            // Use Properties
            Item.useStyle = ItemUseStyleID.Swing;
            Item.useAnimation = 40;
            Item.useTime = 40;
            Item.UseSound = SoundID.Item1;
            Item.autoReuse = false;
            // Weapon Properties
            Item.damage = 32;
            Item.knockBack = 6.6f;
            Item.crit = 10;
            Item.DamageType = DamageClass.Melee;
            // Projectile Properties


        }
        public override bool AltFunctionUse(Player player)
        {
            return true;
        }
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            if (player.controlUp && !player.HasBuff(ModContent.BuffType<WeaponArtCooldown>()))
            {
                Vector2 target = Main.screenPosition + new Vector2(Main.mouseX, Main.mouseY);
                float ceilingLimit = target.Y;
                if (ceilingLimit > player.Center.Y - 200f)
                {
                    ceilingLimit = player.Center.Y - 200f;
                }   
                for (int i = 0; i < 5; i++)
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
                    Projectile.NewProjectile(source, position, heading, type, damage * 2, knockback, player.whoAmI, 0f, ceilingLimit);
                }
            }
            if (player.altFunctionUse == 2)
            {
               // position = player.Center + new Vector2(player.direction);
                Projectile.NewProjectileDirect(source, position, velocity, type, damage * 2, knockback, player.whoAmI);
                if (Item.shoot == ModContent.ProjectileType<StarscourgeGreatswordSlash>())
                    Item.shoot = ModContent.ProjectileType<StarscourgeGreatswordSlash>();
                else
                    Item.shoot = ModContent.ProjectileType<StarscourgeGreatswordSlash>();
            }
            return false;
        }
        public override bool CanUseItem(Player player)
        {
            if (player.controlUp)
            {
                Item.damage = 32;
                Item.knockBack = 6.5f;
                Item.crit = 10;
                Item.useStyle = ItemUseStyleID.Swing;
                Item.useAnimation = 40;
                Item.useTime = 40;
                Item.autoReuse = false;
                Item.shoot = 503;
                Item.noUseGraphic = false;
                Item.shootSpeed = 8f;
                if (player.HasBuff(ModContent.BuffType<WeaponArtCooldown>()))
                {
                    return false;
                }
            }
            else if (player.altFunctionUse == 2)
            {
                Item.noUseGraphic = true;
                Item.damage = 32;
                Item.shoot = ModContent.ProjectileType<StarscourgeGreatswordSlash>();
                Item.knockBack = 6.5f;
                Item.crit = 10;
                Item.useStyle = ItemUseStyleID.Shoot;
                Item.useAnimation = 40;
                Item.useTime = 40;
                Item.autoReuse = false;
                
            }
            else
            {
                Item.damage = 32;
                Item.shoot = ModContent.ProjectileType<blankprojectile>();
                Item.knockBack = 6.5f;
                Item.crit = 10;
                Item.useStyle = ItemUseStyleID.Swing;
                Item.useAnimation = 40;
                Item.useTime = 40;
                Item.autoReuse = false;
                Item.noUseGraphic = false;
            }
            return base.CanUseItem(player);
        }
        public override void UseStyle(Player player, Rectangle heldItemFrame)
        {
            if (player.whoAmI == Main.myPlayer)
            {
                if (player.controlUp && !player.HasBuff<WeaponArtCooldown>())
                {
                    player.AddBuff(Item.buffType, 3600, true);
                   
                    player.AddBuff(ModContent.BuffType<WeaponArtCooldown>(), 3600, true);
                }
            }
        }
        public override Vector2? HoldoutOffset()
        {
            return new Vector2(-5, 0);
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