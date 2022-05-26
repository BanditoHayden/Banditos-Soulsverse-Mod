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
    public class RifleSpear : ModItem
    {
        public override void SetStaticDefaults()
        {

            Tooltip.SetDefault("Right click to use special\n[c/FFD700:Gun Shot]");

            ItemID.Sets.SkipsInitialUseSound[Item.type] = true;
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            // Common Properties
            Item.rare = 2;
            Item.value = Item.sellPrice(gold: 40);
            Item.width = 60;
            Item.height = 60; 
            // Use Properties
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.autoReuse = false;
            Item.useTime = 40;
            Item.useAnimation = 40;
            // Weapon Properties
            Item.damage = 29;
            Item.knockBack = 6.6f;
            
            Item.DamageType = DamageClass.Melee;
            
            // Projectile Properties
            
        }
        public override bool AltFunctionUse(Player player)
        {
            return true;
        }
        public override bool CanUseItem(Player player)
        {
            if (player.altFunctionUse == 2)
            {
                Item.shootSpeed = 9.4f;
                Item.shoot = ProjectileID.ExplosiveBullet;
                Item.noUseGraphic = false;
                Item.UseSound = SoundID.Item11;
                Item.useTime = 50;
                Item.useAnimation = 50;
            }
            else
            {
                Item.shootSpeed = 3.4f;
                Item.shoot = ModContent.ProjectileType<RifleSpearProjectile>();
                Item.noUseGraphic = true;
                Item.UseSound = SoundID.Item71;
                Item.useTime = 40;
                Item.useAnimation = 40;
            }
            //return player.ownedProjectileCounts[Item.shoot] < 1;
            return true;
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
