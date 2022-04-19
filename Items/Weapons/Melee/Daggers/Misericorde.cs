using SoulsMod.Buffs;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;
using SoulsMod.Projectiles.Daggers;

namespace SoulsMod.Items.Weapons.Melee.Daggers
{


    public class Misericorde : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Misericorde");
            Tooltip.SetDefault("Hold UP to use weapon art\n[c/FFD700:Flurry]\nRight click to use special\n[c/FFD700:Quickstep]");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            Item.knockBack = 4f;
            Item.useStyle = ItemUseStyleID.Rapier; // Makes the player do the proper arm motion
            Item.width = 32;
            Item.height = 32;
            Item.UseSound = SoundID.Item1;
            Item.DamageType = DamageClass.Melee;
            Item.useTime = 12;
            Item.useAnimation = 12;
            Item.damage = 8;
            Item.noUseGraphic = true; // The sword is actually a "projectile", so the item should not be visible when used


            Item.rare = 0;
            Item.value = Item.sellPrice(0, 0, 0, 10);

            Item.shoot = ModContent.ProjectileType<MisericordeProjectile>(); // The projectile is what makes a shortsword work
                                                                             // This value bleeds into the behavior of the projectile as velocity, keep that in mind when tweaking values
        }
        public override bool AltFunctionUse(Player player)
        {
            return true;
        }

        public override bool CanUseItem(Player player)
        {

            if (player.controlUp)
            {
                Item.useStyle = ItemUseStyleID.Rapier;
                Item.useTime = 7;
                Item.useAnimation = 28;
                Item.damage = 8;
                Item.shootSpeed = 2.4f;
                Item.noMelee = true;
                Item.autoReuse = false;
                Item.shoot = ModContent.ProjectileType<MisericordeProjectile>();
                Item.knockBack = 8;

            }
            else if (player.altFunctionUse == 2)
            {
                player.velocity.X = -5 * player.direction;
                player.velocity.Y = 0;

            }
            else
            {

                Item.useStyle = ItemUseStyleID.Rapier;
                Item.useTime = 12;
                Item.useAnimation = 12;
                Item.damage = 8;
                Item.knockBack = 4;
                Item.shootSpeed = 2.4f;
                Item.noMelee = true;
                Item.autoReuse = true;
                Item.shoot = ModContent.ProjectileType<MisericordeProjectile>();
            }
            return base.CanUseItem(player);
        }
    }
}