using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SoulsMod.Buffs;
using SoulsMod.Buffs.GoldenVow;
using SoulsMod.Projectiles.Spears;
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

            Tooltip.SetDefault("Hold UP to use weapon art\n[c/FFD700:Golden Vow]\nRight click to use special\n[c/FFD700:...]");

            ItemID.Sets.SkipsInitialUseSound[Item.type] = true;
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            Item.rare = ItemRarityID.Pink;
            Item.value = Item.sellPrice(silver: 10);
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.useAnimation = 12;
            Item.useTime = 18;
            Item.UseSound = SoundID.Item71;
            Item.autoReuse = true;
            Item.damage = 16;
            Item.knockBack = 6.5f;
            Item.noUseGraphic = true;
            Item.DamageType = DamageClass.Melee;
            Item.knockBack = 6.5f;
            Item.shoot = ModContent.ProjectileType<GoldenHalberdProjectile>();
            Item.shootSpeed = 3.7f;
        }
        public override bool AltFunctionUse(Player player)
        {
            return true;
        }
        int dusttype;
       
        public override bool CanUseItem(Player player)
        {
            if (player.controlUp)
            {
                Item.useStyle = ItemUseStyleID.Shoot;
                Item.useTime = 50;
                Item.useAnimation = 50;
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
                Item.useTime = 30;
                Item.useAnimation = 30;
                Item.damage = 16;
                Item.shootSpeed = 3.4f;
                Item.shoot = ModContent.ProjectileType<GoldenHalberdProjectile>();
                Item.knockBack = 6;
            }
            return player.ownedProjectileCounts[Item.shoot] < 1;
        }
        public override void UseStyle(Player player, Rectangle heldItemFrame)
        {
            if (player.whoAmI == Main.myPlayer)
            {
                if (player.controlUp && !player.HasBuff<WeaponArtCooldown>())
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