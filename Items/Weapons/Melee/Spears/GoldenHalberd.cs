using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SoulsMod.Buffs;
using SoulsMod.Buffs.GoldenVow;
using SoulsMod.Projectiles.Spears;
using SoulsMod.Rarities;
using Terraria;
using Terraria.Audio;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace SoulsMod.Items.Weapons.Melee.Spears
{
    public class GoldenHalberd : ModItem
    {
        public override void SetStaticDefaults()
        {

            Tooltip.SetDefault("Right Click to use weapon art\n[c/FFD700:Golden Vow]");

            ItemID.Sets.SkipsInitialUseSound[Item.type] = true;
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            // Common Properties
           // Item.rare = ModContent.RarityType<testrarity>();
            Item.rare = 2;
            Item.value = Item.sellPrice(silver: 10);
            Item.width = 60;
            Item.height = 60;
            Item.noUseGraphic = true;
            Item.UseSound = SoundID.Item71;
            // Use Properties
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.autoReuse = true;
            Item.useTime = 30;
            Item.useAnimation = 30;
            // Weapon Properties
            Item.damage = 10;
            Item.knockBack = 6.6f;
            Item.DamageType = DamageClass.Melee;
            // Projectile Properties
            Item.shoot = ModContent.ProjectileType<GoldenHalberdProjectile>();
            Item.shootSpeed = 3.7f;
        }
        public override bool AltFunctionUse(Player player)
        {
            return true;
        }
       
        public override bool CanUseItem(Player player)
        {
            if (player.altFunctionUse == 2)
            {
                Item.useStyle = ItemUseStyleID.Shoot;
                Item.useTime = 60;
                Item.useAnimation = 60;
                Item.damage = 16;
                Item.shootSpeed = 3.4f;
                Item.shoot = ModContent.ProjectileType<GoldenHalberdProjectile>();
                Item.knockBack = 6;
                if (player.HasBuff(ModContent.BuffType<WeaponArtCooldown>()))
                {
                    return false;
                }
            }
            else
            {
                Item.useStyle = ItemUseStyleID.Shoot;
                Item.useTime = 40;
                Item.useAnimation = 40;
                Item.damage = 16;
                Item.shootSpeed = 5.4f;
                Item.shoot = ModContent.ProjectileType<GoldenHalberdProjectile>();
                Item.knockBack = 6;
            }
            return player.ownedProjectileCounts[Item.shoot] < 1;
        }
       

        public override void UseStyle(Player player, Rectangle heldItemFrame)
        {
            if (player.whoAmI == Main.myPlayer)
            {
                if (player.altFunctionUse == 2 && !player.HasBuff<WeaponArtCooldown>())
                {
                    player.AddBuff(Item.buffType, 3600, true);
                    player.AddBuff(ModContent.BuffType<GoldenVow>(), 600, true);
                    player.AddBuff(ModContent.BuffType<WeaponArtCooldown>(), 3600, true);
                }
            }
        }
        public override void AddRecipes()
        {
            CreateRecipe()
           .AddIngredient(ItemID.GoldBar, 21)
            
            .AddTile(TileID.Anvils)
            .Register();
        }
        public override bool? UseItem(Player player)
        {
            if (!Main.dedServ)
            {
                SoundEngine.PlaySound(Item.UseSound, player.Center);
            }

            return null;
        }

    }

}